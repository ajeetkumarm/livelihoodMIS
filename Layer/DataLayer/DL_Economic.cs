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
    public class DL_Economic
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelEconomicStatus(ML_Economic obj_ML_Economic)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Economic.Qstring),
                                  new SqlParameter("@EcoStatusId", obj_ML_Economic.EconomicId),
                                  new SqlParameter("@EcoStatusName", obj_ML_Economic.EconomicStatus),
                                  new SqlParameter("@CreatedBy", obj_ML_Economic.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Economic.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_EconomicStatusM", par);
        }
        public DataTable DL_EconomicStatusDetails(ML_Economic obj_ML_Economic)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Economic.Qstring),
                                  new SqlParameter("@EcoStatusId", obj_ML_Economic.EconomicId),
                                  new SqlParameter("@EcoStatusName", obj_ML_Economic.EconomicStatus),
                                  new SqlParameter("@CreatedBy", obj_ML_Economic.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Economic.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_EconomicStatusM", par).Tables[0];
        }
    }
}
