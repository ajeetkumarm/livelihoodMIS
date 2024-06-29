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
    public class DL_UserCategory
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelUserCategory(ML_UserCategory obj_ML_UserCategory)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_UserCategory.Qstring),
                                 new SqlParameter("@CategoryId", obj_ML_UserCategory.CategoryId),
                                 new SqlParameter("@Category", obj_ML_UserCategory.Category),
                                 new SqlParameter("@CreatedBy", obj_ML_UserCategory.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_UserCategory.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_UserCategoryM", par);
        }
        public DataTable DL_UserCategoryDetails(ML_UserCategory obj_ML_UserCategory)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_UserCategory.Qstring),
                                 new SqlParameter("@CategoryId", obj_ML_UserCategory.CategoryId),
                                 new SqlParameter("@Category", obj_ML_UserCategory.Category),
                                 new SqlParameter("@CreatedBy", obj_ML_UserCategory.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_UserCategory.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_UserCategoryM", par).Tables[0];
        }
    }
}
