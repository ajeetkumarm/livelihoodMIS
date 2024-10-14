using DataLayer;
using ModelLayer;
using System.Data;


namespace BusinessLayer
{
    public class BL_Dashboard
    {
        DL_Dashboard obj_DL_Dashboard = new DL_Dashboard();
        //public DataSet BL_DashboardCount(ML_Dashboard obj_ML_Dashboard)
        //{
        //    return obj_DL_Dashboard.DL_DashboardCount(obj_ML_Dashboard);
        //}
        public DashboardCountModel BL_DashboardCount(ML_Dashboard obj_ML_Dashboard)
        {
            return obj_DL_Dashboard.DL_DashboardCount(obj_ML_Dashboard);
        }



        public DataTable BL_FetchProject(ML_Dashboard obj_ML_Dashboard)
        {
            return obj_DL_Dashboard.DL_FetchProject(obj_ML_Dashboard);
        }
    }
}
