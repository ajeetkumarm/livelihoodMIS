Create OR ALTER Procedure dbo.usp_EDPTrainingMoveToEnrollment
@EnrollmentId			INT,
@UpdatedBy				INT
As
	BEGIN
			Update EnrollmentForm SET IntrestedEDPTraining=0, UpdatedBy=@UpdatedBy, UpdatedOn=GETDATE() Where EnrollmentId=@EnrollmentId
			Delete TrainingForm Where EnrollmentId=@EnrollmentId
	END