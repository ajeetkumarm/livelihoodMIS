Create Or Alter Procedure dbo.usp_GetEnrollmentDetailById
@EnrollmentId		INT
AS
	BEGIN
		 Select * From EnrollmentForm Where EnrollmentId=@EnrollmentId
	END

