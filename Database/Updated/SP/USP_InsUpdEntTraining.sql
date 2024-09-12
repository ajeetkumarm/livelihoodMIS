ALTER PROCEDURE [dbo].[USP_InsUpdEntTraining]
(
	@EntTrainingId int=null,
	@EnrollmentId int=null,
	@StartBusiness varchar(10)=null,
	@BusinessReasons varchar(50)=null,
	@Business varchar(50)=null,
	@BusinessWhen varchar(50)=null,
	@StatusBusiness varchar(50)=null,
	@VillagePopulation varchar(50)=null,
	@BusinessIdea varchar(10)=null,
	@BusinessType varchar(50)=null,
	@ProcureBusiness nvarchar(MAX)=null,
	@CurrentBusiness varchar(50)=null,
	@RegularFinancialBusiness varchar(10)=null,
	@HowRegularFinancial varchar(50)=null,
	@SettingBusinessType varchar(30)=null,
	@MonthlyRent varchar(50)=null,
	@ExpandBusiness varchar(50)=null,
	@PotentialCustomers varchar(10)=null,
	@BusinessDistance varchar(50)=null,
	@ExpectedFootfall varchar(100)=null,
	@HowFarBussiness varchar(50)=null,
	@PlanningBusiness varchar(MAX)=null,
	@SupportBusiness varchar(10)=null,
	@SupportType varchar(MAX)=null,
	@NotProvidedSupport varchar(50)=null,
	@PaidWorker varchar(5)=null,
	@DigitalInclusion varchar(5)=null,
	@DigitalInclusionDate varchar(50)=null,
	@OwnSmartPhone varchar(5)=null,
	@UseSmartPhone varchar(5)=null,
	@SupplyChain varchar(5)=null,
	@CreatedBy varchar(30)=null,
	@UpdatedBy varchar(30)=null
)
AS
BEGIN
	IF NOT EXISTS(Select * from EnterpriesTrainingForm where EntTrainingId=@EntTrainingId)
		BEGIN
			INSERT INTO EnterpriesTrainingForm(EnrollmentId,StartBusiness,BusinessReasons,Business,BusinessWhen,StatusBusiness,VillagePopulation,
										BusinessIdea,BusinessType,ProcureBusiness,CurrentBusiness,RegularFinancialBusiness,HowRegularFinancial,
										SettingBusinessType,MonthlyRent,ExpandBusiness,PotentialCustomers,BusinessDistance,ExpectedFootfall,
										HowFarBussiness,PlanningBusiness,SupportBusiness,SupportType,NotProvidedSupport,
										PaidWorker,DigitalInclusion,DigitalInclusionDate,OwnSmartPhone,UseSmartPhone,SupplyChain,
										IsCompleteEntTraining,CreatedBy,CreatedOn)
									VALUES(@EnrollmentId,@StartBusiness,@BusinessReasons,@Business,@BusinessWhen,@StatusBusiness,@VillagePopulation,@BusinessIdea,
											@BusinessType,@ProcureBusiness,@CurrentBusiness,@RegularFinancialBusiness,@HowRegularFinancial,@SettingBusinessType,
											@MonthlyRent,@ExpandBusiness,@PotentialCustomers,@BusinessDistance,@ExpectedFootfall,@HowFarBussiness,@PlanningBusiness,
											@SupportBusiness,@SupportType,@NotProvidedSupport,@PaidWorker,@DigitalInclusion,@DigitalInclusionDate,@OwnSmartPhone,
											@UseSmartPhone,@SupplyChain,
											1,@CreatedBy,GETDATE())

			-- INSERT Business Progess Status
			INSERT INTO BusinessProgressStatus (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,UpdatedBy,BusinessStatusReason)
				  VALUES(@EnrollmentId,1,Convert(varchar, Getdate(), 5),@CreatedBy,@CreatedBy,'');

			-- INSERT Business Progess Status Log
			INSERT INTO BusinessProgressStatusLog (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,BusinessStatusReason)
				  VALUES(@EnrollmentId,1,Convert(varchar, Getdate(), 5),@CreatedBy,'');
		END
END
