using System.Data;
using System.Data.SqlClient;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;

namespace DataLayer
{
    public class DL_Dashboard
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);

        //public DataSet DL_DashboardCount(ML_Dashboard obj_ML_Dashboard)
        //{
        //    SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Dashboard.CreatedUser),
        //                           new SqlParameter("@ProjectCode", obj_ML_Dashboard.ProjectCode),
        //                           new SqlParameter("@FromDate", obj_ML_Dashboard.FromDate),
        //                           new SqlParameter("@ToDate", obj_ML_Dashboard.ToDate),
        //    };
        //    return SqlHelper.ExecuteDataset(con, "USP_DashboardCount", par);
        //}

        public DashboardCountModel DL_DashboardCount(ML_Dashboard obj_ML_Dashboard)
        {
            DashboardCountModel objDashboardCountModel = new DashboardCountModel();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_DashboardCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreatedUser", obj_ML_Dashboard.CreatedUser);
                    cmd.Parameters.AddWithValue("@Project", obj_ML_Dashboard.ProjectCode);
                    cmd.Parameters.AddWithValue("@FromDate", obj_ML_Dashboard.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", obj_ML_Dashboard.ToDate);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objDashboardCountModel.TotalEnrollment = TypeConversionUtility.ToInteger(dr["TotalEnrollment"]);
                            objDashboardCountModel.TotalEDPTraining = TypeConversionUtility.ToInteger(dr["TotalEDPTraining"]);
                            objDashboardCountModel.TotalEnterpriesTraining = TypeConversionUtility.ToInteger(dr["TotalEnterpriesTraining"]);
                            objDashboardCountModel.TotalBusinessProgress = TypeConversionUtility.ToInteger(dr["TotalBusinessProgress"]);
                            objDashboardCountModel.TotalBusinessNew = TypeConversionUtility.ToInteger(dr["TotalBusinessNew"]);
                            objDashboardCountModel.TotalBusinessUpgrade = TypeConversionUtility.ToInteger(dr["TotalBusinessUpgrade"]);
                            objDashboardCountModel.TotalBusinessInnovative = TypeConversionUtility.ToInteger(dr["TotalBusinessInnovative"]);
                            objDashboardCountModel.TotalFinancialLiteracyTraining = TypeConversionUtility.ToInteger(dr["TotalFinancialLiteracyTraining"]);

                            objDashboardCountModel.TotalBusinessProgressActive = TypeConversionUtility.ToInteger(dr["TotalBusinessProgressActive"]);
                            objDashboardCountModel.TotalBusinessProgressHold = TypeConversionUtility.ToInteger(dr["TotalBusinessProgressHold"]);
                            objDashboardCountModel.TotalBusinessProgressClose = TypeConversionUtility.ToInteger(dr["TotalBusinessProgressClose"]);
                        }
                    }
                }
            }
            return objDashboardCountModel;
        }

        //public static List<BusinessProgressCustomerCountEntity> GetBusinessProgressServiceLineCount(int enrollmentId)
        //{
        //    List<BusinessProgressCustomerCountEntity> lstBusinessProgressCustomerCount = new List<BusinessProgressCustomerCountEntity>();
        //    using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("usp_BusinessProgressServiceLineCount", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    BusinessProgressCustomerCountEntity objBusinessProgressCustomerCount = new BusinessProgressCustomerCountEntity();
        //                    objBusinessProgressCustomerCount.Category = TypeConversionUtility.ToStringWithNull(dr["Category"]);
        //                    objBusinessProgressCustomerCount.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
        //                    lstBusinessProgressCustomerCount.Add(objBusinessProgressCustomerCount);
        //                }
        //            }
        //        }
        //    }
        //    return lstBusinessProgressCustomerCount;
        //}

        public DataTable DL_FetchProject(ML_Dashboard obj_ML_Dashboard)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Dashboard.CreatedUser) };
            return SqlHelper.ExecuteDataset(con, "USP_FetchProject", par).Tables[0];
        }

    }
}
