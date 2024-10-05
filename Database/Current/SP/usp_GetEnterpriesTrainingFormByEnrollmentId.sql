Create Or Alter Procedure dbo.usp_GetEnterpriesTrainingFormByEnrollmentId
@EnrollmentId			INT
As
	BEGIN
		Select * From EnterpriesTrainingForm Where EnrollmentId=@EnrollmentId
	END
