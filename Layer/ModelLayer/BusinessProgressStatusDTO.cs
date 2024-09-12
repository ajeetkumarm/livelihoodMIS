namespace ModelLayer
{
    public class BusinessProgressStatusDTO
    {
        public int EnrollmentId { get; set; }
        public int BusinessStatus { get; set; }
        public string BusinessStatusDate { get; set; }
        public string BusinessStatusReason { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
