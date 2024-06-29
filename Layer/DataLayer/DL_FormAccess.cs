using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;

namespace DataLayer
{
    public class DL_FormAccess
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_UpdUserLoginWithFormAccess(ML_FormAccess obj_ML_FormAccess)
        {
            SqlParameter[] par ={new SqlParameter("@UserCode", obj_ML_FormAccess.UserCode),
                                 new SqlParameter("@FormAccess", obj_ML_FormAccess.FormAccess),
                                  new SqlParameter("@UpdatedBy", obj_ML_FormAccess.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_UpdUserLogin", par);
        }
        public DataTable DL_FetchFormDetails(ML_FormAccess obj_ML_FormAccess)
        {
            SqlParameter[] par ={new SqlParameter("@UserCategory", obj_ML_FormAccess.UserCategoryCode),
                                 new SqlParameter("@ProjectCode", obj_ML_FormAccess.UserProjectCode),
                                  new SqlParameter("@UserCode", obj_ML_FormAccess.UserCode)
                               };
            return SqlHelper.ExecuteDataset(con, "USP_UserFormAccessDetails", par).Tables[0];
        }
    }
}
