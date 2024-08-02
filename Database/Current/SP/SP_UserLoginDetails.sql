ALTER PROCEDURE [dbo].[SP_UserLoginDetails]
(
	@UserEmail varchar(100)='sharmarekha1101@gmail.com'

)
AS
BEGIN

	SELECT UserCode,FormAccess,StateCode,M_State.StateName,DistrictCode,M_District.DistrictName,BlockCode,M_BLock.BlockName,
	VillageCode,M_Village.VillageName,PartnerCode,M_Partner.PartnerName,ProjectCode,M_Project.ProjectName,LocationCode,
	M_ProjectLocation.ProjectName,
	FirstName,LastName,FirstName+' '+LastName as FullName,
	ContactNo,Email,PwdHash,IsActive,UserCategory,M_UserCategory.Category
	,UserLogin.EnrollmentId
	FROM UserLogin
	LEFT JOIN M_State ON UserLogin.StateCode=M_State.StateId
	LEFT JOIN M_District ON UserLogin.DistrictCode=M_District.DistrictId
	LEFT JOIN M_BLock ON UserLogin.BlockCode=M_BLock.BlockId
	LEFT JOIN M_Village ON UserLogin.VillageCode=M_Village.VillageId
	INNER JOIN M_Partner ON UserLogin.PartnerCode=M_Partner.PartnerId
	INNER JOIN M_Project ON UserLogin.ProjectCode=M_Project.ProjectId
	LEFT JOIN M_ProjectLocation ON UserLogin.LocationCode=M_ProjectLocation.ProjectId
	INNER JOIN M_UserCategory ON UserLogin.UserCategory=M_UserCategory.CategoryId
	WHERE Email=@UserEmail or isnull(@UserEmail,'')=''
END


