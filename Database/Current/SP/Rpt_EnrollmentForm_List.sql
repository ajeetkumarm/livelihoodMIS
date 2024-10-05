ALTER   PROCEDURE [dbo].[Rpt_EnrollmentForm_List] --[Rpt_EnrollmentForm_List] 1,1,25,25
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
				   PartSHG,EF.SHGName,SHGType,MSH.SHGName,
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
				   EF.CohortValue

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
			Order By T.RowNum

			-- Drop the temporary table
			DROP TABLE #TempResults



	--set @Query='Select BeneficiaryCode,State,MS.StateName,District,MD.DistrictName,Block,MB.BlockName,Village,mv.VillageName,
	--UL.ProjectCode,MP.ProjectName,(UL.FirstName+'' ''+UL.LastName) as UserName,WomenName,
	--HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,MC.CastName,MES.EconomicStatus,MaritalStatus,
	--CASE WHEN CONVERT(DATE, BirthDate) = ''1900-01-01''   THEN ''''  ELSE CONVERT(CHAR(20), BirthDate, 103) END BirthDate ,
	--Age,PartSHG,EF.SHGName,SHGType,MSH.SHGName,
	--CASE WHEN CONVERT(DATE, RegistrationDate) = ''1900-01-01''   THEN ''''  ELSE CONVERT(CHAR(20), RegistrationDate, 103) END RegistrationDate ,
	--CASE WHEN CONVERT(DATE, SHGDate) = ''1900-01-01''   THEN ''''  ELSE CONVERT(CHAR(20), SHGDate, 103) END SHGDate ,
	--Education,ME.EducationName,	PwD,PwDSpecify,AadhaarrCard,
	--AadhaarCardDetails,AadhaarNo,AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
	--LinkedSocialSecuritySchemes,Reasons,WomenBelong,ValidCertificate,MonthlyIndividualIncome,MonthlyHouseholdIncome,Scheme,
	--MSC.SchemeName,EF.CreatedOn,EF.UpdatedOn
	--From EnrollmentForm EF
	--INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode
	--INNER JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
	--LEFT JOIN M_State MS ON EF.State=MS.StateId
	--LEFT JOIN M_District MD ON EF.District=MD.DistrictId
	--LEFT JOIN M_BLock MB ON EF.Block=MB.BlockId
	--LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
	--LEFT JOIN M_Cast MC ON EF.Cast=MC.CastId
	--LEFT JOIN M_EconomicStatus MES ON EF.EconomicStatus=MES.EconomicId
	--LEFT JOIN M_SHG MSH ON EF.SHGType=MSH.SHGId
	--LEFT JOIN M_Education ME ON EF.Education=ME.EducationId
	--LEFT JOIN M_Scheme MSC ON EF.Scheme=MSC.SchemeId
	--where 1=1 '+@condition+''
	----WHERE EF.CreatedBy=@LoginUser or isnull(@LoginUser,0)=0'

	--print(@Query)
	--exec sp_sqlexec @Query 
END
