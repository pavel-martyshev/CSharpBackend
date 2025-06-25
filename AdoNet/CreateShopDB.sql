BEGIN
    CREATE DATABASE [Shop];
END
GO

USE [Shop];
GO

BEGIN
    CREATE TABLE [dbo].[Categories]
    (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(100) NOT NULL UNIQUE,
        CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (Id)
    );
END
GO

BEGIN
    CREATE TABLE [dbo].[Products]
    (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(100) NOT NULL,
        [Price] DECIMAL(9, 2) NOT NULL,
        [CategoryId] INT NOT NULL,
        CONSTRAINT PK_Products PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT FK_Products_Categories
            FOREIGN KEY (CategoryId)
            REFERENCES dbo.Categories(Id)
);
END
GO

INSERT INTO [dbo].[Categories] ([Name])
VALUES 
    (N'Laptops'),
    (N'Computers'),
    (N'Periphery');

INSERT [dbo].[Products] ([Name], [Price], [CategoryId]) 
VALUES 
    (N'ASUS ROG Spatha X', 10000, 3),
    (N'NULLASUS ROG Azoth Extreme', 25000, 3),
    (N'ASUS ProArt PA32UCX-PK', 100000, 3),
    (N'Fragmachine FIRE 9101', 150000, 2),
    (N'MSI CreatorPro X18 A14VMG-604RU', 200000, 1);