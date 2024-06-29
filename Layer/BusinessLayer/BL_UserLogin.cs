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
    public class BL_UserLogin
    {
        DL_UserLogin obj_DL_UserLogin = new DL_UserLogin();
        public DataTable BL_LoginUserDetails(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_LoginUserDetails(obj_ML_UserLogin);
        }
        public int BL_InsUpdUser(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_InsUpdUser(obj_ML_UserLogin);
        }
        public DataTable BL_UserActInactiveDetails(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_UserActInactiveDetails(obj_ML_UserLogin);
        }
    }
}
