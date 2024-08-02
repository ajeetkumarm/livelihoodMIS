ALTER PROCEDURE [dbo].[USP_InsUpdUser]
(
	@UserCode int=null,
	@StateCode int=null,
	@DistrictCode int=null,
	@BlockCode int=null,
	@VillageCode int=null,
	@PartnerCode int=null,
	@ProjectCode int=null,
	@LocationCode int=null,
	@FirstName nvarchar(30)=null,
	@LastName nvarchar(30)=null,
	@ContactNo nvarchar(30)=null,
	@Email nvarchar(100)=null,
	@LoginName nvarchar(100)=null,
	@PwdHash varchar(100)=null,
	@UserCategory int=null,
	@CreatedBy varchar(50)=null,
	@UpdatedBy varchar(50)=null,
	@EnrollmentId	INT=NULL

)
AS
BEGIN
	IF NOT EXISTS(SELECT UserCode FROM UserLogin WHERE UserCode=@UserCode)
	BEGIN
		INSERT INTO UserLogin(StateCode,DistrictCode,BlockCode,VillageCode,PartnerCode,ProjectCode,LocationCode,FirstName,LastName,
								ContactNo,Email,LoginName,PwdHash,IsActive,UserCategory,CreatedBy,CreatedOn,EnrollmentId)
							VALUES(@StateCode,@DistrictCode,@BlockCode,@VillageCode,@PartnerCode,@ProjectCode,@LocationCode,@FirstName,
									@LastName,@ContactNo,@Email,@LoginName,@PwdHash,1,@UserCategory,@CreatedBy,GETDATE(),@EnrollmentId)
	END
	ELSE
	BEGIN
		UPDATE UserLogin SET StateCode=@StateCode,DistrictCode=@DistrictCode,BlockCode=@BlockCode,VillageCode=@VillageCode,
							 PartnerCode=@PartnerCode,ProjectCode=@ProjectCode,LocationCode=@LocationCode,
							 FirstName=@FirstName,LastName=@LastName,ContactNo=@ContactNo,Email=@Email,LoginName=@LoginName,
							 --PwdHash=@PwdHash,
							 UserCategory=@UserCategory,UpdatedBy=@UpdatedBy,UpdatedOn=GETDATE()
							WHERE UserCode=@UserCode
	END
END
