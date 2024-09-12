ALTER proc [dbo].[USP_InsEnrollmentForm]
(
	@BeneficiaryCode nvarchar(100)= NULL,
	@WomenName nvarchar(50)= NULL,
	@HusbandFatherName nvarchar(50)= NULL,
	@MotherName nvarchar(50) =NULL,
	@PhoneNo varchar(15)= NULL,
	@ThemeCode varchar(10)= NULL,
	@Cast int= NULL,
	@EconomicStatus int=NULL,
	@MaritalStatus varchar(30) =NULL,
	@BirthDate varchar(30)= NULL,
	@Age int =NULL,	
	@RegistrationDate varchar(30)= NULL,
	@State int= NULL,
	@District int= NULL,
	@Block int=NULL,
	@Village int= NULL,
	@PartSHG varchar(5)= NULL,
	@SHGName nvarchar(100)= NULL,
	@SHGDate varchar(30) =NULL,
	@SHGType int= NULL,	
	@Education int= NULL,
	@PwD varchar(5)= NULL,
	@PwDSpecify nvarchar(100)=null,
	@AadhaarrCard varchar(5)= NULL,
	@AadhaarCardDetails nvarchar(100)= NULL,
	@AadhaarNo varchar(15) =NULL,
	@AnyIDProofDetails nvarchar(100)= NULL,
	@IDProofNo nvarchar(50)= NULL,
	@IssuingAuthority nvarchar(100)= NULL,
	@RationCard varchar(5)= NULL,
	@RationCardlinkedPDS varchar(5)= NULL,
	@BankAccountNo nvarchar(50) =NULL,
	@LinkedSocialSecuritySchemes varchar(5) =NULL,
	@WomenBelong varchar(100)=NULL,
	@ValidCertificate varchar(5)=NULL,
	@MonthlyIndividualIncome varchar(100)=NULL,
	@MonthlyHouseholdIncome varchar(100)=NULL,
	@Scheme int =NULL,
	@CreatedBy varchar(30) =NULL,
	@EmployeeId	Varchar(100) = NULL,
	@ReplacementEmployeeId Varchar(100) = NULL,
	@ReplacementBeneficiaryCode Varchar(155) = NULL,
	@EnrollmentStatus			Varchar(55)
) 
AS
BEGIN
	INSERT INTO EnrollmentForm(BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,Cast,EconomicStatus,
								MaritalStatus,BirthDate,Age,RegistrationDate,State,District,Block,Village,
								PartSHG,SHGName,SHGDate,SHGType,Education,PwD,PwDSpecify,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
								AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
								LinkedSocialSecuritySchemes,WomenBelong,ValidCertificate,MonthlyIndividualIncome,MonthlyHouseholdIncome,
								Scheme,IntrestedEDPTraining,CreatedBy,CreatedOn,EmployeeId,ReplacementEmployeeId,ReplacementBeneficiaryCode,EnrollmentStatus)
	VALUES(@BeneficiaryCode,@WomenName,@HusbandFatherName,@MotherName,@PhoneNo,@ThemeCode,@Cast,@EconomicStatus,
			@MaritalStatus,@BirthDate,@Age,@RegistrationDate,@State,@District,@Block,@Village,
			@PartSHG,@SHGName,@SHGDate,@SHGType,@Education,@PwD,@PwDSpecify,@AadhaarrCard,@AadhaarCardDetails,@AadhaarNo,
			@AnyIDProofDetails,@IDProofNo,@IssuingAuthority,@RationCard,@RationCardlinkedPDS,@BankAccountNo,
			@LinkedSocialSecuritySchemes,@WomenBelong,@ValidCertificate,@MonthlyIndividualIncome,@MonthlyHouseholdIncome,
			@Scheme,0,@CreatedBy,getdate(),@EmployeeId,@ReplacementEmployeeId,@ReplacementBeneficiaryCode,@EnrollmentStatus)
END




