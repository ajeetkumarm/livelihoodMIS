Create Table dbo.BusinessProgressStatusLog
(
 Id						Int Not Null Identity(1,1),
 EnrollmentId			INT,
 BusinessStatus			INT,
 BusinessStatusDate		Varchar(25),
 BusinessStatusReason	Varchar(255),
 CreatedBy				INT,
 CreatedDate			DateTime Not Null Default(GetDate()),
)



INSERT INTO BusinessProgressStatus (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,UpdatedBy,BusinessStatusReason)
SELECT 
									EF.EnrollmentId, 
									1,
									Convert(varchar,ET.CreatedOn, 5)
									,ET.CreatedBy
									,ET.CreatedBy
									,''
								    
							FROM EnrollmentForm EF  
							INNER JOIN UserLogin UL ON EF.CreatedBy = UL.UserCode  
							INNER JOIN TrainingForm TF on EF.EnrollmentId = TF.EnrollmentId  
							INNER JOIN EnterpriesTrainingForm ET on EF.EnrollmentId=ET.EnrollmentId
							WHERE 1=1 AND ET.IsCompleteEntTraining=1 

INSERT INTO BusinessProgressStatusLog (EnrollmentId,BusinessStatus,BusinessStatusDate,CreatedBy,BusinessStatusReason)
SELECT 
									EF.EnrollmentId, 
									1,
									Convert(varchar,ET.CreatedOn, 5)
									,ET.CreatedBy
									,''
								    
							FROM EnrollmentForm EF  
							INNER JOIN UserLogin UL ON EF.CreatedBy = UL.UserCode  
							INNER JOIN TrainingForm TF on EF.EnrollmentId = TF.EnrollmentId  
							INNER JOIN EnterpriesTrainingForm ET on EF.EnrollmentId=ET.EnrollmentId
							WHERE 1=1 AND ET.IsCompleteEntTraining=1 