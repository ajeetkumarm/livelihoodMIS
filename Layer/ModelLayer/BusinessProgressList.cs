
namespace ModelLayer
{
    public class BusinessProgressList
    {
        public int RowNum { get; set; }
        public int EnrollmentId { get; set; }
        public int TotalCount { get; set; }
        public string BeneficiaryCode { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string WomenName { get; set; }
        public string PhoneNo { get; set; }
        public string RegistrationDate { get; set; }
        public int BusinessStatus { get; set; }
        public string BusinessStatusDisplay => BusinessStatus == 1 ? "Active" : BusinessStatus == 2 ? "Hold" : BusinessStatus == 3 ? "Closed" : string.Empty;
        public string RegistrationDateDisplay => RegistrationDate != null ? TypeConversionUtility.ToDateTime(RegistrationDate).ToString("dd/MM/yyyy") : string.Empty;
    }
}
