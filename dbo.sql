/*
 Navicat Premium Dump SQL

 Source Server         : SQL Server
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : DESKTOP-EME7EMM:1433
 Source Catalog        : ISAD
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 13/06/2024 09:30:09
*/


-- ----------------------------
-- Table structure for tbCustomers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbCustomers]') AND type IN ('U'))
	DROP TABLE [dbo].[tbCustomers]
GO

CREATE TABLE [dbo].[tbCustomers] (
  [cusID] int  IDENTITY(1,1) NOT NULL,
  [cusName] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [cusCon] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tbCustomers] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbCustomers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbCustomers] ON
GO

INSERT INTO [dbo].[tbCustomers] ([cusID], [cusName], [cusCon]) VALUES (N'1', N'U178-Navi', N'98474744')
GO

SET IDENTITY_INSERT [dbo].[tbCustomers] OFF
GO


-- ----------------------------
-- Table structure for tbImportsT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbImportsT]') AND type IN ('U'))
	DROP TABLE [dbo].[tbImportsT]
GO

CREATE TABLE [dbo].[tbImportsT] (
  [ImpID] int  IDENTITY(1,1) NOT NULL,
  [ImpDate] date  NOT NULL,
  [staffID] tinyint  NOT NULL,
  [fullName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [supID] int  NOT NULL,
  [supplier] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Total] money  NOT NULL
)
GO

ALTER TABLE [dbo].[tbImportsT] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbImportsT
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbImportsT] ON
GO

SET IDENTITY_INSERT [dbo].[tbImportsT] OFF
GO


-- ----------------------------
-- Table structure for tbInvoiceDetails
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbInvoiceDetails]') AND type IN ('U'))
	DROP TABLE [dbo].[tbInvoiceDetails]
GO

CREATE TABLE [dbo].[tbInvoiceDetails] (
  [InvCode] int  NOT NULL,
  [ProCode] int  NOT NULL,
  [ProName] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [qty] smallint  NOT NULL,
  [price] money  NOT NULL,
  [amount] money  NOT NULL
)
GO

ALTER TABLE [dbo].[tbInvoiceDetails] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbInvoiceDetails
-- ----------------------------

-- ----------------------------
-- Table structure for tbInvoices
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbInvoices]') AND type IN ('U'))
	DROP TABLE [dbo].[tbInvoices]
GO

CREATE TABLE [dbo].[tbInvoices] (
  [InvCode] int  IDENTITY(1,1) NOT NULL,
  [InvDate] date  NOT NULL,
  [staffID] tinyint  NOT NULL,
  [fullName] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [cusID] int  NOT NULL,
  [cusName] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [Total] money  NOT NULL
)
GO

ALTER TABLE [dbo].[tbInvoices] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbInvoices
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbInvoices] ON
GO

SET IDENTITY_INSERT [dbo].[tbInvoices] OFF
GO


-- ----------------------------
-- Table structure for tbPayments
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbPayments]') AND type IN ('U'))
	DROP TABLE [dbo].[tbPayments]
GO

CREATE TABLE [dbo].[tbPayments] (
  [PayCode] int  IDENTITY(1,1) NOT NULL,
  [PayDate] smalldatetime  NOT NULL,
  [staffID] tinyint  NOT NULL,
  [fullName] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [InvCode] int  NOT NULL,
  [Amount] money  NOT NULL
)
GO

ALTER TABLE [dbo].[tbPayments] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbPayments
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbPayments] ON
GO

SET IDENTITY_INSERT [dbo].[tbPayments] OFF
GO


-- ----------------------------
-- Table structure for tbProducts
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbProducts]') AND type IN ('U'))
	DROP TABLE [dbo].[tbProducts]
GO

CREATE TABLE [dbo].[tbProducts] (
  [ProCode] int  IDENTITY(1,1) NOT NULL,
  [ProName] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [qty] smallint  NOT NULL,
  [UPIS] money  NOT NULL
)
GO

ALTER TABLE [dbo].[tbProducts] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbProducts
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbProducts] ON
GO

INSERT INTO [dbo].[tbProducts] ([ProCode], [ProName], [qty], [UPIS]) VALUES (N'2', N'Mintor 24" Dell SH-3232', N'8', N'199.0000')
GO

INSERT INTO [dbo].[tbProducts] ([ProCode], [ProName], [qty], [UPIS]) VALUES (N'3', N'Mintor 32" Dell SH-3232', N'2', N'400.0000')
GO

SET IDENTITY_INSERT [dbo].[tbProducts] OFF
GO


-- ----------------------------
-- Table structure for tbStaffs
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbStaffs]') AND type IN ('U'))
	DROP TABLE [dbo].[tbStaffs]
GO

CREATE TABLE [dbo].[tbStaffs] (
  [staffID] tinyint  IDENTITY(1,1) NOT NULL,
  [fullName] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [gen] char(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Dob] date  NOT NULL,
  [position] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [salary] money  NULL,
  [stopwork] bit  NULL
)
GO

ALTER TABLE [dbo].[tbStaffs] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbStaffs
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbStaffs] ON
GO

INSERT INTO [dbo].[tbStaffs] ([staffID], [fullName], [gen], [Dob], [position], [salary], [stopwork]) VALUES (N'1', N'Vann Ya', N'M', N'1991-08-21', N'dev', N'2000.0000', N'0')
GO

INSERT INTO [dbo].[tbStaffs] ([staffID], [fullName], [gen], [Dob], [position], [salary], [stopwork]) VALUES (N'2', N'Dan Ua', N'M', N'2000-11-09', N'Network', N'12200.0000', N'0')
GO

INSERT INTO [dbo].[tbStaffs] ([staffID], [fullName], [gen], [Dob], [position], [salary], [stopwork]) VALUES (N'3', N'Mary Ma', N'F', N'2000-08-16', N'HR', N'350.0000', N'0')
GO

SET IDENTITY_INSERT [dbo].[tbStaffs] OFF
GO


-- ----------------------------
-- Table structure for tbSuppliers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbSuppliers]') AND type IN ('U'))
	DROP TABLE [dbo].[tbSuppliers]
GO

CREATE TABLE [dbo].[tbSuppliers] (
  [supID] int  IDENTITY(101,1) NOT NULL,
  [supplier] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [supAdd] nvarchar(max) COLLATE Khmer_100_BIN  NOT NULL,
  [supCon] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[tbSuppliers] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbSuppliers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbSuppliers] ON
GO

INSERT INTO [dbo].[tbSuppliers] ([supID], [supplier], [supAdd], [supCon]) VALUES (N'101', N'Niki Company', N'USA, Alaska, St1262', N'18938434')
GO

INSERT INTO [dbo].[tbSuppliers] ([supID], [supplier], [supAdd], [supCon]) VALUES (N'103', N'Starbucks Company', N'Kanada, St172', N'1893344333')
GO

SET IDENTITY_INSERT [dbo].[tbSuppliers] OFF
GO


-- ----------------------------
-- Table structure for tbUsers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tbUsers]') AND type IN ('U'))
	DROP TABLE [dbo].[tbUsers]
GO

CREATE TABLE [dbo].[tbUsers] (
  [u_name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [pwd] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [roles] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [id] int  IDENTITY(1,1) NOT NULL
)
GO

ALTER TABLE [dbo].[tbUsers] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tbUsers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tbUsers] ON
GO

INSERT INTO [dbo].[tbUsers] ([u_name], [pwd], [roles], [id]) VALUES (N'admin', N'admin123', N'admin', N'1')
GO

INSERT INTO [dbo].[tbUsers] ([u_name], [pwd], [roles], [id]) VALUES (N'staff001', N'staff123', N'staff', N'2')
GO

SET IDENTITY_INSERT [dbo].[tbUsers] OFF
GO


-- ----------------------------
-- procedure structure for RCusE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RCusE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RCusE6]
GO

CREATE PROCEDURE [dbo].[RCusE6] AS
SELECT cusID as ID, cusName as Name, cusCon as Contact FROM dbo.tbCustomers
GO


-- ----------------------------
-- procedure structure for RCusNameE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RCusNameE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RCusNameE6]
GO

CREATE PROCEDURE [dbo].[RCusNameE6] (@cn VARCHAR(MAX))  AS
SELECT cusID as ID, cusName as Name, cusCon as Contact
FROM dbo.tbCustomers
WHERE cusName LIKE '%' + @cn + '%'
GO


-- ----------------------------
-- procedure structure for InsCusE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[InsCusE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[InsCusE6]
GO

CREATE PROCEDURE [dbo].[InsCusE6] (@cn VARCHAR(MAX), @co VARCHAR(MAX) ) AS
BEGIN
  INSERT INTO tbCustomers(cusName, cusCon)
  VALUES(@cn, @co)
END
GO


-- ----------------------------
-- procedure structure for UpCusE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UpCusE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[UpCusE6]
GO

CREATE PROCEDURE [dbo].[UpCusE6] (@id INT, @cn VARCHAR(MAX), @co VARCHAR(MAX) ) AS
UPDATE tbCustomers
SET cusName=@cn , cusCon = @co
WHERE cusID= @id
GO


-- ----------------------------
-- procedure structure for DelCusE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DelCusE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[DelCusE6]
GO

CREATE PROCEDURE [dbo].[DelCusE6] (@id INT) AS
DELETE FROM tbCustomers WHERE cusID=@id
GO


-- ----------------------------
-- procedure structure for RProductsE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RProductsE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RProductsE6]
GO

CREATE PROCEDURE [dbo].[RProductsE6] AS
SELECT ProCode as Code, ProName as Name, qty as Quantity, UPIS as UnitPrice
FROM dbo.tbProducts
GO


-- ----------------------------
-- procedure structure for RProductNameE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RProductNameE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RProductNameE6]
GO

CREATE PROCEDURE [dbo].[RProductNameE6] (@name VARCHAR(MAX)) AS
SELECT ProCode as Code, ProName as Name, qty as Quantity, UPIS as UnitPrice
FROM dbo.tbProducts
WHERE ProName LIKE '%' + @name + '%'
GO


-- ----------------------------
-- procedure structure for InsProductE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[InsProductE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[InsProductE6]
GO

CREATE PROCEDURE [dbo].[InsProductE6] (@name VARCHAR(MAX), @quantity SMALLINT, @unitPrice MONEY) AS
BEGIN
    INSERT INTO tbProducts (ProName, qty, UPIS)
    VALUES (@name, @quantity, @unitPrice)
END
GO


-- ----------------------------
-- procedure structure for UpProductE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UpProductE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[UpProductE6]
GO

CREATE PROCEDURE [dbo].[UpProductE6] (@code INT, @name VARCHAR(MAX), @quantity SMALLINT, @unitPrice MONEY) AS
UPDATE tbProducts
SET ProName = @name, qty = @quantity, UPIS = @unitPrice
WHERE ProCode = @code
GO


-- ----------------------------
-- procedure structure for DelProductE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DelProductE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[DelProductE6]
GO

CREATE PROCEDURE [dbo].[DelProductE6] (@code INT) AS
DELETE FROM tbProducts WHERE ProCode = @code
GO


-- ----------------------------
-- procedure structure for RStaffE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RStaffE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RStaffE6]
GO

CREATE PROCEDURE [dbo].[RStaffE6] AS
SELECT staffID as ID, fullName as Name, gen as Gender, Dob as DateOfBirth, position as Position, salary as Salary, stopwork as StopWork
FROM dbo.tbStaffs
GO


-- ----------------------------
-- procedure structure for RStaffNameE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RStaffNameE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RStaffNameE6]
GO

CREATE PROCEDURE [dbo].[RStaffNameE6] (@name NVARCHAR(MAX)) AS
SELECT staffID as ID, fullName as Name, gen as Gender, Dob as DateOfBirth, position as Position, salary as Salary, stopwork as StopWork
FROM dbo.tbStaffs
WHERE fullName LIKE '%' + @name + '%'
GO


-- ----------------------------
-- procedure structure for InsStaffE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[InsStaffE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[InsStaffE6]
GO

CREATE PROCEDURE [dbo].[InsStaffE6] (@name NVARCHAR(MAX), @gen CHAR, @dob DATE, @position VARCHAR(MAX), @salary MONEY, @stopwork BIT) AS
BEGIN
    INSERT INTO tbStaffs (fullName, gen, Dob, position, salary, stopwork)
    VALUES (@name, @gen, @dob, @position, @salary, @stopwork)
END
GO


-- ----------------------------
-- procedure structure for UpStaffE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UpStaffE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[UpStaffE6]
GO

CREATE PROCEDURE [dbo].[UpStaffE6] (@id TINYINT, @name NVARCHAR(MAX), @gen CHAR, @dob DATE, @position VARCHAR(MAX), @salary MONEY, @stopwork BIT) AS
UPDATE tbStaffs
SET fullName = @name, gen = @gen, Dob = @dob, position = @position, salary = @salary, stopwork = @stopwork
WHERE staffID = @id
GO


-- ----------------------------
-- procedure structure for DelStaffE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DelStaffE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[DelStaffE6]
GO

CREATE PROCEDURE [dbo].[DelStaffE6] (@id TINYINT) AS
DELETE FROM tbStaffs WHERE staffID = @id
GO


-- ----------------------------
-- procedure structure for RSuppliersE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RSuppliersE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RSuppliersE6]
GO

CREATE PROCEDURE [dbo].[RSuppliersE6] AS
SELECT supID as ID, supplier as Supplier, supAdd as Address, supCon as Contact
FROM dbo.tbSuppliers
GO


-- ----------------------------
-- procedure structure for RSupplierNameE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RSupplierNameE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[RSupplierNameE6]
GO

CREATE PROCEDURE [dbo].[RSupplierNameE6] (@name NVARCHAR(MAX)) AS
SELECT supID as ID, supplier as Supplier, supAdd as Address, supCon as Contact
FROM dbo.tbSuppliers
WHERE supplier LIKE '%' + @name + '%'
GO


-- ----------------------------
-- procedure structure for InsSupplierE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[InsSupplierE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[InsSupplierE6]
GO

CREATE PROCEDURE [dbo].[InsSupplierE6] (@supplier NVARCHAR(MAX), @address NVARCHAR(MAX), @contact VARCHAR(MAX)) AS
BEGIN
    INSERT INTO tbSuppliers (supplier, supAdd, supCon)
    VALUES (@supplier, @address, @contact)
END
GO


-- ----------------------------
-- procedure structure for UpSupplierE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSupplierE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[UpSupplierE6]
GO

CREATE PROCEDURE [dbo].[UpSupplierE6] (@id INT, @supplier NVARCHAR(MAX), @address NVARCHAR(MAX), @contact VARCHAR(MAX)) AS
UPDATE tbSuppliers
SET supplier = @supplier, supAdd = @address, supCon = @contact
WHERE supID = @id
GO


-- ----------------------------
-- procedure structure for DelSupplierE6
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DelSupplierE6]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[DelSupplierE6]
GO

CREATE PROCEDURE [dbo].[DelSupplierE6] (@id INT) AS
DELETE FROM tbSuppliers WHERE supID = @id
GO


-- ----------------------------
-- procedure structure for AuthenticateUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AuthenticateUser]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[AuthenticateUser]
GO

CREATE PROCEDURE [dbo].[AuthenticateUser]
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SELECT id
    FROM tbUsers
    WHERE u_name = @username AND pwd = @password
END
GO


-- ----------------------------
-- Auto increment value for tbCustomers
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbCustomers]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table tbCustomers
-- ----------------------------
ALTER TABLE [dbo].[tbCustomers] ADD CONSTRAINT [pkCus] PRIMARY KEY CLUSTERED ([cusID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbImportsT
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbImportsT]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tbImportsT
-- ----------------------------
ALTER TABLE [dbo].[tbImportsT] ADD CONSTRAINT [pk_imp] PRIMARY KEY CLUSTERED ([ImpID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tbInvoiceDetails
-- ----------------------------
ALTER TABLE [dbo].[tbInvoiceDetails] ADD CONSTRAINT [pkInvD] PRIMARY KEY CLUSTERED ([InvCode], [ProCode])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbInvoices
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbInvoices]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tbInvoices
-- ----------------------------
ALTER TABLE [dbo].[tbInvoices] ADD CONSTRAINT [pk_inv] PRIMARY KEY CLUSTERED ([InvCode])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbPayments
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbPayments]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tbPayments
-- ----------------------------
ALTER TABLE [dbo].[tbPayments] ADD CONSTRAINT [pkPay] PRIMARY KEY CLUSTERED ([PayCode])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbProducts
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbProducts]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table tbProducts
-- ----------------------------
ALTER TABLE [dbo].[tbProducts] ADD CONSTRAINT [pkPro] PRIMARY KEY CLUSTERED ([ProCode])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbStaffs
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbStaffs]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table tbStaffs
-- ----------------------------
ALTER TABLE [dbo].[tbStaffs] ADD CONSTRAINT [pkSta] PRIMARY KEY CLUSTERED ([staffID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbSuppliers
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbSuppliers]', RESEED, 103)
GO


-- ----------------------------
-- Primary Key structure for table tbSuppliers
-- ----------------------------
ALTER TABLE [dbo].[tbSuppliers] ADD CONSTRAINT [pksub] PRIMARY KEY CLUSTERED ([supID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tbUsers
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tbUsers]', RESEED, 2)
GO


-- ----------------------------
-- Uniques structure for table tbUsers
-- ----------------------------
ALTER TABLE [dbo].[tbUsers] ADD CONSTRAINT [UQ_tbUsers_u_name] UNIQUE NONCLUSTERED ([u_name] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tbUsers
-- ----------------------------
ALTER TABLE [dbo].[tbUsers] ADD CONSTRAINT [PK__tbUsers__3213E83FF666AFF5] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table tbImportsT
-- ----------------------------
ALTER TABLE [dbo].[tbImportsT] ADD CONSTRAINT [fksup_imp] FOREIGN KEY ([supID]) REFERENCES [dbo].[tbSuppliers] ([supID]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tbInvoiceDetails
-- ----------------------------
ALTER TABLE [dbo].[tbInvoiceDetails] ADD CONSTRAINT [fkinv_invd] FOREIGN KEY ([InvCode]) REFERENCES [dbo].[tbInvoices] ([InvCode]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[tbInvoiceDetails] ADD CONSTRAINT [fkpro_invd] FOREIGN KEY ([ProCode]) REFERENCES [dbo].[tbProducts] ([ProCode]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tbInvoices
-- ----------------------------
ALTER TABLE [dbo].[tbInvoices] ADD CONSTRAINT [fksta_inv] FOREIGN KEY ([staffID]) REFERENCES [dbo].[tbStaffs] ([staffID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[tbInvoices] ADD CONSTRAINT [fkcus_inv] FOREIGN KEY ([cusID]) REFERENCES [dbo].[tbCustomers] ([cusID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table tbPayments
-- ----------------------------
ALTER TABLE [dbo].[tbPayments] ADD CONSTRAINT [fksta_Pay] FOREIGN KEY ([staffID]) REFERENCES [dbo].[tbStaffs] ([staffID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[tbPayments] ADD CONSTRAINT [fk_inv] FOREIGN KEY ([InvCode]) REFERENCES [dbo].[tbInvoices] ([InvCode]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

