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
    public class BL_Economic
    {
        DL_Economic obj_DL_Economic = new DL_Economic();
        public int BL_InsUpdDelEconomicStatus(ML_Economic obj_ML_Economic)
        {
            return obj_DL_Economic.DL_InsUpdDelEconomicStatus(obj_ML_Economic);
        }
        public DataTable BL_EconomicStatusDetails(ML_Economic obj_ML_Economic)
        {
            return obj_DL_Economic.DL_EconomicStatusDetails(obj_ML_Economic);
        }
    }
}
