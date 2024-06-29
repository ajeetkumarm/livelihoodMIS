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
    public class DL_Cast
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelCast(ML_Cast obj_ML_Cast)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Cast.Qstring),
                                  new SqlParameter("@CastId", obj_ML_Cast.CastId),
                                  new SqlParameter("@CastName", obj_ML_Cast.CastName),
                                  new SqlParameter("@CreatedBy", obj_ML_Cast.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Cast.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_CastM", par);
        }
        public DataTable DL_CastDetails(ML_Cast obj_ML_Cast)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Cast.Qstring),
                                  new SqlParameter("@CastId", obj_ML_Cast.CastId),
                                  new SqlParameter("@CastName", obj_ML_Cast.CastName),
                                  new SqlParameter("@CreatedBy", obj_ML_Cast.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Cast.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_CastM", par).Tables[0];
        }
    }
}
