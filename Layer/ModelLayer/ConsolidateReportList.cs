using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ConsolidateReportList
    {
        public int RowNum { get; set; }
        public int EnrollmentId { get; set; }
        public int TotalCount { get; set; }
        public string BeneficiaryCode { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string WomenName { get; set; }
        public string HusbandFatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo { get; set; }
        public string ThemeCode { get; set; }
        public int Cast { get; set; }
        public string CastName { get; set; }
        public string EconomicStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string BirthDate { get; set; }
        public string BirthDateDisplay => BirthDate != null ? TypeConversionUtility.ToDateTime(BirthDate).ToString("dd/MM/yyyy") : string.Empty;
        public int Age { get; set; }
        public string PartSHG { get; set; }
        public string SHGName { get; set; }
        public int SHGType { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationDateDisplay => RegistrationDate != null ? TypeConversionUtility.ToDateTime(RegistrationDate).ToString("dd/MM/yyyy") : string.Empty;
        public string SHGDate { get; set; }
        public string SHGDateDisplay => SHGDate != null ? TypeConversionUtility.ToDateTime(SHGDate).ToString("dd/MM/yyyy") : string.Empty;
        public int Education { get; set; }
        public string EducationName { get; set; }
        public string PwD { get; set; }
        public string PwDSpecify { get; set; }
        public string AadhaarrCard { get; set; }
        public string AadhaarCardDetails { get; set; }
        public string AadhaarNo { get; set; }
        public string AnyIDProofDetails { get; set; }
        public string IDProofNo { get; set; }
        public string IssuingAuthority { get; set; }
        public string RationCard { get; set; }
        public string RationCardlinkedPDS { get; set; }
        public string BankAccountNo { get; set; }
        public string LinkedSocialSecuritySchemes { get; set; }
        public string Reasons { get; set; }
        public string WomenBelong { get; set; }
        public string ValidCertificate { get; set; }
        public string MonthlyIndividualIncome { get; set; }
        public string MonthlyHouseholdIncome { get; set; }
        public string Scheme { get; set; }
        public string SchemeName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedDisplay => CreatedOn != null ? TypeConversionUtility.ToDateTime(CreatedOn).ToString("dd/MM/yyyy") : string.Empty;
        public DateTime? UpdatedOn { get; set; }
        public string EmployeeId { get; set; }
        public string ReplacementEmployeeId { get; set; }
        public string ReplacementBeneficiaryCode { get; set; }
        public string EnrollmentStatus { get; set; }
        public string CohortValue { get; set; }

        // EDP Training Report Data
        public string IsLifeSkillsTraining { get; set; }
        public string RCSCDate { get; set; }
        public string WRPCDate { get; set; }
        public string HNCDate { get; set; }
        public string FLCDate { get; set; }
        public string EDTSDate { get; set; }
        public string LEAPDate { get; set; }
        public string ESISDate { get; set; }
        public string BMTCDate { get; set; }
        public string MMTCDate { get; set; }
        public string EDPTCDate { get; set; }
        public int IsTrainingCompleted { get; set; }

        // Add Enterpries Training Report
        public string StartBusiness { get; set; }
        public string BusinessReasons { get; set; }
        public string Business { get; set; }
        public string BusinessWhen { get; set; }
        public string StatusBusiness { get; set; }
        public string VillagePopulation { get; set; }
        public string BusinessIdea { get; set; }
        public string BusinessType { get; set; }
        public string ProcureBusiness { get; set; }
        public string CurrentBusiness { get; set; }
        public string RegularFinancialBusiness { get; set; }
        public string HowRegularFinancial { get; set; }
        public string SettingBusinessType { get; set; }
        public string MonthlyRent { get; set; }
        public string ExpandBusiness { get; set; }
        public string PotentialCustomers { get; set; }
        public string BusinessDistance { get; set; }
        public string ExpectedFootfall { get; set; }
        public string HowFarBussiness { get; set; }
        public string PlanningBusiness { get; set; }
        public string SupportBusiness { get; set; }
        public string SupportType { get; set; }
        public string NotProvidedSupport { get; set; }
        public string PaidWorker { get; set; }
        public string DigitalInclusion { get; set; }
        public string DigitalInclusionDate { get; set; }
        public string OwnSmartPhone { get; set; }
        public string UseSmartPhone { get; set; }
        public string SupplyChain { get; set; }
        public int IsCompleteEntTraining { get; set; }
    }
}