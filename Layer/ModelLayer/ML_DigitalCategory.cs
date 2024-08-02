namespace ModelLayer
{
    public class ML_DigitalCategory
    {
        public string Qstring { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? DisplayOrder { get; set; } = null;
    }
}
