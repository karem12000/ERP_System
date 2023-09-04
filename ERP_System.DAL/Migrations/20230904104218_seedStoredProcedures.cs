using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class seedStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// Schema And Data
			migrationBuilder.Sql(
				@"
                    /****** Object:  Schema [Guide]    Script Date: 9/4/2023 2:04:42 PM ******/
CREATE SCHEMA [Guide]
GO
/****** Object:  Schema [Page]    Script Date: 9/4/2023 2:04:42 PM ******/
CREATE SCHEMA [Page]
GO
/****** Object:  Schema [People]    Script Date: 9/4/2023 2:04:42 PM ******/
CREATE SCHEMA [People]
GO
/****** Object:  Schema [Report]    Script Date: 9/4/2023 2:04:42 PM ******/
CREATE SCHEMA [Report]
GO
/****** Object:  Schema [Setting]    Script Date: 9/4/2023 2:04:42 PM ******/
CREATE SCHEMA [Setting]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/4/2023 2:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Guide].[Attachments]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[Attachments](
	[ID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Path] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[InvoiceDetails]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[InvoiceDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[UnitName] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[ProductName] [nvarchar](max) NULL,
	[Qty] [decimal](18, 2) NULL,
	[SalePrice] [decimal](18, 2) NULL,
	[InvoiceId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[QtyPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[Invoices]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[Invoices](
	[ID] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[InvoiceType] [int] NULL,
	[Supplier] [nvarchar](max) NULL,
	[StockName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Buyer] [nvarchar](max) NULL,
	[StockId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[ItemGrpoups]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[ItemGrpoups](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ItemGrpoups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[Products]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[Products](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BarCodeText] [nvarchar](max) NULL,
	[BarCodePath] [nvarchar](max) NULL,
	[QtyInStock] [decimal](18, 2) NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[NameUnitOfQty] [nvarchar](max) NULL,
	[IdUnitOfQty] [uniqueidentifier] NULL,
	[ExpireDate] [datetime2](7) NULL,
	[GroupId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[ProductUnits]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[ProductUnits](
	[ID] [uniqueidentifier] NOT NULL,
	[ConversionFactor] [decimal](18, 2) NULL,
	[PurchasingPrice] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[UnitBarcodeText] [nvarchar](max) NULL,
	[UnitBarcodePath] [nvarchar](max) NULL,
	[ProductId] [uniqueidentifier] NULL,
	[UnitId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ProductUnits] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[PurchaseInvoiceDetails]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[PurchaseInvoiceDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[TotalQtyPrice] [decimal](18, 2) NULL,
	[PurchasingPrice] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NULL,
	[ProductBarCode] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[PurchaseInvoiceId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[ConversionFactor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseInvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[PurchaseInvoices]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[PurchaseInvoices](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NULL,
	[StockName] [nvarchar](max) NULL,
	[InvoiceNumber] [int] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[SupplierName] [nvarchar](max) NULL,
	[InvoiceTotalPrice] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[TransactionType] [int] NULL,
 CONSTRAINT [PK_PurchaseInvoices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[PurchaseThrowbackDetails]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[PurchaseThrowbackDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[ProductBarCode] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[ConversionFactor] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NULL,
	[PurchasingPrice] [decimal](18, 2) NULL,
	[TotalQtyPrice] [decimal](18, 2) NULL,
	[PurchaseThrowbackId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[PurchaseDetailId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PurchaseThrowbackDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[PurchaseThrowbacks]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[PurchaseThrowbacks](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NULL,
	[StockName] [nvarchar](max) NULL,
	[InvoiceNumber] [int] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[SupplierName] [nvarchar](max) NULL,
	[InvoiceTotalPrice] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[TransactionType] [int] NULL,
	[AddedTax] [decimal](18, 2) NULL,
	[PurchaseInvoiceDate] [datetime2](7) NULL,
	[PurchaseInvoiceId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PurchaseThrowbacks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[SaleInvoiceDetails]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[SaleInvoiceDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[TotalQtyPrice] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NULL,
	[ProductBarCode] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[SaleInvoiceId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[ConversionFactor] [decimal](18, 2) NULL,
	[ItemUnitPrice] [decimal](18, 2) NULL,
	[DiscountPProduct] [decimal](18, 2) NULL,
	[DiscountTypePProduct] [int] NULL,
 CONSTRAINT [PK_SaleInvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[SaleInvoices]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[SaleInvoices](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NULL,
	[StockName] [nvarchar](max) NULL,
	[InvoiceNumber] [int] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[Buyer] [nvarchar](max) NULL,
	[InvoiceTotalPrice] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[InvoiceTotalDiscount] [decimal](18, 2) NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[InvoiceTotalDiscountType] [int] NULL,
	[AddedTax] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SaleInvoices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[SaleThrowbackDetails]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[SaleThrowbackDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductBarCode] [nvarchar](max) NULL,
	[ProductId] [uniqueidentifier] NULL,
	[ProductName] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[ConversionFactor] [decimal](18, 2) NULL,
	[ItemUnitPrice] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[TotalQtyPrice] [decimal](18, 2) NULL,
	[SaleThrowbackId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[DiscountPProduct] [decimal](18, 2) NULL,
	[DiscountTypePProduct] [int] NULL,
	[SaleDetailId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_SaleThrowbackDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[SaleThrowbacks]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[SaleThrowbacks](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NULL,
	[StockName] [nvarchar](max) NULL,
	[InvoiceNumber] [int] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[Buyer] [nvarchar](max) NULL,
	[InvoiceTotalPrice] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[InvoiceTotalDiscount] [decimal](18, 2) NULL,
	[InvoiceTotalDiscountType] [int] NULL,
	[AddedTax] [decimal](18, 2) NULL,
	[SaleInvoiceId] [uniqueidentifier] NULL,
	[SaleInvoiceDate] [datetime2](7) NULL,
 CONSTRAINT [PK_SaleThrowbacks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[StockProducts]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[StockProducts](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_StockProducts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Guide].[Stocks]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[Stocks](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[ManagerName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[Units]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[Units](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[UserTypes]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[UserTypes](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Page].[ActionsPages]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Page].[ActionsPages](
	[ID] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[ActionName] [int] NOT NULL,
	[PageId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ActionsPages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Page].[Pages]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Page].[Pages](
	[ID] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[AreaName] [nvarchar](max) NULL,
	[OrderNo] [int] NULL,
	[IconName] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[IsArea] [bit] NOT NULL,
	[haveArea] [bit] NOT NULL,
	[CollapsedArea] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [People].[Clients]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [People].[Clients](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[companyName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProcessType] [int] NULL,
	[ProcessAmount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [People].[Suppliers]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [People].[Suppliers](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[companyName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProcessType] [int] NULL,
	[ProcessAmount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [People].[UserPermissions]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [People].[UserPermissions](
	[ID] [uniqueidentifier] NOT NULL,
	[PageActionId] [uniqueidentifier] NULL,
	[UserTypeId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [People].[Users]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [People].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[UserImage] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[UseDefaultPassword] [bit] NOT NULL,
	[ResetPasswordDate] [datetime2](7) NULL,
	[CodeOfReset] [nvarchar](max) NULL,
	[UserClassification] [int] NULL,
	[ScreenId] [uniqueidentifier] NULL,
	[Salt] [nvarchar](max) NULL,
	[UserTypeId] [uniqueidentifier] NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[DiscountPermission] [bit] NOT NULL,
	[SalePriceEdit] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [People].[UserStocks]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [People].[UserStocks](
	[ID] [uniqueidentifier] NOT NULL,
	[StockId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserStocks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setting].[Settings]    Script Date: 9/4/2023 2:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setting].[Settings](
	[ID] [uniqueidentifier] NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[CompanyImage] [nvarchar](max) NULL,
	[SiteName] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyPhone] [nvarchar](max) NULL,
	[CompanyAddress] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AddedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230610134212_initDb', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230610134258_insertData', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230611140523_InvoicesTbl', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230611141645_InvoicesTables', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230612231711_EditPurchaseTbl', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230614162352_SaleInvoiceTbl', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230614170538_EditPurchaseInvoiceTbl', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230614201234_addThrowbackTables', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618222243_UpdatePInvoice', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618225638_UpdateDiscountInvoice', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618230857_AddTotalPaid', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620231210_addPaidTpPurchase', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620231422_addPaidTpPurchaseThrowback', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230705082451_addPermissionToUser', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706101718_updateSaleInvoice', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706134628_addedTax', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707163647_emptyMigration', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230708002322_saleDetailId', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230708110554_AddPurchaseDetailId', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230711065539_addHaveArea', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230711065847_addCollapsedArea', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230725072649_SalePriceEditPermission', N'5.0.13')
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', N'أدمن', 2, CAST(N'2023-06-10T01:49:43.4233333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', N'مدير النظام', 1, CAST(N'2023-05-29T13:32:04.3970000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', N'كاشير', 4, CAST(N'2023-06-10T01:29:36.8133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a21009fb-d118-4727-bb2f-4b0e5e558714', N'مستخدم', 3, CAST(N'2023-06-10T01:30:22.8066667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8484e624-c5a0-463e-986a-66a118d1f2eb', N'العملاء', 5, CAST(N'2023-05-29T13:33:05.2100000' AS DateTime2), NULL, NULL, NULL, 1, 1, NULL, NULL)
GO
INSERT [Guide].[UserTypes] ([ID], [Name], [Type], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'df5d2d3c-655a-431e-93a3-ac4af07c8805', N'الموردين', 6, CAST(N'2023-05-29T13:33:26.6000000' AS DateTime2), NULL, NULL, NULL, 1, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12', N'اضافة', 1, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:25:35.4500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f0a7b823-ecc4-4090-836f-10efc82aafe1', N'تعديل', 2, N'680e0745-ba76-4180-bc58-21247c7d10b5', CAST(N'2023-06-03T13:33:01.3300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e5525d49-0ffc-430a-a384-10f69dff488c', N'العرض', 4, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9030000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'54ee0ca0-90b1-4fc8-9b96-1250bf732248', N'حذف', 3, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6d518792-e233-4afc-9b7e-13829ccdd81d', N'العرض', 4, N'06bd0f47-1f95-44bb-bb2f-50c24a487fa9', CAST(N'2023-07-25T12:36:51.4733333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'cdaf62fa-2e6f-40b8-8c66-1ce4cd491987', N'تعديل', 2, N'75cd0ab2-7004-4dea-842b-15228d704f68', CAST(N'2023-06-03T13:32:25.6133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'تعديل', 2, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e658ffdd-4304-4ebf-8f7f-2417f8204c33', N'تعديل', 2, N'3d407090-4739-438e-b302-c41c4b23cb60', CAST(N'2023-06-14T23:15:33.5933333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'377674bd-a7fe-4fa4-b6fe-301fd199115a', N'تعديل', 2, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9170000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b9d583d8-fab7-462c-bfda-31fe10ad84dc', N'مرتجع شراء', 5, N'680e0745-ba76-4180-bc58-21247c7d10b5', CAST(N'2023-06-11T11:43:38.1500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'552fd52b-f1b1-47b7-847a-37e57a86bd58', N'العرض', 4, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1530000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2541811c-4fc2-49e4-93dd-381ed129f8e4', N'العرض', 4, N'680e0745-ba76-4180-bc58-21247c7d10b5', CAST(N'2023-06-03T13:33:01.3200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'207672c0-0214-4b87-a2ea-3849695685d0', N'تعديل', 2, N'428474bc-78dd-4d51-b514-ac33b3bd4119', CAST(N'2023-06-03T13:34:13.1300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ab5a5c01-426e-4a80-87a8-43274db628d2', N'اضافة', 1, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1630000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'238d4d11-ad63-4659-ba5f-4da19db65dcf', N'تعديل', 2, N'06bd0f47-1f95-44bb-bb2f-50c24a487fa9', CAST(N'2023-07-25T12:36:51.4866667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6c62dc6b-7e88-4046-9bfa-52c8463e384c', N'اضافة', 1, N'75cd0ab2-7004-4dea-842b-15228d704f68', CAST(N'2023-06-03T13:32:25.6100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'43ae699a-55f6-43ca-aaa1-53c3e4956792', N'اضافة', 1, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0ef9be5c-a720-4f28-9318-5d9bb8f9143a', N'اضافة', 1, N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', CAST(N'2023-06-03T13:33:33.0166667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'7707e574-0079-4bec-9a6e-610fb48f6fd9', N'العرض', 4, N'428474bc-78dd-4d51-b514-ac33b3bd4119', CAST(N'2023-06-03T13:34:13.1133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0038da23-2868-46f8-928b-644af455dd1c', N'تعديل', 2, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7530000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'اضافة', 1, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'15899858-d17c-40e4-aa4d-6df48d9b2891', N'حذف', 3, N'f4fed4ee-b244-4132-a811-62c205ea0b92', CAST(N'2023-06-14T23:14:59.2833333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'66a37477-5024-4750-b4ae-7190088091af', N'تعديل', 2, N'f4fed4ee-b244-4132-a811-62c205ea0b92', CAST(N'2023-06-14T23:14:59.2800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9b2e31d5-9177-405f-9776-76e7f6a48be0', N'حذف', 3, N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', CAST(N'2023-06-03T13:33:33.0300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'496a3e67-9a96-4e8b-9965-76ed20b62968', N'تعديل', 2, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd617a98a-430f-4ef1-aa44-795cd2b92674', N'العرض', 4, N'3d407090-4739-438e-b302-c41c4b23cb60', CAST(N'2023-06-14T23:15:33.5800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'feec286c-0026-4cf1-911f-7e86eb0b4384', N'حذف', 3, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b541519d-5391-4ece-bc2a-80320424ec0e', N'العرض', 4, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8a6861e7-52a3-4473-be9d-80831f456db0', N'حذف', 3, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6330000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'182e5b2e-773e-41e8-b8fe-88fcffaadcff', N'العرض', 4, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:26:19.7930000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f25bc116-cf01-41e7-879f-8a775abd2888', N'حذف', 3, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.7000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'46685805-a92c-4c6f-b02f-8f3851f9965d', N'حذف', 3, N'3d407090-4739-438e-b302-c41c4b23cb60', CAST(N'2023-06-14T23:15:33.5966667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a', N'اضافة', 1, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9170000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2e5c1cab-1215-4261-b0d7-992b83ac7373', N'العرض', 4, N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', CAST(N'2023-06-03T13:33:33.0133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'951ef6a4-ece0-42cf-a73b-9961f5f40b39', N'العرض', 4, N'f4fed4ee-b244-4132-a811-62c205ea0b92', CAST(N'2023-06-14T23:14:59.2633333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'081c16ba-c791-4152-b688-9c5f4a08864f', N'تعديل', 2, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'fa6e9967-cb80-4239-acd5-9d2d47a26b97', N'اضافة', 1, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'54120a72-aa08-4860-b385-9edb22911825', N'اضافة', 1, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6ab69860-e185-47fb-9ddb-a0614f83b6ab', N'حذف', 3, N'428474bc-78dd-4d51-b514-ac33b3bd4119', CAST(N'2023-06-03T13:34:13.1300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1a665a41-ed24-407c-99db-a1ee56333115', N'حذف', 3, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:26:54.6370000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'be40c11e-4383-4815-9d9d-a49694700579', N'حذف', 3, N'06bd0f47-1f95-44bb-bb2f-50c24a487fa9', CAST(N'2023-07-25T12:36:51.4900000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f635961a-1a75-4878-a1dd-a4c1130845cf', N'تعديل', 2, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0970000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'beff4b50-05c8-4695-857b-a527f8d959d7', N'العرض', 4, N'b861c3dc-e415-43ba-9394-b37fd0e6f328', CAST(N'2023-06-09T17:25:14.9666667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4147c899-0151-41a6-9f96-a537373478bd', N'تعديل', 2, N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', CAST(N'2023-06-03T13:33:33.0200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd8689322-b954-4522-a49c-a6593b15494e', N'تعديل', 2, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:27:38.5400000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'679ca60f-fc09-4c17-9d42-aa2eb7384b51', N'اضافة', 1, N'b861c3dc-e415-43ba-9394-b37fd0e6f328', CAST(N'2023-06-09T17:25:14.9700000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'039c5787-abe1-4e36-b1d6-b306068a4908', N'مرتجع بيع', 6, N'428474bc-78dd-4d51-b514-ac33b3bd4119', CAST(N'2023-06-11T11:43:38.1700000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2e2a39a5-7dd5-4adc-ac98-bc42241f0499', N'حذف', 3, N'680e0745-ba76-4180-bc58-21247c7d10b5', CAST(N'2023-06-03T13:33:01.3333333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1e806797-6966-4603-93a4-bd378ea2dfe5', N'اضافة', 1, N'428474bc-78dd-4d51-b514-ac33b3bd4119', CAST(N'2023-06-03T13:34:13.1166667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'اضافة', 1, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6933333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'625a38e3-b3ec-4ead-8353-bebbadada3fc', N'حذف', 3, N'b861c3dc-e415-43ba-9394-b37fd0e6f328', CAST(N'2023-06-09T17:25:14.9833333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5ab23973-1cbf-451e-b54d-bfd63f102b03', N'اضافة', 1, N'3d407090-4739-438e-b302-c41c4b23cb60', CAST(N'2023-06-14T23:15:33.5900000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e86f4243-42b2-4e78-88bc-c511e3203e41', N'تعديل', 2, N'b861c3dc-e415-43ba-9394-b37fd0e6f328', CAST(N'2023-06-09T17:25:14.9733333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f7de7da4-e434-4121-b0ac-ce3f59a43cad', N'اضافة', 1, N'680e0745-ba76-4180-bc58-21247c7d10b5', CAST(N'2023-06-03T13:33:01.3300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'7783238a-6dac-4c7d-9e49-d0f28f335ab7', N'العرض', 4, N'75cd0ab2-7004-4dea-842b-15228d704f68', CAST(N'2023-06-03T13:32:25.6033333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'تعديل', 2, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6966667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0a4d6779-fb6d-4221-b20c-db7425390b78', N'حذف', 3, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'العرض', 4, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6833333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5bd9a512-2c0c-43a2-83d0-df627f797c7d', N'العرض', 4, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0770000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'81481927-e5a6-4148-aa98-e444563644c6', N'اضافة', 1, N'06bd0f47-1f95-44bb-bb2f-50c24a487fa9', CAST(N'2023-07-25T12:36:51.4800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1be47aca-5471-4af9-aa4d-e8202375af43', N'العرض', 4, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'حذف', 3, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'648515d6-20d8-4507-95e0-ef863b45926e', N'اضافة', 1, N'f4fed4ee-b244-4132-a811-62c205ea0b92', CAST(N'2023-06-14T23:14:59.2766667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd2011900-b929-4243-b4ca-f36575c54d8f', N'حذف', 3, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.1000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'العرض', 4, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:14.8670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[ActionsPages] ([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1e47184e-ad94-4629-a093-fe13895578bf', N'حذف', 3, N'75cd0ab2-7004-4dea-842b-15228d704f68', CAST(N'2023-06-03T13:32:25.6133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', N'المخازن', N'Guide', 2, N'fas fa-store', N'Stock', CAST(N'2023-05-31T01:30:53.5800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'75cd0ab2-7004-4dea-842b-15228d704f68', N'المنتجات', N'Guide', 7, N'fas fa-th-large', N'Product', CAST(N'2023-05-29T13:36:50.7930000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'680e0745-ba76-4180-bc58-21247c7d10b5', N'المشتريات', N'Guide', 10, N'fas fa-cart-arrow-down', N'PurchaseInvoice', CAST(N'2023-05-29T13:37:37.3600000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'78a3d3b4-58b8-4feb-b1a6-28ccdb6d9f02', N'الإعدادات العامة', N'GeneralSettings', 15, N'fas fa-cogs', N'GeneralSettings', CAST(N'2023-07-11T10:04:35.9366667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 1, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'b1ae3420-c251-4768-8d67-3c7b080826d8', N'صلاحيات المستخدمين', N'People', 13, N'fas fa-user-shield', N'Permissions', CAST(N'2023-06-02T13:38:37.7766667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'GeneralSettings')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'06bd0f47-1f95-44bb-bb2f-50c24a487fa9', N'أسعار المنتجات', N'Guide', 8, N'fas fa-th-large', N'ProductPrice', CAST(N'2023-07-25T12:29:43.3366667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'f4fed4ee-b244-4132-a811-62c205ea0b92', N'مرتجع المشتريات', N'Guide', 11, N'fas fa-exchange-alt', N'PurchaseThrowback', CAST(N'2023-06-14T23:12:54.4133333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', N'التقارير', N'Report', 12, N'fas fa-chart-bar', N'Report', CAST(N'2023-05-29T13:38:15.2570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', N'الموردين', N'People', 4, N'fas fa-sitemap', N'Supplier', CAST(N'2023-05-29T13:39:10.6500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', N'العملاء', N'People', 3, N'fas fa-id-card-alt', N'Client', CAST(N'2023-05-29T14:20:29.2900000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'54eb4de9-3354-4ab1-ab1a-84b093d30214', N'الوحدات', N'Guide', 5, N'fas fa-balance-scale', N'Unit', CAST(N'2023-05-31T12:18:47.8430000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', N'الإعدادات', N'Setting', 14, N'fas fa-cogs', N'SiteSetting', CAST(N'2023-05-29T14:22:28.1000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'GeneralSettings')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'428474bc-78dd-4d51-b514-ac33b3bd4119', N'المبيعات', N'Guide', 8, N'fas fa-paper-plane', N'SaleInvoice', CAST(N'2023-05-29T14:23:02.9000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'b861c3dc-e415-43ba-9394-b37fd0e6f328', N'الرئيسية', N'Home', 1, N'bi bi-grid-fill', N'Home', CAST(N'2023-06-09T17:23:52.5733333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'df0c5afd-926f-4b8b-88dc-b4dda73b8f51', N'الصفحات الرئيسية', N'HomePages', 1, N'bi bi-grid-1x2-fill', N'HomePages', CAST(N'2023-07-12T11:01:13.3366667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 1, 0, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'3d407090-4739-438e-b302-c41c4b23cb60', N'مرتجع المبيعات', N'Guide', 9, N'fas fa-exchange-alt', N'SaleThrowback', CAST(N'2023-06-14T23:12:21.9500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 0, NULL)
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'2d7535b1-9e0a-4f8c-892b-d028ed989613', N'المجموعات', N'Guide', 6, N'fas fa-layer-group', N'ItemGrpoup', CAST(N'2023-05-29T14:21:10.9100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'HomePages')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', N'المستخدمين', N'People', 11, N'fas fa-sharp fa-solid fa-users', N'User', CAST(N'2023-05-29T14:21:53.6100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 0, 1, N'GeneralSettings')
GO
INSERT [Page].[Pages] ([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [IsArea], [haveArea], [CollapsedArea]) VALUES (N'4ae76a8b-c6f9-475b-87b9-f4c7a12ae65b', N'التقارير', N'AllReports', 12, N'fas fa-chart-bar', N'AllReports', CAST(N'2023-07-16T11:46:35.9766667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 1, 0, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'22f42400-caa3-43ac-b99e-026c52816cc0', N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4468067' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4466d663-11b7-46e8-8086-026fb58cc379', N'f635961a-1a75-4878-a1dd-a4c1130845cf', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2920199' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a4da8c45-fe56-4df0-9c98-05851733128f', N'6ab69860-e185-47fb-9ddb-a0614f83b6ab', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-05T18:55:22.0166705' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9be0523f-80f3-4b73-ac27-077b34188379', N'648515d6-20d8-4507-95e0-ef863b45926e', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4954011' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'08f7c882-4995-413c-90e1-084898f38119', N'43ae699a-55f6-43ca-aaa1-53c3e4956792', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2673710' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e9b2be58-d8bb-41fc-92c2-08fb9f1bd648', N'be40c11e-4383-4815-9d9d-a49694700579', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-07-25T11:44:00.7456115' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'648f9702-3f07-468e-a105-096e99043ba7', N'15899858-d17c-40e4-aa4d-6df48d9b2891', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6602736' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c9ada347-0bfa-4390-8237-0b04c980aeb3', N'1be47aca-5471-4af9-aa4d-e8202375af43', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9218796' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4f69c515-8406-460b-bcab-0b14a152a178', N'15899858-d17c-40e4-aa4d-6df48d9b2891', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6162220' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f010e8ec-e415-476e-ac6e-0c876fcdefa2', N'e658ffdd-4304-4ebf-8f7f-2417f8204c33', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6425781' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5fa48470-0d4b-4e90-859a-0d7eaccf56a0', N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1731741' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1a14d468-bfd9-4537-b253-0dd145d46c69', N'625a38e3-b3ec-4ead-8353-bebbadada3fc', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4398509' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd5d138b8-7274-4559-bb9e-13b72dcfe3b8', N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4595551' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b6b49373-442f-4eb2-8c93-14cc769936b0', N'8a6861e7-52a3-4473-be9d-80831f456db0', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:29:49.3966275' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a8133cb1-b4f6-473d-9f2f-157138dcecae', N'1a665a41-ed24-407c-99db-a1ee56333115', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4693702' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'86f77dbe-d725-4f1c-aec2-1659a61dbc46', N'1be47aca-5471-4af9-aa4d-e8202375af43', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5189553' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b1fbc87a-07fe-4bd9-97ff-16a8d150faa7', N'648515d6-20d8-4507-95e0-ef863b45926e', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6550859' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3c4f4241-f8f4-412f-a59e-16d7b41f9c2a', N'feec286c-0026-4cf1-911f-7e86eb0b4384', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5045314' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3f16bc35-0f96-4a26-b911-1750b85ca770', N'377674bd-a7fe-4fa4-b6fe-301fd199115a', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8181875' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b31cb6bd-f2a0-41f4-afe6-19f2e6ef0913', N'8a6861e7-52a3-4473-be9d-80831f456db0', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5217599' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'bc00f1db-06de-440c-aff4-1a50c94dfd35', N'7783238a-6dac-4c7d-9e49-d0f28f335ab7', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:19:57.8948280' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'79772022-4f47-4675-b251-1a7456d209c4', N'f7de7da4-e434-4121-b0ac-ce3f59a43cad', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4884094' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'afc12323-9fdf-4b2e-9e60-1bc6ffce87a8', N'7783238a-6dac-4c7d-9e49-d0f28f335ab7', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4720061' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0e587fcf-63c4-4418-b2db-1e8022df8b77', N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9242647' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e5114bc3-38ae-49d0-9803-1f5b54bb2cd5', N'b541519d-5391-4ece-bc2a-80320424ec0e', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5017844' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd59d8491-3738-4661-b4d2-26106eb9bdbe', N'081c16ba-c791-4152-b688-9c5f4a08864f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7456700' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'11fb31aa-055a-4445-bdd3-29425edcbd5d', N'f7de7da4-e434-4121-b0ac-ce3f59a43cad', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6049385' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ac3ced8a-73a2-4d4c-a01f-2b1a2e7802c6', N'1a665a41-ed24-407c-99db-a1ee56333115', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5894483' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3fa969dd-2bed-47bc-959c-2b8a6c87de34', N'fa6e9967-cb80-4239-acd5-9d2d47a26b97', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2502363' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6932536a-d1b4-4eb5-9a4e-2ba1f27a9fc0', N'f0a7b823-ecc4-4090-836f-10efc82aafe1', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7581561' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4a4fe650-5f78-40ca-afb5-2ccc9adb3c7f', N'2541811c-4fc2-49e4-93dd-381ed129f8e4', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6063852' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'deb7222b-57ad-420c-84a6-2df530f6e5c2', N'15899858-d17c-40e4-aa4d-6df48d9b2891', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4992728' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1b4fb8c9-e8ef-47c1-b198-2fa5779519e3', N'0038da23-2868-46f8-928b-644af455dd1c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2751996' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'45a85051-7433-40b0-a165-2fca1d3c557b', N'd2011900-b929-4243-b4ca-f36575c54d8f', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4521036' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'33a645ee-ec17-416c-a27d-2fff84a55924', N'1be47aca-5471-4af9-aa4d-e8202375af43', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:29:49.3941689' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'77f16bf3-ef76-4763-94c8-3206c70d35d3', N'd2011900-b929-4243-b4ca-f36575c54d8f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2934465' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8e98cdbb-a24a-4f4c-9ff6-36974e541fc4', N'e86f4243-42b2-4e78-88bc-c511e3203e41', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4383912' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a904134d-5c89-405c-baef-3868a8dc4565', N'0038da23-2868-46f8-928b-644af455dd1c', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4455161' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5358a240-c5a9-46c3-a7d7-3903a74af098', N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5204310' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'51c39cdd-72fc-43cf-b3b6-3949625b53ac', N'7707e574-0079-4bec-9a6e-610fb48f6fd9', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-05T18:55:22.0142336' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'23c47732-dadb-4329-a9c9-3a84ce57f575', N'6c62dc6b-7e88-4046-9bfa-52c8463e384c', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:19:57.8791883' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a42354b4-873e-4e28-a391-3b4a9c61558d', N'5bd9a512-2c0c-43a2-83d0-df627f797c7d', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4495980' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3f9b9db0-d33a-425b-8e80-3ba6cefd13cd', N'5ab23973-1cbf-451e-b54d-bfd63f102b03', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4826813' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ccc6936e-3f52-4e09-92f8-3bdf87776724', N'f0a7b823-ecc4-4090-836f-10efc82aafe1', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4926456' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'43282ba0-ac35-41b8-8681-3ebec4515caa', N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:16:07.5336155' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a32ce03d-ee13-43f1-bede-40262ab8f180', N'2e2a39a5-7dd5-4adc-ac98-bc42241f0499', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7595398' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'25cf7ae7-0149-4a42-8125-405a896ce2d1', N'f25bc116-cf01-41e7-879f-8a775abd2888', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1748929' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f7ea9ec4-f033-417e-90a1-40cb0cfb9694', N'951ef6a4-ece0-42cf-a73b-9961f5f40b39', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4966651' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b06d01f2-4444-4d35-9688-4137ee18058a', N'7707e574-0079-4bec-9a6e-610fb48f6fd9', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4785425' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'97fde137-53fb-4000-a2c9-41b4d30066a8', N'0ef9be5c-a720-4f28-9318-5d9bb8f9143a', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7804001' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e883a79f-69fd-4792-a5e1-4250bdc52f04', N'f25bc116-cf01-41e7-879f-8a775abd2888', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5160049' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd9cd0c76-9a54-4aac-9f58-443d9f510aee', N'beff4b50-05c8-4695-857b-a527f8d959d7', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4369632' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6c49d7df-b564-40b5-a4eb-454bcb31bae0', N'6c62dc6b-7e88-4046-9bfa-52c8463e384c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7268848' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0e1b320a-8706-4654-b388-46a4626250af', N'679ca60f-fc09-4c17-9d42-aa2eb7384b51', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4347284' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3c0a1232-dc22-4313-ba66-46dcda38b09e', N'496a3e67-9a96-4e8b-9965-76ed20b62968', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2685248' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'61ae2e31-c9bb-41f0-8067-48cea960065f', N'fa6e9967-cb80-4239-acd5-9d2d47a26b97', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5005112' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'db58c21a-0a38-43ef-ba4a-4aa2b39abb87', N'7707e574-0079-4bec-9a6e-610fb48f6fd9', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7753637' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'88c62be2-570b-4a30-947a-4b775f692c4c', N'0038da23-2868-46f8-928b-644af455dd1c', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:16:07.5577541' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'383d773e-0180-4b09-b17c-4c3d4091a7ec', N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:16:07.5591004' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4255bead-3870-499a-8a36-4d15b63794e4', N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4654494' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6de6fb08-bdc9-479a-aafa-4daab7c1b431', N'e86f4243-42b2-4e78-88bc-c511e3203e41', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-10T01:43:31.8087215' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5d80426c-566c-403d-85b8-4de021654ab8', N'b9d583d8-fab7-462c-bfda-31fe10ad84dc', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-11T12:57:09.9191861' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8942e410-6d9d-48b0-ae0a-506a3545b828', N'be40c11e-4383-4815-9d9d-a49694700579', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-07-25T11:37:01.5458864' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c50a6b28-21fd-4e6c-9ed8-5081b475fa6f', N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1714565' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1d4320f6-788a-40d1-ad0f-5163fab7f84a', N'2e5c1cab-1215-4261-b0d7-992b83ac7373', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7822955' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8fadcaee-eb43-4018-9059-541c32212474', N'0a4d6779-fb6d-4221-b20c-db7425390b78', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8197430' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1ceee8ed-fb19-4c98-ad99-54e024c37eb1', N'4147c899-0151-41a6-9f96-a537373478bd', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-09-04T12:58:12.8655025' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4ee58a1e-7d1c-4f1c-b4a1-565ca8155857', N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:30:23.3855055' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ec3d61f4-1aba-4593-995a-5790cab0f1e0', N'496a3e67-9a96-4e8b-9965-76ed20b62968', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5032691' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1e7243fd-5e47-476b-bd33-57d4b2116234', N'ab5a5c01-426e-4a80-87a8-43274db628d2', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4533103' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'74af7020-da03-4686-908e-58b4916fa7fb', N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:30:23.3817941' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f375c69a-b3a6-4f77-b37b-58df7c24b647', N'43ae699a-55f6-43ca-aaa1-53c3e4956792', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4481033' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6f58937c-fa4f-46a3-afa8-596e77859add', N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:29:49.3954167' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'33565762-eb30-42dd-aaeb-5b6c8759dc8d', N'951ef6a4-ece0-42cf-a73b-9961f5f40b39', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6567614' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e7253ce1-4a99-48ea-bdeb-5bab555fb1bd', N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5848196' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'886cb977-446e-4e22-a14b-5e2395bfeb86', N'66a37477-5024-4750-b4ae-7190088091af', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4980059' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3d1634dc-9621-4b47-a256-5ed93e2519ce', N'1e47184e-ad94-4629-a093-fe13895578bf', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4758984' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f26ea33a-f8eb-483b-a3de-605233c8c88a', N'1e47184e-ad94-4629-a093-fe13895578bf', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7481723' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c2e6dfc0-20b1-444a-b63a-613ebc6b53f3', N'6c62dc6b-7e88-4046-9bfa-52c8463e384c', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4706463' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'eef79a57-e1a1-4b9f-b325-61b8f9f31637', N'2e2a39a5-7dd5-4adc-ac98-bc42241f0499', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4941235' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd0f804b8-2f3f-4bfb-8b63-641c2b41297d', N'be40c11e-4383-4815-9d9d-a49694700579', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-25T11:37:43.6972074' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a7664c61-1304-476c-887b-652022b08ec1', N'd8689322-b954-4522-a49c-a6593b15494e', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5880417' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'48bcd964-fa52-416a-adb3-66bc77b08082', N'1e806797-6966-4603-93a4-bd378ea2dfe5', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4772546' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'613c439a-7c01-4a3a-8fc2-68586d7dccee', N'81481927-e5a6-4148-aa98-e444563644c6', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-25T11:37:43.6933819' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'cdd2065f-3cd3-4cc7-bda6-69d7b1ae2328', N'1e806797-6966-4603-93a4-bd378ea2dfe5', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-05T18:55:22.0130422' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9a06851a-c36b-4aef-80f5-6a00755b2f3b', N'54ee0ca0-90b1-4fc8-9b96-1250bf732248', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7473353' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'10ef91ff-ed51-440a-9a7d-6b4e513c49a0', N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.7983742' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3dff466c-34eb-4b7a-8e3b-729cb6e14849', N'54ee0ca0-90b1-4fc8-9b96-1250bf732248', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4572165' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6bb5bac4-dd0c-4deb-9970-753aea35480f', N'e658ffdd-4304-4ebf-8f7f-2417f8204c33', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4854205' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9c7ceaed-de91-4693-997c-75b15055990b', N'1e806797-6966-4603-93a4-bd378ea2dfe5', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7736641' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'37f9fa61-f113-4e2d-a670-76b5a577b573', N'207672c0-0214-4b87-a2ea-3849695685d0', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4798388' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'cf8ebed4-657c-4c18-af89-78698ca88bbd', N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1530205' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'4b6ab653-290b-4177-9765-7ad40f57be9f', N'679ca60f-fc09-4c17-9d42-aa2eb7384b51', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-10T01:43:31.7934534' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd2b6a092-b488-4d13-a97a-7b0135cf0569', N'9b2e31d5-9177-405f-9776-76e7f6a48be0', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7856515' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'aa1bc561-1b9a-45ef-8113-84c77246a204', N'6ab69860-e185-47fb-9ddb-a0614f83b6ab', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7787488' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd570cd54-2ad3-49a1-a914-851e2f68fe5c', N'6d518792-e233-4afc-9b7e-13829ccdd81d', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-07-25T11:37:01.5417315' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f8ce8434-93eb-4f91-93ac-880cd1a293f9', N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:30:23.3835652' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1b9faf50-19e9-44ad-ac08-88a891c20cb5', N'552fd52b-f1b1-47b7-847a-37e57a86bd58', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4544322' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'7aab8ce4-65e7-4e8d-bf58-8bf9ebc03c84', N'5ab23973-1cbf-451e-b54d-bfd63f102b03', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6204178' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1a0fc7eb-63bc-42e8-bd92-8ea362ee6f84', N'625a38e3-b3ec-4ead-8353-bebbadada3fc', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-10T01:43:31.8103018' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a8c62b7a-9173-44ce-ba1a-8f16f77d29b7', N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:16:07.5559714' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'db2a3010-5482-4fca-9d92-8f8b5925964b', N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5120310' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'24ca7b4f-e332-4e67-8a2a-8fad23631026', N'66a37477-5024-4750-b4ae-7190088091af', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6584958' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'09b777c3-f706-4776-9ec8-91e04989fcd1', N'd8689322-b954-4522-a49c-a6593b15494e', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4680543' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3c83794e-9fa4-48d8-a195-923fc5043aac', N'207672c0-0214-4b87-a2ea-3849695685d0', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7770538' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f416c662-16be-4bad-8560-97ecbe8e0b7f', N'46685805-a92c-4c6f-b02f-8f3851f9965d', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6440356' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'fc63b889-0534-44c8-a074-98d2c50392ef', N'2e2a39a5-7dd5-4adc-ac98-bc42241f0499', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6108235' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'33531247-1620-4e05-aaaf-99c2b7112796', N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4442164' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f708b410-9cab-42e6-9e8d-9c115b18a29a', N'182e5b2e-773e-41e8-b8fe-88fcffaadcff', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:09.9339934' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'fc2ab65b-05c0-4cd6-8c38-9d7c240a8526', N'238d4d11-ad63-4659-ba5f-4da19db65dcf', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-25T11:37:43.6959115' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'41e8f390-26ee-4daa-acf1-9dc9c4b376bb', N'8a6861e7-52a3-4473-be9d-80831f456db0', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9260858' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'67103d09-0717-4848-9ed1-9feb6e341d42', N'552fd52b-f1b1-47b7-847a-37e57a86bd58', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7437437' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'5eb01507-95b3-4a9d-8ddd-a0071e625404', N'2541811c-4fc2-49e4-93dd-381ed129f8e4', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4900743' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'90053ab5-1a2b-457a-8f7a-a111ab949e6e', N'54120a72-aa08-4860-b385-9edb22911825', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:29:49.3839208' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2242e0af-a0d6-404c-b2a1-a4508c96bbf8', N'b541519d-5391-4ece-bc2a-80320424ec0e', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2667159' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'7668ef0e-387e-4013-8920-a48d6e74ceec', N'f25bc116-cf01-41e7-879f-8a775abd2888', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-14T14:30:23.3869429' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9cc02c3b-db73-422d-a80d-a7b64dba9ff9', N'54120a72-aa08-4860-b385-9edb22911825', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.8992901' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a84739f4-4b6e-4883-93d2-a7e422c67a74', N'039c5787-abe1-4e36-b1d6-b306068a4908', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-11T12:57:09.8917155' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2de4d6d4-5a39-43e7-a3ae-ac13fd7ed161', N'46685805-a92c-4c6f-b02f-8f3851f9965d', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6035697' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a515b5b6-daad-4a62-9f54-af27f6febfee', N'4147c899-0151-41a6-9f96-a537373478bd', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7840291' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'dd2717b0-567b-4164-b321-af56115a2055', N'648515d6-20d8-4507-95e0-ef863b45926e', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6120305' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2dedd6e2-82e1-4fe4-be7c-afd5e429b44a', N'cdaf62fa-2e6f-40b8-8c66-1ce4cd491987', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7465264' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'b6f0528d-0357-4021-a8f1-b2a8b108523a', N'0a4d6779-fb6d-4221-b20c-db7425390b78', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4639321' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'03b96957-8d76-485b-a007-bab6024aec34', N'951ef6a4-ece0-42cf-a73b-9961f5f40b39', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6132391' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c78195c1-5271-41fb-a898-bb4adf9d3087', N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5147761' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'567c8556-96b4-4665-a8e4-bbe37e59e0c9', N'7783238a-6dac-4c7d-9e49-d0f28f335ab7', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7448658' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'8072ca63-c92b-4fc3-9a6f-bc3e08b8d6ca', N'f635961a-1a75-4878-a1dd-a4c1130845cf', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4508173' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0671ccf2-f01f-4c09-a3bf-bc5dea8d4c1f', N'81481927-e5a6-4148-aa98-e444563644c6', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-07-25T11:37:01.5321131' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1414af28-ebb7-4640-a57e-bd3da5ff32ca', N'377674bd-a7fe-4fa4-b6fe-301fd199115a', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4625977' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a50a8448-cddf-416a-8953-bee764cf2838', N'e5525d49-0ffc-430a-a384-10f69dff488c', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4611172' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c715dee0-fb02-4812-b326-bf20bdaa5df4', N'f7de7da4-e434-4121-b0ac-ce3f59a43cad', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7554252' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9088ceb0-5306-4b7f-8133-bfb1cee05bc9', N'6d518792-e233-4afc-9b7e-13829ccdd81d', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-25T11:37:43.6947894' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'02e832e0-471a-446c-b117-c0d17cd4aa8f', N'2541811c-4fc2-49e4-93dd-381ed129f8e4', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-03T13:34:46.7568142' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'59dbaee3-c049-4717-a366-c1a041343b08', N'238d4d11-ad63-4659-ba5f-4da19db65dcf', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-07-25T11:37:01.5444364' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ffb03e1b-1050-4b1a-8a0f-c237b4e93d5d', N'9b2e31d5-9177-405f-9776-76e7f6a48be0', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-09-04T12:58:12.8669083' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1e9e8828-03c0-4ef6-81ee-c4cc5096f999', N'81481927-e5a6-4148-aa98-e444563644c6', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-07-25T11:44:00.7283522' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd69fd83c-cc83-4253-a038-c4d3b73291e6', N'd617a98a-430f-4ef1-aa44-795cd2b92674', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-14T23:16:08.6405241' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0aaa7619-49f4-49c0-9a8f-c84f9369b060', N'5bd9a512-2c0c-43a2-83d0-df627f797c7d', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2900401' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'06ecdc44-f015-4645-becf-cae801e9fd9b', N'5ab23973-1cbf-451e-b54d-bfd63f102b03', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.5989505' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'603cee50-1a80-4668-b650-cd4f2764db63', N'54120a72-aa08-4860-b385-9edb22911825', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5173385' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'3708b706-e38f-428f-9030-cdb057c5fec3', N'238d4d11-ad63-4659-ba5f-4da19db65dcf', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-07-25T11:44:00.7443566' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'de898dac-f3fc-4295-85c7-cdbd42585ae7', N'd617a98a-430f-4ef1-aa44-795cd2b92674', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6009981' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a2453ce5-9ee8-44c9-aa34-d2c959abcba2', N'feec286c-0026-4cf1-911f-7e86eb0b4384', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2701019' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'846b3903-4ed7-4ac4-a04e-d3763b76aa7e', N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2774056' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'77363809-6ca5-40a5-ad10-d3b9ad2e33c0', N'cdaf62fa-2e6f-40b8-8c66-1ce4cd491987', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:19:57.8965373' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f663c56a-0860-4ca2-9a2c-d47ae83de0be', N'207672c0-0214-4b87-a2ea-3849695685d0', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-05T18:55:22.0153609' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2e55e490-767f-491f-9367-d5308dcc0fcc', N'6ab69860-e185-47fb-9ddb-a0614f83b6ab', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4814360' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'ade725db-66fa-461f-adf7-d72c71517794', N'0ef9be5c-a720-4f28-9318-5d9bb8f9143a', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-09-04T12:58:12.8476078' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'26791103-e2fb-45de-ad47-db15ff67e5fc', N'f0a7b823-ecc4-4090-836f-10efc82aafe1', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6092308' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f547b791-ff84-4f2e-bf3e-dcc0ec1b505e', N'cdaf62fa-2e6f-40b8-8c66-1ce4cd491987', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4733392' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'16791475-5ab4-40f5-8451-de0343ce9aa1', N'e5525d49-0ffc-430a-a384-10f69dff488c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8164479' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'53c08d6b-3829-4585-8250-e32bdcbf38a1', N'1e47184e-ad94-4629-a093-fe13895578bf', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T13:19:57.8979467' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c9ec9dda-7e0c-417d-a2b3-e36151203c14', N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2048315' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f07f8553-53d6-4e1f-a4b7-e40af3594a20', N'e658ffdd-4304-4ebf-8f7f-2417f8204c33', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6023620' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'eefde21f-cf27-4675-b32b-e4a05d443504', N'66a37477-5024-4750-b4ae-7190088091af', N'7b95531a-edcb-4c1f-b7d8-3abeb1aac16d', CAST(N'2023-07-26T12:59:32.6149513' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'04df5afb-df5a-470d-8ca4-e4acfcc8a8ec', N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2725935' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'e17c184d-1997-4ce6-a6e6-e7dc2aca5822', N'beff4b50-05c8-4695-857b-a527f8d959d7', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-10T01:43:31.8070398' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'1b1720f0-82ec-407a-a2ac-ec4f2124634e', N'46685805-a92c-4c6f-b02f-8f3851f9965d', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4867547' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'9324cfce-bddf-471a-972c-f4201a179506', N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4426526' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f03d2411-5b62-481c-81c0-f46c5ba917ce', N'd617a98a-430f-4ef1-aa44-795cd2b92674', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4840121' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'18d88962-d4ef-4414-b802-f7899a7fe4a0', N'2e5c1cab-1215-4261-b0d7-992b83ac7373', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-09-04T12:58:12.8641528' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'91ef5f84-a996-4db4-b29b-fcf13aacbb1b', N'6d518792-e233-4afc-9b7e-13829ccdd81d', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-07-25T11:44:00.7430243' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'd4a29d23-0dce-4561-a880-fd331e989615', N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.5134020' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a41798e4-de7d-4c5d-ab30-fd332ee43591', N'182e5b2e-773e-41e8-b8fe-88fcffaadcff', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4668096' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'91d728c1-dc17-4a05-9efb-fe96d9f479d5', N'081c16ba-c791-4152-b688-9c5f4a08864f', N'5a45d22f-b9f5-4b28-be74-0f1d16ab1efa', CAST(N'2023-06-25T00:07:37.4555770' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[UserPermissions] ([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'2112699b-2983-42a2-91a2-ff35ab920888', N'ab5a5c01-426e-4a80-87a8-43274db628d2', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7237282' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
GO
INSERT [People].[Users] ([ID], [UserName], [Email], [Phone], [Address], [PasswordHash], [UserImage], [IsAdmin], [UseDefaultPassword], [ResetPasswordDate], [CodeOfReset], [UserClassification], [ScreenId], [Salt], [UserTypeId], [Name], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy], [DiscountPermission], [SalePriceEdit]) VALUES (N'80968c16-15d8-4533-b771-5285299edcb6', N'admin', N'admin@admin.com', N'01252441', N'cairo', N'BEdsAtAvCWXvEwBKx1Pdng==', N'edfadawd', 1, 0, NULL, N'', 1, NULL, N'n1xdl54xsefeghk9z3xodibpmctoneyj', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', N'Admin', CAST(N'2023-05-29T13:33:41.3770000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL, 1, 1)
GO
ALTER TABLE [Page].[Pages] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsArea]
GO
ALTER TABLE [Page].[Pages] ADD  DEFAULT (CONVERT([bit],(0))) FOR [haveArea]
GO
ALTER TABLE [People].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [DiscountPermission]
GO
ALTER TABLE [People].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [SalePriceEdit]
GO
ALTER TABLE [Guide].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [Guide].[Products] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [Guide].[Attachments] CHECK CONSTRAINT [FK_Attachments_Products_ProductId]
GO
ALTER TABLE [Guide].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Attachments] CHECK CONSTRAINT [FK_Attachments_Users_AddedBy]
GO
ALTER TABLE [Guide].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Attachments] CHECK CONSTRAINT [FK_Attachments_Users_DeletedBy]
GO
ALTER TABLE [Guide].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Attachments] CHECK CONSTRAINT [FK_Attachments_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [Guide].[Invoices] ([ID])
GO
ALTER TABLE [Guide].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId]
GO
ALTER TABLE [Guide].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [Guide].[Products] ([ID])
GO
ALTER TABLE [Guide].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products_ProductId]
GO
ALTER TABLE [Guide].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Users_AddedBy]
GO
ALTER TABLE [Guide].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Users_DeletedBy]
GO
ALTER TABLE [Guide].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Invoices] CHECK CONSTRAINT [FK_Invoices_Users_AddedBy]
GO
ALTER TABLE [Guide].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Invoices] CHECK CONSTRAINT [FK_Invoices_Users_DeletedBy]
GO
ALTER TABLE [Guide].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Invoices] CHECK CONSTRAINT [FK_Invoices_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[ItemGrpoups]  WITH CHECK ADD  CONSTRAINT [FK_ItemGrpoups_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ItemGrpoups] CHECK CONSTRAINT [FK_ItemGrpoups_Users_AddedBy]
GO
ALTER TABLE [Guide].[ItemGrpoups]  WITH CHECK ADD  CONSTRAINT [FK_ItemGrpoups_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ItemGrpoups] CHECK CONSTRAINT [FK_ItemGrpoups_Users_DeletedBy]
GO
ALTER TABLE [Guide].[ItemGrpoups]  WITH CHECK ADD  CONSTRAINT [FK_ItemGrpoups_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ItemGrpoups] CHECK CONSTRAINT [FK_ItemGrpoups_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ItemGrpoups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [Guide].[ItemGrpoups] ([ID])
GO
ALTER TABLE [Guide].[Products] CHECK CONSTRAINT [FK_Products_ItemGrpoups_GroupId]
GO
ALTER TABLE [Guide].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Products] CHECK CONSTRAINT [FK_Products_Users_AddedBy]
GO
ALTER TABLE [Guide].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Products] CHECK CONSTRAINT [FK_Products_Users_DeletedBy]
GO
ALTER TABLE [Guide].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Products] CHECK CONSTRAINT [FK_Products_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[ProductUnits]  WITH CHECK ADD  CONSTRAINT [FK_ProductUnits_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [Guide].[Products] ([ID])
GO
ALTER TABLE [Guide].[ProductUnits] CHECK CONSTRAINT [FK_ProductUnits_Products_ProductId]
GO
ALTER TABLE [Guide].[ProductUnits]  WITH CHECK ADD  CONSTRAINT [FK_ProductUnits_Units_UnitId] FOREIGN KEY([UnitId])
REFERENCES [Guide].[Units] ([ID])
GO
ALTER TABLE [Guide].[ProductUnits] CHECK CONSTRAINT [FK_ProductUnits_Units_UnitId]
GO
ALTER TABLE [Guide].[ProductUnits]  WITH CHECK ADD  CONSTRAINT [FK_ProductUnits_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ProductUnits] CHECK CONSTRAINT [FK_ProductUnits_Users_AddedBy]
GO
ALTER TABLE [Guide].[ProductUnits]  WITH CHECK ADD  CONSTRAINT [FK_ProductUnits_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ProductUnits] CHECK CONSTRAINT [FK_ProductUnits_Users_DeletedBy]
GO
ALTER TABLE [Guide].[ProductUnits]  WITH CHECK ADD  CONSTRAINT [FK_ProductUnits_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[ProductUnits] CHECK CONSTRAINT [FK_ProductUnits_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetails_PurchaseInvoices_PurchaseInvoiceId] FOREIGN KEY([PurchaseInvoiceId])
REFERENCES [Guide].[PurchaseInvoices] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails] CHECK CONSTRAINT [FK_PurchaseInvoiceDetails_PurchaseInvoices_PurchaseInvoiceId]
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetails_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails] CHECK CONSTRAINT [FK_PurchaseInvoiceDetails_Users_AddedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetails_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails] CHECK CONSTRAINT [FK_PurchaseInvoiceDetails_Users_DeletedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetails_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoiceDetails] CHECK CONSTRAINT [FK_PurchaseInvoiceDetails_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoices]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoices_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoices] CHECK CONSTRAINT [FK_PurchaseInvoices_Users_AddedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoices]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoices_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoices] CHECK CONSTRAINT [FK_PurchaseInvoices_Users_DeletedBy]
GO
ALTER TABLE [Guide].[PurchaseInvoices]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoices_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseInvoices] CHECK CONSTRAINT [FK_PurchaseInvoices_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbackDetails_PurchaseThrowbacks_PurchaseThrowbackId] FOREIGN KEY([PurchaseThrowbackId])
REFERENCES [Guide].[PurchaseThrowbacks] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails] CHECK CONSTRAINT [FK_PurchaseThrowbackDetails_PurchaseThrowbacks_PurchaseThrowbackId]
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbackDetails_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails] CHECK CONSTRAINT [FK_PurchaseThrowbackDetails_Users_AddedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbackDetails_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails] CHECK CONSTRAINT [FK_PurchaseThrowbackDetails_Users_DeletedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbackDetails_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbackDetails] CHECK CONSTRAINT [FK_PurchaseThrowbackDetails_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbacks_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbacks] CHECK CONSTRAINT [FK_PurchaseThrowbacks_Users_AddedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbacks_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbacks] CHECK CONSTRAINT [FK_PurchaseThrowbacks_Users_DeletedBy]
GO
ALTER TABLE [Guide].[PurchaseThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseThrowbacks_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[PurchaseThrowbacks] CHECK CONSTRAINT [FK_PurchaseThrowbacks_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[SaleInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoiceDetails_SaleInvoices_SaleInvoiceId] FOREIGN KEY([SaleInvoiceId])
REFERENCES [Guide].[SaleInvoices] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoiceDetails] CHECK CONSTRAINT [FK_SaleInvoiceDetails_SaleInvoices_SaleInvoiceId]
GO
ALTER TABLE [Guide].[SaleInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoiceDetails_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoiceDetails] CHECK CONSTRAINT [FK_SaleInvoiceDetails_Users_AddedBy]
GO
ALTER TABLE [Guide].[SaleInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoiceDetails_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoiceDetails] CHECK CONSTRAINT [FK_SaleInvoiceDetails_Users_DeletedBy]
GO
ALTER TABLE [Guide].[SaleInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoiceDetails_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoiceDetails] CHECK CONSTRAINT [FK_SaleInvoiceDetails_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[SaleInvoices]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoices_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoices] CHECK CONSTRAINT [FK_SaleInvoices_Users_AddedBy]
GO
ALTER TABLE [Guide].[SaleInvoices]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoices_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoices] CHECK CONSTRAINT [FK_SaleInvoices_Users_DeletedBy]
GO
ALTER TABLE [Guide].[SaleInvoices]  WITH CHECK ADD  CONSTRAINT [FK_SaleInvoices_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleInvoices] CHECK CONSTRAINT [FK_SaleInvoices_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[SaleThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbackDetails_SaleThrowbacks_SaleThrowbackId] FOREIGN KEY([SaleThrowbackId])
REFERENCES [Guide].[SaleThrowbacks] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbackDetails] CHECK CONSTRAINT [FK_SaleThrowbackDetails_SaleThrowbacks_SaleThrowbackId]
GO
ALTER TABLE [Guide].[SaleThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbackDetails_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbackDetails] CHECK CONSTRAINT [FK_SaleThrowbackDetails_Users_AddedBy]
GO
ALTER TABLE [Guide].[SaleThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbackDetails_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbackDetails] CHECK CONSTRAINT [FK_SaleThrowbackDetails_Users_DeletedBy]
GO
ALTER TABLE [Guide].[SaleThrowbackDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbackDetails_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbackDetails] CHECK CONSTRAINT [FK_SaleThrowbackDetails_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[SaleThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbacks_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbacks] CHECK CONSTRAINT [FK_SaleThrowbacks_Users_AddedBy]
GO
ALTER TABLE [Guide].[SaleThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbacks_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbacks] CHECK CONSTRAINT [FK_SaleThrowbacks_Users_DeletedBy]
GO
ALTER TABLE [Guide].[SaleThrowbacks]  WITH CHECK ADD  CONSTRAINT [FK_SaleThrowbacks_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[SaleThrowbacks] CHECK CONSTRAINT [FK_SaleThrowbacks_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[StockProducts]  WITH CHECK ADD  CONSTRAINT [FK_StockProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [Guide].[Products] ([ID])
GO
ALTER TABLE [Guide].[StockProducts] CHECK CONSTRAINT [FK_StockProducts_Products_ProductId]
GO
ALTER TABLE [Guide].[StockProducts]  WITH CHECK ADD  CONSTRAINT [FK_StockProducts_Stocks_StockId] FOREIGN KEY([StockId])
REFERENCES [Guide].[Stocks] ([ID])
GO
ALTER TABLE [Guide].[StockProducts] CHECK CONSTRAINT [FK_StockProducts_Stocks_StockId]
GO
ALTER TABLE [Guide].[StockProducts]  WITH CHECK ADD  CONSTRAINT [FK_StockProducts_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[StockProducts] CHECK CONSTRAINT [FK_StockProducts_Users_AddedBy]
GO
ALTER TABLE [Guide].[StockProducts]  WITH CHECK ADD  CONSTRAINT [FK_StockProducts_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[StockProducts] CHECK CONSTRAINT [FK_StockProducts_Users_DeletedBy]
GO
ALTER TABLE [Guide].[StockProducts]  WITH CHECK ADD  CONSTRAINT [FK_StockProducts_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[StockProducts] CHECK CONSTRAINT [FK_StockProducts_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Stocks] CHECK CONSTRAINT [FK_Stocks_Users_AddedBy]
GO
ALTER TABLE [Guide].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Stocks] CHECK CONSTRAINT [FK_Stocks_Users_DeletedBy]
GO
ALTER TABLE [Guide].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Stocks] CHECK CONSTRAINT [FK_Stocks_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[Units]  WITH CHECK ADD  CONSTRAINT [FK_Units_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Units] CHECK CONSTRAINT [FK_Units_Users_AddedBy]
GO
ALTER TABLE [Guide].[Units]  WITH CHECK ADD  CONSTRAINT [FK_Units_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Units] CHECK CONSTRAINT [FK_Units_Users_DeletedBy]
GO
ALTER TABLE [Guide].[Units]  WITH CHECK ADD  CONSTRAINT [FK_Units_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[Units] CHECK CONSTRAINT [FK_Units_Users_ModifiedBy]
GO
ALTER TABLE [Guide].[UserTypes]  WITH CHECK ADD  CONSTRAINT [FK_UserTypes_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[UserTypes] CHECK CONSTRAINT [FK_UserTypes_Users_AddedBy]
GO
ALTER TABLE [Guide].[UserTypes]  WITH CHECK ADD  CONSTRAINT [FK_UserTypes_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[UserTypes] CHECK CONSTRAINT [FK_UserTypes_Users_DeletedBy]
GO
ALTER TABLE [Guide].[UserTypes]  WITH CHECK ADD  CONSTRAINT [FK_UserTypes_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Guide].[UserTypes] CHECK CONSTRAINT [FK_UserTypes_Users_ModifiedBy]
GO
ALTER TABLE [Page].[ActionsPages]  WITH CHECK ADD  CONSTRAINT [FK_ActionsPages_Pages_PageId] FOREIGN KEY([PageId])
REFERENCES [Page].[Pages] ([ID])
GO
ALTER TABLE [Page].[ActionsPages] CHECK CONSTRAINT [FK_ActionsPages_Pages_PageId]
GO
ALTER TABLE [Page].[ActionsPages]  WITH CHECK ADD  CONSTRAINT [FK_ActionsPages_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[ActionsPages] CHECK CONSTRAINT [FK_ActionsPages_Users_AddedBy]
GO
ALTER TABLE [Page].[ActionsPages]  WITH CHECK ADD  CONSTRAINT [FK_ActionsPages_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[ActionsPages] CHECK CONSTRAINT [FK_ActionsPages_Users_DeletedBy]
GO
ALTER TABLE [Page].[ActionsPages]  WITH CHECK ADD  CONSTRAINT [FK_ActionsPages_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[ActionsPages] CHECK CONSTRAINT [FK_ActionsPages_Users_ModifiedBy]
GO
ALTER TABLE [Page].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[Pages] CHECK CONSTRAINT [FK_Pages_Users_AddedBy]
GO
ALTER TABLE [Page].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[Pages] CHECK CONSTRAINT [FK_Pages_Users_DeletedBy]
GO
ALTER TABLE [Page].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Page].[Pages] CHECK CONSTRAINT [FK_Pages_Users_ModifiedBy]
GO
ALTER TABLE [People].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Clients] CHECK CONSTRAINT [FK_Clients_Users_AddedBy]
GO
ALTER TABLE [People].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Clients] CHECK CONSTRAINT [FK_Clients_Users_DeletedBy]
GO
ALTER TABLE [People].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Clients] CHECK CONSTRAINT [FK_Clients_Users_ModifiedBy]
GO
ALTER TABLE [People].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Users_AddedBy]
GO
ALTER TABLE [People].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Users_DeletedBy]
GO
ALTER TABLE [People].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Users_ModifiedBy]
GO
ALTER TABLE [People].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_ActionsPages_PageActionId] FOREIGN KEY([PageActionId])
REFERENCES [Page].[ActionsPages] ([ID])
GO
ALTER TABLE [People].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_ActionsPages_PageActionId]
GO
ALTER TABLE [People].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Users_AddedBy]
GO
ALTER TABLE [People].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Users_DeletedBy]
GO
ALTER TABLE [People].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Users_ModifiedBy]
GO
ALTER TABLE [People].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_UserTypes_UserTypeId] FOREIGN KEY([UserTypeId])
REFERENCES [Guide].[UserTypes] ([ID])
GO
ALTER TABLE [People].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_UserTypes_UserTypeId]
GO
ALTER TABLE [People].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Users] CHECK CONSTRAINT [FK_Users_Users_AddedBy]
GO
ALTER TABLE [People].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Users] CHECK CONSTRAINT [FK_Users_Users_DeletedBy]
GO
ALTER TABLE [People].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[Users] CHECK CONSTRAINT [FK_Users_Users_ModifiedBy]
GO
ALTER TABLE [People].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserTypes_UserTypeId] FOREIGN KEY([UserTypeId])
REFERENCES [Guide].[UserTypes] ([ID])
GO
ALTER TABLE [People].[Users] CHECK CONSTRAINT [FK_Users_UserTypes_UserTypeId]
GO
ALTER TABLE [People].[UserStocks]  WITH CHECK ADD  CONSTRAINT [FK_UserStocks_Stocks_StockId] FOREIGN KEY([StockId])
REFERENCES [Guide].[Stocks] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [People].[UserStocks] CHECK CONSTRAINT [FK_UserStocks_Stocks_StockId]
GO
ALTER TABLE [People].[UserStocks]  WITH CHECK ADD  CONSTRAINT [FK_UserStocks_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserStocks] CHECK CONSTRAINT [FK_UserStocks_Users_AddedBy]
GO
ALTER TABLE [People].[UserStocks]  WITH CHECK ADD  CONSTRAINT [FK_UserStocks_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserStocks] CHECK CONSTRAINT [FK_UserStocks_Users_DeletedBy]
GO
ALTER TABLE [People].[UserStocks]  WITH CHECK ADD  CONSTRAINT [FK_UserStocks_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [People].[UserStocks] CHECK CONSTRAINT [FK_UserStocks_Users_ModifiedBy]
GO
ALTER TABLE [People].[UserStocks]  WITH CHECK ADD  CONSTRAINT [FK_UserStocks_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [People].[Users] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [People].[UserStocks] CHECK CONSTRAINT [FK_UserStocks_Users_UserId]
GO
ALTER TABLE [Setting].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Users_AddedBy] FOREIGN KEY([AddedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Setting].[Settings] CHECK CONSTRAINT [FK_Settings_Users_AddedBy]
GO
ALTER TABLE [Setting].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Users_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Setting].[Settings] CHECK CONSTRAINT [FK_Settings_Users_DeletedBy]
GO
ALTER TABLE [Setting].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Users_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [People].[Users] ([ID])
GO
ALTER TABLE [Setting].[Settings] CHECK CONSTRAINT [FK_Settings_Users_ModifiedBy]
GO

                "
				);

            /// StoredProcedures
			migrationBuilder.Sql(
				@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc[Guide].[spItemGroups]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL

            as
            begin
            Declare @FirstRec int, @LastRec int
            Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
            
             case when(@SortCol = 0 and @SortDir = 'asc')


                     then Name


                 end asc,
                     case when(@SortCol = 0 and @SortDir = 'desc')


                     then Name


                 end desc,
            		   case when(@SortCol = 1 and @SortDir = 'asc')


                     then Name


                 end asc,
                     case when(@SortCol = 1 and @SortDir = 'desc')


                     then Name


                 end desc,
            		   
		    
		       case when(@SortCol = 4 and @SortDir = 'asc')


                     then[CreatedDate]


                 end asc,
                     case when(@SortCol = 4 and @SortDir = 'desc')


                     then[CreatedDate]


                 end desc

              )

                 as RowNum,
             COUNT(*) over() as TotalCount
                ,format( [CreatedDate],'yyyy/MM/dd')AddedDate,
                [ID]
                ,[Name]
                ,[AddedBy]
                ,[ModifiedDate]
                ,[ModifiedBy]
                ,[IsDeleted]
                ,[IsActive]
                ,[DeletedDate]
                ,[DeletedBy]
            FROM[Guide].[ItemGrpoups] with (nolock)

             where(@Search IS NULL
                     Or[Name] like '%' + @Search + '%'
                     ) and IsDeleted = 0
		    		   )
            Select*
            from TBL
            where RowNum > @FirstRec and RowNum <= @LastRec

            end
GO
/****** Object:  StoredProcedure [Guide].[spProduct]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Guide].[spProduct]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
			@UserID uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')

					 
                     then p.BarcodeText


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then p.BarcodeText


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then p.[Name]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then p.[Name]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then p.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then p.[CreatedDate]


                 end desc

              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(p.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  p.[ID]
                  ,p.[Name]
                  ,p.[AddedBy]
                  ,p.[IsActive]
				  ,p.BarCodeText
                  ,p.[Image]
                  ,p.[Description]
				  ,p.[IdUnitOfQty]
				  ,p.[NameUnitOfQty]
            , p.QtyInStock
            , p.GroupId
                  , ig.[Name] GroupName
				  ,s.ID StockId
				  ,s.[Name]StockName

			  from Guide.Products p with (nolock)
				inner join Guide.StockProducts sp with (nolock) on sp.ProductId = p.Id
				inner join Guide.Stocks s with (nolock) on s.Id = sp.StockId
				inner join People.UserStocks ut with (nolock) on ut.StockId = s.Id
				inner join Guide.ItemGrpoups ig on ig.ID = p.GroupId
				where p.IsDeleted = 0 and sp.IsDeleted = 0 and ut.IsDeleted = 0
				and ut.UserId = @UserID
				and (@Search IS NULL  Or p.[Name] like '%' + @Search + '%' or p.BarCodeText like '%'+@Search+'%'))

                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Guide].[spPurchaseInvoice]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Guide].[spPurchaseInvoice]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
			@UserID uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.InvoiceNumber


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.InvoiceNumber


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[InvoiceDate]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[InvoiceDate]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
				  ,s.[InvoiceNumber]
				  ,format(s.[InvoiceDate], 'yyyy/MM/dd') InvoiceDate
				  ,s.StockId
				  ,(select ss.Name from [Guide].[Stocks] ss where ss.ID=s.StockId 
				  and ss.IsActive=1 and ss.IsDeleted=0) StockName
				  ,(select count(*) from [Guide].[PurchaseInvoiceDetails] sd where sd.PurchaseInvoiceId=s.ID 
				  and sd.IsActive=1 and sd.IsDeleted=0) ProductsCount
                  ,s.[AddedBy]
                  ,s.[IsActive]
				  ,(select sss.Name from People.Suppliers sss where sss.ID=s.SupplierId 
				  and sss.IsActive=1 and sss.IsDeleted=0) SupplierName		
				  ,s.[InvoiceTotalPrice]
				  ,s.[SupplierId]
				  ,s.[TotalPaid]
				  ,s.[TransactionType]
              FROM [Guide].[PurchaseInvoices] s with (nolock)


                where(@Search IS NULL  Or s.[InvoiceNumber] like '%' + @Search + '%'
                ) and s.IsDeleted = 0
				and s.StockId in (select us.StockId from People.UserStocks us where us.UserId = @UserID )	
)
				 	
                Select*
                from TBL t
                where RowNum > @FirstRec and RowNum <= @LastRec
				order by t.AddedDate desc , t.InvoiceNumber desc


                end
GO
/****** Object:  StoredProcedure [Guide].[spPurchaseThrowback]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Guide].[spPurchaseThrowback]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
			@UserID uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.InvoiceNumber


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.InvoiceNumber


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[InvoiceDate]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[InvoiceDate]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )
                  as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
				  ,s.[InvoiceNumber]
				  ,format(s.[InvoiceDate], 'yyyy/MM/dd') InvoiceDate
				  ,s.StockId
				  ,(select ss.Name from [Guide].[Stocks] ss where ss.ID=s.StockId 
				  and ss.IsActive=1 and ss.IsDeleted=0) StockName
				  ,(select count(*) from [Guide].[PurchaseThrowbackDetails] sd where sd.PurchaseThrowbackId=s.ID 
				  and sd.IsActive=1 and sd.IsDeleted=0) ProductsCount
                  ,s.[AddedBy]
                  ,s.[IsActive]
				  ,(select sss.Name from People.Suppliers sss where sss.ID=s.SupplierId 
				  and sss.IsActive=1 and sss.IsDeleted=0) SupplierName		
				  ,s.[InvoiceTotalPrice]
				  ,s.[SupplierId]
				  ,s.[TotalPaid]
				  ,s.[TransactionType]
              FROM [Guide].[PurchaseThrowbacks] s with (nolock)


                where(@Search IS NULL  Or s.[InvoiceNumber] like '%' + @Search + '%'
                ) and s.IsDeleted = 0
				and s.StockId in (select us.StockId from People.UserStocks us where us.UserId = @UserID )	
)
				 	
                Select*
                from TBL t
                where RowNum > @FirstRec and RowNum <= @LastRec
				order by t.AddedDate desc , t.InvoiceNumber desc

                end
GO
/****** Object:  StoredProcedure [Guide].[spSaleInvoice]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Guide].[spSaleInvoice] 10,0,0,'asc'
CREATE proc [Guide].[spSaleInvoice]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
			@UserID uniqueidentifier = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.InvoiceNumber


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.InvoiceNumber


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[InvoiceDate]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[InvoiceDate]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
				  ,s.[InvoiceNumber]
				  ,format(s.[InvoiceDate], 'yyyy/MM/dd') InvoiceDate
				  ,s.Buyer as Buyer
				  ,s.StockId
				  ,(select ss.Name from [Guide].[Stocks] ss where ss.ID=s.StockId 
				  and ss.IsActive=1 and ss.IsDeleted=0) StockName
				  ,(select count(*) from [Guide].[SaleInvoiceDetails] sd where sd.SaleInvoiceId=s.ID 
				  and sd.IsActive=1 and sd.IsDeleted=0) ProductsCount
                  ,s.[AddedBy]
                  ,s.[IsActive]
              FROM [Guide].[SaleInvoices] s with (nolock)


                where(@Search IS NULL  Or s.[InvoiceNumber] like '%' + @Search + '%'
                ) and s.IsDeleted = 0
				and s.StockId in (select us.StockId from People.UserStocks us where us.UserId = @UserID )	
					)
				 	
                Select*
                from TBL t
                where RowNum > @FirstRec and RowNum <= @LastRec
				order by t.AddedDate desc , t.InvoiceNumber desc

                end
GO
/****** Object:  StoredProcedure [Guide].[spSaleThrowback]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Guide].[spSaleThrowback]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
			@UserID uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.InvoiceNumber


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.InvoiceNumber


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[InvoiceDate]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[InvoiceDate]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
				  ,s.[InvoiceNumber]
				  ,format(s.[InvoiceDate], 'yyyy/MM/dd') InvoiceDate
				  ,s.Buyer
				  ,s.StockId
				  ,(select ss.Name from [Guide].[Stocks] ss where ss.ID=s.StockId 
				  and ss.IsActive=1 and ss.IsDeleted=0) StockName
				  ,(select count(*) from [Guide].[SaleThrowbackDetails] sd where sd.SaleThrowbackId=s.ID 
				  and sd.IsActive=1 and sd.IsDeleted=0) ProductsCount
                  ,s.[AddedBy]
                  ,s.[IsActive]
              FROM [Guide].[SaleThrowbacks] s with (nolock)


                where(@Search IS NULL  Or s.[InvoiceNumber] like '%' + @Search + '%'
                ) and s.IsDeleted = 0
				and s.StockId in (select us.StockId from People.UserStocks us where us.UserId = @UserID )	
)
				 	
                Select*
                from TBL t
                where RowNum > @FirstRec and RowNum <= @LastRec
				order by t.AddedDate desc , t.InvoiceNumber desc
				
                end
GO
/****** Object:  StoredProcedure [Guide].[spStocks]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Guide].[spStocks] 10,0,0,'asc',@UserID = 'CA7DB9AB-679C-4A19-95BF-B44AA0ED0EA7'
CREATE proc[Guide].[spStocks]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
            @UserID uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.Name


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.Name


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[Name]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[Name]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )

                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
                  ,s.[Name]
                  ,s.[AddedBy]
                  ,s.[IsActive]
	              ,s.[Address]
                  ,s.[Phone]
                   ,s.[ManagerName]
              FROM[Guide].Stocks s with (nolock)


                     where(@Search IS NULL
                             Or s.[Name] like '%' + @Search + '%'
                             ) and s.IsDeleted = 0
							and s.ID in (select us.StockId from People.UserStocks us where us.UserId = @UserID )	

				 
				               )
				 					

    
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Guide].[spUnits]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Guide].[spUnits]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
         case when(@SortCol = 0 and @SortDir = 'asc')
        
                     then Name
        
                 end asc,
                 case when(@SortCol = 0 and @SortDir = 'desc')
        
                     then Name
        
                 end desc,
        		   case when(@SortCol = 1 and @SortDir = 'asc')
        
                     then Name
        
                 end asc,
                 case when(@SortCol = 1 and @SortDir = 'desc')
        
                     then Name
        
                 end desc,
        		   
		
		   case when(@SortCol = 4 and @SortDir = 'asc')
        
                     then[CreatedDate]
        
                 end asc,
                 case when(@SortCol = 4 and @SortDir = 'desc')
        
                     then[CreatedDate]
        
                 end desc

              )

                 as RowNum,
         COUNT(*) over() as TotalCount
      ,format( [CreatedDate],'yyyy/MM/dd')AddedDate,
      [ID]
      ,[Name]
      ,[AddedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
      ,[IsDeleted]
      ,[IsActive]
      ,[DeletedDate]
      ,[DeletedBy]
            FROM[Guide].[Units] u with (nolock)



         where(@Search IS NULL
                 Or[Name] like '%' + @Search + '%'
                 ) and IsDeleted = 0
				 
				 
				 
				   )
				 					

    
    Select*
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec

    end
GO
/****** Object:  StoredProcedure [People].[spClients]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [People].[spClients]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.ID


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.ID


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[Name]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[Name]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )

                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
                 ,s.[Name]
      ,s.[companyName]
      ,s.[Phone]
      ,s.[Address]
      ,s.[ProcessType]
      ,s.[ProcessAmount]
	  ,s.IsActive
              FROM [People].[Clients] s with (nolock)


                     where(@Search IS NULL
                             Or s.[Name] like '%' + @Search + '%'
                             ) and s.IsDeleted = 0
				               )
				 					

    
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [People].[spGetCasherMoney]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [People].[spGetCasherMoney] 
 @userId uniqueidentifier null= Null,
 @date date null =Null
 as
 begin
select 
convert (nvarchar(max),format(Max(s.CreatedDate ), 'yyyy-MM-dd HH:mm')) EndDate
,
convert (nvarchar(max),format(Min(s.CreatedDate), 'yyyy-MM-dd HH:mm')) StartDate
,
isnull( (select Count(sth.ID) from Guide.SaleThrowbacks sth with(nolock) where sth.AddedBy =@userId and (cast (sth.CreatedDate as date) >= cast(@date as date) and cast (sth.CreatedDate as date) <= cast(@date as date)) ) ,0 ) NumOfThrowbackInvoices
,
isnull((select Sum(sth.InvoiceTotalPrice)  from Guide.SaleThrowbacks sth with(nolock) where sth.AddedBy =@userId and (cast (sth.CreatedDate as date) >= cast(@date as date) and cast (sth.CreatedDate as date) <= cast(@date as date)) ),0) TotalMoneyForThrowback
,
isnull( (select count ( distinct sth.ProductId)  from Guide.SaleThrowbackDetails sth with(nolock) where sth.AddedBy =@userId and (cast (sth.CreatedDate as date) >= cast(@date as date) and cast (sth.CreatedDate as date) <= cast(@date as date)) ),0 ) NumOfThrowbackProducts
,
isnull( COUNT(s.ID) , 0) NumOfSaleInvoices
,
isnull(Count(Distinct sd.ProductId ),0) NumOfSaleProducts 
,Sum(s.InvoiceTotalPrice) TotalMoney 
, Sum(s.TotalPaid) TotalPaid 
, u.Name
,(select ss.CompanyName from Setting.Settings ss) CompanyName
,(select ss.CompanyAddress from Setting.Settings ss) CompanyAddress
,(select ss.CompanyPhone from Setting.Settings ss) CompanyPhone
,(select ss.CompanyImage from Setting.Settings ss) CompanyImage
,format(@date, 'yyyy/MM/dd') CurrentDate
from Guide.SaleInvoices s with (nolock)
inner join Guide.SaleInvoiceDetails sd with(nolock) on sd.SaleInvoiceId = s.ID
inner join People.Users u with (nolock)  on u.ID = s.AddedBy
where s.AddedBy = @userId  and (cast (s.CreatedDate as date) >= cast(@date as date) and cast (s.CreatedDate as date) <= cast(@date as date))
group by u.Name

end
GO
/****** Object:  StoredProcedure [People].[spSupplier]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [People].[spSupplier]
                        @DisplayLength int,
                        @DisplayStart int,
            @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL
            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.ID


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.ID


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then s.[Name]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then s.[Name]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then s.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then s.[CreatedDate]


                 end desc

              )

                  as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
                 ,s.[Name]
      ,s.[companyName]
      ,s.[Phone]
      ,s.[Address]
      ,s.[ProcessType]
      ,s.[ProcessAmount]
	  ,s.IsActive
              FROM [People].[Suppliers] s with (nolock)


                     where(@Search IS NULL
                             Or s.[Name] like '%' + @Search + '%'
                             ) and s.IsDeleted = 0
				               )
				 					

    
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [People].[spUsers]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [People].[spUsers]
@DisplayLength int,
            @DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
         case when(@SortCol = 0 and @SortDir = 'asc')
        
                     then s.ID
        
                 end asc,
                 case when(@SortCol = 0 and @SortDir = 'desc')
        
                     then s.ID
        
                 end desc,
        		   case when(@SortCol = 1 and @SortDir = 'asc')
        
                     then s.[Name]
        
                 end asc,
                 case when(@SortCol = 1 and @SortDir = 'desc')
        
                     then s.[Name]
        
                 end desc,
        		   
		
		   case when(@SortCol = 4 and @SortDir = 'asc')
        
                     then s.[CreatedDate]
        
                 end asc,
                 case when(@SortCol = 4 and @SortDir = 'desc')
        
                     then s.[CreatedDate]
        
                 end desc

              )

                 as RowNum,
         COUNT(*) over() as TotalCount
      ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate
	  ,s.ID
      ,s.[UserName]
      ,s.[Email]
      ,s.[Phone]
      ,s.[Address]
      ,s.[UserImage]
      ,s.[UserClassification]
      ,s.[UserTypeId]
	  ,(select top 1 ut.Name from[Guide].[UserTypes] ut where ut.ID = s.UserTypeId) UserTypeName
	  --,	(select STRING_AGG(CONVERT(NVARCHAR(max), gs.Name), '/') from[Guide].[Stocks] gs
   --     inner join[People].[UserStocks] us with (nolock) on us.StockId = gs.ID
   --     where gs.IsActive = 1 and gs.IsDeleted = 0 and us.UserId = s.ID) StockNames
      ,s.[Name]
      ,s.[IsActive]
  FROM[People].[Users] s with (nolock)




  where(@Search IS NULL
                 Or s.[Name] like '%' + @Search + '%'
                 ) and s.IsDeleted = 0
				 and s.UserClassification <> 1
				   )
        
    Select*
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec

    end
GO
/****** Object:  StoredProcedure [Report].[spGetCreditorSupplier]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetMostProductsSale] 10,0,0,'asc',Null
CREATE proc [Report].[spGetCreditorSupplier]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
					case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.Name


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.Name
                 end desc
				 ,   case when(@SortCol = 1 and @SortDir = 'asc')


                     then ABS(s.ProcessAmount)


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')

                     then ABS(s.ProcessAmount)
                 end desc

               
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
				 s.Name 
				 , s.companyName  as CompanyName
				 , s.Address 
				 , s.Phone 
				 , ABS(s.ProcessAmount) as Amount 
				 ,s.IsActive
				 from People.Suppliers  s with (nolock)
					where s.ProcessType = 2 and s.IsDeleted = 0
				)	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetDebtorSupplier]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetMostProductsSale] 10,0,0,'asc',Null
CREATE proc [Report].[spGetDebtorSupplier]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
					case when(@SortCol = 0 and @SortDir = 'asc')


                     then s.Name


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then s.Name
                 end desc
				 ,   case when(@SortCol = 1 and @SortDir = 'asc')


                     then ABS(s.ProcessAmount)


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')

                     then ABS(s.ProcessAmount)
                 end desc

               
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
				 s.Name 
				 , s.companyName  as CompanyName
				 , s.Address 
				 , s.Phone 
				 , ABS(s.ProcessAmount) as Amount 
				 ,s.IsActive
				 from People.Suppliers  s with (nolock)
					where s.ProcessType = 1 and s.IsDeleted = 0
				)	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetLeastProductsSale]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetMostProductsSale] 10,0,0,'asc',Null
CREATE proc [Report].[spGetLeastProductsSale]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
			@FromDate datetime = null ,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                    (select count(sp.Id) from [Guide].[SaleInvoiceDetails] sp with (nolock)
where sp.ProductId = p.ID
 and sp.IsDeleted = 0) asc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 --(select top 1 p.Name from [Guide].[Products] p where p.ID=sd.ProductId and p.IsDeleted=0) ProductName
					 --,(select top 1 u.Name from [Guide].[Units] u where u.ID=sd.UnitId and u.IsDeleted=0) UnitName
					 --,(select top 1 pu.ConversionFactor from [Guide].ProductUnits pu where pu.UnitId=sd.UnitId and pu.IsDeleted=0) ConversionFactor
					 --,(sd.Qty * ConversionFactor) ProductQty
      --           from [Guide].[SaleInvoiceDetails] sd 
      --          where sd.IsDeleted = 0
	  p.ID,p.[Name] ProductName,
u.[Name] UnitName,
(select count(sp.Id) from [Guide].[SaleInvoiceDetails] sp with (nolock)
inner join Guide.SaleInvoices s with (nolock) on s.ID=sp.SaleInvoiceId
where sp.ProductId = p.ID and (@FromDate is null or cast(s.InvoiceDate as date)>= cast(@FromDate as date))
and (@ToDate is null or cast(s.InvoiceDate as date)<= cast(@ToDate as date) )
 and sp.IsDeleted = 0) as NumOfPay
from  [Guide].[Products] p with (nolock)
inner join Guide.Units u with (nolock) on u.ID = p.IdUnitOfQty
where p.IsDeleted = 0
and ( @StockId is null or @StockId in (select sp.StockId from Guide.StockProducts sp where sp.ProductId = p.ID))
and (@Search is null or (p.Name like '%' + @Search +'%') )
				)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetLeastSupplierPurchase]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetLeastSupplierPurchase] 10,0,0,'asc',Null
CREATE proc [Report].[spGetLeastSupplierPurchase]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
			@FromDate datetime = null ,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
					(select count(sp.ID) from [Guide].PurchaseInvoices sp with (nolock)
						  where sp.SupplierId = sup.ID and (cast(@FromDate as date) is null or cast(sp.InvoiceDate as date)>=@FromDate )
						  and (cast(@ToDate as date) is null or cast(sp.InvoiceDate as date)<= cast(@ToDate as date))
						   and sp.IsDeleted = 0)  asc
                  
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount,
					 	  
					 sup.Name as SupplierName,
					 sup.companyName,
					 sup.Address,
					 sup.Phone,
					 sup.IsActive,
					 (select count(sp.ID) from [Guide].PurchaseInvoices sp with (nolock)
						  where sp.SupplierId = sup.ID and (cast(@FromDate as date) is null or cast(sp.InvoiceDate as date)>=@FromDate )
						  and (cast(@ToDate as date)is null or cast(sp.InvoiceDate as date)<= cast(@ToDate as date))
						   and sp.IsDeleted = 0) as NumOfProcess
					 from  People.Suppliers sup with (nolock)
					 inner join Guide.PurchaseInvoices purchase with (nolock) on purchase.SupplierId = sup.ID
				where 
				sup.IsDeleted = 0
				--and (  @StockId is null or 
				-- @StockId in (select purchase.StockId from Guide.PurchaseInvoices purchase where  purchase.SupplierId = sup.ID)
				--)
				and (  @FromDate is null or 
				cast(@FromDate as date )<= cast(purchase.InvoiceDate as date)
				)
				and (  @ToDate is null or 
				cast(@ToDate as date)>= cast(purchase.InvoiceDate as date) 
				)
				and (@Search is null or (sup.Name like '%'+@Search+'%') or (sup.companyName like '%'+@Search+'%') or (sup.Phone like '%'+@Search+'%'))
				group by sup.ID , sup.Name , sup.companyName , sup.Address , sup.Phone , sup.IsActive

				--and ((@FromDate is null or @ToDate is null ) or (purchase.InvoiceDate >= @FromDate and purchase.InvoiceDate <= @ToDate))
				)	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetMostProductsSale]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetMostProductsSale] 10,0,0,'asc',Null
CREATE proc [Report].[spGetMostProductsSale]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
			@FromDate datetime = null ,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                    (select count(sp.Id) from [Guide].[SaleInvoiceDetails] sp with (nolock)
where sp.ProductId = p.ID
 and sp.IsDeleted = 0) desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 --(select top 1 p.Name from [Guide].[Products] p where p.ID=sd.ProductId and p.IsDeleted=0) ProductName
					 --,(select top 1 u.Name from [Guide].[Units] u where u.ID=sd.UnitId and u.IsDeleted=0) UnitName
					 --,(select top 1 pu.ConversionFactor from [Guide].ProductUnits pu where pu.UnitId=sd.UnitId and pu.IsDeleted=0) ConversionFactor
					 --,(sd.Qty * ConversionFactor) ProductQty
      --           from [Guide].[SaleInvoiceDetails] sd 
      --          where sd.IsDeleted = 0
	  p.ID,p.[Name] ProductName,
u.[Name] UnitName,
(select count(sp.Id) from [Guide].[SaleInvoiceDetails] sp with (nolock)
inner join Guide.SaleInvoices s with (nolock) on s.ID=sp.SaleInvoiceId
where sp.ProductId = p.ID and (@FromDate is null or cast(s.InvoiceDate as date)>=cast(@FromDate as date) )
and (@ToDate is null or cast(s.InvoiceDate as date )<= cast(@ToDate as date) )
 and sp.IsDeleted = 0) as NumOfPay
from  [Guide].[Products] p with (nolock)
inner join Guide.Units u with (nolock) on u.ID = p.IdUnitOfQty
where p.IsDeleted = 0 
and ( @StockId is null or @StockId in (select sp.StockId from Guide.StockProducts sp where sp.ProductId = p.ID))
and (@Search is null or (p.Name like '%' + @Search +'%') )
				)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetMostSupplierPurchase]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spGetMostSupplierPurchase] 10,0,0,'asc',Null
CREATE proc [Report].[spGetMostSupplierPurchase]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
			@FromDate datetime = null ,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
					(select count(sp.ID) from [Guide].PurchaseInvoices sp with (nolock)
						  where sp.SupplierId = sup.ID and (@FromDate is null or sp.InvoiceDate>=@FromDate )
						  and (@ToDate is null or sp.InvoiceDate<=@ToDate )
						  and (@StockId is null or sp.StockId = @StockId)
						   and sp.IsDeleted = 0 
						   )  

						   desc

                  
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount,  
					 sup.Name as SupplierName,
					 sup.companyName,
					 sup.Address,
					 sup.Phone,
					 sup.IsActive,
					 (select count(sp.ID) from [Guide].PurchaseInvoices sp with (nolock)
						  where sp.SupplierId = sup.ID and (@FromDate is null or cast( sp.InvoiceDate as date)>= cast(@FromDate as date))
						  and (@ToDate is null or cast(sp.InvoiceDate as date)<=cast(@ToDate as date))
						  and (@StockId is null or sp.StockId = @StockId)
						   and sp.IsDeleted = 0) as NumOfProcess
					 from  People.Suppliers sup with (nolock)
					 inner join Guide.PurchaseInvoices purchase with (nolock) on purchase.SupplierId = sup.ID
					 --Guide.PurchaseInvoices purchase
				where 
				sup.IsDeleted = 0
				and (  @StockId is null or 
				 @StockId in (select purchase.StockId from Guide.PurchaseInvoices purchase where  purchase.SupplierId = sup.ID)
				)
				and (  @FromDate is null or 
				cast(@FromDate as date )<= cast(purchase.InvoiceDate as date)
				)
				and (  @ToDate is null or 
				cast(@ToDate as date)>= cast(purchase.InvoiceDate as date) 
				)
				and (@Search is null or (sup.Name like '%'+@Search+'%') or (sup.companyName like '%'+@Search+'%') or (sup.Phone like '%'+@Search+'%'))
				group by sup.ID , sup.Name , sup.companyName , sup.Address , sup.Phone , sup.IsActive
				)	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spGetPurchaseInvoiceToPrint]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [Report].[spGetPurchaseInvoiceToPrint] 
 @invoiceId uniqueidentifier null =Null
 as
 begin
select
(select ss.CompanyName from Setting.Settings ss) CompanyName
,(select ss.CompanyAddress from Setting.Settings ss) CompanyAddress
,(select ss.CompanyPhone from Setting.Settings ss) CompanyPhone
,(select ss.CompanyImage from Setting.Settings ss) CompanyImage
,stock.Name StockName
,s.InvoiceNumber 
,format(s.CreatedDate, 'yyyy/MM/dd HH:mm:ss') InvoiceDate
,sd.Name as SupplierName
,sd.Phone as SupplierPhone
,s.TotalPaid
,s.InvoiceTotalPrice
,(s.InvoiceTotalPrice - s.TotalPaid) Remainning
,(select
sdd.Qty as ProductQty
,sdd.TotalQtyPrice ProductTotalQtyPrice
,sdd.PurchasingPrice as ProductPurchasingPrice
,UnitJsonDto.Name as UnitName
,ProductJsonDto.Name as ProductName
,ProductJsonDto.BarCodeText as ProductParcode
from Guide.PurchaseInvoiceDetails sdd
inner join Guide.Units UnitJsonDto with (nolock)  on UnitJsonDto.id = sdd.UnitId
inner join Guide.Products ProductJsonDto with (nolock)  on ProductJsonDto.id = sdd.ProductId
where sdd.PurchaseInvoiceId = s.ID for json auto) as DetailsAsJson
from Guide.PurchaseInvoices s with (nolock)
inner join People.Suppliers sd with (nolock)  on sd.id = s.SupplierId
inner join guide.Stocks stock with(nolock) on stock.ID = s.StockId
where s.IsDeleted = 0 and s.Id = @invoiceId

end

GO
/****** Object:  StoredProcedure [Report].[spGetPurchaseThrowbackInvoiceToPrint]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [Report].[spGetPurchaseThrowbackInvoiceToPrint] 
 @invoiceId uniqueidentifier null =Null
 as
 begin
select
(select ss.CompanyName from Setting.Settings ss) CompanyName
,(select ss.CompanyAddress from Setting.Settings ss) CompanyAddress
,(select ss.CompanyPhone from Setting.Settings ss) CompanyPhone
,(select ss.CompanyImage from Setting.Settings ss) CompanyImage
,stock.Name StockName
,s.InvoiceNumber 
,purchaseInvoice.InvoiceNumber as PurchaseInvoiceNumber
,format(s.InvoiceDate, 'yyyy/MM/dd HH:mm:ss') InvoiceDate
,format(purchaseInvoice.InvoiceDate, 'yyyy/MM/dd HH:mm:ss') PurchaseInvoiceDate
,sd.Name as SupplierName
,sd.Phone as SupplierPhone
,s.TotalPaid
,s.InvoiceTotalPrice
,(s.InvoiceTotalPrice - s.TotalPaid) Remainning
,(select
sdd.Qty as ProductQty
,sdd.TotalQtyPrice ProductTotalQtyPrice
,sdd.PurchasingPrice as ProductPurchasingPrice
,UnitJsonDto.Name as UnitName
,ProductJsonDto.Name as ProductName
,ProductJsonDto.BarCodeText as ProductParcode
from Guide.PurchaseThrowbackDetails sdd
inner join Guide.Units UnitJsonDto with (nolock)  on UnitJsonDto.id = sdd.UnitId
inner join Guide.Products ProductJsonDto with (nolock)  on ProductJsonDto.id = sdd.ProductId
where sdd.PurchaseThrowbackId = s.ID for json auto) as DetailsPTAsJson
from Guide.PurchaseThrowbacks s with (nolock)
inner join People.Suppliers sd with (nolock)  on sd.id = s.SupplierId
inner join guide.Stocks stock with(nolock) on stock.ID = s.StockId
inner join Guide.PurchaseInvoices purchaseInvoice with(nolock) on purchaseInvoice.ID = s.PurchaseInvoiceId
where s.IsDeleted = 0 and s.Id = @invoiceId

end

GO
/****** Object:  StoredProcedure [Report].[spGetSaleInvoiceToPrint]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [Report].[spGetSaleInvoiceToPrint] 
 @invoiceId uniqueidentifier null =Null
 as
 begin
select
(select ss.CompanyName from Setting.Settings ss) CompanyName
,(select ss.CompanyAddress from Setting.Settings ss) CompanyAddress
,(select ss.CompanyPhone from Setting.Settings ss) CompanyPhone
,(select ss.CompanyImage from Setting.Settings ss) CompanyImage
,stock.Name StockName
,s.InvoiceNumber 
,format(s.InvoiceDate, 'yyyy/MM/dd HH:mm:ss') InvoiceDate
,s.Buyer
,s.TotalPaid
,s.InvoiceTotalDiscountType
,s.InvoiceTotalDiscount
,s.InvoiceTotalPrice
,(s.InvoiceTotalPrice - s.TotalPaid) Remainning
,(select
sdd.Qty as ProductQty
,sdd.TotalQtyPrice ProductTotalQtyPrice
,sdd.SellingPrice as ProductSellingPrice
,sdd.DiscountPProduct ProductDisscount
,sdd.DiscountTypePProduct as ProductDiscountType
,UnitJsonDto.Name as UnitName
,ProductJsonDto.Name as ProductName
,ProductJsonDto.BarCodeText as ProductParcode
from Guide.SaleInvoiceDetails sdd
inner join Guide.Units UnitJsonDto with (nolock)  on UnitJsonDto.id = sdd.UnitId
inner join Guide.Products ProductJsonDto with (nolock)  on ProductJsonDto.id = sdd.ProductId
where sdd.SaleInvoiceId = s.ID for json auto) as DetailsAsJson
from Guide.SaleInvoices s with (nolock)
--inner join Guide.SaleInvoiceDetails sd with (nolock)  on sd.SaleInvoiceId = s.ID
inner join guide.Stocks stock with(nolock) on stock.ID = s.StockId
where s.IsDeleted = 0 and s.Id = @invoiceId

end

GO
/****** Object:  StoredProcedure [Report].[spGetSaleThrowbackInvoiceToPrint]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [Report].[spGetSaleThrowbackInvoiceToPrint] 
 @invoiceId uniqueidentifier null =Null
 as
 begin
select
(select ss.CompanyName from Setting.Settings ss) CompanyName
,(select ss.CompanyAddress from Setting.Settings ss) CompanyAddress
,(select ss.CompanyPhone from Setting.Settings ss) CompanyPhone
,(select ss.CompanyImage from Setting.Settings ss) CompanyImage
,stock.Name StockName
,s.InvoiceNumber
,format(s.InvoiceDate, 'yyyy/MM/dd HH:mm:ss') InvoiceDate
,format(saleInvoice.InvoiceDate, 'yyyy/MM/dd HH:mm:ss') SaleInvoiceDate
,saleInvoice.InvoiceNumber as SaleInvoiceNumber
,s.Buyer
,s.TotalPaid
,s.InvoiceTotalPrice
,s.InvoiceTotalDiscountType
,s.InvoiceTotalDiscount
,(s.InvoiceTotalPrice - s.TotalPaid) Remainning
,(select
sdd.Qty as ProductQty
,sdd.TotalQtyPrice ProductTotalQtyPrice
,sdd.SellingPrice as ProductSellingPrice
,sdd.DiscountPProduct ProductDisscount
,sdd.DiscountTypePProduct as ProductDiscountType
,UnitJsonDto.Name as UnitName
,ProductJsonDto.Name as ProductName
,ProductJsonDto.BarCodeText as ProductParcode
from Guide.SaleThrowbackDetails sdd
inner join Guide.Units UnitJsonDto with (nolock)  on UnitJsonDto.id = sdd.UnitId
inner join Guide.Products ProductJsonDto with (nolock)  on ProductJsonDto.id = sdd.ProductId
where sdd.SaleThrowbackId = s.ID for json auto) as DetailsSTAsJson
from Guide.SaleThrowbacks s with (nolock)
inner join Guide.SaleInvoices saleInvoice with (nolock)  on saleInvoice.ID = s.SaleInvoiceId
inner join guide.Stocks stock with(nolock) on stock.ID = s.StockId
where s.IsDeleted = 0 and s.Id = @invoiceId

end

GO
/****** Object:  StoredProcedure [Report].[spProductPriceReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spProductPriceReport] 10,0,0,'asc',Null

CREATE proc [Report].[spProductPriceReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then p.Name


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then p.Name


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then p.Name


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then p.Name


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount,
					 (select top 1 u.Name from Guide.Units u where u.ID = pu.UnitId) QtyName,
					 p.Name as ProductName,
					 pu.UnitBarcodeText as BarCode,
					 pu.PurchasingPrice,
					 pu.SellingPrice					
                 from [Guide].[ProductUnits] pu with (nolock)
				 inner join Guide.Products p with (nolock) on pu.ProductId = p.ID
                where(@Search IS NULL  Or pu.UnitBarcodeText like '%' + @Search + '%' or p.Name like '%'+@Search+'%') 
				and ( @StockId is null or @StockId in (select sp.StockId from Guide.StockProducts sp where sp.ProductId = p.ID))
				and pu.IsDeleted = 0 and p.IsDeleted=0)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spProductQtyReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spProductQtyReport] 10,0,0,'asc',Null

CREATE proc [Report].[spProductQtyReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then p.Name


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then p.Name


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then p.Name


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then p.Name


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount,
					 (select top 1 u.Name from Guide.Units u where u.ID = p.IdUnitOfQty) QtyName,
					 p.Name as ProductName,
					 p.QtyInStock,
					 p.BarCodeText as BarCode
                 from [Guide].Products p with (nolock)
				 --inner join Guide.StockProducts sp on sp.ProductId=p.ID
                where(@Search IS NULL or p.Name like '%'+@Search+'%' or p.BarCodeText like '%' +@Search + '%') 
				and ( @StockId is null or @StockId in (select sp.StockId from Guide.StockProducts sp where sp.ProductId = p.ID))
				and p.IsDeleted=0)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spProductReportData]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spProductReportData] 20,0,0,'asc'
CREATE proc [Report].[spProductReportData]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then p.BarcodeText


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then p.BarcodeText


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then p.[Name]


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then p.[Name]


                 end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')


                     then p.[CreatedDate]


                 end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')


                     then p.[CreatedDate]


                 end desc

              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(p.[CreatedDate], 'yyyy/MM/dd')AddedDate,
				  p.ExpireDate,
                  p.[ID]
                  ,p.[Name]
                  ,p.[IsActive]
				  ,p.BarCodeText
                  ,p.[Description]
				  ,(select top 1 u.Name from [Guide].[Units] u where u.ID=p.IdUnitOfQty) NameUnitOfQty
				  , p.QtyInStock
                  , (select top 1 ig.Name from[Guide].[ItemGrpoups] ig where ig.ID = p.GroupId) GroupName
				  ,(select top 1 sp.StockId from[Guide].[StockProducts] sp where sp.ProductId = p.ID) StockId
				  --,(select top 1 s.Name from[Guide].[Stocks] s
      --            where s.ID = (select top 1 sp.StockId from[Guide].[StockProducts] sp where sp.ProductId = p.ID)) StockName
				  , (select STRING_AGG(s.Name,',') from[Guide].[Stocks] s
                  where s.ID in (select sp.StockId from[Guide].[StockProducts] sp where sp.ProductId = p.ID)) as StockName
              FROM[Guide].[Products] p with (nolock)


                where(@Search IS NULL  Or p.[Name] like '%' + @Search + '%' or p.BarCodeText like '%'+@Search+'%') 
				and ( @StockId is null or @StockId in (select sp.StockId from Guide.StockProducts sp where sp.ProductId = p.ID))
				and p.IsDeleted = 0)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spPurchaseInvoiceReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Report].[spPurchaseInvoiceReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = null,
			@FromDate datetime = null,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then st.InvoiceDate


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then st.InvoiceDate


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then st.InvoiceNumber


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then st.InvoiceNumber


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 st.ID,
					 st.TransactionType,
					 (select s.Name from [Guide].[Stocks] s where s.ID=st.StockId) StockName,
					 st.InvoiceNumber,
					 (select convert(varchar, st.InvoiceDate, 20)) as InvoiceDateStr,
					 (select top 1 s.Name from People.Suppliers s where s.ID=st.SupplierId) SupplierName,
					 (select count(sd2.ProductId) from [Guide].PurchaseInvoiceDetails sd2 where sd2.PurchaseInvoiceId=st.ID) NumOfProducts,
					 st.InvoiceTotalPrice,
					 st.TotalPaid
                 from [Guide].PurchaseInvoices st with (nolock)
				 inner join People.Suppliers s with (nolock) on s.ID=st.SupplierId 
				 inner join Guide.Stocks ss with (nolock) on ss.ID=st.StockId
                where
				(@FromDate is null or cast(@FromDate as date)<= cast(st.CreatedDate as date))
					and (@ToDate is null or cast(@ToDate as date)>= cast(st.CreatedDate as date))
					and	(@Search IS NULL  Or st.InvoiceNumber like '%' + @Search + '%' or s.Name like '%'+@Search+'%' or ss.Name like '%' +@Search+ '%' ) 
				and (@StockId is null or st.StockId=@StockId)
				and st.IsDeleted = 0)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spPurchaseThrowbackInvoiceReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Report].[spPurchaseThrowbackInvoiceReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = null,
			@FromDate datetime = null,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then st.InvoiceDate


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then st.InvoiceDate


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then st.InvoiceNumber


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then st.InvoiceNumber


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 st.ID,
					 (select s.Name from [Guide].[Stocks] s where s.ID=st.StockId) StockName,
					 st.InvoiceNumber,
					 (select convert(varchar, st.InvoiceDate, 20)) as InvoiceDateStr,
					 (select top 1 s.Name from People.Suppliers s where s.ID=st.SupplierId) SupplierName,
					 (select count(sd2.ProductId) from [Guide].PurchaseThrowbackDetails sd2 where sd2.PurchaseThrowbackId=st.ID) NumOfProducts,
					 st.InvoiceTotalPrice,
					 st.TotalPaid,
					 (select convert(varchar, p.InvoiceDate, 20)) as PurchaseInvoiceDateStr,
					 p.InvoiceNumber as PurchaseInvoiceNumber
                 from [Guide].PurchaseThrowbacks st with (nolock)
				 inner join Guide.PurchaseInvoices p with (nolock) on p.ID=st.PurchaseInvoiceId
				 inner join People.Suppliers s with (nolock) on s.ID=st.SupplierId
				 inner join Guide.Stocks ss with (nolock) on ss.ID=st.StockId
                where(@Search IS NULL  Or st.InvoiceNumber like '%' + @Search + '%' or s.Name like '%'+@Search+'%' or ss.Name like '%' +@Search+ '%' ) 
				and (@StockId is null or st.StockId=@StockId)
				and	(@FromDate is null or cast(@FromDate as date)<= cast(st.CreatedDate as date))
				and (@ToDate is null or cast(@ToDate as date)>= cast(st.CreatedDate as date))
				and st.IsDeleted = 0)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spSaleProductData]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spSaleProductData] 20,0,0,'asc'
CREATE proc [Report].[spSaleProductData]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = NULL,
			@CashierId uniqueidentifier = NULL,
            @Search nvarchar(255) = NULL,
			@FromDate datetime=Null,
			@ToDate datetime=Null

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
                     case when(@SortCol = 0 and @SortDir = 'asc')
                     then pd.ID
                 end asc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(pd.[CreatedDate], 'yyyy/MM/dd')AddedDate,
				  pd.ID 
				  ,pd.[Name]ProductName
				  ,u.[Name]UnitName
				  ,Sum(sai.Qty * sai.ConversionFactor)TotalQuantity,
					min(sai.CreatedDate)FirstDate
					,max(sai.CreatedDate)MaxDate
					from Guide.SaleInvoiceDetails sai with (nolock)
					inner join Guide.Products pd with (nolock) on pd.Id = sai.ProductId
					inner join Guide.Units u with (nolock)  on u.Id = pd.IdUnitOfQty 
					inner join Guide.SaleInvoices sa with(nolock) on sa.ID = sai.SaleInvoiceId
					where (@FromDate is null or cast(@FromDate as date)<= cast(sai.CreatedDate as date))
					and (@ToDate is null or cast(@ToDate as date)>= cast(sai.CreatedDate as date))
					and pd.IsDeleted = 0 
					and (@CashierId is null or (@CashierId = sa.AddedBy))
					and (@StockId is null or (@StockId in (select sp.StockId from [Guide].[StockProducts] sp where sp.ProductId = pd.ID))
					)
					group by pd.ID,pd.[Name],u.[Name],pd.[CreatedDate]
					)
					
                Select *
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spSaleReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Report].[spSaleReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = null,
			@FromDate datetime = null,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL,
            @CashierId uniqueidentifier = NULL


            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                    
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then si.InvoiceNumber


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then si.InvoiceNumber


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 si.ID,
					 si.InvoiceNumber,
					 si.InvoiceTotalPrice,
					 (select convert(varchar, si.InvoiceDate, 20)) as InvoiceDateStr,
					 si.InvoiceDate,
					 sI.InvoiceTotalDiscount,
					 si.InvoiceTotalDiscountType,
					 si.Buyer,
					 si.TotalPaid,
					 (select s.Name from [Guide].[Stocks] s where s.ID=si.StockId) StockName,
					 (select count(sd2.ProductId) from [Guide].[SaleInvoiceDetails] sd2 where sd2.SaleInvoiceId=si.ID) NumOfProducts
                 from [Guide].[SaleInvoiceDetails] sd with (nolock)
				 inner join [Guide].[SaleInvoices] sI with (nolock)	 on si.ID=sd.SaleInvoiceId
                where
				(@FromDate is null or cast(@FromDate as date)<= cast(si.CreatedDate as date))
					and (@ToDate is null or cast(@ToDate as date)>= cast(si.CreatedDate as date))
					and	(@Search IS NULL  Or sI.InvoiceNumber like '%' + @Search + '%' or sI.Buyer like '%'+@Search+'%') 
				and (@StockId is null or si.StockId=@StockId)
				and sI.IsDeleted = 0
				and (@CashierId is null or sd.AddedBy = @CashierId)
				)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO
/****** Object:  StoredProcedure [Report].[spSaleThrowbackReport]    Script Date: 9/4/2023 1:41:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [Report].[spSaleThrowbackReport] 10,0,0,'asc'
CREATE proc [Report].[spSaleThrowbackReport]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
			@StockId uniqueidentifier = null,
			@FromDate datetime = null,
			@ToDate datetime = null,
            @Search nvarchar(255) = NULL,
            @CashierId uniqueidentifier = NULL

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
            Set @LastRec = @DisplayStart + @DisplayLength;

            With TBL as
            (
                 Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')


                     then st.InvoiceDate


                 end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')


                     then st.InvoiceDate


                 end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')


                     then st.InvoiceNumber


                 end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')


                     then st.InvoiceNumber


                 end desc
              )
                 as RowNum,
                     COUNT(*) over() as TotalCount ,
					 st.ID,
					 st.InvoiceNumber,
					 (select convert(varchar, st.InvoiceDate, 20)) as InvoiceDateStr,
					 si.InvoiceNumber as SaleInvoiceNumber,
					 si.InvoiceDate as SaleInvoiceDate,
					 (select convert(varchar, si.InvoiceDate, 20)) as SaleInvoiceDateStr,
					 st.InvoiceTotalPrice,
					 st.Buyer,
					 st.TotalPaid,
					 (select s.Name from [Guide].[Stocks] s where s.ID=st.StockId) StockName,
					 (select count(sd2.ProductId) from [Guide].SaleThrowbackDetails sd2 where sd2.SaleThrowbackId=st.ID) NumOfProducts
                 from [Guide].SaleThrowbacks st with (nolock)
				 inner join [Guide].[SaleInvoices] sI  with (nolock)
				 on si.ID=st.SaleInvoiceId
                where
				(@FromDate is null or cast(@FromDate as date)<= cast(st.CreatedDate as date))
					and (@ToDate is null or cast(@ToDate as date)>= cast(st.CreatedDate as date))
					and	(@Search IS NULL  Or sI.InvoiceNumber like '%' + @Search + '%' or sI.Buyer like '%'+@Search+'%') 
				and (@StockId is null or si.StockId=@StockId)
				and sI.IsDeleted = 0
				and (@CashierId is null or st.AddedBy = @CashierId)
				)
				 	
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end
GO

                "
				);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
