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
    public class DL_Dashboard
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);

        public DataSet DL_DashboardCount(ML_Dashboard obj_ML_Dashboard)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Dashboard.CreatedUser),
                                   new SqlParameter("@ProjectCode", obj_ML_Dashboard.ProjectCode),
                                   new SqlParameter("@FromDate", obj_ML_Dashboard.FromDate),
                                   new SqlParameter("@ToDate", obj_ML_Dashboard.ToDate),
            };
            return SqlHelper.ExecuteDataset(con, "USP_DashboardCount", par);
        }

        public DataTable DL_FetchProject(ML_Dashboard obj_ML_Dashboard)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Dashboard.CreatedUser) };
            return SqlHelper.ExecuteDataset(con, "USP_FetchProject", par).Tables[0];
        }

    }
}
