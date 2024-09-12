Create OR Alter Procedure dbo.usp_GetBusinessProgressCustomerByBusinessProgressId
	@BusinessProgressId				Int			=	0
As
	BEGIN
		Select BusinessProgressId,EnrollmentId,StartingBusinessDate,[Year],[Month],NoNewCustomer,NoRepeatedCustomer,ServicesOfferedType,
												ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,CreditSellAmount,
												TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,TotalExpenditure,
												LastMonthCredit,CreditSettlement,MonthlyProfitLoss,										
												PaymentReceived,PaymentReceivedMode,CreatedBy,CreatedOn
			  From BusinessProgressForm Where BusinessProgressId=@BusinessProgressId

		Select BusinessProgressId,DigitalCategoryId From BusinessProgressDigitalCategory Where BusinessProgressId=@BusinessProgressId

		Select BPSL.BusinessProgressId,BPSL.ServiceLineId,BPSL.CustomersNo,BPSL.FilePath,BPSL.UplodedFileName
			   , DS.DigitalCategoryId
			   From BusinessProgressServiceLine BPSL INNER JOIN M_DigitalService DS On BPSL.ServiceLineId=DS.ServiceId
			   Where BusinessProgressId=@BusinessProgressId
	END