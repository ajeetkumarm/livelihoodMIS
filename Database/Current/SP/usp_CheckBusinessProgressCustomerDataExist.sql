Create Or Alter Procedure dbo.usp_CheckBusinessProgressCustomerDataExist --usp_CheckBusinessProgressCustomerDataExist 0,1392,2024,'Jan'
	@BusinessProgressId			INT,
	@EnrollmentId				INT,
	@Year						INT,
	@Month						Varchar(10)

As
	Begin
	Select Count(1) As TotalCount
	From BusinessProgressForm
	Where BusinessProgressId != @BusinessProgressId
	And EnrollmentId = @EnrollmentId
	And [Year] = @Year
	And [Month] = @Month
End