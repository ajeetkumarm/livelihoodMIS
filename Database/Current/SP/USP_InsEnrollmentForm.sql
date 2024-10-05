ALTER PROCEDURE [dbo].[USP_InsEnrollmentForm]
(
    @EnrollmentId INT = 0,
    @BeneficiaryCode NVARCHAR(100) = NULL,
    @WomenName NVARCHAR(50) = NULL,
    @HusbandFatherName NVARCHAR(50) = NULL,
    @MotherName NVARCHAR(50) = NULL,
    @PhoneNo VARCHAR(15) = NULL,
    @ThemeCode VARCHAR(10) = NULL,
    @Cast INT = NULL,
    @EconomicStatus INT = NULL,
    @MaritalStatus VARCHAR(30) = NULL,
    @BirthDate VARCHAR(30) = NULL,
    @Age INT = NULL,
    @RegistrationDate VARCHAR(30) = NULL,
    @State INT = NULL,
    @District INT = NULL,
    @Block INT = NULL,
    @Village INT = NULL,
    @PartSHG VARCHAR(5) = NULL,
    @SHGName NVARCHAR(100) = NULL,
    @SHGDate VARCHAR(30) = NULL,
    @SHGType INT = NULL,
    @Education INT = NULL,
    @PwD VARCHAR(5) = NULL,
    @PwDSpecify NVARCHAR(100) = NULL,
    @AadhaarrCard VARCHAR(5) = NULL,
    @AadhaarCardDetails NVARCHAR(100) = NULL,
    @AadhaarNo VARCHAR(15) = NULL,
    @AnyIDProofDetails NVARCHAR(100) = NULL,
    @IDProofNo NVARCHAR(50) = NULL,
    @IssuingAuthority NVARCHAR(100) = NULL,
    @RationCard VARCHAR(5) = NULL,
    @RationCardlinkedPDS VARCHAR(5) = NULL,
    @BankAccountNo NVARCHAR(50) = NULL,
    @LinkedSocialSecuritySchemes VARCHAR(5) = NULL,
    @WomenBelong NVARCHAR(100) = NULL,
    @ValidCertificate VARCHAR(5) = NULL,
    @MonthlyIndividualIncome NVARCHAR(100) = NULL,
    @MonthlyHouseholdIncome NVARCHAR(100) = NULL,
    @Scheme INT = NULL,
    @CreatedBy VARCHAR(30) = NULL,
    @EmployeeId VARCHAR(100) = NULL,
    @ReplacementEmployeeId VARCHAR(100) = NULL,
    @ReplacementBeneficiaryCode VARCHAR(155) = NULL,
    @EnrollmentStatus VARCHAR(55) = NULL,
    @CohortValue VARCHAR(55) = NULL
)
AS
BEGIN
    IF @EnrollmentId > 0 
    BEGIN
        -- Update existing record
        UPDATE EnrollmentForm
        SET BeneficiaryCode = @BeneficiaryCode,
            WomenName = @WomenName,
            HusbandFatherName = @HusbandFatherName,
            MotherName = @MotherName,
            PhoneNo = @PhoneNo,
            ThemeCode = @ThemeCode,
            [Cast] = @Cast,
            EconomicStatus = @EconomicStatus,
            MaritalStatus = @MaritalStatus,
            BirthDate = @BirthDate,
            Age = @Age,
            RegistrationDate = @RegistrationDate,
            [State] = @State,
            District = @District,
            [Block] = @Block,
            Village = @Village,
            PartSHG = @PartSHG,
            SHGName = @SHGName,
            SHGDate = @SHGDate,
            SHGType = @SHGType,
            Education = @Education,
            PwD = @PwD,
            PwDSpecify = @PwDSpecify,
            AadhaarrCard = @AadhaarrCard,
            AadhaarCardDetails = @AadhaarCardDetails,
            AadhaarNo = @AadhaarNo,
            AnyIDProofDetails = @AnyIDProofDetails,
            IDProofNo = @IDProofNo,
            IssuingAuthority = @IssuingAuthority,
            RationCard = @RationCard,
            RationCardlinkedPDS = @RationCardlinkedPDS,
            BankAccountNo = @BankAccountNo,
            LinkedSocialSecuritySchemes = @LinkedSocialSecuritySchemes,
            WomenBelong = @WomenBelong,
            ValidCertificate = @ValidCertificate,
            MonthlyIndividualIncome = @MonthlyIndividualIncome,
            MonthlyHouseholdIncome = @MonthlyHouseholdIncome,
            Scheme = @Scheme,
            EmployeeId = @EmployeeId,
            ReplacementEmployeeId = @ReplacementEmployeeId,
            ReplacementBeneficiaryCode = @ReplacementBeneficiaryCode,
            EnrollmentStatus = @EnrollmentStatus,
            CohortValue = @CohortValue,
            UpdatedOn = GETDATE(),
			UpdatedBy = @CreatedBy
            
        WHERE EnrollmentId = @EnrollmentId;
    END
    ELSE 
    BEGIN
        -- Insert new record
        INSERT INTO EnrollmentForm(BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,[Cast],EconomicStatus,
								MaritalStatus,BirthDate,Age,RegistrationDate,[State],District,[Block],Village,
								PartSHG,SHGName,SHGDate,SHGType,Education,PwD,PwDSpecify,AadhaarrCard,AadhaarCardDetails,AadhaarNo,
								AnyIDProofDetails,IDProofNo,IssuingAuthority,RationCard,RationCardlinkedPDS,BankAccountNo,
								LinkedSocialSecuritySchemes,WomenBelong,ValidCertificate,MonthlyIndividualIncome,MonthlyHouseholdIncome,
								Scheme,IntrestedEDPTraining,CreatedBy,CreatedOn,EmployeeId,ReplacementEmployeeId,ReplacementBeneficiaryCode,EnrollmentStatus,CohortValue)
		VALUES(@BeneficiaryCode,@WomenName,@HusbandFatherName,@MotherName,@PhoneNo,@ThemeCode,@Cast,@EconomicStatus,
				@MaritalStatus,@BirthDate,@Age,@RegistrationDate,@State,@District,@Block,@Village,
				@PartSHG,@SHGName,@SHGDate,@SHGType,@Education,@PwD,@PwDSpecify,@AadhaarrCard,@AadhaarCardDetails,@AadhaarNo,
				@AnyIDProofDetails,@IDProofNo,@IssuingAuthority,@RationCard,@RationCardlinkedPDS,@BankAccountNo,
				@LinkedSocialSecuritySchemes,@WomenBelong,@ValidCertificate,@MonthlyIndividualIncome,@MonthlyHouseholdIncome,
				@Scheme,0,@CreatedBy,getdate(),@EmployeeId,@ReplacementEmployeeId,@ReplacementBeneficiaryCode,@EnrollmentStatus,@CohortValue);
    END
END
