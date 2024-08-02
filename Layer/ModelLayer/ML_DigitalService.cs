namespace ModelLayer
{
    public class ML_DigitalService
    {
        public string Qstring { get; set; }
        public int ServiceId { get; set; }
        public int DigitalCategoryId { get; set; }
        public string ServiceLine { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? DisplayOrder { get; set; } = null;
        public string ServiceURL { get; set; }
    }
}
