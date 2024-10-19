
using System;

namespace ModelLayer
{
    public class TrainingReportList
    {
        public int RowNum { get; set; }
        public int EnrollmentId { get; set; }
        public int TotalCount { get; set; }
        public int TrainingId { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        public string CreatedDisplay => CreatedOn != null ? TypeConversionUtility.ToDateTime(CreatedOn).ToString("dd/MM/yyyy") : string.Empty;
        public DateTime? UpdatedOn { get; set; }
        public string IsInductionTraining { get; set; }
        public string InductionTrainingDay1 { get; set; }
        public string InductionTrainingDay2 { get; set; }
        public string IsDigitalSkillTraining { get; set; }
        public string DigitalSkillTrainingDay1 { get; set; }
        public string DigitalSkillTrainingDay2 { get; set; }
        public string DigitalSkillTrainingDay3 { get; set; }
        public string EDPIntroDay1 { get; set; }
        public string BusinessPlanDay2 { get; set; }
        public string FinancialLiteracyDay3 { get; set; }
        public string FinancialTermsDay4 { get; set; }
        public string BusinessManagementDay5 { get; set; }
    }
}
