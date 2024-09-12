ALTER PROCEDURE [dbo].[USP_DashboardCount] -- [USP_DashboardCount] 1,0
(
	@CreatedUser varchar(50)='1',
	@Project varchar(50)='3'
)
AS
BEGIN
declare @LoginUser nvarchar(max),@UserCategory varchar(10),@ProjectCode varchar(50),
		@TotalEnrollment nvarchar(max), @TotalEDPTraining nvarchar(max),@condition nvarchar(max)='',
		@TotalEnterpriesTraining nvarchar(max), @TotalBusinessProgress nvarchar(max),
		@condition1 nvarchar(max)='',  @InputUserCategory varchar(50) , @input varchar(50)

		set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)
		
		 if(@UserCategory=1)
			 Begin
				If(@Project<>0)
			
					set @condition=@condition + 'and convert(varchar,UL.ProjectCode) = '+@Project+' '
					Begin
						set @TotalEnrollment= 'Select Count(*)TotalEnrollment from EnrollmentForm EF
											   INNER JOIN UserLogin UL on EF.CreatedBy=UL.UserCode Where 1=1  '+@condition+'' 
						 
						set @TotalEDPTraining= 'Select Count(*)TotalEDPTraining from TrainingForm TF
												INNER JOIN UserLogin UL on TF.CreatedBy=UL.UserCode 
												INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId
												Where 1=1  '+@condition+'' 			 

						set @TotalEnterpriesTraining= 'select Count(*)TotalEnterpriesTraining from EnterpriesTrainingForm ET
													   Inner Join UserLogin UL on ET.CreatedBy=UL.UserCode 
													   INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId 
													   Where 1=1  '+@condition+'' 

						set @TotalBusinessProgress= 'Select Count(*)TotalBusinessProgress from BusinessProgressForm BP
													 Inner Join UserLogin UL on BP.CreatedBy=UL.UserCode 
													 INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId 
													 Where 1=1  '+@condition+'' 

					End
			 End
		 Else if(@UserCategory=7)
			 Begin
				 set @condition= 'and EF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
			 end
		 Else
			 Begin

				 set @InputUserCategory=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCategory AS VARCHAR(10)) [text()]
									  FROM UserLogin   where UserCategory not in (1)    FOR XML PATH(''), TYPE)
									  .value('.','NVARCHAR(MAX)'),1,1,'') UserCategory FROM UserLogin t)

		

				set @Input=(SELECT CHARINDEX(@UserCategory, @InputUserCategory) AS MatchPosition)

				set @InputUserCategory=(select SUBSTRING(@InputUserCategory, @Input+0 , LEN(@InputUserCategory)))
				print @InputUserCategory

				set @LoginUser=(SELECT  distinct STUFF((SELECT distinct ',' + CAST(UserCode AS VARCHAR(10)) [text()]
								FROM UserLogin    WHERE  1=1 and cast(UserCategory as varchar) not  in('1,7,'''+@InputUserCategory+'')   FOR XML PATH(''), TYPE)
								.value('.','NVARCHAR(MAX)'),1,1,'') UserCode FROM UserLogin t)
				print @LoginUser
		
				set @condition= 'and EF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '	
		
			End		
		
		set @TotalEnrollment= 'Select Count(*)TotalEnrollment from EnrollmentForm EF
								INNER JOIN UserLogin UL on EF.CreatedBy=UL.UserCode
								where 1=1 '+@condition+'' 
	
		set @TotalEDPTraining='Select count(*)TotalEDPTraining from TrainingForm EF
								INNER JOIN UserLogin UL on EF.CreatedBy=UL.UserCode
								INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId 
								where 1=1 '+@condition+''		

		set @TotalEnterpriesTraining='Select count(*)TotalEnterpriesTraining from EnterpriesTrainingForm EF
										INNER JOIN UserLogin UL on EF.CreatedBy=UL.UserCode
										INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId 
										Where 1=1 '+@condition+''								

		set @TotalBusinessProgress='Select count(*)TotalBusinessProgress from BusinessProgressForm EF
									INNER JOIN UserLogin UL on EF.CreatedBy=UL.UserCode
									INNER JOIN EnrollmentForm EFF on EF.EnrollmentId=EFF.EnrollmentId 
									where 1=1 '+@condition+''
		

	print(@TotalEnrollment)
	exec sp_sqlexec @TotalEnrollment 
	
	print(@TotalEDPTraining)
	exec sp_sqlexec @TotalEDPTraining
	
	print(@TotalEnterpriesTraining)
	exec sp_sqlexec @TotalEnterpriesTraining

	print(@TotalBusinessProgress)
	exec sp_sqlexec @TotalBusinessProgress
END