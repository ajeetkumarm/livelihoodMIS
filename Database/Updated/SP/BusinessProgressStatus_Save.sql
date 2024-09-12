Create OR Alter Procedure dbo.BusinessProgressStatus_Save
@EnrollmentId			INT,
@BusinessStatus			INT,
@BusinessStatusDate		Varchar(25)=NULL,
@BusinessStatusReason	Varchar(255)=NULL,
@CreatedBy				INT,
@UpdatedBy				INT
AS
	BEGIN
		MERGE BusinessProgressStatus AS T
		USING (Select @EnrollmentId AS EnrollmentId) AS S On T.EnrollmentId=S.EnrollmentId
		When Matched THEN
			Update SET BusinessStatus=@BusinessStatus,BusinessStatusDate=@BusinessStatusDate,BusinessStatusReason=@BusinessStatusReason,UpdatedBy=@UpdatedBy,UpdatedDate=GetDate()
		When Not Matched THEN
			INSERT (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,UpdatedBy,BusinessStatusReason)
				  VALUES(@EnrollmentId,@BusinessStatus,@BusinessStatusDate,@CreatedBy,@UpdatedBy,@BusinessStatusReason);

		-- Add Business Progess Log
		INSERT INTO BusinessProgressStatusLog (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,BusinessStatusReason)
				  VALUES(@EnrollmentId,@BusinessStatus,@BusinessStatusDate,@CreatedBy,@BusinessStatusReason);
	END