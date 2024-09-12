ALTER   Procedure [dbo].[usp_BusinessProgressList] --usp_BusinessProgressList 1,1,0,25
@CreatedUser		varchar(50)='1',  
@Project			varchar(50)='1' ,
@PageNumber			int = 1,
@PageSize			int = 10,
@Search				Varchar(100)=Null
AS
	BEGIN
		   Declare @LoginUser varchar(max),@UserCategory varchar(10),  @Query nvarchar(max)='',@InputUserCategory varchar(50) , @input varchar(50),@condition nvarchar(max)='' 
		   , @searchCondition nvarchar(max) = ''

		   Set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)  
		   If(@UserCategory=1)  
			   Begin  
					Set @condition=@condition  
			   End  
		   Else If(@UserCategory=7)  
			   Begin  
					Set @condition= 'and EF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '  
			   End  
		   Else  
			   Begin  
				   Set @InputUserCategory=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCategory AS VARCHAR(10)) [text()]  
						 FROM UserLogin   where UserCategory not in (1)    FOR XML PATH(''), TYPE)  
						 .value('.','NVARCHAR(MAX)'),1,1,'') UserCategory FROM UserLogin t)    
  
				   Set @Input=(SELECT CHARINDEX(@UserCategory, @InputUserCategory) AS MatchPosition)  
  
				   Set @InputUserCategory=(select SUBSTRING(@InputUserCategory, @Input+0 , LEN(@InputUserCategory)))  
				  --print @InputUserCategory  
  
				   Set @LoginUser=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCode AS VARCHAR(10)) [text()]  
					  FROM UserLogin    WHERE  1=1 and cast(UserCategory as varchar) not  in('1,7,'''+@InputUserCategory+'')   FOR XML PATH(''), TYPE)  
					  .value('.','NVARCHAR(MAX)'),1,1,'') UserCode FROM UserLogin t)  
				  --print @LoginUser  
    
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
				TotalCount		 INT
			)
			-- Where RowNum BETWEEN (('+Convert(Varchar,@PageNumber)+' - 1) * '+Convert(Varchar,@PageSize)+' + 1) AND ('+CONVERT(Varchar,@PageNumber)+' * '+CONVERT(Varchar,@PageSize)+')
			-- Query to get the paged results and insert them into the temporary table
			Set @Query = 'WITH CTE AS (
							SELECT 
									ROW_NUMBER() OVER (ORDER BY EF.EnrollmentId) AS RowNum,
									EF.EnrollmentId, 
								    COUNT(*) OVER() AS TotalCount
							FROM EnrollmentForm EF  
							INNER JOIN UserLogin UL ON EF.CreatedBy = UL.UserCode  
							INNER JOIN TrainingForm TF on EF.EnrollmentId = TF.EnrollmentId  
							INNER JOIN EnterpriesTrainingForm ET on EF.EnrollmentId=ET.EnrollmentId
							WHERE 1=1 AND ET.IsCompleteEntTraining=1 ' + @condition + @searchCondition +' 
						  )
						  INSERT INTO #TempResults (RowNum,EnrollmentId, TotalCount)
						  SELECT RowNum,EnrollmentId, TotalCount
						  FROM CTE 
						  
						  ORDER BY RowNum 
						  OFFSET ' + CAST(@PageNumber AS NVARCHAR(10))   + ' ROWS 
						  FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY
						  '

			EXEC sp_executesql @Query

			-- Select the results from the temporary table
			SELECT	T.RowNum, T.EnrollmentId, T.TotalCount, 
				   EF.BeneficiaryCode,S.StateName,D.DistrictName,B.BlockName,V.VillageName,  
				   EF.WomenName,
				   EF.PhoneNo,
				   EF.RegistrationDate,
				   BusinessStatus= (Select Top 1 BusinessStatus From BusinessProgressStatus Where EnrollmentId=EF.EnrollmentId)

			FROM #TempResults T INNER JOIN  EnrollmentForm EF  On T.EnrollmentId=EF.EnrollmentId
			INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode  
			LEFT JOIN M_State S On EF.State=S.StateId  
			LEFT JOIN M_District D On EF.District=D.DistrictId  
			LEFT JOIN M_BLock B On EF.Block=B.BlockId  
			LEFT JOIN M_Village V On EF.Village=V.VillageId  
			Order By T.RowNum

			-- Drop the temporary table
			DROP TABLE #TempResults  
	END