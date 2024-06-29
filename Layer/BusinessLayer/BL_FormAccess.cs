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
    public class BL_FormAccess
    {
        DL_FormAccess obj_DL_FormAccess = new DL_FormAccess();
        public int BL_UpdUserLoginWithFormAccess(ML_FormAccess obj_ML_FormAccess)
        {
            return obj_DL_FormAccess.DL_UpdUserLoginWithFormAccess(obj_ML_FormAccess);
        }
        public DataTable BL_FetchFormDetails(ML_FormAccess obj_ML_FormAccess)
        {
            return obj_DL_FormAccess.DL_FetchFormDetails(obj_ML_FormAccess);
        }
    }
}
