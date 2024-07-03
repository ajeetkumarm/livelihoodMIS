CREATE OR ALTER PROCEDURE [dbo].[usp_BusinessProgressCustomer_Save]
(
	@BusinessProgressId				Int			=	0,
	@EnrollmentId					Int			=	Null,
	@StartingBusinessDate			Varchar(30)	=	Null,
	@Year							Varchar(10)	=	Null,
	@Month							Varchar(10)	=	Null,
	@NoNewCustomer					Int			=	Null,
	@NoRepeatedCustomer				Int			=	Null,
	@ServicesOfferedType			Varchar(30)	=	Null,
	@ServicesProvidedDetails		NChar(10)	=	Null,
	@GovCustomerServices			Int			=	Null,
	@G2CServices					Varchar(50)	=	Null,
	@IncomefromSell					Nvarchar(50)=	Null,
	@CashSellAmount					Varchar(20)	=	Null,
	@CreditSellAmount				Varchar(20)	=	Null,
	@TotalIncome					Varchar(20)	=	Null,
	@Investment						Varchar(20)	=	Null,
	@ExpenditurefromPurchase		Nvarchar(50)=	Null,
	@CashExpenditure				Varchar(20)	=	Null,
	@CreditExpenditure				Varchar(20)	=	Null,
	@TotalExpenditure				Varchar(20)	=	Null,
	@LastMonthCredit				Varchar(20)	=	Null,
	@CreditSettlement				Varchar(20)	=	Null,
	@MonthlyProfitLoss				Varchar(20)	=	Null,
	@PaymentReceived				Varchar(30)	=	Null,
	@PaymentReceivedMode			Varchar(50)	=	Null,
	@CreatedBy						Varchar(30)	=	Null,
	@UpdatedBy						Varchar(30)	=	Null,
	@JsonDigitalCategory			Varchar(4000)=  NULL,
	@JsonServiceLine				Varchar(4000)=  NULL,
	@IsCategoryAdded				Bit			 =  0,
	@IsServiceLineAdded				Bit			 =  0
)
AS
	BEGIN
		IF NOT EXISTS (SELECT BusinessProgressId FROM BusinessProgressForm WHERE BusinessProgressId=@BusinessProgressId)
			BEGIN
				INSERT INTO BusinessProgressForm(EnrollmentId,StartingBusinessDate,[Year],[Month],NoNewCustomer,NoRepeatedCustomer,ServicesOfferedType,
												ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,CreditSellAmount,
												TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,TotalExpenditure,
												LastMonthCredit,CreditSettlement,MonthlyProfitLoss,										
												PaymentReceived,PaymentReceivedMode,CreatedBy,CreatedOn)
										VALUES(@EnrollmentId,@StartingBusinessDate,@Year,@Month,@NoNewCustomer,@NoRepeatedCustomer,@ServicesOfferedType,
												@ServicesProvidedDetails,@GovCustomerServices,@G2CServices,@IncomefromSell,@CashSellAmount,@CreditSellAmount,
												@TotalIncome,@Investment,@ExpenditurefromPurchase,@CashExpenditure,@CreditExpenditure,@TotalExpenditure,
												@LastMonthCredit,@CreditSettlement,@MonthlyProfitLoss,										
												@PaymentReceived,@PaymentReceivedMode,@CreatedBy,GETDATE())

				Set @BusinessProgressId =(SELECT SCOPE_IDENTITY())
		END
		ELSE
			BEGIN
				 Update BusinessProgressForm SET StartingBusinessDate=@EnrollmentId,[Year]=@Year,[Month]=@Month,
												 NoNewCustomer=@NoNewCustomer,NoRepeatedCustomer=@NoRepeatedCustomer,ServicesOfferedType=@ServicesOfferedType,
												ServicesProvidedDetails=@ServicesProvidedDetails,GovCustomerServices=@GovCustomerServices,G2CServices=@G2CServices,
												IncomefromSell=@IncomefromSell,CashSellAmount=@CashSellAmount,CreditSellAmount=@CreditSellAmount,TotalIncome=@TotalIncome,
												Investment=@Investment,ExpenditurefromPurchase=@ExpenditurefromPurchase,CashExpenditure=@CashExpenditure,CreditExpenditure=@CreditExpenditure,
												TotalExpenditure=@TotalExpenditure,LastMonthCredit=@LastMonthCredit,CreditSettlement=@CreditSettlement,MonthlyProfitLoss=@MonthlyProfitLoss,										
												PaymentReceived=@PaymentReceived,PaymentReceivedMode=@PaymentReceivedMode,UpdatedBy=@UpdatedBy,UpdatedOn=GETDATE()
										WHERE BusinessProgressId=@BusinessProgressId
			END

		Delete dbo.BusinessProgressDigitalCategory WHERE BusinessProgressId=@BusinessProgressId

		If @IsCategoryAdded = 1
			BEGIN
				INSERT INTO BusinessProgressDigitalCategory (BusinessProgressId,DigitalCategoryId)
				SELECT @BusinessProgressId, DigitalCategoryId
					FROM                                                     
					OPENJSON(@JsonDigitalCategory) WITH                                                    
					(                                                    
						DigitalCategoryId	INT
					)
			END

		Delete dbo.BusinessProgressServiceLine WHERE BusinessProgressId=@BusinessProgressId

		If @IsServiceLineAdded = 1
		   BEGIN
				INSERT INTO BusinessProgressServiceLine 
			   (BusinessProgressId,ServiceLineId,CustomersNo,FilePath,UplodedFileName)
				SELECT @BusinessProgressId,ServiceLineId,CustomersNo,FilePath,UplodedFileName
					FROM                                                     
					OPENJSON(@JsonServiceLine) WITH                                                    
					(                                                    
						ServiceLineId	INT,
						CustomersNo		INT,
						FilePath		Varchar(200),
						UplodedFileName	Varchar(200)
					)
		   END

		Select @BusinessProgressId
	END
