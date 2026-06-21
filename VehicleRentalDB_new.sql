SET FOREIGN_KEY_CHECKS = 0;

DROP DATABASE IF EXISTS VehicleRentalDB;

CREATE DATABASE VehicleRentalDB
CHARACTER SET utf8mb4
COLLATE utf8mb4_general_ci;

USE VehicleRentalDB;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL,
    is_active TINYINT(1) NOT NULL DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (username, password, role) VALUES
('manager', 'Mgr@2024', 'Manager'),
('staff', 'Staff@001', 'Staff');
CREATE TABLE vehicle (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Brand VARCHAR(100) NOT NULL,
    Model VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    RegNo VARCHAR(20) NOT NULL UNIQUE,
    DailyRate DECIMAL(10,2) NOT NULL,
    ManufactureYear INT NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Available'
);

INSERT INTO vehicle
(Brand, Model, Type, RegNo, DailyRate, ManufactureYear, Status)
VALUES
('Toyota','Corolla','Car','CBA-1001',5500,2020,'Available'),
('Toyota','Aqua','Car','CBA-1002',4500,2019,'Available'),
('Honda','Fit','Car','CBA-1003',4200,2018,'Available'),
('Suzuki','Wagon R','Car','CBA-1004',3800,2017,'Available'),
('Nissan','Leaf','Car','CBA-1005',6000,2021,'Available'),
('Toyota','Hiace','Van','CBA-2001',8000,2019,'Available'),
('Nissan','Caravan','Van','CBA-2002',7500,2018,'Available'),
('Toyota','Prius','Car','CBA-1006',5000,2020,'Available'),
('Mitsubishi','Montero','SUV','CBA-3001',12000,2019,'Available'),
('Toyota','RAV4','SUV','CBA-3002',9500,2021,'Available'),
('Isuzu','Elf','Truck','CBA-4001',15000,2018,'Available'),
('Toyota','Dyna','Truck','CBA-4002',14000,2017,'Available'),
('Micro','Bus','Bus','CBA-5001',20000,2016,'Available'),
('Toyota','Coaster','Bus','CBA-5002',22000,2018,'Available'),
('Honda','Vezel','SUV','CBA-3003',8500,2020,'Rented'),
('Toyota','Camry','Car','CBA-1007',7000,2021,'Rented'),
('Suzuki','Alto','Car','CBA-1008',3500,2016,'Rented'),
('Nissan','Sunny','Car','CBA-1009',4000,2017,'Rented'),
('Toyota','Axio','Car','CBA-1010',4800,2019,'Rented'),
('Mazda','CX-5','SUV','CBA-3010',9000,2020,'Rented'),
('Honda','Grace','Car','CBA-1011',4600,2018,'Rented'),
('Toyota','Allion','Car','CBA-1012',5200,2019,'Rented'),
('Toyota','Land Cruiser','SUV','CBA-3011',25000,2020,'Maintenance'),
('Isuzu','D-Max','Truck','CBA-4003',16000,2019,'Maintenance');

CREATE TABLE customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(255) NOT NULL,
    NIC VARCHAR(20) NOT NULL UNIQUE,
    Phone VARCHAR(20) NOT NULL,
    LicenseNo VARCHAR(50) NOT NULL,
    Address TEXT NOT NULL,
    DateRegistered DATE NOT NULL,
    ActiveRentals INT NOT NULL DEFAULT 0
);

INSERT INTO customers
(FullName, NIC, Phone, LicenseNo, Address, DateRegistered, ActiveRentals)
VALUES
('Nimali Perera','199012345678','0771234567','B1234567','Colombo 05','2024-01-15',1),
('Kasun Silva','199112345679','0719876543','B2345678','Kandy','2024-02-20',1),
('Amila Fernando','198812345680','0755555555','B3456789','Galle','2024-03-10',0),
('Anura Perera','197512345681','0761112233','B4567890','Negombo','2024-04-05',1),
('Sanduni Jayawardena','199512345682','0782223344','B5678901','Matara','2024-05-12',0);

CREATE TABLE rentals (
    RentalID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    VehicleID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Active',

    CONSTRAINT fk_rental_customer
        FOREIGN KEY (CustomerID)
        REFERENCES customers(CustomerID),

    CONSTRAINT fk_rental_vehicle
        FOREIGN KEY (VehicleID)
        REFERENCES vehicle(ID)
);

INSERT INTO rentals
(CustomerID, VehicleID, StartDate, EndDate, TotalAmount, Status)
VALUES
(1,15,DATE_SUB(CURDATE(), INTERVAL 5 DAY),DATE_ADD(CURDATE(), INTERVAL 2 DAY),59500,'Active'),
(2,16,DATE_SUB(CURDATE(), INTERVAL 3 DAY),DATE_ADD(CURDATE(), INTERVAL 4 DAY),49000,'Active'),
(4,17,DATE_SUB(CURDATE(), INTERVAL 7 DAY),DATE_ADD(CURDATE(), INTERVAL 1 DAY),24500,'Active'),
(1,18,DATE_SUB(CURDATE(), INTERVAL 45 DAY),DATE_SUB(CURDATE(), INTERVAL 40 DAY),20000,'Completed'),
(2,19,DATE_SUB(CURDATE(), INTERVAL 30 DAY),DATE_SUB(CURDATE(), INTERVAL 25 DAY),24000,'Completed'),
(3,20,DATE_SUB(CURDATE(), INTERVAL 20 DAY),DATE_SUB(CURDATE(), INTERVAL 15 DAY),45000,'Completed'),
(4,21,DATE_SUB(CURDATE(), INTERVAL 10 DAY),DATE_SUB(CURDATE(), INTERVAL 5 DAY),23000,'Completed'),
(5,22,DATE_SUB(CURDATE(), INTERVAL 60 DAY),DATE_SUB(CURDATE(), INTERVAL 55 DAY),26000,'Completed');

CREATE TABLE payments (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,
    RentalID INT NOT NULL,
    Customer VARCHAR(255) NOT NULL,
    Vehicle VARCHAR(255) NOT NULL,
    Period VARCHAR(100) NOT NULL,
    BaseAmount DECIMAL(10,2) NOT NULL,
    OverdueDays INT NOT NULL DEFAULT 0,
    PenaltyRate DECIMAL(10,2) NOT NULL DEFAULT 0,
    LatePenalty DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalDue DECIMAL(10,2) NOT NULL,
    Discount DECIMAL(10,2) NOT NULL DEFAULT 0,
    FinalAmount DECIMAL(10,2) NOT NULL,
    Method VARCHAR(50) NOT NULL,
    PayDate DATE NOT NULL,
    ReferenceNo VARCHAR(100) NOT NULL,

    CONSTRAINT fk_payment_rental
        FOREIGN KEY (RentalID)
        REFERENCES rentals(RentalID)
        ON DELETE CASCADE
);

INSERT INTO payments
(RentalID, Customer, Vehicle, Period, BaseAmount, OverdueDays, PenaltyRate, LatePenalty, TotalDue, Discount, FinalAmount, Method, PayDate, ReferenceNo)
VALUES
(4,'Nimali Perera','CBA-1010','2025-01-01 to 2025-01-06',20000,0,0,0,20000,0,20000,'Cash',DATE_SUB(CURDATE(), INTERVAL 40 DAY),'PAY-001'),
(5,'Kasun Silva','CBA-1009','2025-02-01 to 2025-02-06',24000,0,0,0,24000,500,23500,'Card',DATE_SUB(CURDATE(), INTERVAL 25 DAY),'PAY-002'),
(6,'Amila Fernando','CBA-3010','2025-03-01 to 2025-03-06',45000,1,500,500,45500,0,45500,'Bank Transfer',DATE_SUB(CURDATE(), INTERVAL 15 DAY),'PAY-003');

UPDATE customers c
SET ActiveRentals =
(
    SELECT COUNT(*)
    FROM rentals r
    WHERE r.CustomerID = c.CustomerID
    AND r.Status = 'Active'
);

SET FOREIGN_KEY_CHECKS = 1;
