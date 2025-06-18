IF NOT EXISTS (
    SELECT 1 
    FROM sys.databases 
    WHERE name = N'Shop'
)
BEGIN
    CREATE DATABASE [Shop];
END
GO

USE [Shop];
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.tables
    WHERE name = N'Categories'
)
BEGIN
    CREATE TABLE [dbo].[Categories]
    (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(100) NOT NULL UNIQUE,
        CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED(Id)
    );
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.tables
    WHERE name = N'Products'
)
BEGIN
    CREATE TABLE [dbo].[Products]
    (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(100) NOT NULL,
        [Price] DECIMAL(9, 2) NOT NULL,
        [CategoryId] INT NOT NULL,
        CONSTRAINT PK_Products PRIMARY KEY CLUSTERED(Id),
        CONSTRAINT FK_Products_Categories
            FOREIGN KEY(CategoryId)
            REFERENCES dbo.Categories(Id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION 
);
END
GO

INSERT [dbo].[Categories] ([Name]) VALUES (N'Laptops')
INSERT [dbo].[Categories] ([Name]) VALUES (N'Computers')
INSERT [dbo].[Categories] ([Name]) VALUES (N'Periphery')

INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) VALUES (N'ASUS ROG Spatha X', 10000, 3)
INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) VALUES (N'NULLASUS ROG Azoth Extreme', 25000, 3)
INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) VALUES (N'ASUS ProArt PA32UCX-PK', 100000, 3)
INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) VALUES (N'Fragmachine FIRE 9101', 150000, 2)
INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) VALUES (N'MSI CreatorPro X18 A14VMG-604RU', 200000, 1)