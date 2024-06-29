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
    public class DL_ProjectLocation
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelProjectLoction(ML_ProjectLocation obj_ML_ProjectLocation)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_ProjectLocation.Qstring),
                                 new SqlParameter("@ProjectId", obj_ML_ProjectLocation.ProjectId),
                                 new SqlParameter("@ProjectName", obj_ML_ProjectLocation.ProjectName),
                                 new SqlParameter("@CreatedBy", obj_ML_ProjectLocation.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_ProjectLocation.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_ProjectLocationM", par);
        }
        public DataTable DL_ProjectLoctionDetails(ML_ProjectLocation obj_ML_ProjectLocation)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_ProjectLocation.Qstring),
                                 new SqlParameter("@ProjectId", obj_ML_ProjectLocation.ProjectId),
                                 new SqlParameter("@ProjectName", obj_ML_ProjectLocation.ProjectName),
                                 new SqlParameter("@CreatedBy", obj_ML_ProjectLocation.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_ProjectLocation.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_ProjectLocationM", par).Tables[0];
        }
    }
}
