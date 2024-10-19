
Alter Table TrainingForm
Add IsInductionTraining Varchar(10) Null,
	IsDigitalSkillTraining Varchar(10) Null

Alter Table TrainingForm
Add EDPIntroDay1 Varchar(25) Null,
	BusinessPlanDay2 Varchar(25) Null,
	FinancialLiteracyDay3 Varchar(25) Null,
	FinancialTermsDay4 Varchar(10) Null,
	BusinessManagementDay5 Varchar(25) Null

Alter Table BusinessProgressForm
Add TotalVillagesCovered Int Null

