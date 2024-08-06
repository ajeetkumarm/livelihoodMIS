using System;

namespace ModelLayer
{
    [Serializable]
    public class EnterpriesTrainingReportList
    {
        public int RowNum { get; set; }
        public int EnrollmentId { get; set;     }
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
        public DateTime? CreatedOn { get; set; }
        public string CreatedDisplay => CreatedOn != null ? TypeConversionUtility.ToDateTime(CreatedOn).ToString("dd/MM/yyyy") : string.Empty;
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedDisplay => UpdatedOn != null ? TypeConversionUtility.ToDateTime(UpdatedOn).ToString("dd/MM/yyyy") : string.Empty;
    }
}
