Create OR ALTER Procedure dbo.usp_GetBusinessProgressFormByEnrollmentId -- usp_GetBusinessProgressFormByEnrollmentId 0,10,10,Null
@EnrollmentId			INT,
@PageNumber				Int = 1,
@PageSize				Int = 10,
@SearchText				Varchar(50)=NUll
AS
	BEGIN
		
		CREATE TABLE #TempResults (
				RowNum					INT,
				BusinessProgressId		INT,
				TotalCount				INT
			)

			;WITH CTE AS (
							SELECT 
									ROW_NUMBER() OVER (ORDER BY BPF.BusinessProgressId ) AS RowNum,
									BPF.BusinessProgressId, 
								    COUNT(*) OVER() AS TotalCount
							FROM BusinessProgressForm BPF  
							INNER JOIN EnrollmentForm EF on EF.EnrollmentId=BPF.EnrollmentId
							WHERE 1=1
							AND BPF.EnrollmentId=@EnrollmentId
							AND (@SearchText IS NULL OR EF.WomenName LIKE '%' + @SearchText + '%' )
							
							
						  )
						  INSERT INTO #TempResults (RowNum,BusinessProgressId, TotalCount)
						  SELECT RowNum,BusinessProgressId, TotalCount
						  FROM CTE 
						  
						  ORDER BY RowNum 
						  OFFSET @PageNumber ROWS 
						  FETCH NEXT @PageSize ROWS ONLY




		Select BPF.BusinessProgressId,BPF.EnrollmentId,
				BeneficiaryCode,MS.StateName,MD.DistrictName,MB.BlockName,mv.VillageName,
				MP.ProjectName,(UL.FirstName+' '+UL.LastName) as UserName,WomenName,
				StartingBusinessDate,[Year],[Month],NoNewCustomer,NoRepeatedCustomer,
				ServicesOfferedType,ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,
				CreditSellAmount,TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,
				TotalExpenditure,LastMonthCredit,CreditSettlement,MonthlyProfitLoss,PaymentReceived,PaymentReceivedMode,
				BPF.CreatedOn,BPF.UpdatedOn	
				,R.TotalCount
				,R.RowNum
				From BusinessProgressForm BPF
				INNER JOIN #TempResults R ON BPF.BusinessProgressId=R.BusinessProgressId
				LEFT JOIN UserLogin UL ON BPF.CreatedBy=UL.UserCode
				LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=BPF.EnrollmentId
				LEFT JOIN M_State MS ON EF.State=MS.StateId
				LEFT JOIN M_District MD ON EF.District=MD.DistrictId
				LEFT JOIN M_BLock MB ON EF.Block=MB.BlockId
				LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
				LEFT JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
				--where 1=1 AND BPF.EnrollmentId=@EnrollmentId 
				-- Order By CreatedOn desc

		-- Drop the temporary table
			DROP TABLE #TempResults  
	END