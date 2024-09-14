Create OR Alter Procedure dbo.usp_BusinessProgressMoveToEnterpriseSetup
@EnrollmentId		INT,
@UpdatedBy			INT
As
	BEGIN
		Update EnterpriesTrainingForm SET IsCompleteEntTraining=0, UpdatedBy=@UpdatedBy, UpdatedOn=GETDATE() Where EnrollmentId=@EnrollmentId
	END