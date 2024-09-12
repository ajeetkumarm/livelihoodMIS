
--Alter Table BusinessProgressForm
--Add IsImported Bit Not Null Default(0)

--Alter Table BusinessProgressForm
--Add ImportedDate DateTime

--Select * From BusinessProgressForm

INSERT INTO BusinessProgressForm
(EnrollmentId,StartingBusinessDate,[Year],[Month],NoNewCustomer,
 NoRepeatedCustomer,ServicesOfferedType,ServicesProvidedDetails,
 GovCustomerServices,G2CServices, IncomefromSell, 
 CashSellAmount,CreditSellAmount,TotalIncome,Investment,
 ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,TotalExpenditure, 
 LastMonthCredit,CreditSettlement,MonthlyProfitLoss,PaymentReceived,PaymentReceivedMode,CreatedBy,
 CreatedOn,IsImported,ImportedDate)
 Select E.EnrollmentId,
 BGE.StartingBusinessDate, BGE.[Year], BGE.[Month], BGE.NoNewCustomer, BGE.NoRepeatedCustomer, 
 BGE.ServicesOfferedType, BGE.ServicesProvidedDetails, 
 BGE.GovCustomerServices, BGE.G2CServices, BGE.IncomefromSell, BGE.CashSellAmount, 
 BGE.CreditSellAmount, BGE.TotalIncome, BGE.Investment, 
 BGE.ExpenditurefromPurchase, BGE.CashExpenditure, BGE.CreditExpenditure, BGE.TotalExpenditure, 
 BGE.LastMonthCredit, BGE.CreditSettlement, BGE.MonthlyProfitLoss, BGE.PaymentReceived, BGE.PaymentReceivedMode
 ,E.CreatedBy, GETDATE(), 1, GETDATE()
 From 
 BusinessProgressExcel BGE 
 Inner Join EnrollmentForm E On BGE.[Beneficiary Code]=E.BeneficiaryCode


 --Select Count(1) From BusinessProgressExcel