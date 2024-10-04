IF DB_ID('ProductCatalogDb') IS NOT NULL
BEGIN
    ALTER DATABASE ProductCatalogDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ProductCatalogDb;
END;

CREATE DATABASE [ProductCatalogDb];

USE [ProductCatalogDb];

/*
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Products;
END
GO

CREATE TABLE [dbo].[Products] (
    Id uniqueidentifier NOT NULL,
    Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    Description nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    Price decimal(18,2) NOT NULL,
    StockQuantity int NOT NULL,
    CONSTRAINT PK_Products PRIMARY KEY (Id)
);
GO

CREATE TABLE [__EFMigrationsHistory] (
    MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);
GO

INSERT INTO [__EFMigrationsHistory] (MigrationId, ProductVersion) VALUES('20241003152751_InitialMigration', '8.0.8');
GO

INSERT INTO Products (Id, Name, Description, Price, StockQuantity) VALUES
('e7f5d5b7-cb8a-4b3b-8346-bd9f27a6f9bb', 'Laptop Gamer', 'Laptop com placa de vídeo dedicada e processador Intel i7', 4500.99, 25),
('c8a4b6fa-1b62-4fdc-82ea-afa9b054c792', 'Smartphone Pro Max', 'Smartphone com tela OLED e câmera de 108MP', 2999.49, 50),
('a2b33e9d-ecb1-4f9f-8a83-3f32bc7b67a7', 'Monitor UltraWide', 'Monitor de 34 polegadas UltraWide para produtividade', 1999.90, 15),
('f9e3a291-d029-4184-9a87-2bba2f237b8a', 'Teclado Mecânico', 'Teclado mecânico RGB com switches Cherry MX', 499.99, 120),
('b6d1a7d5-6f34-432e-8bfc-8e4f92068a21', 'Mouse Gamer', 'Mouse com sensor óptico de 16.000 DPI', 249.90, 80),
('d04af3e8-3d14-4e56-9a58-6559d5fc7e6e', 'Fone de Ouvido Bluetooth', 'Fone de ouvido com cancelamento de ruído ativo', 799.99, 60),
('fb3e762c-9173-4a94-bae2-bd8d65f04f59', 'SSD 1TB', 'SSD NVMe com velocidade de leitura de até 3500MB/s', 749.90, 100),
('ac57e2c3-88c4-4b7b-900e-9fd94d8344a3', 'Smartwatch', 'Relógio inteligente com monitoramento de atividades físicas', 899.90, 40),
('5c3a9e36-8d56-4c9e-8744-54ea7c9eae3a', 'Cadeira Gamer', 'Cadeira ergonômica com ajuste de altura e inclinação', 1299.99, 30),
('84b9b8a0-b83e-4041-9d9e-4b7de5f98b7a', 'Headset Gamer', 'Headset com som surround 7.1 e microfone removível', 349.90, 45);
GO

*/