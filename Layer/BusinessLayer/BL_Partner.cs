using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class BL_Partner
    {
        DL_Partner obj_DL_Partner=new DL_Partner();
        public int BL_InsUpdDelPartner(ML_Partner obj_ML_Partner)
        {
            return obj_DL_Partner.DL_InsUpdDelPartner(obj_ML_Partner);
        }
        public DataTable BL_PartnerDetails(ML_Partner obj_ML_Partner)
        {
            return obj_DL_Partner.DL_PartnerDetails(obj_ML_Partner);
        }
    }
}
