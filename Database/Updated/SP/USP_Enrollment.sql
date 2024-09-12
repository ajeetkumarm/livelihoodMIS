USE [HPPI_Livelihood]
GO
/****** Object:  StoredProcedure [dbo].[USP_Enrollment]    Script Date: 06-08-2024 11:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_Enrollment]
(
	@QueryType varchar(30)='EnrollmentList',
	@CreatedUser varchar(50)='1',
	@Project varchar(50)='1'
)
AS
BEGIN
	declare @LoginUser varchar(max),@UserCategory varchar(10),
			@Query nvarchar(max)='',@InputUserCategory varchar(50) , @input varchar(50),@condition nvarchar(max)=''

		set @UserCategory=(select UserCategory from UserLogin where UserCode=@CreatedUser)
		 if(@UserCategory=1)
		 begin
			set @condition=@condition
		 end
		  else if(@UserCategory=7)
		 begin
			--set @LoginUser=@CreatedUser
			set @condition= 'and EF.CreatedBy in ('+@CreatedUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '
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
						FROM UserLogin    WHERE  1=1 and cast(UserCategory as varchar) not  in('1,7,'''+@InputUserCategory+'')   FOR XML PATH(''), TYPE)
						.value('.','NVARCHAR(MAX)'),1,1,'') UserCode FROM UserLogin t)
		--print @LoginUser
		
		  set @condition= 'and EF.CreatedBy in ('+@LoginUser+')  and convert(varchar,UL.ProjectCode) = '+@Project+' '			
		End	



	IF(@QueryType='EnrollmentList')
	BEGIN
	set @Query='SELECT EF.EnrollmentId,BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,EconomicStatus,
		MaritalStatus,BirthDate,Age,convert(varchar(30), RegistrationDate) RegistrationDate,
		State,S.StateName,District,D.DistrictName,Block,B.BlockName,Village,V.VillageName,
		PartSHG,SHGName,SHGDate,SHGType,Education,PwD,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
		AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
		LinkedSocialSecuritySchemes,Scheme,IntrestedEDPTraining
		FROM EnrollmentForm EF
		INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode
		LEFT JOIN M_State S On EF.State=S.StateId
		LEFT JOIN M_District D On EF.District=D.DistrictId
		LEFT JOIN M_BLock B On EF.Block=B.BlockId
		LEFT JOIN M_Village V On EF.Village=V.VillageId
		where 1=1 and IntrestedEDPTraining=0 '+@condition+''
	--WHERE EF.CreatedBy=@LoginUser or isnull(@LoginUser,0)=0'

	
	END
	ELSE IF(@QueryType='EDPTraining')
	BEGIN
		set @Query='SELECT EF.EnrollmentId,BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,EconomicStatus,
		MaritalStatus,BirthDate,Age,convert(varchar(30), RegistrationDate) RegistrationDate,
		State,S.StateName,District,D.DistrictName,Block,B.BlockName,Village,V.VillageName,
		PartSHG,SHGName,SHGDate,SHGType,Education,PwD,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
		AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
		LinkedSocialSecuritySchemes,Scheme,IntrestedEDPTraining
		FROM EnrollmentForm EF
		INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode
		LEFT JOIN M_State S On EF.State=S.StateId
		LEFT JOIN M_District D On EF.District=D.DistrictId
		LEFT JOIN M_BLock B On EF.Block=B.BlockId
		LEFT JOIN M_Village V On EF.Village=V.VillageId
		LEFT JOIN TrainingForm TF on EF.EnrollmentId=TF.EnrollmentId
		where 1=1 and IntrestedEDPTraining=1 and (TF.IsTrainingCompleted=0 or TF.IsTrainingCompleted is null) '+@condition+''

		--WHERE EF.CreatedBy IN (@LoginUser) or isnull(@LoginUser,0)=0 and IntrestedEDPTraining=1 and (TF.IsTrainingCompleted=0 or TF.IsTrainingCompleted is null)
	END
	ELSE IF(@QueryType='EntSetup')
	BEGIN
		set @Query='SELECT EF.EnrollmentId,BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,EconomicStatus,
		MaritalStatus,BirthDate,Age,convert(varchar(30), RegistrationDate) RegistrationDate,
		State,S.StateName,District,D.DistrictName,Block,B.BlockName,Village,V.VillageName,
		PartSHG,SHGName,SHGDate,SHGType,Education,PwD,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
		AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
		LinkedSocialSecuritySchemes,Scheme,IntrestedEDPTraining
		FROM EnrollmentForm EF
		INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode
		LEFT JOIN M_State S On EF.State=S.StateId
		LEFT JOIN M_District D On EF.District=D.DistrictId
		LEFT JOIN M_BLock B On EF.Block=B.BlockId
		LEFT JOIN M_Village V On EF.Village=V.VillageId
		INNER JOIN TrainingForm TF on EF.EnrollmentId=TF.EnrollmentId
		LEFT JOIN EnterpriesTrainingForm ET on EF.EnrollmentId=ET.EnrollmentId
		where 1=1 and TF.IsTrainingCompleted=1 and (ET.IsCompleteEntTraining=0 or ET.IsCompleteEntTraining is null) '+@condition+''

		--WHERE EF.CreatedBy IN (@LoginUser) or isnull(@LoginUser,0)=0 and TF.IsTrainingCompleted=1 and (ET.IsCompleteEntTraining=0 or ET.IsCompleteEntTraining is null)
	END
	ELSE IF(@QueryType='BusinessProgress')
	BEGIN
		set @Query='SELECT EF.EnrollmentId,BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,EconomicStatus,
		MaritalStatus,BirthDate,Age,convert(varchar(30), RegistrationDate) RegistrationDate,
		State,S.StateName,District,D.DistrictName,Block,B.BlockName,Village,V.VillageName,
		PartSHG,SHGName,SHGDate,SHGType,Education,PwD,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
		AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
		LinkedSocialSecuritySchemes,Scheme,IntrestedEDPTraining
		FROM EnrollmentForm EF
		INNER JOIN UserLogin UL ON EF.CreatedBy=UL.UserCode
		LEFT JOIN M_State S On EF.State=S.StateId
		LEFT JOIN M_District D On EF.District=D.DistrictId
		LEFT JOIN M_BLock B On EF.Block=B.BlockId
		LEFT JOIN M_Village V On EF.Village=V.VillageId
		INNER JOIN TrainingForm TF on EF.EnrollmentId=TF.EnrollmentId
		INNER JOIN EnterpriesTrainingForm ET on EF.EnrollmentId=ET.EnrollmentId
		where 1=1 and ET.IsCompleteEntTraining=1 '+@condition+''

		--WHERE EF.CreatedBy IN (@LoginUser) or isnull(@LoginUser,0)=0 and ET.IsCompleteEntTraining=1
	END
	print(@Query)
	exec sp_sqlexec @Query 
END