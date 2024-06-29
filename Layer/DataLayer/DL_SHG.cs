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
    public class DL_SHG
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelSHG(ML_SHG obj_ML_SHG)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_SHG.Qstring),
                                  new SqlParameter("@ShgId", obj_ML_SHG.ShgId),
                                  new SqlParameter("@ShgName", obj_ML_SHG.ShgName),
                                  new SqlParameter("@CreatedBy", obj_ML_SHG.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_SHG.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_SHGM", par);
        }
        public DataTable DL_SHGDetails(ML_SHG obj_ML_SHG)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_SHG.Qstring),
                                  new SqlParameter("@ShgId", obj_ML_SHG.ShgId),
                                  new SqlParameter("@ShgName", obj_ML_SHG.ShgName),
                                  new SqlParameter("@CreatedBy", obj_ML_SHG.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_SHG.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_SHGM", par).Tables[0];
        }
    }
}
