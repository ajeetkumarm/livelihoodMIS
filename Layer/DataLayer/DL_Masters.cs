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
    public class DL_Masters
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public DataTable DL_AllMasters(ML_Masters obj_ML_Masters)
        {
            SqlParameter[] par = {new SqlParameter("@QType", obj_ML_Masters.QueryType),
                                  new SqlParameter("@StateId", obj_ML_Masters.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_Masters.DistrictId),
                                  new SqlParameter("@BlockId", obj_ML_Masters.BlockId),
                                  new SqlParameter("@VillageId", obj_ML_Masters.VillageId),
                                  new SqlParameter("@DigitalCategoryId", obj_ML_Masters.DigitalCategoryId),
                                  new SqlParameter("@PartnerId", obj_ML_Masters.PartnerId)
            };
            return SqlHelper.ExecuteDataset(con, "USP_AllMasters", par).Tables[0];
        }
        public DataTable DL_ProjectAndEmailUsers(ML_Masters obj_ML_Masters)
        {
            SqlParameter[] par = {new SqlParameter("@Qtype", obj_ML_Masters.QueryType),
                                  new SqlParameter("@UserCategory", obj_ML_Masters.UserCategory),
                                  new SqlParameter("@UserProject", obj_ML_Masters.ProjectId)
            };
            return SqlHelper.ExecuteDataset(con, "USP_ProjectAndEmailFromUser", par).Tables[0];
        }
    }
}
