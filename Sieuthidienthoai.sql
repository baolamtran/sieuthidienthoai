USE [SieuThiDienThoaiDb]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiveForms]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_ReceiveForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiveFormItems]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveFormItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ReceiveFormId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ReceiveFormItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[Value] [int] NOT NULL,
	[MinTotalPrice] [int] NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
	[MadeIn] [nvarchar](max) NULL,
	[TimeGuarantee] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Width] [real] NOT NULL,
	[Height] [real] NOT NULL,
	[Length] [real] NOT NULL,
	[Os] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ProductCategoryId] [int] NOT NULL,
	[ManufacturerId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderForms]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_OrderForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderFormPayments]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderFormPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Method] [nvarchar](max) NULL,
	[BankInfo] [nvarchar](max) NULL,
	[OrderFormId] [int] NOT NULL,
 CONSTRAINT [PK_OrderFormPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderFormItems]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderFormItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderFormId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderFormItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuaranteeForms]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuaranteeForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_GuaranteeForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuaranteeFormItems]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuaranteeFormItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuaranteeFormId] [int] NOT NULL,
	[GuaranteeFormCustomerId] [int] NOT NULL,
 CONSTRAINT [PK_GuaranteeFormItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuaranteeFormCustomers]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuaranteeFormCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_GuaranteeFormCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[IsVip] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CompanyDirector] [nvarchar](max) NULL,
	[CompanyPhone] [nvarchar](max) NULL,
	[score] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[PercentDiscount] [real] NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[AmountPromotion] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PromotionId] [int] NOT NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillPayments]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[BillId] [int] NOT NULL,
 CONSTRAINT [PK_BillPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[BillId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_BillItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDeliveryInfoItems]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDeliveryInfoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[BillDeliveryInfoId] [int] NOT NULL,
 CONSTRAINT [PK_BillDeliveryInfoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDeliveryInfoes]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDeliveryInfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillDeliveryId] [int] NOT NULL,
 CONSTRAINT [PK_BillDeliveryInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDeliveries]    Script Date: 05/14/2019 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDeliveries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Distance] [real] NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[IsInsideHcm] [bit] NOT NULL,
	[BillId] [int] NOT NULL,
 CONSTRAINT [PK_BillDeliveries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/14/2019 16:07:38 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE BillItems
ADD CONSTRAINT FK_Bill
FOREIGN KEY (BillId) REFERENCES Bills(id);

ALTER TABLE BillItems
ADD CONSTRAINT FK_Product_ID
FOREIGN KEY (ProductId) REFERENCES Products(id);

ALTER TABLE BillPayments
ADD CONSTRAINT FK_Bill_ID
FOREIGN KEY (BillId) REFERENCES Bills(id);

ALTER TABLE Bills
ADD CONSTRAINT FK_Promotion_ID
FOREIGN KEY (PromotionId) REFERENCES Promotions(id);

ALTER TABLE Bills
ADD CONSTRAINT FK_Customer_ID
FOREIGN KEY (CustomerId) REFERENCES Customers(id);

ALTER TABLE Bills
ADD CONSTRAINT FK_Employee_ID
FOREIGN KEY (EmployeeId) REFERENCES Employees(id);

ALTER TABLE GuaranteeForms
ADD CONSTRAINT FK_Guarantee_Employee
FOREIGN KEY (EmployeeId) REFERENCES Employees(id);

ALTER TABLE GuaranteeFormItems
ADD CONSTRAINT FK_GuaranteeFormItem_GuaranteeForm
FOREIGN KEY (GuaranteeFormId) REFERENCES GuaranteeForms(id);

ALTER TABLE GuaranteeFormItems
ADD CONSTRAINT FK_GuaranteeFormItem_GuaranteeForm
FOREIGN KEY (GuaranteeFormId) REFERENCES GuaranteeForms(id);

ALTER TABLE GuaranteeFormItems
ADD CONSTRAINT FK_GuaranteeFormItem_GuaranteeFormCustomer
FOREIGN KEY (GuaranteeFormCustomerId) REFERENCES GuaranteeFormCustomers(id);

ALTER TABLE GuaranteeFormCustomers
ADD CONSTRAINT FK_GuaranteeFormCustomer_Customer
FOREIGN KEY (CustomerId) REFERENCES Customers(id);

ALTER TABLE GuaranteeFormCustomers
ADD CONSTRAINT FK_GuaranteeFormCustomer_Employee
FOREIGN KEY (EmployeeId) REFERENCES Employees(id);

ALTER TABLE GuaranteeFormCustomers
ADD CONSTRAINT FK_GuaranteeFormCustomer_Product
FOREIGN KEY (ProductId) REFERENCES Products(id);

ALTER TABLE BillDeliveries
ADD CONSTRAINT FK_BillDelivery_Bill
FOREIGN KEY (BillId) REFERENCES Bills(id);

ALTER TABLE BillDeliveryInfoes
ADD CONSTRAINT FK_BillDeliveryInfo_BillDelivery
FOREIGN KEY (BillDeliveryId) REFERENCES BillDeliveries(id);

ALTER TABLE BillDeliveryInfoItems
ADD CONSTRAINT FK_BillDeliveryInfoItem_BillDeliveryInfo
FOREIGN KEY (BillDeliveryInfoId) REFERENCES BillDeliveryInfoes(id);

ALTER TABLE BillDeliveryInfoItems
ADD CONSTRAINT FK_BillDeliveryInfoItem_Product
FOREIGN KEY (ProductId) REFERENCES Products(id);

ALTER TABLE Products
ADD CONSTRAINT FK_Product_Manufacturer
FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers(id);

ALTER TABLE Products
ADD CONSTRAINT FK_Product_ProductCategory
FOREIGN KEY (ProductCategoryId) REFERENCES ProductCategories(id);

ALTER TABLE OrderForms
ADD CONSTRAINT FK_OrderForm_Supplier
FOREIGN KEY (SupplierId) REFERENCES Suppliers(id);

ALTER TABLE OrderForms
ADD CONSTRAINT FK_OrderForm_Employee
FOREIGN KEY (EmployeeId) REFERENCES Employees(id);

ALTER TABLE OrderFormItems
ADD CONSTRAINT FK_OrderFormItems_OrderForm
FOREIGN KEY (OrderFormId) REFERENCES OrderForms(id);

ALTER TABLE OrderFormItems
ADD CONSTRAINT FK_OrderFormItems_Product
FOREIGN KEY (ProductId) REFERENCES Products(id);

ALTER TABLE OrderFormPayments
ADD CONSTRAINT FK_OrderFormPayment_OrderForm
FOREIGN KEY (OrderFormId) REFERENCES OrderForms(id);

ALTER TABLE ReceiveForms
ADD CONSTRAINT FK_ReceiveForm_OrderForm
FOREIGN KEY (OrderId) REFERENCES OrderForms(id);

ALTER TABLE ReceiveForms
ADD CONSTRAINT FK_ReceiveForm_Employee
FOREIGN KEY (EmployeeId) REFERENCES Employees(id);

ALTER TABLE ReceiveFormItems
ADD CONSTRAINT FK_ReceiveFormItem_ReceiveForm
FOREIGN KEY (ReceiveFormId) REFERENCES ReceiveForms(id);

ALTER TABLE ReceiveFormItems
ADD CONSTRAINT FK_ReceiveFormItem_Product
FOREIGN KEY (ProductId) REFERENCES Products(id);








