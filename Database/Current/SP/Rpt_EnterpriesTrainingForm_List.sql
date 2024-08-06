Create OR ALTER PROCEDURE [dbo].[Rpt_EnterpriesTrainingForm_List] --[Rpt_EnterpriesTrainingForm_List] 1,1,25,25
(
	@CreatedUser			Varchar(50)='9',
	@Project				Varchar(50)='3',
	@PageNumber				Int = 1,
	@PageSize				Int = 10,
	@Search					Varchar(100)=Null
)
AS
BEGIN
	DECLARE @LoginUser varchar(max),@UserCategory varchar(max),@Query nvarchar(max)='', @InputUserCategory varchar(max) , @input varchar(max),@condition nvarchar(max)='',
			@searchCondition nvarchar(max) = ''

		SET @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)
		--print @UserCategory

		If(@UserCategory=1)
			begin
			set @condition=@condition
			end
		Else if(@UserCategory=7)
			Begin
				set @condition= 'and ETF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
			End
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
		
			  set @condition= 'and ETF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '			
			End

		If(@Search IS NOT NULL)
			Begin
				Set @searchCondition = ' AND EF.WomenName LIKE ''%' + @Search + '%'''
			End

		-- Create a temporary table to store the results
		CREATE TABLE #TempResults (
			RowNum			 INT,
			EntTrainingId	 INT,
			TotalCount		 INT,
			ProjectCode		 INT,
			ProjectName		 Varchar(100),
			UserName		 Varchar(100)
		)

		--Print 'Table Created'

		Set @Query = '; WITH CTE AS (
					SELECT 
							ROW_NUMBER() OVER (ORDER BY ETF.EntTrainingId) AS RowNum,
							ETF.EntTrainingId, 
							COUNT(*) OVER() AS TotalCount,
							UL.ProjectCode,
							MP.ProjectName ,
							(UL.FirstName+'' ''+UL.LastName) AS UserName 
					FROM EnterpriesTrainingForm ETF  
					INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode  
					INNER JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
					INNER JOIN EnrollmentForm EF on EF.EnrollmentId=ETF.EnrollmentId
					WHERE 1=1 ' + @condition + @searchCondition +'
					)
					INSERT INTO #TempResults (RowNum,EntTrainingId, TotalCount,ProjectCode,ProjectName,UserName)
					SELECT RowNum,EntTrainingId, TotalCount,ProjectCode,ProjectName,UserName
					FROM CTE 
						  
					ORDER BY RowNum 
					OFFSET ' + CAST(@PageNumber AS NVARCHAR(10))   + ' ROWS 
					FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY
					'
		
		Exec sp_sqlexec @Query  


		Select T.RowNum,  T.TotalCount, T.EntTrainingId, EF.EnrollmentId,
					EF.BeneficiaryCode, MS.StateName, MD.DistrictName, MB.BlockName,
					MV.VillageName, T.ProjectCode,T.ProjectName, T.UserName, EF.WomenName,

					StartBusiness,BusinessReasons,Business,BusinessWhen,StatusBusiness,VillagePopulation,
					BusinessIdea,BusinessType,ProcureBusiness ,CurrentBusiness,RegularFinancialBusiness,HowRegularFinancial,
					SettingBusinessType,MonthlyRent,ExpandBusiness,PotentialCustomers,BusinessDistance,ExpectedFootfall,
					HowFarBussiness ,PlanningBusiness ,SupportBusiness ,SupportType ,NotProvidedSupport,
					PaidWorker ,DigitalInclusion ,DigitalInclusionDate,OwnSmartPhone,UseSmartPhone,SupplyChain,
					IsCompleteEntTraining ,ETF.CreatedOn,ETF.UpdatedOn

					From #TempResults T 
					INNER JOIN EnterpriesTrainingForm ETF On T.EntTrainingId=ETF.EntTrainingId
					LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=ETF.EnrollmentId
					LEFT JOIN M_State MS ON EF.[State]=MS.StateId
					LEFT JOIN M_District MD ON EF.District=MD.DistrictId
					LEFT JOIN M_BLock MB ON EF.[Block]=MB.BlockId
					LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
					Order by T.RowNum
					
		-- Drop the temporary table
		DROP TABLE #TempResults


	--set @Query='SELECT EntTrainingId,ETF.EnrollmentId,
	--			BeneficiaryCode,State,MS.StateName,District,MD.DistrictName,Block,MB.BlockName,Village,mv.VillageName,
	--			UL.ProjectCode,MP.ProjectName,(UL.FirstName+'' ''+UL.LastName) as UserName,WomenName,
	--			StartBusiness,BusinessReasons,Business,BusinessWhen,StatusBusiness,VillagePopulation,
	--			BusinessIdea,BusinessType,ProcureBusiness ,CurrentBusiness,RegularFinancialBusiness,HowRegularFinancial,
	--			SettingBusinessType,MonthlyRent,ExpandBusiness,PotentialCustomers,BusinessDistance,ExpectedFootfall,
	--			HowFarBussiness ,PlanningBusiness ,SupportBusiness ,SupportType ,NotProvidedSupport,
	--			PaidWorker ,DigitalInclusion ,DigitalInclusionDate,OwnSmartPhone,UseSmartPhone,SupplyChain,
	--			IsCompleteEntTraining ,ETF.CreatedOn,ETF.UpdatedOn
	--			FROM EnterpriesTrainingForm ETF
	--			LEFT JOIN UserLogin UL ON ETF.CreatedBy=UL.UserCode
	--			LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=ETF.EnrollmentId
	--			LEFT JOIN M_State MS ON EF.State=MS.StateId
	--			LEFT JOIN M_District MD ON EF.District=MD.DistrictId
	--			LEFT JOIN M_BLock MB ON EF.Block=MB.BlockId
	--			LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
	--			LEFT JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
	--			where 1=1 '+@condition+''

	--print(@Query)
	--exec sp_sqlexec @Query 
END