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
    public class DL_State
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);       
        public int DL_InsState(ML_State obj_ML_State)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_State.Qstring),
                                  new SqlParameter("@StateId", obj_ML_State.StateId),
                                  new SqlParameter("@StateName", obj_ML_State.StateName),
                                  new SqlParameter("@CreatedBy", obj_ML_State.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_State.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_StateM", par);
        }
        public DataTable DL_StateDetails(ML_State obj_ML_State)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_State.Qstring),
                                  new SqlParameter("@StateId", obj_ML_State.StateId),
                                  new SqlParameter("@StateName", obj_ML_State.StateName),
                                  new SqlParameter("@CreatedBy", obj_ML_State.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_State.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_StateM", par).Tables[0];
        }
        public int DL_UpdState(ML_State obj_ML_State)
        {
            SqlParameter[] par ={ new SqlParameter("@QString",obj_ML_State.Qstring),
                                  new SqlParameter("@StateId",obj_ML_State.StateId),
                                  new SqlParameter("@StateName",obj_ML_State.StateName),
                                  new SqlParameter("@CreatedBy", obj_ML_State.CreatedBy),
                                  new SqlParameter("@UpdatedBy",obj_ML_State.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_StateM", par);
        }
        public int DL_StateDelete(ML_State obj_ML_State)
        {
            SqlParameter[] par ={new SqlParameter("@QString",obj_ML_State.Qstring),
                                 new SqlParameter("@StateId",obj_ML_State.StateId),
                                 new SqlParameter("@StateName",obj_ML_State.StateName),
                                 new SqlParameter("@CreatedBy", obj_ML_State.CreatedBy),
                                 new SqlParameter("@UpdatedBy",obj_ML_State.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_StateM", par);
        }
        
    }
}
