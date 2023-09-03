Use PaySpaceTaxCalculation
go

if not Exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'tblFlatRateTax')
Begin
 CREATE TABLE [dbo].[tblFlatRateTax](
	[FlatRateID] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 2) NULL,
	[isDeleted] [int] NULL
 CONSTRAINT [PK_tblFlatRateTax] PRIMARY KEY CLUSTERED 
(
	[FlatRateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
End
go

if not Exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'tblFlatValueTax')
Begin
 CREATE TABLE [dbo].[tblFlatValueTax](
	[FlatValueID] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 2) NULL,
	[FromValue] [decimal](18, 2) NULL,
	[ToValue] [decimal](18, 2) NULL,
	[isDeleted] [int] NULL
 CONSTRAINT [PK_tblFlatValueTax] PRIMARY KEY CLUSTERED 
(
	[FlatValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
End
go

if not Exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'tblPostalCode')
Begin
 CREATE TABLE [dbo].[tblPostalCode](
	[PostalCodeID] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[TaxType] [varchar](50) NOT NULL,
	[isDeleted] [int] NOT NULL
 CONSTRAINT [PK_tblPostalCode] PRIMARY KEY CLUSTERED 
(
	[PostalCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
End
go

if not Exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'tblProgressiveTax')
Begin
 CREATE TABLE [dbo].[tblProgressiveTax](
	[ProgressiveTaxID] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 2) NULL,
	[FromValue] [decimal](18, 2) NULL,
	[ToValue] [decimal](18, 2) NULL,
	[isDeleted] [int] NULL
 CONSTRAINT [PK_tblProgressiveTax] PRIMARY KEY CLUSTERED 
(
	[ProgressiveTaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
End
go

if not Exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'tblUserTaxList')
Begin
 CREATE TABLE [dbo].[tblUserTaxList](
	[UserTaxID] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](50) NULL,
	[TaxType] [varchar](50) NULL,
	[AnnualIncome] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
	[isDeleted] [int] NULL
	 
 CONSTRAINT [PK_tblUserTaxList] PRIMARY KEY CLUSTERED 
(
	[UserTaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
End
go

 