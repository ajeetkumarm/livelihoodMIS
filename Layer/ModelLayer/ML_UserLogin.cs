using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ML_UserLogin
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int UserRole { get; set; }
        public string LoginLogout { get; set; }
        public string IP { get; set; }
        public string PageName { get; set; }

        public string QType { get; set; }
        public int UserCode { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public int BlockCode { get; set; }
        public int VillageCode { get; set; }
        public int PartnerCode { get; set; }
        public int ProjectCode { get; set; }
        public int LocationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string LoginName { get; set; }
        public string PwdHash { get; set; }
        public string IsActive { get; set; }
        public string UserCategory { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

    }
}
