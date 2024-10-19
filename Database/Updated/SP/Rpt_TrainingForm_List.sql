ALTER   PROCEDURE [dbo].[Rpt_TrainingForm_List] --[Rpt_TrainingForm_List] 1,1,25,25
(
	@CreatedUser			Varchar(50)='9',
	@Project				Varchar(50)='3',
	@PageNumber				Int = 1,
	@PageSize				Int = 10,
	@Search					Varchar(100)=Null
)
AS
BEGIN
	DECLARE @LoginUser varchar(max),@UserCategory varchar(max),
			@Query nvarchar(max)='', 
			@InputUserCategory varchar(max) , @input varchar(max),@condition nvarchar(max)='',@searchCondition nvarchar(max) = ''

		set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)
		print @UserCategory
		 if(@UserCategory=1)
		 begin
			set @condition=@condition
		 end
		 else if(@UserCategory=7)
		 begin
			set @condition= 'and TF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
		 end
		 else
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

			
			--print @LoginUser
		
			 set @condition= 'and TF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '			
		End

		If(@Search IS NOT NULL)
		Begin
			Set @searchCondition = ' AND EF.WomenName LIKE ''%' + @Search + '%'''
		End
		-- Create a temporary table to store the results
		CREATE TABLE #TempResults (
			RowNum			 INT,
			TrainingId		 INT,
			TotalCount		 INT,
			ProjectCode		 INT,
			ProjectName		 Varchar(100),
			UserName		 Varchar(100)
		)

		Set @Query = 'WITH CTE AS (
					SELECT 
							ROW_NUMBER() OVER (ORDER BY TF.TrainingId) AS RowNum,
							TF.TrainingId, 
							COUNT(*) OVER() AS TotalCount,
							UL.ProjectCode,
							MP.ProjectName ,
							(UL.FirstName+'' ''+UL.LastName) AS UserName 
					FROM TrainingForm TF  
					INNER JOIN UserLogin UL ON TF.CreatedBy = UL.UserCode  
					LEFT JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
					INNER JOIN EnrollmentForm EF on EF.EnrollmentId=TF.EnrollmentId
					WHERE 1=1 ' + @condition + @searchCondition +'
					)
					INSERT INTO #TempResults (RowNum,TrainingId, TotalCount,ProjectCode,ProjectName,UserName)
					SELECT RowNum,TrainingId, TotalCount,ProjectCode,ProjectName,UserName
					FROM CTE 
						  
					ORDER BY RowNum 
					OFFSET ' + CAST(@PageNumber AS NVARCHAR(10))   + ' ROWS 
					FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY
					'
		Print(@Query)
		Exec sp_sqlexec @Query 

		Select T.RowNum,  T.TotalCount, TF.TrainingId, EF.EnrollmentId,
					EF.BeneficiaryCode, MS.StateName, MD.DistrictName, MB.BlockName,
					MV.VillageName, T.ProjectCode,T.ProjectName, T.UserName, EF.WomenName,
					TF.IsLifeSkillsTraining,
					TF.RCSCDate,TF.WRPCDate,TF.HNCDate,TF.FLCDate,TF.EDTSDate,
					TF.LEAPDate,TF.ESISDate ,TF.BMTCDate,TF.MMTCDate,TF.EDPTCDate ,TF.IsTrainingCompleted,TF.CreatedOn,TF.UpdatedOn
					,TF.IsInductionTraining, TF.InductionTrainingDay1, TF.InductionTrainingDay2, 
					TF.IsDigitalSkillTraining, TF.DigitalSkillTrainingDay1, TF.DigitalSkillTrainingDay2, TF.DigitalSkillTrainingDay3, 
					TF.EDPIntroDay1, TF.BusinessPlanDay2, TF.FinancialLiteracyDay3, TF.FinancialTermsDay4, TF.BusinessManagementDay5
					From #TempResults T 
					INNER JOIN TrainingForm TF On T.TrainingId=TF.TrainingId
					LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=TF.EnrollmentId
					LEFT JOIN M_State MS ON EF.[State]=MS.StateId
					LEFT JOIN M_District MD ON EF.District=MD.DistrictId
					LEFT JOIN M_BLock MB ON EF.[Block]=MB.BlockId
					LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
					
					-- Drop the temporary table
					DROP TABLE #TempResults

		--set @Query='SELECT TrainingId,TF.EnrollmentId,
		--			BeneficiaryCode,State,MS.StateName,District,MD.DistrictName,Block,MB.BlockName,Village,mv.VillageName,
		--			UL.ProjectCode,MP.ProjectName,(UL.FirstName+'' ''+UL.LastName) as UserName,WomenName,
		--			IsLifeSkillsTraining,RCSCDate,WRPCDate,HNCDate,FLCDate,EDTSDate,
		--			LEAPDate,ESISDate ,BMTCDate,MMTCDate,EDPTCDate ,IsTrainingCompleted,TF.CreatedOn,TF.UpdatedOn
		--			FROM TrainingForm TF
		--			LEFT JOIN UserLogin UL ON TF.CreatedBy=UL.UserCode
		--			LEFT JOIN EnrollmentForm EF on EF.EnrollmentId=TF.EnrollmentId
		--			LEFT JOIN M_State MS ON EF.State=MS.StateId
		--			LEFT JOIN M_District MD ON EF.District=MD.DistrictId
		--			LEFT JOIN M_BLock MB ON EF.Block=MB.BlockId
		--			LEFT JOIN M_Village MV ON EF.Village=MV.VillageId
		--			LEFT JOIN M_Project MP ON UL.ProjectCode=MP.ProjectId
		--			where 1=1 '+@condition+''

	
END
