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
    public class DL_District
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelDistrict(ML_District obj_ML_District)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_District.Qstring),
                                  new SqlParameter("@StateId", obj_ML_District.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_District.DistrictId),
                                  new SqlParameter("@DistrictName", obj_ML_District.DistrictName),
                                  new SqlParameter("@CreatedBy", obj_ML_District.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_District.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_DistrictM", par);
        }
        public DataTable DL_DistrictDetails(ML_District obj_ML_District)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_District.Qstring),
                                  new SqlParameter("@StateId", obj_ML_District.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_District.DistrictId),
                                  new SqlParameter("@DistrictName", obj_ML_District.DistrictName),
                                  new SqlParameter("@CreatedBy", obj_ML_District.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_District.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_DistrictM", par).Tables[0];
        }
    }
}
