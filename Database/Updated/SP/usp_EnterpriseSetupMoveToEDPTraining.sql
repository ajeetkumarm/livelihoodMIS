Create OR Alter Procedure dbo.usp_EnterpriseSetupMoveToEDPTraining
@EnrollmentId		INT,
@UpdatedBy			INT
As
	BEGIN
			Delete EnterpriesTrainingForm Where EnrollmentId=@EnrollmentId
			Update TrainingForm SET IsTrainingCompleted=0, UpdatedBy=@UpdatedBy, UpdatedOn=GETDATE() WHere EnrollmentId=@EnrollmentId
	END