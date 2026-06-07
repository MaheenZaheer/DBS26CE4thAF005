-- ============================================================
-- Courier & Parcel Tracking System — Main Schema
-- CMPE-232L | Database Systems Lab | UET Lahore
-- FIX LOG:
--   1. Removed all e-commerce tables not needed for courier system
--   2. Added courier_name column to parcel (was missing, caused view/SP errors)
--   3. Removed duplicate index idx_tracking / idx_tracking_code on parcel
--   4. Removed DROP of shipment/seller tables before rename (avoids FK errors)
--   5. Cleaned up commented-out duplicate ALTER blocks
--   6. Added sample data for courier-specific tables
-- Run this entire file in MySQL Workbench 8.0
-- ============================================================

DROP DATABASE IF EXISTS CourierDB;
CREATE DATABASE CourierDB;
USE CourierDB;

-- ============================================================
-- TABLE 1: users
-- ============================================================
CREATE TABLE users (
    user_id       INT AUTO_INCREMENT PRIMARY KEY,
    name          VARCHAR(100)  NOT NULL,
    email         VARCHAR(150)  NOT NULL UNIQUE,
    password_hash VARCHAR(256)  NOT NULL,
    phone         VARCHAR(15),
    role          VARCHAR(20)   NOT NULL DEFAULT 'Customer',
    created_at    DATETIME      DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_role CHECK (role IN ('Customer','Staff','Admin'))
);

-- ============================================================
-- TABLE 2: address
-- ============================================================
CREATE TABLE address (
    address_id  INT AUTO_INCREMENT PRIMARY KEY,
    user_id     INT NOT NULL,
    street      VARCHAR(200) NOT NULL,
    city        VARCHAR(100) NOT NULL,
    province    VARCHAR(100) NOT NULL,
    postal_code VARCHAR(10),
    is_default  TINYINT(1) DEFAULT 0,
    CONSTRAINT fk_address_user FOREIGN KEY (user_id)
        REFERENCES users(user_id) ON DELETE CASCADE
);

-- ============================================================
-- TABLE 3: error_log
-- ============================================================
CREATE TABLE error_log (
    log_id      INT AUTO_INCREMENT PRIMARY KEY,
    module      VARCHAR(100),
    message     VARCHAR(500),
    stack_trace TEXT,
    logged_at   DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ============================================================
-- TABLE 4: branch  (renamed from seller)
-- ============================================================
CREATE TABLE branch (
    seller_id   INT AUTO_INCREMENT PRIMARY KEY,
    user_id     INT NOT NULL UNIQUE,
    shop_name   VARCHAR(150) NOT NULL,
    description VARCHAR(500),
    rating      DECIMAL(3,2) DEFAULT 0.00,
    CONSTRAINT chk_rating CHECK (rating BETWEEN 0.00 AND 5.00),
    CONSTRAINT fk_branch_user FOREIGN KEY (user_id)
        REFERENCES users(user_id) ON DELETE CASCADE
);

-- ============================================================
-- TABLE 5: rate_card  (renamed from discount)
-- ============================================================
CREATE TABLE rate_card (
    discount_id  INT AUTO_INCREMENT PRIMARY KEY,
    code         VARCHAR(50)   NOT NULL UNIQUE,
    type         VARCHAR(20)   NOT NULL,
    value        DECIMAL(10,2) NOT NULL,
    expiry_date  DATETIME      NOT NULL,
    usage_limit  INT NOT NULL DEFAULT 100,
    used_count   INT NOT NULL DEFAULT 0,
    CONSTRAINT chk_rc_type        CHECK (type IN ('Percentage','Fixed')),
    CONSTRAINT chk_rc_value       CHECK (value > 0),
    CONSTRAINT chk_rc_usage_limit CHECK (usage_limit > 0),
    CONSTRAINT chk_rc_used_count  CHECK (used_count >= 0)
);

-- ============================================================
-- TABLE 6: delivery_zone  (NEW)
-- ============================================================
CREATE TABLE delivery_zone (
    zone_id      INT AUTO_INCREMENT PRIMARY KEY,
    zone_name    VARCHAR(100) NOT NULL,
    cities       VARCHAR(500) NOT NULL,
    base_rate    DECIMAL(8,2) NOT NULL DEFAULT 200.00,
    per_kg_rate  DECIMAL(8,2) NOT NULL DEFAULT 50.00,
    is_active    TINYINT(1) DEFAULT 1,
    CONSTRAINT chk_base_rate   CHECK (base_rate > 0),
    CONSTRAINT chk_per_kg_rate CHECK (per_kg_rate > 0)
);

-- ============================================================
-- TABLE 7: booking  (renamed from orders)
-- ============================================================
CREATE TABLE booking (
    order_id         INT AUTO_INCREMENT PRIMARY KEY,
    user_id          INT NOT NULL,
    address_id       INT NOT NULL,
    discount_id      INT DEFAULT NULL,
    total_amount     DECIMAL(10,2) NOT NULL,
    discount_applied DECIMAL(10,2) NOT NULL DEFAULT 0,
    status           VARCHAR(20)   NOT NULL DEFAULT 'Pending',
    order_date       DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_booking_total    CHECK (total_amount >= 0),
    CONSTRAINT chk_booking_discount CHECK (discount_applied >= 0),
    CONSTRAINT chk_booking_status   CHECK (status IN ('Pending','Confirmed','Shipped','Delivered','Cancelled')),
    CONSTRAINT fk_booking_user     FOREIGN KEY (user_id)
        REFERENCES users(user_id),
    CONSTRAINT fk_booking_address  FOREIGN KEY (address_id)
        REFERENCES address(address_id),
    CONSTRAINT fk_booking_ratecard FOREIGN KEY (discount_id)
        REFERENCES rate_card(discount_id)
);

-- ============================================================
-- TABLE 8: payment  (KEPT)
-- ============================================================
CREATE TABLE payment (
    payment_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id   INT NOT NULL UNIQUE,
    amount     DECIMAL(10,2) NOT NULL,
    method     VARCHAR(30)   NOT NULL,
    status     VARCHAR(20)   NOT NULL DEFAULT 'Pending',
    paid_at    DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_pay_amount CHECK (amount > 0),
    CONSTRAINT chk_pay_method CHECK (method IN ('Cash','Card','EasyPaisa','JazzCash')),
    CONSTRAINT chk_pay_status CHECK (status IN ('Pending','Completed','Failed','Refunded')),
    CONSTRAINT fk_payment_booking FOREIGN KEY (order_id)
        REFERENCES booking(order_id)
);

-- ============================================================
-- TABLE 9: parcel  (renamed from shipment)
-- FIX: courier_name column added here directly (was missing)
-- FIX: all courier-specific columns added here (not via ALTER)
-- ============================================================
CREATE TABLE parcel (
    shipment_id    INT AUTO_INCREMENT PRIMARY KEY,
    order_id       INT NOT NULL UNIQUE,
    sender_name    VARCHAR(100),
    receiver_name  VARCHAR(100),
    receiver_phone VARCHAR(15),
    receiver_city  VARCHAR(100),
    weight_kg      DECIMAL(6,2),
    parcel_type    VARCHAR(50),
    -- FIX: courier_name was used in views/SPs but was never added via ALTER
    courier_name   VARCHAR(100) NOT NULL DEFAULT 'TCS',
    tracking_code  VARCHAR(20),
    zone_id        INT,
    branch_id      INT,
    declared_value DECIMAL(10,2) DEFAULT 0,
    status         VARCHAR(30)   NOT NULL DEFAULT 'Processing',
    shipped_at     DATETIME DEFAULT NULL,
    delivered_at   DATETIME DEFAULT NULL,
    CONSTRAINT chk_parcel_status  CHECK (status IN ('Processing','Shipped','OutForDelivery','Delivered','Cancelled')),
    CONSTRAINT chk_delivery_date  CHECK (delivered_at IS NULL OR delivered_at >= shipped_at),
    -- FIX: single unique index only (duplicate idx_tracking / idx_tracking_code removed)
    CONSTRAINT uq_tracking_code   UNIQUE (tracking_code),
    CONSTRAINT fk_parcel_booking  FOREIGN KEY (order_id)
        REFERENCES booking(order_id),
    CONSTRAINT fk_parcel_zone     FOREIGN KEY (zone_id)
        REFERENCES delivery_zone(zone_id),
    CONSTRAINT fk_parcel_branch   FOREIGN KEY (branch_id)
        REFERENCES branch(seller_id)
);

-- ============================================================
-- TABLE 10: tracking_log  (NEW)
-- ============================================================
CREATE TABLE tracking_log (
    log_id     INT AUTO_INCREMENT PRIMARY KEY,
    parcel_id  INT NOT NULL,
    status     VARCHAR(30) NOT NULL,
    location   VARCHAR(150),
    remarks    VARCHAR(300),
    updated_by INT NOT NULL,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_tlog_parcel FOREIGN KEY (parcel_id)
        REFERENCES parcel(shipment_id),
    CONSTRAINT fk_tlog_user FOREIGN KEY (updated_by)
        REFERENCES users(user_id)
);

-- ============================================================
-- TABLE 11: courier_staff  (NEW)
-- ============================================================
CREATE TABLE courier_staff (
    staff_id    INT AUTO_INCREMENT PRIMARY KEY,
    user_id     INT NOT NULL,
    branch_id   INT NOT NULL,
    designation VARCHAR(100) NOT NULL,
    cnic        VARCHAR(15) UNIQUE,
    join_date   DATE NOT NULL,
    is_active   TINYINT(1) DEFAULT 1,
    CONSTRAINT fk_staff_user   FOREIGN KEY (user_id)
        REFERENCES users(user_id),
    CONSTRAINT fk_staff_branch FOREIGN KEY (branch_id)
        REFERENCES branch(seller_id)
);

-- ============================================================
-- TABLE 12: vehicle  (NEW)
-- ============================================================
CREATE TABLE vehicle (
    vehicle_id      INT AUTO_INCREMENT PRIMARY KEY,
    registration_no VARCHAR(20) NOT NULL UNIQUE,
    vehicle_type    VARCHAR(50) NOT NULL,
    capacity_kg     DECIMAL(6,2) NOT NULL,
    branch_id       INT NOT NULL,
    is_available    TINYINT(1) DEFAULT 1,
    CONSTRAINT chk_capacity     CHECK (capacity_kg > 0),
    CONSTRAINT chk_vehicle_type CHECK (vehicle_type IN ('Bike','Van','Truck')),
    CONSTRAINT fk_vehicle_branch FOREIGN KEY (branch_id)
        REFERENCES branch(seller_id)
);

-- ============================================================
-- TABLE 13: warehouse  (NEW)
-- ============================================================
CREATE TABLE warehouse (
    warehouse_id  INT AUTO_INCREMENT PRIMARY KEY,
    branch_id     INT NOT NULL,
    name          VARCHAR(150) NOT NULL,
    address       VARCHAR(300) NOT NULL,
    city          VARCHAR(100) NOT NULL,
    capacity      INT NOT NULL DEFAULT 500,
    current_stock INT NOT NULL DEFAULT 0,
    CONSTRAINT chk_capacity_wh CHECK (capacity > 0),
    CONSTRAINT chk_stock       CHECK (current_stock >= 0),
    CONSTRAINT fk_wh_branch    FOREIGN KEY (branch_id)
        REFERENCES branch(seller_id)
);

-- ============================================================
-- TABLE 14: complaint  (NEW)
-- ============================================================
CREATE TABLE complaint (
    complaint_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id      INT NOT NULL,
    parcel_id    INT,
    subject      VARCHAR(200) NOT NULL,
    description  TEXT,
    status       VARCHAR(20) NOT NULL DEFAULT 'Open',
    filed_at     DATETIME DEFAULT CURRENT_TIMESTAMP,
    resolved_at  DATETIME DEFAULT NULL,
    CONSTRAINT chk_complaint_status CHECK (status IN ('Open','InProgress','Resolved','Closed')),
    CONSTRAINT fk_complaint_user   FOREIGN KEY (user_id)
        REFERENCES users(user_id),
    CONSTRAINT fk_complaint_parcel FOREIGN KEY (parcel_id)
        REFERENCES parcel(shipment_id)
);

-- ============================================================
-- TABLE 15: notification  (NEW)
-- ============================================================
CREATE TABLE notification (
    notification_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id         INT NOT NULL,
    parcel_id       INT,
    message         VARCHAR(500) NOT NULL,
    type            VARCHAR(30) NOT NULL DEFAULT 'SMS',
    is_read         TINYINT(1) DEFAULT 0,
    sent_at         DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_notif_type CHECK (type IN ('SMS','Email','System')),
    CONSTRAINT fk_notif_user   FOREIGN KEY (user_id)
        REFERENCES users(user_id),
    CONSTRAINT fk_notif_parcel FOREIGN KEY (parcel_id)
        REFERENCES parcel(shipment_id)
);

-- ============================================================
-- VERIFY: 15 tables
-- ============================================================
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'CourierDB'
ORDER BY TABLE_NAME;

-- ============================================================
-- SAMPLE DATA
-- ============================================================

-- Users
INSERT INTO users (name, email, password_hash, phone, role)
VALUES ('Admin User', 'admin@courier.com',
        '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
        '03001234567', 'Admin');

INSERT INTO users (name, email, password_hash, phone, role)
VALUES ('Ali Hassan', 'ali@gmail.com',
        '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
        '03111234567', 'Customer');

INSERT INTO users (name, email, password_hash, phone, role)
VALUES ('Sara Khan', 'sara@courier.com',
        '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
        '03211234567', 'Staff');

-- Address for customer
INSERT INTO address (user_id, street, city, province, postal_code, is_default)
VALUES (2, 'House 5 Block B Gulberg', 'Lahore', 'Punjab', '54000', 1);

-- Branch
INSERT INTO branch (user_id, shop_name, description)
VALUES (1, 'Lahore Main Branch', 'Head office Lahore');

-- Delivery zones
INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate)
VALUES ('Punjab Zone',  'Lahore,Faisalabad,Multan',  200.00, 50.00);
INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate)
VALUES ('Sindh Zone',   'Karachi,Hyderabad',          250.00, 60.00);
INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate)
VALUES ('KPK Zone',     'Peshawar,Swat',              300.00, 70.00);

-- Rate card
INSERT INTO rate_card (code, type, value, expiry_date, usage_limit)
VALUES ('SAVE10',  'Percentage', 10.00, '2026-12-31 23:59:59', 100);
INSERT INTO rate_card (code, type, value, expiry_date, usage_limit)
VALUES ('FLAT200', 'Fixed',     200.00, '2026-12-31 23:59:59',  50);

-- Booking
INSERT INTO booking (user_id, address_id, total_amount, discount_applied, status)
VALUES (2, 1, 450.00, 0, 'Confirmed');

-- Payment
INSERT INTO payment (order_id, amount, method, status)
VALUES (1, 450.00, 'Cash', 'Completed');

-- Parcel
INSERT INTO parcel (order_id, sender_name, receiver_name, receiver_phone,
                    receiver_city, weight_kg, parcel_type, courier_name,
                    tracking_code, zone_id, branch_id, declared_value, status)
VALUES (1, 'Ali Hassan', 'Ahmed Raza', '03001112222',
        'Karachi', 2.5, 'Document', 'TCS',
        'PK-20260605-1001', 2, 1, 5000.00, 'Shipped');

-- Tracking log
INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
VALUES (1, 'Processing',    'Lahore',  'Booking created',         1);
INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
VALUES (1, 'Shipped',       'Lahore',  'Dispatched from branch',  1);

-- Courier staff
INSERT INTO courier_staff (user_id, branch_id, designation, cnic, join_date)
VALUES (3, 1, 'Delivery Rider', '35201-1234567-1', '2024-01-15');

-- Vehicle
INSERT INTO vehicle (registration_no, vehicle_type, capacity_kg, branch_id)
VALUES ('LHR-001', 'Bike', 20.00, 1);

-- Warehouse
INSERT INTO warehouse (branch_id, name, address, city, capacity, current_stock)
VALUES (1, 'LHR Warehouse A', 'Plot 12, Sundar Industrial Estate', 'Lahore', 1000, 120);

-- Complaint
INSERT INTO complaint (user_id, parcel_id, subject, description)
VALUES (2, 1, 'Parcel delayed', 'My parcel was supposed to arrive yesterday.');

-- Notification
INSERT INTO notification (user_id, parcel_id, message, type)
VALUES (2, 1, 'Your parcel PK-20260605-1001 has been shipped.', 'SMS');


USE CourierDB;

-- Add a test address for the customer (user_id=3 is your Customer)
INSERT INTO address (user_id, street, city, province, postal_code, is_default)
VALUES (3, '123 Test Street', 'Lahore', 'Punjab', '54000', 1);

-- Add a test booking
INSERT INTO booking (user_id, address_id, total_amount, discount_applied, status)
VALUES (3, 1, 500.00, 0, 'Confirmed');

-- Add a test parcel linked to that booking
INSERT INTO parcel (order_id, tracking_code, sender_name, receiver_name, 
receiver_phone, receiver_city, weight_kg, parcel_type, status, 
courier_name, zone_id)
VALUES (1, 'TRK-001', 'Admin User', 'Customer User', 
'03001234569', 'Karachi', 2.5, 'General', 'Shipped', 
'CourierDB Express', 1);

-- Add a tracking log entry for that parcel
INSERT INTO tracking_log (parcel_id, status, location, remarks, updated_by)
VALUES (1, 'Shipped', 'Lahore Warehouse', 'Parcel dispatched', 1);

-- Add a test complaint
INSERT INTO complaint (user_id, parcel_id, subject, description, status)
VALUES (3, 1, 'Late Delivery', 'My parcel has not arrived yet.', 'Open');

INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate, is_active)
VALUES ('Zone A - Punjab', 'Lahore, Faisalabad, Multan', 200.00, 50.00, 1);

USE CourierDB;

-- Add second booking
INSERT INTO booking (user_id, address_id, total_amount, discount_applied, status)
VALUES (3, 1, 600.00, 0, 'Confirmed');

-- Add address for Admin (user_id = 1)
INSERT INTO address (user_id, street, city, province, postal_code, is_default)
VALUES (1, 'Main Office, Gulberg III', 'Lahore', 'Punjab', '54000', 1);

-- Also add address for Sara Khan / Staff (user_id = 3) if not exists
INSERT INTO address (user_id, street, city, province, postal_code, is_default)
VALUES (3, '123 Model Town', 'Lahore', 'Punjab', '54000', 1);

-- Add a parcel for it
INSERT INTO parcel (order_id, tracking_code, sender_name, receiver_name,
receiver_phone, receiver_city, weight_kg, parcel_type, status,
courier_name, zone_id)
VALUES (2, 'TRK-002', 'Admin User', 'Customer User',
'03001234569', 'Islamabad', 3.0, 'Document', 'Processing',
'CourierDB Express', 1);


