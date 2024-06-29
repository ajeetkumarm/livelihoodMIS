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
    public class BL_Scheme
    {
        DL_Scheme obj_DL_Scheme = new DL_Scheme();
        public int BL_InsUpdDelScheme(ML_Scheme obj_ML_Scheme)
        {
            return obj_DL_Scheme.DL_InsUpdDelScheme(obj_ML_Scheme);
        }
        public DataTable BL_SchemeDetails(ML_Scheme obj_ML_Scheme)
        {
            return obj_DL_Scheme.DL_SchemeDetails(obj_ML_Scheme);
        }
    }
}
