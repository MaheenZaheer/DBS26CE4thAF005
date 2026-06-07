# Courier Management System

## 📌 Overview
The **Courier Management System** is a Windows Forms desktop application developed using **C#**, **.NET Framework**, and **MySQL**. The system helps courier companies manage parcels, bookings, customers, staff, payments, warehouses, vehicles, complaints, tracking, and reporting through a centralized dashboard.

---

## 🚀 Features

### 🔒 Authentication
* Secure Login System
* Role-Based Access Control
* Password Hashing using SHA-256

### 👥 User Management
* Add, Update, Delete Users
* Manage Customers
* Manage Staff Members

### 📦 Parcel & Delivery Management
* Create Parcel Records
* Update Parcel Status
* Track Parcel Movement
* Parcel Delivery Management

### 📅 Booking Management
* Create Courier Bookings
* Manage Sender and Receiver Information
* Booking History

### 📍 Tracking System
* Real-Time Parcel Tracking
* Tracking Logs
* Delivery Status Updates

### 💳 Payment Management
* Record Payments
* Payment History
* Billing Support

### 🏢 Warehouse & Vehicle Management
* Manage Warehouses & Parcel Storage Tracking
* Manage Delivery Vehicles & Vehicle Assignment

### 🛠️ Complaint Management
* Customer Complaint Handling
* Complaint Tracking

### 📊 Reports
* Generate Courier Reports
* Export Reports

### 🗺️ Zone & Rate Management
* Delivery Zones
* Shipping Rates & Cost Calculation

---

## 🛠️ Technologies Used
* **Frontend:** C# Windows Forms (.NET Framework 4.7.2)
* **Backend & Database:** MySQL, ADO.NET
* **Database Logic:** Stored Procedures, Triggers, Views

---

## 🗄️ Database Setup

### Step 1
Create a MySQL database on your local system.

### Step 2
Run the following SQL scripts in your MySQL workbench (in order):
1. `CourierDB_FIXED.sql`
2. `CourierDB_SP_Triggers_Views_FIXED.sql`

### Step 3
Update the MySQL connection string in the project configuration according to your local database username and password.

---

## 🔑 Default Login Credentials

| Role | Email | Password |
| :--- | :--- | :--- |
| **Admin** | `admin@courier.com` | `admin123` |
| **Staff** | `sara@courier.com` | `admin123` |
| **Customer** | `ali@gmail.com` | `admin123` |

---

## 🧩 Project Modules
The application consists of the following key modules accessible via the dashboard:
* Login & Dashboard
* User & Staff Management
* Parcel & Booking Management
* Tracking System
* Payment Management
* Vehicle & Warehouse Management
* Complaint Management
* Zone & Rate Management
* Reports

---

## 💻 Installation & Running
1. **Clone the repository:**
```bash
   git clone [https://github.com/MaheenZaheer/DBS26CE4thAF005.git](https://github.com/MaheenZaheer/DBS26CE4thAF005.git)
