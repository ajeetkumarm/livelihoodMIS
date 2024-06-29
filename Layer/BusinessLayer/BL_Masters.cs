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
    public class BL_Masters
    {
        DL_Masters obj_DL_Masters = new DL_Masters();
        public DataTable BL_AllMasters(ML_Masters obj_ML_Masters)
        {
            return obj_DL_Masters.DL_AllMasters(obj_ML_Masters);
        }
        public DataTable BL_ProjectAndEmailUsers(ML_Masters obj_ML_Masters)
        {
            return obj_DL_Masters.DL_ProjectAndEmailUsers(obj_ML_Masters);
        }
    }
}
