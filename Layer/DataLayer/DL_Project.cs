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
    public class DL_Project
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelProject(ML_Project obj_ML_Project)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Project.Qstring),
                                 new SqlParameter("@ProjectId", obj_ML_Project.ProjectId),
                                 new SqlParameter("@PartnerId", obj_ML_Project.PartnerId),
                                 new SqlParameter("@ProjectName", obj_ML_Project.ProjectName),
                                 new SqlParameter("@CreatedBy", obj_ML_Project.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_Project.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_ProjectM", par);
        }
        public DataTable DL_ProjectDetails(ML_Project obj_ML_Project)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Project.Qstring),
                                 new SqlParameter("@ProjectId", obj_ML_Project.ProjectId),
                                 new SqlParameter("@PartnerId", obj_ML_Project.PartnerId),
                                 new SqlParameter("@ProjectName", obj_ML_Project.ProjectName),
                                 new SqlParameter("@CreatedBy", obj_ML_Project.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_Project.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_ProjectM", par).Tables[0];
        }
    }
}
