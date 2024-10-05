using System;

namespace ModelLayer
{
    public class ML_Dashboard
    {
        public string CreatedUser { get; set; }
        public string ProjectCode { get; set; }
        public int UserType { get; set; }
        public int TotalEnrollment { get; set; }
        public int TotalEDPTraining { get; set; }
        public int TotalEnterpriesTraining { get; set; }
        public int TotalBusinessProgress { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
