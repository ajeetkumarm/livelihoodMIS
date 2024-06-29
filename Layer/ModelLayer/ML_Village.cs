namespace ModelLayer
{
    public class ML_Village
    {
        public string Qstring { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int BlockId { get; set; }
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class VillageList
    {
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public int  TotalCount { get; set; }
        public int RowNum { get; set; }
    }
}
