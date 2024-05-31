-- Create Employees Table
CREATE TABLE [dbo].[Employees]
(
    [EmployeeID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FirstName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NULL
);

-- Create Farmers Table
CREATE TABLE [dbo].[Farmers]
(
    [FarmerID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FirstName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NULL,
    [Location] NVARCHAR(50) NULL,
    [MobileNumber] NVARCHAR(15) NULL,
    [EmployeeID] INT NULL FOREIGN KEY REFERENCES Employees (EmployeeID)
);

-- Create Products Table
CREATE TABLE [dbo].[Products]
(
    [ProductID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Name] NVARCHAR(50) NULL,
    [Category] NVARCHAR(50) NULL,
    [ProductionDate] DATETIME2 NULL,
    [Description] NVARCHAR(50) NULL,
    [FarmerID] INT NULL FOREIGN KEY REFERENCES Farmers (FarmerID)
);

-- Create Users Table
CREATE TABLE [dbo].[Users]
(
    [UserID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FullName] NVARCHAR(50) NULL,
    [MobileNumber] NVARCHAR(15) NULL,
    [Email] NVARCHAR(50) NULL,
    [Username] NVARCHAR(50) NULL,
    [Password] NVARCHAR(50) NULL,
    [Role] NVARCHAR(50) NULL -- Role can be 'Farmer' or 'Employee'
);

-- Insert Employees
INSERT INTO [dbo].[Employees] ([FirstName], [LastName])
VALUES 
('John', 'Doe'),
('Jane', 'Smith');

-- Insert Farmers
INSERT INTO [dbo].[Farmers] ([FirstName], [LastName], [Location], [MobileNumber], [EmployeeID])
VALUES 
('Alex', 'Brown', 'New York', '1234567890', 1),
('Maria', 'Garcia', 'California', '0987654321', 2),
('Jan', 'Piet', 'Melkbos', '0215486325', 1),
('Henko', 'Markus', 'CPT', '0216548965', 1);

-- Insert Products
INSERT INTO [dbo].[Products] ([Name], [Category], [ProductionDate], [Description], [FarmerID])
VALUES 
('Apple', 'Fruit', '2023-05-01', 'Fresh apples', 1),
('Wheat', 'Grain', '2023-04-20', 'Organic wheat', 2),
('Watermelon sweets', 'Sweets', '2024-05-31', 'Sugary', 2),
('Chicken wrap', 'Lunch', '2024-05-31', 'Have during the afternoon', 2),
('Biscuits', 'Lemon creams', '2024-05-31', 'Have with tea', 2);

-- Insert Users
-- Insert Users with Roles
INSERT INTO [dbo].[Users] ([FullName], [MobileNumber], [Email], [Username], [Password], [Role])
VALUES 
('Merwyn Le Roux', '0123365478', 'merwyn@gmail.com', 'merw_', 'Merywn1_', 'Employee'),
('Alice Wonderland', '1112223333', 'alice@gmail.com', 'alice_w', 'password123!', 'Farmer'),
('Bob Builder', '4445556666', 'bob@gmail.com', 'bob_b', 'password456!', 'Employee'),
('Jan Piet', '0215486325', 'piet12@gmail.com', 'piet_', 'Fami12_', 'Farmer'),
('Henko Markus', '0216548965', 'markus21@gmail.com', 'mark_', 'Fami12_', 'Farmer');

