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
    public class DL_Scheme
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelScheme(ML_Scheme obj_ML_Scheme)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Scheme.Qstring),
                                  new SqlParameter("@SchemeId", obj_ML_Scheme.SchemeId),
                                  new SqlParameter("@SchemeName", obj_ML_Scheme.SchemeName),
                                  new SqlParameter("@CreatedBy", obj_ML_Scheme.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Scheme.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_SchemeM", par);
        }
        public DataTable DL_SchemeDetails(ML_Scheme obj_ML_Scheme)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Scheme.Qstring),
                                  new SqlParameter("@SchemeId", obj_ML_Scheme.SchemeId),
                                  new SqlParameter("@SchemeName", obj_ML_Scheme.SchemeName),
                                  new SqlParameter("@CreatedBy", obj_ML_Scheme.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Scheme.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_SchemeM", par).Tables[0];
        }
    }
}
