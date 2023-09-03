Use PaySpaceTaxCalculation
go

--Add Flat Value Tax
INSERT INTO [dbo].[tblFlatValueTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (5.00
           ,0.00
           ,200000.00
           ,0)
GO

-- Add FLatRate Tax
INSERT INTO [dbo].[tblFlatRateTax]
           ([Rate],[isDeleted])
     VALUES
           (17.5,0)
GO

-- Add Progressive Tax

INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (10.00
           ,0.00
           ,8350.00
           ,0)
GO


INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (15.00
           ,8351.00
           ,33950.00
           ,0)
GO


INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (25.00
           ,33951.00
           ,82250.00
           ,0)
GO


INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (28.00
           ,82251.00
           ,171550
           ,0)
GO


INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (33.00
           ,171551.00
           ,372950.00
           ,0)
GO


INSERT INTO [dbo].[tblProgressiveTax]
           ([Rate]
           ,[FromValue]
           ,[ToValue]
           ,[isDeleted])
     VALUES
           (35.00
           ,372951.00
           ,0
           ,0)
GO

-- Add Postal Codes

INSERT INTO [dbo].[tblPostalCode]
           ([PostalCode]
           ,[TaxType]
           ,[isDeleted])
     VALUES
           ('7441'
           ,'Progressive'
           ,0)
GO

INSERT INTO [dbo].[tblPostalCode]
           ([PostalCode]
           ,[TaxType]
           ,[isDeleted])
     VALUES
           ('A100'
           ,'Flat Value'
           ,0)

		   GO

INSERT INTO [dbo].[tblPostalCode]
           ([PostalCode]
           ,[TaxType]
           ,[isDeleted])
     VALUES
           ('7000'
           ,'Flat Rate'
           ,0)
		   GO

INSERT INTO [dbo].[tblPostalCode]
           ([PostalCode]
           ,[TaxType]
           ,[isDeleted])
     VALUES
           ('1000'
           ,'Progressive'
           ,0)
