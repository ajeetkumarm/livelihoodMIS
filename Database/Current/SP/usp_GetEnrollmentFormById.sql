Create Or Alter Procedure dbo.usp_GetEnrollmentFormById
@EnrollmentId			INT
AS
	BEGIN
		Select EF.EnrollmentId, EF.WomenName, EF.[State], EF.District,EF.[Block],EF.Village, EF.PhoneNo,
		U.ProjectCode, U.PartnerCode, U.LocationCode
		From EnrollmentForm EF Left Join UserLogin U On EF.CreatedBy=U.UserCode
		Where EF.EnrollmentId=@EnrollmentId
	END