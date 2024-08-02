Create Or Alter Procedure dbo.usp_GetBusinessProgressForm_StartingBusinessDate
@EnrollmentId			INT
AS
	BEGIN
		 Select Top 1 StartingBusinessDate From BusinessProgressForm Where EnrollmentId=@EnrollmentId Order by UpdatedOn,CreatedOn Desc
	END
