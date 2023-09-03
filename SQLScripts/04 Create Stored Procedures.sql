Use PaySpaceTaxCalculation
go

-- Delete User Tax Items Procedure
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spDeleteUserTaxList'))
   exec('CREATE PROCEDURE [dbo].[spDeleteUserTaxList] AS BEGIN SET NOCOUNT ON; END')
GO

	Alter PROCEDURE spDeleteUserTaxList (
		@ID as int
	) AS
	BEGIN  
		  Update [tblUserTaxList] set isDeleted = 1 , DateUpdated = GetDate() where [UserTaxID] =@ID
End

Go

-- Get List of Tax Items
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spGetUserTaxList'))
   exec('CREATE PROCEDURE [dbo].[spGetUserTaxList] AS BEGIN SET NOCOUNT ON; END')
GO
Alter PROCEDURE spGetUserTaxList AS
BEGIN
SELECT [UserTaxID]
      ,[PostalCode]
      ,[TaxType]
      ,[AnnualIncome]
      ,[TaxAmount]
      ,[DateCreated]
      ,[DateUpdated]
      ,[isDeleted]
  FROM [tblUserTaxList] where [isDeleted] = 0 order by [DateCreated] DESC
END
Go

-- Add User Tax Item
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spAddUserTaxList'))
   exec('CREATE PROCEDURE [dbo].[spAddUserTaxList] AS BEGIN SET NOCOUNT ON; END')
GO

	Alter PROCEDURE spAddUserTaxList (
	@PostalCode as varchar(50)
	,@TaxType as varchar(50)
	,@AnnualIncome as decimal(18,2)
	,@TaxAmount as decimal(18,2)
) AS
BEGIN 

  Insert Into [tblUserTaxList](
	   [PostalCode]
      ,[TaxType]
      ,[AnnualIncome]
      ,[TaxAmount]
      ,[DateCreated]
      ,[DateUpdated]
      ,[isDeleted])
	  Values
	  (@PostalCode,@TaxType,@AnnualIncome,@TaxAmount,GETDATE(),GETDATE(),0)
End
Go

-- Get Postal Codes

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spGetPostalCodes'))
   exec('CREATE PROCEDURE [dbo].[spGetPostalCodes] AS BEGIN SET NOCOUNT ON; END')
GO

	Alter PROCEDURE spGetPostalCodes AS
BEGIN
	Select * from tblPostalCode where isDeleted =0
End
Go


--Calculate Progresive Tax
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spCalculateProgressiveTax'))
   exec('CREATE PROCEDURE [dbo].[spCalculateProgressiveTax] AS BEGIN SET NOCOUNT ON; END')
GO

	Alter PROCEDURE spCalculateProgressiveTax (
    @AnnualIncome decimal(18,2),
    @TaxValue decimal(18,2) OUTPUT
) AS
BEGIN
    declare @rate as decimal(18,2), 
	@sumRateOne as decimal(18,2),
	@sumRateTwo as decimal(18,2),
	@sumRateThree as decimal(18,2),
	@sumRatefour as decimal(18,2),
	@sumRatefive as decimal(18,2),
	@NewAnnualAmount as decimal(18,2)

	
	set @sumRateOne = (8350 * 10/100);
	set @sumRateTwo = ((33950-8350) * 15/100);
	set @sumRateThree = ((82250-33950) * 25/100);
	set @sumRatefour = ((171550-82250) * 28/100);
	set @sumRatefive = ((372950-171550) * 33/100);

	if(@AnnualIncome < 8351)
	Begin
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 1;
		set @TaxValue =  (@AnnualIncome * @rate/100);
		 
	end

	Else if(@AnnualIncome < 33951)
	Begin
		set @NewAnnualAmount = @AnnualIncome - 8350;
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 2;
		set @TaxValue =  (@NewAnnualAmount * @rate/100) + @sumRateOne;
		 
	End

	Else if(@AnnualIncome < 82251)
	Begin
		set @NewAnnualAmount = @AnnualIncome - 33950;
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 3;
		set @TaxValue =  (@NewAnnualAmount * @rate/100) + (@sumRateOne + @sumRateTwo);
		 
	End

	Else if(@AnnualIncome < 171551)
	Begin
		set @NewAnnualAmount = @AnnualIncome - 82250;
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 4;
		set @TaxValue =  (@NewAnnualAmount * @rate/100) + (@sumRateOne + @sumRateTwo+@sumRateThree);
		 
	End

	Else if(@AnnualIncome < 372951)
	Begin
		set @NewAnnualAmount = @AnnualIncome - 171550;
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 5;
		set @TaxValue =  (@NewAnnualAmount * @rate/100) + (@sumRateOne + @sumRateTwo + @sumRateThree + @sumRatefour);
		 
	End
	
	Else if(@AnnualIncome > 372950)
	Begin
		set @NewAnnualAmount = @AnnualIncome - 372950;
		select @rate = rate from tblProgressiveTax where [ProgressiveTaxID] = 6;
		set @TaxValue = (@NewAnnualAmount * @rate/100) + (@sumRateOne + @sumRateTwo + @sumRateThree + @sumRatefour + @sumRatefive);
		 
	End
	Else
	Begin
		set @TaxValue = 0;
	End
END
Go

-- Calculate Tax Values
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spCalculateTax'))
   exec('CREATE PROCEDURE [dbo].[spCalculateTax] AS BEGIN SET NOCOUNT ON; END')
GO

	Alter PROCEDURE spCalculateTax (
	@TaxType as varchar(50),
    @AnnualIncome decimal(18,2)
) AS
BEGIN
	Declare @Rate as decimal(18,2);
	
If(@TaxType = 'Flat Value')
Begin
	If(@AnnualIncome <200000)
	Begin
		Select @Rate = rate from tblFlatValueTax;
		Select @AnnualIncome * @Rate/100;		
	End
	Else
	Begin

		Select 10000;
	End
End
Else IF(@TaxType = 'Flat Rate')
Begin
	select @Rate = rate from tblFlatRateTax where isDeleted =0;
	Select @AnnualIncome * @Rate/100;
End
Else IF(@TaxType = 'Progressive')
Begin
	Declare @TaxValue as decimal(18,2);
	Exec spCalculateProgressiveTax @AnnualIncome,@TaxValue OUTPUT;
	Select @TaxValue;
End
Else
	Select 0;
End
Go

