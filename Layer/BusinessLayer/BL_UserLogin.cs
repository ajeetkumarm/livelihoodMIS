using DataLayer;
using ModelLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_UserLogin
    {
        DL_UserLogin obj_DL_UserLogin = new DL_UserLogin();
        public DataTable BL_LoginUserDetails(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_LoginUserDetails(obj_ML_UserLogin);
        }
        public int BL_InsUpdUser(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_InsUpdUser(obj_ML_UserLogin);
        }
        public DataTable BL_UserActInactiveDetails(ML_UserLogin obj_ML_UserLogin)
        {
            return obj_DL_UserLogin.DL_UserActInactiveDetails(obj_ML_UserLogin);
        }

        public bool EntrepreneurRegisterAsUser(int enrollmentId)
        {
            ML_UserLogin userInformation = new ML_UserLogin();
            DL_Enrollment obj_DL_Enrollment = new DL_Enrollment();
            DataTable dt = obj_DL_Enrollment.GetEnrollmentDetailById(enrollmentId);
            if (dt.Rows.Count > 0)
            {

                var WomenName = TypeConversionUtility.ToStringWithNull(dt.Rows[0]["WomenName"]).Split(' ');

                if (WomenName.Length > 1)
                {
                    userInformation.FirstName = WomenName[0];
                    userInformation.LastName = WomenName[1];
                }
                else
                {
                    userInformation.FirstName = WomenName[0];
                    userInformation.LastName = "";
                }
                userInformation.ContactNo = TypeConversionUtility.ToStringWithNull(dt.Rows[0]["PhoneNo"]);
                string email = enrollmentId+'-'+ userInformation.ContactNo;

                userInformation.UserEmail = email;
                userInformation.LoginName = email;
                string NewPwd = SHAValidator.SHAValid(userInformation.ContactNo);
                userInformation.PwdHash = NewPwd;
                userInformation.UserCategory = "8";
                userInformation.CreatedBy = "1";
                userInformation.ProjectCode = TypeConversionUtility.ToInteger(dt.Rows[0]["ProjectCode"]);
                userInformation.PartnerCode = TypeConversionUtility.ToInteger(dt.Rows[0]["PartnerCode"]);
                userInformation.LocationCode = TypeConversionUtility.ToInteger(dt.Rows[0]["LocationCode"]);
                userInformation.EnrollmentId = enrollmentId;
                userInformation.StateCode = TypeConversionUtility.ToInteger(dt.Rows[0]["State"]);   
                userInformation.DistrictCode = TypeConversionUtility.ToInteger(dt.Rows[0]["District"]); 
                userInformation.BlockCode = TypeConversionUtility.ToInteger(dt.Rows[0]["Block"]); 
                userInformation.VillageCode = TypeConversionUtility.ToInteger(dt.Rows[0]["Village"]); 


                var userCode = obj_DL_UserLogin.DL_InsUpdUser(userInformation);

                return userCode > 0;
            }

            return false;
            
        }
    }
}
