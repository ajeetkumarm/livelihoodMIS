using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DB_Connection
    {
        public static string Livelihood_Connection
        {
            get
            {
                //return ConfigurationManager.AppSettings["Con_Livelihood"].ToString();
                return ConfigurationManager.ConnectionStrings["Con_Livelihood"].ConnectionString;
            }
        }
    }
}
