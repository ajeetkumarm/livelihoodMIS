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
    public class DL_UserLogin
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public DataTable DL_LoginUserDetails(ML_UserLogin obj_ML_UserLogin)
        {
            SqlParameter[] par = { new SqlParameter("@UserEmail", obj_ML_UserLogin.UserEmail) };
            return SqlHelper.ExecuteDataset(con, "SP_UserLoginDetails", par).Tables[0];
        }

        public int DL_InsUpdUser(ML_UserLogin obj_ML_UserLogin)
        {
            SqlParameter[] par ={new SqlParameter("@UserCode", obj_ML_UserLogin.UserCode),
                                 new SqlParameter("@StateCode", obj_ML_UserLogin.StateCode),
                                  new SqlParameter("@DistrictCode", obj_ML_UserLogin.DistrictCode),
                                  new SqlParameter("@BlockCode", obj_ML_UserLogin.BlockCode),
                                  new SqlParameter("@VillageCode", obj_ML_UserLogin.VillageCode),
                                  new SqlParameter("@PartnerCode", obj_ML_UserLogin.PartnerCode),
                                  new SqlParameter("@ProjectCode", obj_ML_UserLogin.ProjectCode),
                                  new SqlParameter("@LocationCode", obj_ML_UserLogin.LocationCode),
                                  new SqlParameter("@FirstName", obj_ML_UserLogin.FirstName),
                                  new SqlParameter("@LastName", obj_ML_UserLogin.LastName),
                                  new SqlParameter("@ContactNo", obj_ML_UserLogin.ContactNo),
                                  new SqlParameter("@Email", obj_ML_UserLogin.UserEmail),
                                  new SqlParameter("@LoginName", obj_ML_UserLogin.LoginName),
                                  new SqlParameter("@PwdHash", obj_ML_UserLogin.PwdHash),
                                  new SqlParameter("@UserCategory", obj_ML_UserLogin.UserCategory),
                                  new SqlParameter("@CreatedBy", obj_ML_UserLogin.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_UserLogin.UpdatedBy),
                                  new SqlParameter("@EnrollmentId", obj_ML_UserLogin.EnrollmentId),
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_InsUpdUser", par);
        }
        public DataTable DL_UserActInactiveDetails(ML_UserLogin obj_ML_UserLogin)
        {
            SqlParameter[] par = { new SqlParameter("@QType", obj_ML_UserLogin.QType),
                                   new SqlParameter("@UserCode", obj_ML_UserLogin.UserCode)
            };
            return SqlHelper.ExecuteDataset(con, "USP_UserDetails", par).Tables[0];
        }
    }
}
