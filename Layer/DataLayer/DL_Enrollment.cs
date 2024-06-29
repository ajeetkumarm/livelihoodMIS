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
    public class DL_Enrollment
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsEnrollment(ML_Enrollment obj_ML_Enrollment)
        {
            SqlParameter[] par ={ new SqlParameter("@BeneficiaryCode", obj_ML_Enrollment.BeneficiaryCode),
                                  new SqlParameter("@WomenName", obj_ML_Enrollment.WomenName),
                                  new SqlParameter("@HusbandFatherName", obj_ML_Enrollment.HusbandFatherName),
                                  new SqlParameter("@MotherName", obj_ML_Enrollment.MotherName),
                                  new SqlParameter("@PhoneNo", obj_ML_Enrollment.PhoneNo),
                                  new SqlParameter("@ThemeCode", obj_ML_Enrollment.ThemeCode),
                                  new SqlParameter("@Cast", obj_ML_Enrollment.Cast),
                                  new SqlParameter("@EconomicStatus", obj_ML_Enrollment.EconomicStatus),
                                  new SqlParameter("@MaritalStatus", obj_ML_Enrollment.MaritalStatus),
                                  new SqlParameter("@BirthDate", obj_ML_Enrollment.BirthDate),
                                  new SqlParameter("@Age", obj_ML_Enrollment.Age),
                                  new SqlParameter("@RegistrationDate", obj_ML_Enrollment.RegistrationDate),
                                  new SqlParameter("@State", obj_ML_Enrollment.State),
                                  new SqlParameter("@District", obj_ML_Enrollment.District),
                                  new SqlParameter("@Block", obj_ML_Enrollment.Block),
                                  new SqlParameter("@Village", obj_ML_Enrollment.Village),
                                  new SqlParameter("@PartSHG", obj_ML_Enrollment.PartSHG),
                                  new SqlParameter("@SHGName", obj_ML_Enrollment.SHGName),
                                  new SqlParameter("@SHGDate", obj_ML_Enrollment.SHGDate),
                                  new SqlParameter("@SHGType", obj_ML_Enrollment.SHGType),
                                  new SqlParameter("@Education", obj_ML_Enrollment.Education),
                                  new SqlParameter("@PwD", obj_ML_Enrollment.PwD),
                                  new SqlParameter("@PwDSpecify", obj_ML_Enrollment.PwDSpecify),
                                  new SqlParameter("@AadhaarrCard", obj_ML_Enrollment.AadhaarrCard),
                                  new SqlParameter("@AadhaarCardDetails", obj_ML_Enrollment.AadhaarCardDetails),
                                  new SqlParameter("@AadhaarNo", obj_ML_Enrollment.AadhaarNo),
                                  new SqlParameter("@AnyIDProofDetails", obj_ML_Enrollment.AnyIDProofDetails),
                                  new SqlParameter("@IDProofNo", obj_ML_Enrollment.IDProofNo),
                                  new SqlParameter("@IssuingAuthority", obj_ML_Enrollment.IssuingAuthority),
                                  new SqlParameter("@RationCard", obj_ML_Enrollment.RationCard),
                                  new SqlParameter("@RationCardlinkedPDS", obj_ML_Enrollment.RationCardlinkedPDS),
                                  new SqlParameter("@BankAccountNo", obj_ML_Enrollment.BankAccountNo),
                                  new SqlParameter("@LinkedSocialSecuritySchemes", obj_ML_Enrollment.LinkedSocialSecuritySchemes),
                                  new SqlParameter("@WomenBelong", obj_ML_Enrollment.WomenBelong),
                                  new SqlParameter("@ValidCertificate", obj_ML_Enrollment.ValidCertificate),
                                  new SqlParameter("@MonthlyIndividualIncome", obj_ML_Enrollment.MonthlyIndividualIncome),
                                  new SqlParameter("@MonthlyHouseholdIncome", obj_ML_Enrollment.MonthlyHouseholdIncome),
                                  new SqlParameter("@Scheme", obj_ML_Enrollment.Scheme),
                                  new SqlParameter("@CreatedBy", obj_ML_Enrollment.CreatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_InsEnrollmentForm", par);
        }
        //public DataTable DL_EnrollmentDetails(ML_Enrollment obj_ML_Enrollment)
        //{
        //    SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Economic.Qstring),
        //                          new SqlParameter("@EcoStatusId", obj_ML_Economic.EconomicId),
        //                          new SqlParameter("@EcoStatusName", obj_ML_Economic.EconomicStatus),
        //                          new SqlParameter("@CreatedBy", obj_ML_Economic.CreatedBy),
        //                          new SqlParameter("@UpdatedBy", obj_ML_Economic.UpdatedBy)
        //    };
        //    return SqlHelper.ExecuteDataset(con, "USP_Enrollment", par).Tables[0];
        //}
        
        public DataTable DL_EnrollmentDetails(ML_Enrollment obj_ML_Enrollment)
        {
            SqlParameter[] par = { new SqlParameter("@QueryType", obj_ML_Enrollment.QType),
                                   new SqlParameter("@CreatedUser", obj_ML_Enrollment.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Enrollment.ProjectCode)
                                 };
            return SqlHelper.ExecuteDataset(con, "USP_Enrollment", par).Tables[0];
        }
        public int DL_UpdEDPTraning(ML_Enrollment obj_ML_Enrollment)
        {
            SqlParameter[] par ={ new SqlParameter("@QueryType", obj_ML_Enrollment.QType),
                                  new SqlParameter("@EnrollmentId", obj_ML_Enrollment.EnrollmentId),
                                  new SqlParameter("@Reasons", obj_ML_Enrollment.Reasons)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_UpdateEDPTraning", par);
        }

        public int DL_DeleteEnrollmentForm(ML_Enrollment obj_ML_Enrollment)
        {
            SqlParameter[] par ={ new SqlParameter("@EnrollmentId", obj_ML_Enrollment.EnrollmentId)};
            return SqlHelper.ExecuteNonQuery(con, "USP_DeleteEnrollmentForm", par);
        }
    }
}
