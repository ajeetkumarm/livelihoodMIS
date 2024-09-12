Create OR Alter Procedure dbo.usp_BusinessProgressStatus
@QueryType				INT,
@EnrollmentId			INT
AS
	BEGIN
		 IF @QueryType=1
			BEGIN
				Select * From BusinessProgressStatus Where EnrollmentId=@EnrollmentId
			END
	END