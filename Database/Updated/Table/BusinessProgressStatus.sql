Create Table dbo.BusinessProgressStatus
(
 Id						Int Not Null Identity(1,1),
 EnrollmentId			INT,
 BusinessStatus			INT,
 BusinessStatusDate		Varchar(25),
 BusinessStatusReason	Varchar(255),
 CreatedBy				INT,
 CreatedDate			DateTime Not Null Default(GetDate()),
 UpdatedBy				INT,
 UpdatedDate			DateTime Not Null Default(GetDate())	
)