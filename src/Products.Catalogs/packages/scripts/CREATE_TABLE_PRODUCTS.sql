-- ProductCatalogDb.dbo.Products definition

-- Drop table

-- DROP TABLE ProductCatalogDb.dbo.Products;

CREATE TABLE Products (
	Id uniqueidentifier NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Description nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Price decimal(18,2) NOT NULL,
	StockQuantity int NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (Id)
);