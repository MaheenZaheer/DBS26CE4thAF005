-- ============================================================
-- Courier & Parcel Tracking System
-- Stored Procedures, Triggers & Views — FULLY FIXED
-- ============================================================

USE CourierDB;

-- ============================================================
-- DROP EVERYTHING FIRST
-- ============================================================
DROP PROCEDURE IF EXISTS sp_CreateBooking;
DROP PROCEDURE IF EXISTS sp_UpdateParcelStatus;
DROP PROCEDURE IF EXISTS sp_FileComplaint;
DROP PROCEDURE IF EXISTS sp_GetParcelsByUser;
DROP PROCEDURE IF EXISTS sp_GetRevenueReport;
DROP PROCEDURE IF EXISTS sp_ResolveComplaint;
DROP PROCEDURE IF EXISTS sp_ProcessRefund;

DROP TRIGGER IF EXISTS trg_LogStatusChange;
DROP TRIGGER IF EXISTS trg_AutoDeliver;
DROP TRIGGER IF EXISTS trg_LogUserDelete;
DROP TRIGGER IF EXISTS trg_ConfirmBookingOnPayment;

DROP VIEW IF EXISTS vw_ParcelSummary;
DROP VIEW IF EXISTS vw_PendingDeliveries;
DROP VIEW IF EXISTS vw_RevenueByBranch;
DROP VIEW IF EXISTS vw_StaffWorkload;
DROP VIEW IF EXISTS vw_ZonePerformance;
DROP VIEW IF EXISTS vw_ComplaintSummary;

-- ============================================================
-- TABLE ALTERATIONS (safe — only add if not already there)
-- ============================================================
ALTER TABLE complaint ADD COLUMN remarks      VARCHAR(500) NULL;
ALTER TABLE complaint ADD COLUMN resolved_by  INT          NULL;
-- ALTER TABLE complaint ADD COLUMN resolved_at  DATETIME     NULL;
ALTER TABLE payment   ADD COLUMN refund_reason VARCHAR(255) NULL;

-- ============================================================
-- DELIMITER BLOCK — all SPs and Triggers in ONE block
-- ============================================================
DELIMITER $$

-- ------------------------------------------------------------
-- SP 1: Create a full booking
-- ------------------------------------------------------------
CREATE PROCEDURE sp_CreateBooking(
    IN p_user_id        INT,
    IN p_sender_name    VARCHAR(100),
    IN p_recv_name      VARCHAR(100),
    IN p_recv_phone     VARCHAR(15),
    IN p_recv_city      VARCHAR(100),
    IN p_weight         DECIMAL(6,2),
    IN p_type           VARCHAR(50),
    IN p_zone_id        INT,
    IN p_address_id     INT,
    IN p_method         VARCHAR(30),
    IN p_branch_id      INT,
    IN p_declared_value DECIMAL(10,2)
)
BEGIN
    DECLARE v_base_rate  DECIMAL(8,2);
    DECLARE v_kg_rate    DECIMAL(8,2);
    DECLARE v_charge     DECIMAL(10,2);
    DECLARE v_booking_id INT;
    DECLARE v_parcel_id  INT;
    DECLARE v_track_code VARCHAR(30);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        INSERT INTO error_log(module, message, logged_at)
        VALUES('sp_CreateBooking', 'Transaction failed — rolled back', NOW());
    END;

    START TRANSACTION;

    SELECT base_rate, per_kg_rate
    INTO   v_base_rate, v_kg_rate
    FROM   delivery_zone
    WHERE  zone_id = p_zone_id;

    SET v_charge     = v_base_rate + (p_weight * v_kg_rate);
    SET v_track_code = CONCAT('PK', DATE_FORMAT(NOW(),'%Y%m%d%H%i%s'),
                               FLOOR(RAND() * 999));

    INSERT INTO booking (user_id, address_id, total_amount, discount_applied, status)
    VALUES (p_user_id, p_address_id, v_charge, 0, 'Pending');
    SET v_booking_id = LAST_INSERT_ID();

    INSERT INTO parcel (
        order_id, sender_name, receiver_name, receiver_phone,
        receiver_city, weight_kg, parcel_type, tracking_code,
        zone_id, branch_id, declared_value, status
    )
    VALUES (
        v_booking_id, p_sender_name, p_recv_name, p_recv_phone,
        p_recv_city, p_weight, p_type, v_track_code,
        p_zone_id, p_branch_id, p_declared_value, 'Processing'
    );
    SET v_parcel_id = LAST_INSERT_ID();

    INSERT INTO payment (order_id, amount, method, status)
    VALUES (v_booking_id, v_charge, p_method, 'Completed');

    INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
    VALUES (v_parcel_id, 'Processing', p_recv_city, 'Booking created', p_user_id);

    COMMIT;

    SELECT v_track_code AS TrackingCode,
           v_charge     AS Charge,
           v_booking_id AS BookingID;
END$$

-- ------------------------------------------------------------
-- SP 2: Update parcel status + tracking log
-- ------------------------------------------------------------
CREATE PROCEDURE sp_UpdateParcelStatus(
    IN p_parcel_id INT,
    IN p_status    VARCHAR(30),
    IN p_location  VARCHAR(150),
    IN p_remarks   VARCHAR(300),
    IN p_user_id   INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        INSERT INTO error_log(module, message, logged_at)
        VALUES('sp_UpdateParcelStatus', 'Status update failed', NOW());
    END;

    START TRANSACTION;

    UPDATE parcel SET status = p_status WHERE shipment_id = p_parcel_id;

    IF p_status = 'Delivered' THEN
        UPDATE parcel SET delivered_at = NOW() WHERE shipment_id = p_parcel_id;
        UPDATE booking b
        JOIN   parcel  p ON b.order_id = p.order_id
        SET    b.status  = 'Delivered'
        WHERE  p.shipment_id = p_parcel_id;
    END IF;

    IF p_status = 'Shipped' THEN
        UPDATE parcel SET shipped_at = NOW() WHERE shipment_id = p_parcel_id;
    END IF;

    INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
    VALUES (p_parcel_id, p_status, p_location, p_remarks, p_user_id);

    COMMIT;

    SELECT 'Status updated successfully.' AS Result;
END$$

-- ------------------------------------------------------------
-- SP 3: File a complaint
-- NOTE: parameter is p_description to match C# code
-- ------------------------------------------------------------
CREATE PROCEDURE sp_FileComplaint(
    IN p_user_id     INT,
    IN p_parcel_id   INT,
    IN p_subject     VARCHAR(200),
    IN p_description TEXT
)
BEGIN
    INSERT INTO complaint (user_id, parcel_id, subject, description, status, filed_at)
    VALUES (p_user_id, p_parcel_id, p_subject, p_description, 'Open', NOW());

    SELECT 'Complaint filed successfully.' AS Result;
END$$

-- ------------------------------------------------------------
-- SP 4: Get all parcels for a customer
-- ------------------------------------------------------------
CREATE PROCEDURE sp_GetParcelsByUser(
    IN p_user_id INT
)
BEGIN
    SELECT
        p.shipment_id,
        p.tracking_code,
        p.sender_name,
        p.receiver_name,
        p.receiver_city,
        p.weight_kg,
        p.parcel_type,
        p.status                 AS parcel_status,
        p.shipped_at,
        p.delivered_at,
        COALESCE(pay.amount,  0) AS charge,
        COALESCE(pay.method, '') AS payment_method
    FROM parcel p
    JOIN     booking b   ON p.order_id  = b.order_id
    LEFT JOIN payment pay ON b.order_id = pay.order_id
    WHERE b.user_id = p_user_id
    ORDER BY p.shipment_id DESC;
END$$

-- ------------------------------------------------------------
-- SP 5: Revenue report between two dates
-- ------------------------------------------------------------
CREATE PROCEDURE sp_GetRevenueReport(
    IN p_from_date DATE,
    IN p_to_date   DATE
)
BEGIN
    SELECT
        COALESCE(dz.zone_name, 'Unknown') AS zone_name,
        COUNT(p.shipment_id)              AS total_parcels,
        COALESCE(SUM(pay.amount),  0)     AS total_revenue,
        COALESCE(AVG(pay.amount),  0)     AS avg_charge
    FROM parcel p
    JOIN      booking b   ON p.order_id = b.order_id
    LEFT JOIN payment pay ON b.order_id = pay.order_id
    LEFT JOIN delivery_zone dz ON p.zone_id = dz.zone_id
    WHERE DATE(b.order_date) BETWEEN p_from_date AND p_to_date
    GROUP BY dz.zone_name
    ORDER BY total_revenue DESC;
END$$

-- ------------------------------------------------------------
-- SP 6: Resolve a complaint
-- ------------------------------------------------------------
CREATE PROCEDURE sp_ResolveComplaint(
    IN p_complaint_id INT,
    IN p_resolved_by  INT,
    IN p_remarks      VARCHAR(500)
)
BEGIN
    UPDATE complaint
    SET    status      = 'Resolved',
           remarks     = p_remarks,
           resolved_by = p_resolved_by,
           resolved_at = NOW()
    WHERE  complaint_id = p_complaint_id;

    SELECT 'Complaint resolved.' AS Result;
END$$

-- ------------------------------------------------------------
-- SP 7: Process a refund
-- ------------------------------------------------------------
CREATE PROCEDURE sp_ProcessRefund(
    IN p_order_id INT,
    IN p_reason   VARCHAR(255)
)
BEGIN
    UPDATE payment
    SET    status        = 'Refunded',
           refund_reason = p_reason
    WHERE  order_id = p_order_id
      AND  status   = 'Completed';

    SELECT CONCAT('Refund processed for Order ID ', p_order_id) AS message;
END$$

-- ============================================================
-- TRIGGERS
-- ============================================================

-- TRIGGER 1: Parcel status change → notify customer
CREATE TRIGGER trg_LogStatusChange
AFTER UPDATE ON parcel
FOR EACH ROW
BEGIN
    IF NEW.status != OLD.status THEN
        INSERT INTO notification (user_id, parcel_id, message, type)
        SELECT b.user_id,
               NEW.shipment_id,
               CONCAT('Parcel (', COALESCE(NEW.tracking_code,'N/A'),
                      ') status updated to: ', NEW.status),
               'System'
        FROM booking b
        WHERE b.order_id = NEW.order_id;
    END IF;
END$$

-- TRIGGER 2: delivered_at stamped → auto-complete booking
CREATE TRIGGER trg_AutoDeliver
AFTER UPDATE ON parcel
FOR EACH ROW
BEGIN
    IF NEW.delivered_at IS NOT NULL AND OLD.delivered_at IS NULL THEN
        UPDATE booking SET status = 'Delivered'
        WHERE  order_id = NEW.order_id;
    END IF;
END$$

-- TRIGGER 3: Log user deletion
CREATE TRIGGER trg_LogUserDelete
BEFORE DELETE ON users
FOR EACH ROW
BEGIN
    INSERT INTO error_log (module, message, logged_at)
    VALUES ('UserDeleted',
            CONCAT('User deleted — ID: ', OLD.user_id,
                   ' | Email: ', OLD.email),
            NOW());
END$$

-- TRIGGER 4: Payment completed → confirm booking
CREATE TRIGGER trg_ConfirmBookingOnPayment
AFTER UPDATE ON payment
FOR EACH ROW
BEGIN
    IF NEW.status = 'Completed' AND OLD.status != 'Completed' THEN
        UPDATE booking SET status = 'Confirmed'
        WHERE  order_id = NEW.order_id;
    END IF;
END$$

DELIMITER ;

-- ============================================================
-- VIEWS (no DELIMITER needed — plain SQL)
-- ============================================================

CREATE VIEW vw_ParcelSummary AS
SELECT p.shipment_id, p.tracking_code, p.sender_name, p.receiver_name,
       p.receiver_city, p.weight_kg, p.parcel_type,
       p.status AS parcel_status, p.courier_name, p.shipped_at, p.delivered_at,
       b.order_id AS booking_id, b.user_id, b.status AS booking_status,
       b.order_date, u.name AS booked_by, dz.zone_name,
       pay.amount AS charge, pay.method AS payment_method
FROM parcel p
LEFT JOIN booking       b   ON p.order_id = b.order_id
LEFT JOIN users         u   ON b.user_id  = u.user_id
LEFT JOIN delivery_zone dz  ON p.zone_id  = dz.zone_id
LEFT JOIN payment       pay ON b.order_id = pay.order_id;

CREATE VIEW vw_PendingDeliveries AS
SELECT p.shipment_id, p.tracking_code, p.receiver_name, p.receiver_city,
       p.status, p.courier_name, p.shipped_at,
       DATEDIFF(NOW(), p.shipped_at) AS days_in_transit, dz.zone_name
FROM parcel p
LEFT JOIN delivery_zone dz ON p.zone_id = dz.zone_id
WHERE p.status IN ('Processing','Shipped','OutForDelivery');

CREATE VIEW vw_RevenueByBranch AS
SELECT br.shop_name AS branch_name,
       COUNT(b.order_id)            AS total_bookings,
       COALESCE(SUM(pay.amount), 0) AS total_revenue
FROM branch br
LEFT JOIN booking  b   ON b.user_id  = br.user_id
LEFT JOIN payment pay  ON b.order_id = pay.order_id
GROUP BY br.shop_name;

CREATE VIEW vw_StaffWorkload AS
SELECT u.name AS staff_name, cs.designation, br.shop_name AS branch,
       COUNT(tl.log_id) AS updates_made
FROM courier_staff cs
JOIN users         u  ON cs.user_id   = u.user_id
JOIN branch        br ON cs.branch_id = br.seller_id
LEFT JOIN tracking_log tl ON tl.updated_by = cs.user_id
GROUP BY u.name, cs.designation, br.shop_name;

CREATE VIEW vw_ZonePerformance AS
SELECT dz.zone_name,
       COUNT(p.shipment_id)                                  AS total_parcels,
       COALESCE(SUM(pay.amount), 0)                          AS total_revenue,
       ROUND(AVG(DATEDIFF(p.delivered_at, p.shipped_at)), 1) AS avg_delivery_days
FROM delivery_zone dz
LEFT JOIN parcel  p   ON p.zone_id  = dz.zone_id
LEFT JOIN booking b   ON p.order_id = b.order_id
LEFT JOIN payment pay ON b.order_id = pay.order_id
GROUP BY dz.zone_name;

CREATE OR REPLACE VIEW vw_ComplaintSummary AS
SELECT c.complaint_id, c.user_id, u.name AS user_name, c.parcel_id,
       c.subject, c.description, c.status, c.remarks,
       c.filed_at, c.resolved_at, c.resolved_by
FROM complaint c
JOIN users u ON c.user_id = u.user_id;

-- ============================================================
-- STANDALONE DEMO TRANSACTIONS
-- ============================================================
SET SQL_SAFE_UPDATES = 0;

START TRANSACTION;
UPDATE parcel SET status = 'OutForDelivery' WHERE tracking_code = 'TRK-001';
INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
VALUES (1, 'OutForDelivery', 'Karachi', 'Last mile delivery started', 1);
COMMIT;

START TRANSACTION;
UPDATE booking SET status = 'Cancelled'
WHERE status = 'Pending' AND order_date < DATE_SUB(NOW(), INTERVAL 7 DAY);
COMMIT;

SET SQL_SAFE_UPDATES = 1;

-- ============================================================
-- FINAL VERIFY
-- ============================================================
SELECT 'Stored Procedures' AS ObjectType, COUNT(*) AS TotalCount
FROM information_schema.ROUTINES
WHERE ROUTINE_SCHEMA = 'CourierDB' AND ROUTINE_TYPE = 'PROCEDURE'
UNION ALL
SELECT 'Triggers', COUNT(*)
FROM information_schema.TRIGGERS
WHERE TRIGGER_SCHEMA = 'CourierDB'
UNION ALL
SELECT 'Views', COUNT(*)
FROM information_schema.VIEWS
WHERE TABLE_SCHEMA = 'CourierDB';