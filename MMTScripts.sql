USE [MMTShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/11/2020 16:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/11/2020 16:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Product_Category_CategoryId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Product_Category_CategoryId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO

/****** Object:  Table [dbo].[FeaturedProductRange]    Script Date: 12/11/2020 16:42:43 ******/
CREATE TABLE [dbo].[FeaturedProductRange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SKUMin] [int] NOT NULL,
	[SKUMax] [int] NOT NULL,
 CONSTRAINT [PK_FeaturedProductRange] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO FeaturedProductRange(Skumin, Skumax) VALUES(10000, 19999);
INSERT INTO FeaturedProductRange(Skumin, Skumax) VALUES(20000, 29999);
INSERT INTO FeaturedProductRange(Skumin, Skumax) VALUES(30000, 39999);

GO

INSERT INTO Category(Name) VALUES('Home');
INSERT INTO Category(Name) VALUES('Garden');
INSERT INTO Category(Name) VALUES('Electronics');
INSERT INTO Category(Name) VALUES('Fitness');
INSERT INTO Category(Name) VALUES('Toys');

GO

INSERT INTO Product(Sku, Name, CategoryId, Price) VALUES(10000, 'Prod1', 1, 1);
INSERT INTO Product(Sku, Name, CategoryId, Price) VALUES(10001, 'Prod2', 1, 1);
INSERT INTO Product(Sku, Name, CategoryId, Price) VALUES(20000, 'Prod3', 2, 1);
INSERT INTO Product(Sku, Name, CategoryId, Price) VALUES(20001, 'Prod4', 2, 1);

GO

/****** Object:  StoredProcedure [dbo].[sp_GetFeaturedProducts]    Script Date: 12/11/2020 17:26:21 ******/
CREATE PROCEDURE [dbo].[sp_GetFeaturedProducts]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.* FROM Product p 
		Inner Join [FeaturedProductRange] fp ON
		p.Sku >= fp.Skumin AND p.Sku <= fp.Skumax
END
GO

CREATE PROCEDURE [dbo].[sp_GetProductsByCategory]
	@CategoryId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.* FROM Product p Where CategoryId = @CategoryId
END
GO

