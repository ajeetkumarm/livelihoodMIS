using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SqlBusinessProgressCustomer
    {
        public static DataSet GetCategoryAndServiceLineList()
        {
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_DigitalCategoryAndServiceLine_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }
    }
}
