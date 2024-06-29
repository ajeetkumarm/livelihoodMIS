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
    public class BL_Cast
    {
        DL_Cast obj_DL_Cast = new DL_Cast();
        public int BL_InsUpdDelCast(ML_Cast obj_ML_Cast)
        {
            return obj_DL_Cast.DL_InsUpdDelCast(obj_ML_Cast);
        }
        public DataTable BL_CastDetails(ML_Cast obj_ML_Cast)
        {
            return obj_DL_Cast.DL_CastDetails(obj_ML_Cast);
        }
    }
}
