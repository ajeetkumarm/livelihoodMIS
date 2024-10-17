ALTER PROCEDURE [dbo].[USP_FetchTraining]
(
	@EnrollmentId int='1'
)
AS
BEGIN
	SELECT TrainingId,EnrollmentId,IsLifeSkillsTraining,RCSCDate,WRPCDate,HNCDate,FLCDate,EDTSDate,LEAPDate,
	ESISDate,BMTCDate,MMTCDate,EDPTCDate,InductionTrainingDay1,InductionTrainingDay2,DigitalSkillTrainingDay1,DigitalSkillTrainingDay2,DigitalSkillTrainingDay3
	FROM TrainingForm WHERE EnrollmentId=@EnrollmentId
END
