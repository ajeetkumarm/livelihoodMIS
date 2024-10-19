ALTER     PROCEDURE [dbo].[Rpt_consolidated_List] 
(
	@CreatedUser		varchar(50)='2',
	@Project			varchar(50)='1',
	@PageNumber			int = 1,
	@PageSize			int = 10,
	@Search				Varchar(100)=Null
)
AS
BEGIN
	DECLARE @LoginUser varchar(max),@UserCategory varchar(max),
			@Query nvarchar(max)='', 
			@InputUserCategory varchar(max) , @input varchar(max),@condition nvarchar(max)='',@searchCondition nvarchar(max) = ''

	Set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)
	Print @UserCategory

	If(@UserCategory=1)
		begin
			set @condition=@condition
		end
	Else if(@UserCategory=7)
		begin
			set @condition= 'and EF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
		end
	Else
		Begin
			Set @InputUserCategory=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCategory AS VARCHAR(10)) [text()]
								FROM UserLogin   where UserCategory not in (1)    FOR XML PATH(''), TYPE)
								.value('.','NVARCHAR(MAX)'),1,1,'') UserCategory FROM UserLogin t)		

			Set @Input=(SELECT CHARINDEX(@UserCategory, @InputUserCategory) AS MatchPosition)
			
		   Set @InputUserCategory=(select SUBSTRING(@InputUserCategory, @Input+0 , LEN(@InputUserCategory)))
		  --print @InputUserCategory

		  Set @LoginUser=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCode AS VARCHAR(10)) [text()]
						FROM UserLogin    WHERE  1=1 and cast(UserCategory as nvarchar) not  in(1)
						or cast(UserCategory as nvarchar)   in(''+@InputUserCategory+'')
							
						FOR XML PATH(''), TYPE)
						.value('.','NVARCHAR(MAX)'),1,1,'') UserCode FROM UserLogin t)

			
		
		Set @condition= 'and EF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '			
	End

	If(@Search IS NOT NULL)
		Begin
			Set @searchCondition = ' AND EF.WomenName LIKE ''%' + @Search + '%'''
		End

	-- Create a temporary table to store the results
	CREATE TABLE #TempResults (
		RowNum			 INT,
		EnrollmentId	 INT,
		TotalCount		 INT,
		ProjectCode		 INT,
		ProjectName		 Varchar(100),
		UserName		 Varchar(100)
	)


	Set @Query = 'WITH CTE AS (
					SELECT 
							ROW_NUMBER() OVER (ORDER BY EF.EnrollmentId) AS RowNum,
							EF.EnrollmentId, 
							COUNT(*) OVER() AS TotalCount,
							UL.ProjectCode,
							MP.ProjectName ,
							(UL.FirstName+'' ''+UL.LastName) AS UserName 
					FROM EnrollmentForm EF  
					INNER JOIN UserLogin UL ON EF.CreatedBy = UL.UserCode  
					Left JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
					WHERE 1=1 ' + @condition + @searchCondition +'
					)
					INSERT INTO #TempResults (RowNum,EnrollmentId, TotalCount,ProjectCode,ProjectName,UserName)
					SELECT RowNum,EnrollmentId, TotalCount,ProjectCode,ProjectName,UserName
					FROM CTE 
						  
					ORDER BY RowNum 
					OFFSET ' + CAST(@PageNumber AS NVARCHAR(10))   + ' ROWS 
					FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY
					'

	EXEC sp_executesql @Query

	SELECT	T.RowNum, T.EnrollmentId, T.TotalCount, 
				   BeneficiaryCode,
				   --[State],
				   S.StateName,
				   --District,
				   D.DistrictName,
				   --[Block],
				   B.BlockName,
				   --Village,
				   V.VillageName,  
				   T.ProjectCode,T.ProjectName,T.UserName,WomenName,
				   HusbandFatherName,MotherName,PhoneNo,ThemeCode,[Cast],MC.CastName,MES.EconomicStatus,MaritalStatus,BirthDate,Age,
				   PartSHG,EF.SHGName,MSH.SHGName AS SHGType,
				   convert(varchar(30), RegistrationDate) RegistrationDate,  
				   convert(varchar(30), SHGDate) SHGDate,  
				   
				   Education,ME.EducationName,	PwD,PwDSpecify,AadhaarrCard,
				   AadhaarCardDetails,AadhaarNo,AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
				   LinkedSocialSecuritySchemes,Reasons,WomenBelong,ValidCertificate,MonthlyIndividualIncome,MonthlyHouseholdIncome,Scheme,
				   MSC.SchemeName,EF.CreatedOn,EF.UpdatedOn,
				   EF.EmployeeId,
				   EF.ReplacementEmployeeId,
				   EF.ReplacementBeneficiaryCode,
				   EF.EnrollmentStatus,
				   EF.CohortValue,
				   EF.SHGId,
				   -- Add EDP Training Report Data
				   TF.IsLifeSkillsTraining,
				   TF.RCSCDate,TF.WRPCDate,TF.HNCDate,TF.FLCDate,TF.EDTSDate,
				   TF.LEAPDate,TF.ESISDate ,TF.BMTCDate,TF.MMTCDate,TF.EDPTCDate ,TF.IsTrainingCompleted,
				   TF.IsInductionTraining,TF.IsDigitalSkillTraining, 
				   TF.InductionTrainingDay1,
				   TF.InductionTrainingDay2,
				   TF.DigitalSkillTrainingDay1,
				   TF.DigitalSkillTrainingDay2,
				   TF.DigitalSkillTrainingDay3,
				   TF.EDPIntroDay1,
				   TF.BusinessPlanDay2,TF.FinancialLiteracyDay3,TF.FinancialTermsDay4,TF.BusinessManagementDay5	
				   -- Add Enterpries Training Report
				   ,ETF.StartBusiness,ETF.BusinessReasons,ETF.Business,ETF.BusinessWhen,ETF.StatusBusiness,ETF.VillagePopulation,
					ETF.BusinessIdea,ETF.BusinessType,ETF.ProcureBusiness ,ETF.CurrentBusiness,ETF.RegularFinancialBusiness,ETF.HowRegularFinancial,
					ETF.SettingBusinessType,ETF.MonthlyRent,ETF.ExpandBusiness,ETF.PotentialCustomers,ETF.BusinessDistance,ETF.ExpectedFootfall,
					ETF.HowFarBussiness ,ETF.PlanningBusiness ,ETF.SupportBusiness ,ETF.SupportType ,ETF.NotProvidedSupport,
					ETF.PaidWorker ,ETF.DigitalInclusion ,ETF.DigitalInclusionDate,ETF.OwnSmartPhone,ETF.UseSmartPhone,ETF.SupplyChain,
					ETF.IsCompleteEntTraining


			FROM #TempResults T INNER JOIN  EnrollmentForm EF  On T.EnrollmentId=EF.EnrollmentId
			INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode  
			LEFT JOIN M_State S On EF.State=S.StateId  
			LEFT JOIN M_District D On EF.District=D.DistrictId  
			LEFT JOIN M_BLock B On EF.Block=B.BlockId  
			LEFT JOIN M_Village V On EF.Village=V.VillageId  
			LEFT JOIN M_Cast MC ON EF.[Cast]=MC.CastId
			LEFT JOIN M_EconomicStatus MES ON EF.EconomicStatus=MES.EconomicId
			LEFT JOIN M_SHG MSH ON EF.SHGType=MSH.SHGId
			LEFT JOIN M_Education ME ON EF.Education=ME.EducationId
			LEFT JOIN M_Scheme MSC ON EF.Scheme=MSC.SchemeId
			Left JOIN TrainingForm TF On EF.EnrollmentId=TF.EnrollmentId
			Left JOIN EnterpriesTrainingForm ETF On EF.EnrollmentId=ETF.EnrollmentId
			Order By T.RowNum

			-- Drop the temporary table
			DROP TABLE #TempResults



	
END
