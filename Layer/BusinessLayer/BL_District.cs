using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ModelLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_District
    {
        DL_District obj_DL_District = new DL_District();
        public int BL_InsUpdDelDistrict(ML_District obj_ML_District)
        {
            return obj_DL_District.DL_InsUpdDelDistrict(obj_ML_District);
        }
        public DataTable BL_DistrictDetails(ML_District obj_ML_District)
        {
            return obj_DL_District.DL_DistrictDetails(obj_ML_District);
        }
    }
}
