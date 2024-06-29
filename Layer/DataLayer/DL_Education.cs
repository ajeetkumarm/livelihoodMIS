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
    public class DL_Education
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelEducation(ML_Education obj_ML_Education)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Education.Qstring),
                                  new SqlParameter("@EducationId", obj_ML_Education.EducationId),
                                  new SqlParameter("@EducationName", obj_ML_Education.EducationName),
                                  new SqlParameter("@CreatedBy", obj_ML_Education.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Education.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_EducationM", par);
        }
        public DataTable DL_EducationDetails(ML_Education obj_ML_Education)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Education.Qstring),
                                  new SqlParameter("@EducationId", obj_ML_Education.EducationId),
                                  new SqlParameter("@EducationName", obj_ML_Education.EducationName),
                                  new SqlParameter("@CreatedBy", obj_ML_Education.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Education.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_EducationM", par).Tables[0];
        }
    }
}
