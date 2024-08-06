CREATE OR ALTER PROCEDURE [dbo].[Rpt_BusinessProgressForm_List] --[Rpt_BusinessProgressForm_List] 1,1,0,25
(
	@CreatedUser varchar(50)='25',
	@Project varchar(50)='4',
	@PageNumber				Int = 1,
	@PageSize				Int = 10,
	@Search					Varchar(100)=Null
)
AS
BEGIN
	DECLARE @LoginUser varchar(max),@UserCategory varchar(max),@Query nvarchar(max)='', 
			@InputUserCategory varchar(max) , @input varchar(max),@condition nvarchar(max)='',@searchCondition nvarchar(max) = ''

		set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)

		print @UserCategory
		 If(@UserCategory=1)
			 begin
				set @condition=@condition
			 end
		 Else if(@UserCategory=7)
			 begin
				set @condition= 'and BPF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
			 end
		 Else
			 Begin
				 set @InputUserCategory=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCategory AS VARCHAR(10)) [text()]
									  FROM UserLogin   where UserCategory not in (1)    FOR XML PATH(''), TYPE)
									  .value('.','NVARCHAR(MAX)'),1,1,'') UserCategory FROM UserLogin t)		

			set @Input=(SELECT CHARINDEX(@UserCategory, @InputUserCategory) AS MatchPosition)
			
				set @InputUserCategory=(select SUBSTRING(@InputUserCategory, @Input+0 , LEN(@InputUserCategory)))
				--print @InputUserCategory

				set @LoginUser=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCode AS VARCHAR(10)) [text()]
								FROM UserLogin    WHERE  1=1 and cast(UserCategory as nvarchar) not  in(1)
								or cast(UserCategory as nvarchar)   in(''+@InputUserCategory+'')
							
								FOR XML PATH(''), TYPE)
								.value('.','NVARCHAR(MAX)'),1,1,'') UserCode FROM UserLogin t)

			
				print @LoginUser
		
				  set @condition= 'and BPF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '			
			End


		  If(@Search IS NOT NULL)
			Begin
				Set @searchCondition = ' AND EF.WomenName LIKE ''%' + @Search + '%'''
			End

			-- Create a temporary table to store the results
			CREATE TABLE #TempResults (
				RowNum					INT,
				BusinessProgressId		INT,
				TotalCount				INT,
				ProjectCode				INT,
				ProjectName				Varchar(100),
				UserName				Varchar(100)
			)

			Set @Query = '; WITH CTE AS (
					SELECT 
							ROW_NUMBER() OVER (ORDER BY BPF.BusinessProgressId) AS RowNum,
							BPF.BusinessProgressId, 
							COUNT(*) OVER() AS TotalCount,
							UL.ProjectCode,
							MP.ProjectName ,
							(UL.FirstName+'' ''+UL.LastName) AS UserName 
					FROM BusinessProgressForm BPF  
					INNER JOIN UserLogin UL ON BPF.CreatedBy = UL.UserCode  
					INNER JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
					INNER JOIN EnrollmentForm EF on EF.EnrollmentId=BPF.EnrollmentId
					WHERE 1=1 ' + @condition + @searchCondition +'
					)
					INSERT INTO #TempResults (RowNum,BusinessProgressId,TotalCount,ProjectCode,ProjectName,UserName)
					SELECT RowNum,BusinessProgressId, TotalCount,ProjectCode,ProjectName,UserName
					FROM CTE 
						  
					ORDER BY RowNum 
					OFFSET ' + CAST(@PageNumber AS NVARCHAR(10))   + ' ROWS 
					FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY'

				--set @Query='Select BusinessProgressId,BPF.EnrollmentId,
				--			BeneficiaryCode,State,MS.StateName,District,MD.DistrictName,Block,MB.BlockName,Village,mv.VillageName,
				--			UL.ProjectCode,MP.ProjectName,(UL.FirstName+'' ''+UL.LastName) as UserName,WomenName,
				--			StartingBusinessDate,Year,Month,NoNewCustomer,NoRepeatedCustomer,
				--			ServicesOfferedType,ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,
				--			CreditSellAmount,TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,
				--			TotalExpenditure,LastMonthCredit,CreditSettlement,MonthlyProfitLoss,PaymentReceived,PaymentReceivedMode,
				--			BPF.CreatedOn,BPF.UpdatedOn	From BusinessProgressForm BPF
				--			INNER JOIN UserLogin UL ON BPF.CreatedBy=UL.UserCode
				--			INNER JOIN EnrollmentForm EF on EF.EnrollmentId=BPF.EnrollmentId
				--			INNER JOIN M_State MS ON EF.State=MS.StateId
				--			INNER JOIN M_District MD ON EF.District=MD.DistrictId
				--			INNER JOIN M_BLock MB ON EF.Block=MB.BlockId
				--			INNER JOIN M_Village MV ON EF.Village=MV.VillageId
				--			INNER JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
				--			where 1=1 '+@condition+''

			print(@Query)
			exec sp_sqlexec @Query 

			Select T.RowNum,  T.TotalCount, T.BusinessProgressId, EF.EnrollmentId,
					EF.BeneficiaryCode, MS.StateName, MD.DistrictName, MB.BlockName,
					MV.VillageName, T.ProjectCode,T.ProjectName, T.UserName, EF.WomenName,
					StartingBusinessDate,[Year],[Month],NoNewCustomer,NoRepeatedCustomer,
					ServicesOfferedType,ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,
					CreditSellAmount,TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,
					TotalExpenditure,LastMonthCredit,CreditSettlement,MonthlyProfitLoss,PaymentReceived,PaymentReceivedMode,
					BPF.CreatedOn,BPF.UpdatedOn
					From #TempResults T 
					INNER JOIN BusinessProgressForm BPF On T.BusinessProgressId=BPF.BusinessProgressId
					LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=BPF.EnrollmentId
					LEFT JOIN M_State MS ON EF.[State]=MS.StateId
					LEFT JOIN M_District MD ON EF.District=MD.DistrictId
					LEFT JOIN M_BLock MB ON EF.[Block]=MB.BlockId
					LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
					Order by T.RowNum
					
			-- Drop the temporary table
			DROP TABLE #TempResults
END
