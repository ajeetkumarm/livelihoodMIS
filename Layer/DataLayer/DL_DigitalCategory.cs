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
    public class DL_DigitalCategory
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelDigitalCategory(ML_DigitalCategory obj_ML_DigitalCategory)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_DigitalCategory.Qstring),
                                 new SqlParameter("@CategoryId", obj_ML_DigitalCategory.CategoryId),
                                 new SqlParameter("@Category", obj_ML_DigitalCategory.Category),
                                 new SqlParameter("@CreatedBy", obj_ML_DigitalCategory.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_DigitalCategory.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_DigitalCategoryM", par);
        }
        public DataTable DL_DigitalCategoryDetails(ML_DigitalCategory obj_ML_DigitalCategory)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_DigitalCategory.Qstring),
                                 new SqlParameter("@CategoryId", obj_ML_DigitalCategory.CategoryId),
                                 new SqlParameter("@Category", obj_ML_DigitalCategory.Category),
                                 new SqlParameter("@CreatedBy", obj_ML_DigitalCategory.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_DigitalCategory.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_DigitalCategoryM", par).Tables[0];
        }
    }
}
