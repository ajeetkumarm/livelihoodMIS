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
    public class DL_Theme
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelTheme(ML_Theme obj_ML_Theme)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Theme.Qstring),
                                  new SqlParameter("@ThemeId", obj_ML_Theme.ThemeId),
                                  new SqlParameter("@ThemeName", obj_ML_Theme.ThemeName),
                                  new SqlParameter("@ThemeShortName", obj_ML_Theme.ThemeShortName),
                                  new SqlParameter("@CreatedBy", obj_ML_Theme.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Theme.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_ThemeM", par);
        }
        public DataTable DL_ThemeDetails(ML_Theme obj_ML_Theme)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Theme.Qstring),
                                  new SqlParameter("@ThemeId", obj_ML_Theme.ThemeId),
                                  new SqlParameter("@ThemeName", obj_ML_Theme.ThemeName),
                                  new SqlParameter("@ThemeShortName", obj_ML_Theme.ThemeShortName),
                                  new SqlParameter("@CreatedBy", obj_ML_Theme.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Theme.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_ThemeM", par).Tables[0];
        }
    }
}
