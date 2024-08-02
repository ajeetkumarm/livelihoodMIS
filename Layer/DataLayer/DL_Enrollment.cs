using System.Data;
using System.Data.SqlClient;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System;

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
        public DataTable DL_EnterpriseDetails(ML_Enrollment obj_ML_Enrollment)
        {
            SqlParameter[] par = { 
                                   new SqlParameter("@QueryType", obj_ML_Enrollment.QType),
                                   new SqlParameter("@CreatedUser", obj_ML_Enrollment.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Enrollment.ProjectCode),
                                   new SqlParameter("@Stateid", obj_ML_Enrollment.State),
                                   new SqlParameter("@DistrictId", obj_ML_Enrollment.District)
                                 };
            return SqlHelper.ExecuteDataset(con, "USP_Enrollment_with_filter", par).Tables[0];
        }
        public IList<EnterpriesSetupList> GetEnterpriseSetupList(int createdUser, int projectId, int pageNumber, int pageSize, string search)
        {
            List<EnterpriesSetupList> enterpriesSetupList = new List<EnterpriesSetupList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_EnterpriesSetupList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                    cmd.Parameters.AddWithValue("@Project", projectId);
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    if (!string.IsNullOrEmpty(search))
                    {
                        cmd.Parameters.AddWithValue("@Search", search);
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EnterpriesSetupList objModel = new EnterpriesSetupList();
                            
                            objModel.RowNum = Convert.ToInt32(dr["RowNum"]);
                            objModel.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            objModel.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            objModel.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            objModel.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            objModel.HusbandFatherName = TypeConversionUtility.ToStringWithNull(dr["HusbandFatherName"]);
                            objModel.MotherName = TypeConversionUtility.ToStringWithNull(dr["MotherName"]);
                            objModel.PhoneNo = TypeConversionUtility.ToStringWithNull(dr["PhoneNo"]);
                            objModel.ThemeCode = TypeConversionUtility.ToStringWithNull(dr["ThemeCode"]);
                            objModel.Cast = TypeConversionUtility.ToInteger(dr["Cast"]);
                            objModel.EconomicStatus = TypeConversionUtility.ToInteger(dr["EconomicStatus"]);
                            objModel.MaritalStatus = TypeConversionUtility.ToStringWithNull(dr["MaritalStatus"]);
                            objModel.BirthDate = TypeConversionUtility.ToStringWithNull(dr["BirthDate"]);
                            objModel.Age = TypeConversionUtility.ToInteger(dr["Age"]);
                            objModel.RegistrationDate = TypeConversionUtility.ToStringWithNull(dr["RegistrationDate"]);
                            objModel.State = TypeConversionUtility.ToInteger(dr["State"]);
                            objModel.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            objModel.District = TypeConversionUtility.ToInteger(dr["District"]);
                            objModel.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            objModel.Block = TypeConversionUtility.ToInteger(dr["Block"]);
                            objModel.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            objModel.Village = TypeConversionUtility.ToInteger(dr["Village"]);
                            objModel.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            objModel.PartSHG = TypeConversionUtility.ToStringWithNull(dr["PartSHG"]);
                            objModel.SHGName = TypeConversionUtility.ToStringWithNull(dr["SHGName"]);
                            objModel.SHGDate = TypeConversionUtility.ToStringWithNull(dr["SHGDate"]);
                            objModel.SHGType = TypeConversionUtility.ToInteger(dr["SHGType"]);
                            objModel.Education = TypeConversionUtility.ToInteger(dr["Education"]);
                            // obj_VillageList.PwD = TypeConversionUtility.ToStringWithNull(dr["PwD"]);
                            // obj_VillageList.PwDSpecify = TypeConversionUtility.ToStringWithNull(dr["PwDSpecify"]);
                            objModel.AadhaarrCard = TypeConversionUtility.ToStringWithNull(dr["AadhaarrCard"]);
                            objModel.AadhaarCardDetails = TypeConversionUtility.ToStringWithNull(dr["AadhaarCardDetails"]);
                            objModel.AadhaarNo = TypeConversionUtility.ToStringWithNull(dr["AadhaarNo"]);
                            objModel.AnyIDProofDetails = TypeConversionUtility.ToStringWithNull(dr["AnyIDProofDetails"]);
                            objModel.IDProofNo = TypeConversionUtility.ToStringWithNull(dr["IDProofNo"]);
                            objModel.IssuingAuthority = TypeConversionUtility.ToStringWithNull(dr["IssuingAuthority"]);
                            objModel.RationCard = TypeConversionUtility.ToStringWithNull(dr["RationCard"]);
                            objModel.RationCardlinkedPDS = TypeConversionUtility.ToStringWithNull(dr["RationCardlinkedPDS"]);
                            objModel.BankAccountNo = TypeConversionUtility.ToStringWithNull(dr["BankAccountNo"]);
                            objModel.LinkedSocialSecuritySchemes = TypeConversionUtility.ToStringWithNull(dr["LinkedSocialSecuritySchemes"]);
                            objModel.Scheme = TypeConversionUtility.ToInteger(dr["Scheme"]);
                            objModel.IntrestedEDPTraining = TypeConversionUtility.ToInteger(dr["IntrestedEDPTraining"]);
                            enterpriesSetupList.Add(objModel);
                        }
                    }
                }
            }
            return enterpriesSetupList;
        }
        public DataTable GetEnrollmentDetailById(int enrollmentId)
        {
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId) };
            return SqlHelper.ExecuteDataset(con, "usp_GetEnrollmentFormById", par).Tables[0];
        }
    }
}
