
Alter Table EnrollmentForm
Add IsImported Int Not NUll Default(0)

Alter Table TrainingForm
Add IsImported Int Not NUll Default(0)

Alter Table EnterpriesTrainingForm
Add IsImported Int Not NUll Default(0)

Select top 10 EnrollmentId, IntrestedEDPTraining,EconomicStatus,Education From EnrollmentForm Where BeneficiaryCode='919364458DurgeshRageshEMP'
--Select * from TrainingForm Where EnrollmentId=19151

--Insert INTo EnrollmentForm
--(	IsImported,BeneficiaryCode,WomenName,HusbandFatherName,MotherName,PhoneNo,ThemeCode,[Cast],
--	EconomicStatus,MaritalStatus,BirthDate,Age,RegistrationDate,State,District, Block, 
--	Village, PartSHG, SHGName, SHGDate, SHGType, Education, PwD, PwDSpecify, AadhaarrCard, AadhaarCardDetails, 
--	AadhaarNo, AnyIDProofDetails, IDProofNo, IssuingAuthority, 
--	RationCard, RationCardlinkedPDS, BankAccountNo, LinkedSocialSecuritySchemes, Reasons, 
--	WomenBelong, ValidCertificate, MonthlyIndividualIncome, MonthlyHouseholdIncome, 
--	Scheme, IntrestedEDPTraining, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn
--)

--Select 
--1,
--[Beneficiary Code],[Women Name],[Husband/Father Name],[Mother Name],[Phone No#],[Theme Code],CastId,
--EconomicStatusId,[Marital Status],[Birth Date],Age,[Registration Date],StateId,DistrictId, BlockId, 
--VillageId, [Part SHG], [SHG Name], [SHG Date], [SHG Type], EducationId, PwD, '', [Aadhaar Card], [Aadhaar Card Details], 
--[Aadhaar No#], [Any ID Proof Details], [ID Proof No#], [Issuing Authority], 
--[Ration Card], [Ration Card linked PDS], [Bank Account No#], [Linked Social Security Schemes], Reasons, 
--[Women Belong], [Valid Certificate], [Monthly Individual Income], [Monthly Household Income], 
--Scheme, 1, CreatedUserId, GETDATE(), CreatedUserId, GETDATE()
--From CDPDisha


--Insert Into TrainingForm (EnrollmentId,IsLifeSkillsTraining,
--RCSCDate,WRPCDate,HNCDate,FLCDate,EDTSDate,LEAPDate,ESISDate,BMTCDate,MMTCDate,EDPTCDate,IsTrainingCompleted,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,IsImported)
--Select 
--E.EnrollmentId, Case When  [Is Life Skills Training] = 'Yes' THEN 1 Else 2 End,
--[RCSC Date],[WRPC Date],[HNC Date],[FLC Date],[EDTS Date],[LEAP Date],[ESIS Date],[BMTC Date],[MMTC Date],[EDPT CDate],1,CreatedUserId,GETDATE(),CreatedUserId,GETDATE(),1
--From CDPDisha CD Inner Join EnrollmentForm E On CD.[Beneficiary Code]=E.BeneficiaryCode


--Select Top 10 * From EnterpriesTrainingForm

INSERT INTO EnterpriesTrainingForm
	(EnrollmentId,StartBusiness,BusinessReasons,Business,BusinessWhen,StatusBusiness,VillagePopulation,
	BusinessIdea,BusinessType,ProcureBusiness,CurrentBusiness,RegularFinancialBusiness,HowRegularFinancial,
	SettingBusinessType,MonthlyRent,ExpandBusiness,PotentialCustomers,BusinessDistance,ExpectedFootfall,
	HowFarBussiness,PlanningBusiness,SupportBusiness,SupportType,NotProvidedSupport,
	PaidWorker,DigitalInclusion,DigitalInclusionDate,OwnSmartPhone,UseSmartPhone,SupplyChain,
	IsCompleteEntTraining,CreatedBy,CreatedOn,IsImported)
	
Select 
E.EnrollmentId, 
CD.[Start Business], CD.[Business Reasons], CD.Business, CD.[Business When], CD.[Status Business], CD.[Village Population], 
CD.[Business Idea], CD.[Business Type], CD.[Procure Business], CD.[Current Business],CD.[Regular Financial Business],CD.[How Regular Financial],
CD.[Setting Business Type],CD.[Monthly Rent],CD.[Expand Business],CD.[Potential Customers],CD.[Business Distance], CD.[Expected Foot fall],
CD.[How Far Bussiness], '' , CD.[Support Business], CD.[Support Type], CD.[Not Provided Support],
CD.[Paid Worker], CD.[Digital Inclusion],CD.[Digital Inclusion Date],CD.[Own Smart Phone], CD.[Use Smart Phone], CD.[Supply Chain],
1,CreatedUserId,GETDATE(),1
From CDPDisha CD Inner Join EnrollmentForm E On CD.[Beneficiary Code]=E.BeneficiaryCode
Where CD.[Start Business] <> ''

--Update M_BLock SET DistrictId=36 Where BlockId=155
-- Insert Block Name ='Naidbai', Rajsthan, Bharatpur

--Update PoP 
--Update PoP SET PoP.[Beneficiary Code]= STR(PoP.[Phone No#], 10, 0)+ dbo.GetStringWithOutSpace(PoP.[Women Name])+ dbo.GetStringWithOutSpace(PoP.[Husband/Father Name])+ 'EMP'
--From CDPDisha PoP INNER JOIN  CDPDisha TPop On 
--PoP.SRNO=TPop.SRNO 


Update PoP SET PoP.EducationId=TPop.EducationId
From CDPDisha PoP INNER JOIN  M_Education TPop On Lower(Pop.Education)= Lower(TPop.EducationName)

Select Education From CDPDisha Where EducationId Is null

--Update CDPDisha SET Education='Post Graduate' Where Education='Post graduation'


Update PoP SET PoP.EconomicStatusId=TPop.EconomicId
From CDPDisha PoP INNER JOIN  M_EconomicStatus TPop On Lower(Pop.[Economic Status])= Lower(TPop.EconomicStatus)

Select * From CDPDisha Where EconomicStatusId Is null

Update PoP SET PoP.CastId=TPop.CastId
From CDPDisha PoP INNER JOIN  M_Cast TPop On Lower(Pop.[Cast])= Lower(TPop.CastName)

Select * From CDPDisha Where CastId Is Null

--Update Created User Id
Update PoP SET PoP.CreatedUserId=TPop.UserCode
From CDPDisha PoP INNER JOIN  UserLogin TPop On Lower(Pop.[UserName (FE)])= Lower(TPop.FirstName +' '+TPop.LastName)

Select * From CDPDisha Where CreatedUserId IS NULL


-- Update State Id
Update PoP SET PoP.StateId=(Select [dbo].[GetState](TPop.State))
From CDPDisha PoP INNER JOIN  CDPDisha TPop On Pop.SRNO=TPop.SRNO

--Update CDPDisha SEt StateId=2 Where [State]=' Rajasthan'

-- Select * From CDPDisha WHere StateId Is Null
-- Select * From M_State WHere StateName='Rajasthan'

-- Update District Id
Update PoP SET PoP.DistrictId=(Select [dbo].[GetDistrict](TPop.District,Tpop.StateId))
From CDPDisha PoP INNER JOIN  CDPDisha TPop On Pop.SRNO=TPop.SRNO
--Select * From CDPDisha WHere DistrictId Is Null

--Update CDPDisha Set DistrictId=40,District='Bharatpur' Where  District=' Bharatpur' and StateId=2
--Select * From CDPDisha Where StateId=2

---- Update Block Id
Update PoP SET PoP.BlockId=(Select [dbo].[GetBlock](TPop.[Block],TPop.DistrictId))
From CDPDisha PoP INNER JOIN  CDPDisha TPop On Pop.SRNO=TPop.SRNO

Update CDPDisha SET [Block]='Kiyara' WHere [Block]='Kyara'

--Select Block, DistrictId,StateId,State,District From CDPDisha Where BlockId Is Null
-- 'Kyara'
-- Select * From M_BLock Where BlockName='Nai'
--Select * From M_District Where DistrictId IN (40)
--Select * From M_State Where StateId=2


UPDATE CDPDisha
SET 
    [Block] = LTRIM(RTRIM([Block])), 
    [Village] = LTRIM(RTRIM([Village]));


---- Update Village ID
Update PoP SET PoP.VillageId=(Select [dbo].[GetVillage](TPop.Village,TPop.DistrictId,TPop.BlockId, TPop.StateId))
From CDPDisha PoP INNER JOIN  CDPDisha TPop On Pop.SRNO=TPop.SRNO



--Update CDPDisha SET DistrictId=36 Where Village='Munshipur' ANd DistrictId=44



Select Distinct Village, DistrictId, District,State, StateId, Block, BlockId From CDPDisha Where VillageId Is Null
Select * From M_District Where DistrictId IN (44,36)
Select * From M_BLock Where BlockId IN (180)
Select * From M_Village Where  VillageName Like '%Munshipur%'

--Select * From CDPDisha Where [Block] ='Kyara' and BlockId=155

--Update CDPDisha SET BlockId=179 Where   DistrictId=39 AND StateId=1 AND BlockId=178  AND Village='Karahara'

--Village Name Not Exist
-- Ichoriya
-- Nagla Singh
-- Karai - Block Name is wrong

