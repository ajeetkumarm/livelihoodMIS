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
    public class DL_Reports
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);

        public DataTable DL_RptEnrollmentDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_EnrollmentForm", par).Tables[0];
        }
        public DataTable DL_RptTrainingDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_TrainingForm", par).Tables[0];
        }
        public DataTable DL_RptEnterpriesTrainingDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_EnterpriesTrainingForm", par).Tables[0];
        }
        public DataTable DL_RptBusinessProgressDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_BusinessProgressForm", par).Tables[0];
        }

    }
}
