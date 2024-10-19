ALTER PROCEDURE [dbo].[USP_InsUpdTraining]
(
	@TrainingId				int=null,
	@EnrollmentId			int=null,
	@IsLifeSkillsTraining	varchar(10)=null,
	@RCSCDate				varchar(30)=null,
	@WRPCDate				varchar(30)=null,
	@HNCDate				varchar(30)=null,
	@FLCDate				varchar(30)=null,
	@EDTSDate				varchar(30)=null,
	@LEAPDate				varchar(30)=null,
	@ESISDate				varchar(30)=null,
	@BMTCDate				varchar(30)=null,
	@MMTCDate				varchar(30)=null,
	@EDPTCDate				varchar(30)=null,
	@CreatedBy				varchar(30)=null,
	@UpdateBy				varchar(30)=null,
	@InductionTrainingDay1	varchar(30)=null,
	@InductionTrainingDay2	varchar(30)=null,
	@DigitalSkillTrainingDay1	varchar(30)=null,
	@DigitalSkillTrainingDay2	varchar(30)=null,
	@DigitalSkillTrainingDay3	varchar(30)=null,
	@IsInductionTraining		varchar(10)=null,
	@IsDigitalSkillTraining		varchar(10)=null,
	@EDPIntroDay1				Varchar(25) = Null,
	@BusinessPlanDay2			Varchar(25) = Null,
	@FinancialLiteracyDay3		Varchar(25) = Null,
	@FinancialTermsDay4			Varchar(25) = Null,
	@BusinessManagementDay5		Varchar(25) = Null
	
)
AS
BEGIN
	IF NOT EXISTS(SELECT TrainingId FROM TrainingForm WHERE TrainingId=@TrainingId)
	BEGIN
		IF(@RCSCDate!='' and @WRPCDate!='' and @HNCDate!='' and @FLCDate!='' and @EDTSDate!='' and @LEAPDate!='' and @ESISDate!='' and @BMTCDate!='' and @MMTCDate!='' and @EDPTCDate!='')
		BEGIN
			INSERT INTO TrainingForm(EnrollmentId,IsLifeSkillsTraining,RCSCDate,WRPCDate,HNCDate,FLCDate,EDTSDate,LEAPDate,
										ESISDate,BMTCDate,MMTCDate,EDPTCDate,IsTrainingCompleted,CreatedBy,CreatedOn,InductionTrainingDay1,
										InductionTrainingDay2,DigitalSkillTrainingDay1,DigitalSkillTrainingDay2,DigitalSkillTrainingDay3,
										IsInductionTraining,IsDigitalSkillTraining,
										EDPIntroDay1,BusinessPlanDay2,FinancialLiteracyDay3,FinancialTermsDay4,BusinessManagementDay5)
						VALUES(@EnrollmentId,@IsLifeSkillsTraining,@RCSCDate,@WRPCDate,@HNCDate,@FLCDate,@EDTSDate,@LEAPDate,
										@ESISDate,@BMTCDate,@MMTCDate,@EDPTCDate,1,@CreatedBy,GETDATE(),@InductionTrainingDay1,
										@InductionTrainingDay2,@DigitalSkillTrainingDay1,@DigitalSkillTrainingDay2,@DigitalSkillTrainingDay3,
										@IsInductionTraining,@IsDigitalSkillTraining,@EDPIntroDay1,@BusinessPlanDay2,@FinancialLiteracyDay3,@FinancialTermsDay4,@BusinessManagementDay5)
		END
		ELSE
		BEGIN
			INSERT INTO TrainingForm(EnrollmentId,IsLifeSkillsTraining,RCSCDate,WRPCDate,HNCDate,FLCDate,EDTSDate,LEAPDate,
										ESISDate,BMTCDate,MMTCDate,EDPTCDate,CreatedBy,CreatedOn,InductionTrainingDay1,InductionTrainingDay2,DigitalSkillTrainingDay1,DigitalSkillTrainingDay2,DigitalSkillTrainingDay3,
										IsInductionTraining,IsDigitalSkillTraining,EDPIntroDay1,BusinessPlanDay2,FinancialLiteracyDay3,FinancialTermsDay4,BusinessManagementDay5)
						VALUES(@EnrollmentId,@IsLifeSkillsTraining,@RCSCDate,@WRPCDate,@HNCDate,@FLCDate,@EDTSDate,@LEAPDate,
										@ESISDate,@BMTCDate,@MMTCDate,@EDPTCDate,@CreatedBy,GETDATE(),@InductionTrainingDay1,@InductionTrainingDay2,@DigitalSkillTrainingDay1,@DigitalSkillTrainingDay2,@DigitalSkillTrainingDay3,
										@IsInductionTraining,@IsDigitalSkillTraining,@EDPIntroDay1,@BusinessPlanDay2,@FinancialLiteracyDay3,@FinancialTermsDay4,@BusinessManagementDay5)
		END
	END
	ELSE
	BEGIN
		UPDATE TrainingForm SET --IsLifeSkillsTraining=@IsLifeSkillsTraining,
							RCSCDate=@RCSCDate,
							WRPCDate=@WRPCDate,HNCDate=@HNCDate,FLCDate=@FLCDate,EDTSDate=@EDTSDate,
							LEAPDate=@LEAPDate,ESISDate=@ESISDate,BMTCDate=@BMTCDate,MMTCDate=@MMTCDate,
							EDPTCDate=@EDPTCDate,UpdatedBy=@UpdateBy,UpdatedOn=GETDATE(),
							InductionTrainingDay1=@InductionTrainingDay1,InductionTrainingDay2=@InductionTrainingDay2,
							DigitalSkillTrainingDay1=@DigitalSkillTrainingDay1,DigitalSkillTrainingDay2=@DigitalSkillTrainingDay2,
							DigitalSkillTrainingDay3=@DigitalSkillTrainingDay3,
							IsInductionTraining=@IsInductionTraining,
							IsDigitalSkillTraining=@IsDigitalSkillTraining,
							EDPIntroDay1=@EDPIntroDay1,BusinessPlanDay2=@BusinessPlanDay2,FinancialLiteracyDay3=@FinancialLiteracyDay3,
							FinancialTermsDay4=@FinancialTermsDay4,BusinessManagementDay5=@BusinessManagementDay5
							WHERE TrainingId=@TrainingId


		IF(@IsLifeSkillsTraining='Yes')
		BEGIN
			UPDATE TrainingForm set IsTrainingCompleted=1		
			where TrainingId=@TrainingId and RCSCDate!='' and WRPCDate!='' and HNCDate!='' and FLCDate!='' and EDTSDate!='' 
			and LEAPDate!='' and ESISDate!='' and BMTCDate!='' and MMTCDate!='' and EDPTCDate!=''
		END
		ELSE IF(@IsLifeSkillsTraining='No')
		BEGIN
			UPDATE TrainingForm set IsTrainingCompleted=1		
			where EDTSDate!='' and LEAPDate!='' and ESISDate!='' and BMTCDate!='' and MMTCDate!='' and EDPTCDate!=''
		END
	END
END
