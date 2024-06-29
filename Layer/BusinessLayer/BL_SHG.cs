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
    public class BL_SHG
    {
        DL_SHG obj_DL_SHG = new DL_SHG();
        public int BL_InsUpdDelSHG(ML_SHG obj_ML_SHG)
        {
            return obj_DL_SHG.DL_InsUpdDelSHG(obj_ML_SHG);
        }
        public DataTable BL_SHGDetails(ML_SHG obj_ML_SHG)
        {
            return obj_DL_SHG.DL_SHGDetails(obj_ML_SHG);
        }
    }
}
