
--Alter Table EnterpriesTrainingForm
--Add ImportedDate DateTime

INSERT INTO EnterpriesTrainingForm
	(EnrollmentId,StartBusiness,BusinessReasons,Business,BusinessWhen,StatusBusiness,VillagePopulation,
	BusinessIdea,BusinessType,ProcureBusiness,CurrentBusiness,RegularFinancialBusiness,HowRegularFinancial,
	SettingBusinessType,MonthlyRent,ExpandBusiness,PotentialCustomers,BusinessDistance,ExpectedFootfall,
	HowFarBussiness,PlanningBusiness,SupportBusiness,SupportType,NotProvidedSupport,
	PaidWorker,DigitalInclusion,DigitalInclusionDate,OwnSmartPhone,UseSmartPhone,SupplyChain,
	IsCompleteEntTraining,CreatedBy,CreatedOn,IsImported,ImportedDate)
	
Select 
E.EnrollmentId, 
CD.[Start Business], CD.[Business Reasons], CD.Business, CD.[Business When], CD.[Status Business], CD.[Village Population], 
CD.[Business Idea], CD.[Business Type], CD.[Procure Business], CD.[Current Business],CD.[Regular Financial Business],CD.[How Regular Financial],
CD.[Setting Business Type],CD.[Monthly Rent],CD.[Expand Business],CD.[Potential Customers],CD.[Business Distance], CD.[Expected Footfall],
CD.[How Far Bussiness], '' , CD.[Support Business], CD.[Support Type], CD.[Not Provided Support],
CD.[Paid Worker], CD.[Digital Inclusion],CD.[Digital Inclusion Date],CD.[Own Smart Phone], CD.[Use Smart Phone], CD.[Supply Chain],
1,E.CreatedBy,GETDATE(),1, GETDATE()
From EnterpriesTrainingExcel CD Inner Join EnrollmentForm E On CD.[Beneficiary Code]=E.BeneficiaryCode
Where CD.[Start Business] <> ''

--Select Count(1) From EnterpriesTrainingExcel