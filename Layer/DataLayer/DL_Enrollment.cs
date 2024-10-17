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
            SqlParameter[] par ={ 
                                  new SqlParameter("@EnrollmentId", obj_ML_Enrollment.EnrollmentId),
                                  new SqlParameter("@BeneficiaryCode", obj_ML_Enrollment.BeneficiaryCode),
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
                                  new SqlParameter("@CreatedBy", obj_ML_Enrollment.CreatedBy),
                                  new SqlParameter("@EmployeeId", obj_ML_Enrollment.EmployeeId),
                                  new SqlParameter("@ReplacementEmployeeId", obj_ML_Enrollment.ReplacementEmployeeId),
                                  new SqlParameter("@ReplacementBeneficiaryCode", obj_ML_Enrollment.ReplacementBeneficiaryCode),
                                  new SqlParameter("@EnrollmentStatus", obj_ML_Enrollment.EnrollmentStatus),
                                  new SqlParameter("@CohortValue", obj_ML_Enrollment.CohortValue),
                                  new SqlParameter("@SHGId", obj_ML_Enrollment.SHGId),
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
        public IList<BusinessProgressList> GetBusinessProgressList(int createdUser, int projectId, int pageNumber, int pageSize, string search)
        {
            IList<BusinessProgressList> businessProgressList = new List<BusinessProgressList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_BusinessProgressList", con))
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
                            BusinessProgressList objModel = new BusinessProgressList();
                            objModel.RowNum = Convert.ToInt32(dr["RowNum"]);
                            objModel.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            objModel.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            objModel.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            objModel.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            objModel.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            objModel.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            objModel.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            objModel.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            objModel.PhoneNo = TypeConversionUtility.ToStringWithNull(dr["PhoneNo"]);
                            objModel.RegistrationDate = TypeConversionUtility.ToStringWithNull(dr["RegistrationDate"]);
                            objModel.BusinessStatus = TypeConversionUtility.ToInteger(dr["BusinessStatus"]);
                            businessProgressList.Add(objModel);
                        }
                    }
                }
            }
            return businessProgressList;
        }
        public bool EDPTrainingMoveToEnrollment(int enrollmentId, int updatedBy)
        {
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId), new SqlParameter("@UpdatedBy", updatedBy) };
            return SqlHelper.ExecuteNonQuery(con, "usp_EDPTrainingMoveToEnrollment", par) > 0;
        }
        public bool EnterpriseSetupMoveToEDPTraining(int enrollmentId, int updatedBy)
        {
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId), new SqlParameter("@UpdatedBy", updatedBy) };
            return SqlHelper.ExecuteNonQuery(con, "usp_EnterpriseSetupMoveToEDPTraining", par) > 0;
        }
        public bool BusinessProgressMoveToEnterpriseSetup(int enrollmentId, int updatedBy)
        {
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId), new SqlParameter("@UpdatedBy", updatedBy) };
            return SqlHelper.ExecuteNonQuery(con, "usp_BusinessProgressMoveToEnterpriseSetup", par) > 0;
        }

        public ML_Enrollment GetEnrollmentDetail(int enrollmentId)
        {
            ML_Enrollment obj_ML_Enrollment = new ML_Enrollment();
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId) };
            using (SqlDataReader dr = SqlHelper.ExecuteReader(con, "usp_GetEnrollmentDetailById", par))
            {
                while (dr.Read())
                {
                    obj_ML_Enrollment.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                    obj_ML_Enrollment.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                    obj_ML_Enrollment.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                    obj_ML_Enrollment.HusbandFatherName = TypeConversionUtility.ToStringWithNull(dr["HusbandFatherName"]);
                    obj_ML_Enrollment.MotherName = TypeConversionUtility.ToStringWithNull(dr["MotherName"]);
                    obj_ML_Enrollment.PhoneNo = TypeConversionUtility.ToStringWithNull(dr["PhoneNo"]);
                    obj_ML_Enrollment.ThemeCode = TypeConversionUtility.ToStringWithNull(dr["ThemeCode"]);
                    obj_ML_Enrollment.Cast = TypeConversionUtility.ToInteger(dr["Cast"]);
                    obj_ML_Enrollment.EconomicStatus = TypeConversionUtility.ToInteger(dr["EconomicStatus"]);
                    obj_ML_Enrollment.MaritalStatus = TypeConversionUtility.ToStringWithNull(dr["MaritalStatus"]);
                    obj_ML_Enrollment.BirthDate = TypeConversionUtility.ToStringWithNull(dr["BirthDate"]);
                    obj_ML_Enrollment.Age = TypeConversionUtility.ToInteger(dr["Age"]);
                    obj_ML_Enrollment.RegistrationDate = TypeConversionUtility.ToStringWithNull(dr["RegistrationDate"]);
                    obj_ML_Enrollment.State = TypeConversionUtility.ToInteger(dr["State"]);
                    obj_ML_Enrollment.District = TypeConversionUtility.ToInteger(dr["District"]);
                    obj_ML_Enrollment.Block = TypeConversionUtility.ToInteger(dr["Block"]);
                    obj_ML_Enrollment.Village = TypeConversionUtility.ToInteger(dr["Village"]);
                    obj_ML_Enrollment.PartSHG = TypeConversionUtility.ToStringWithNull(dr["PartSHG"]);
                    obj_ML_Enrollment.SHGName = TypeConversionUtility.ToStringWithNull(dr["SHGName"]);
                    obj_ML_Enrollment.SHGDate = TypeConversionUtility.ToStringWithNull(dr["SHGDate"]);
                    obj_ML_Enrollment.SHGType = TypeConversionUtility.ToInteger(dr["SHGType"]);
                    obj_ML_Enrollment.Education = TypeConversionUtility.ToInteger(dr["Education"]);
                    obj_ML_Enrollment.PwD = TypeConversionUtility.ToStringWithNull(dr["PwD"]);
                    obj_ML_Enrollment.PwDSpecify = TypeConversionUtility.ToStringWithNull(dr["PwDSpecify"]);
                    obj_ML_Enrollment.AadhaarrCard = TypeConversionUtility.ToStringWithNull(dr["AadhaarrCard"]);
                    obj_ML_Enrollment.AadhaarCardDetails = TypeConversionUtility.ToStringWithNull(dr["AadhaarCardDetails"]);
                    obj_ML_Enrollment.AadhaarNo = TypeConversionUtility.ToStringWithNull(dr["AadhaarNo"]);
                    obj_ML_Enrollment.AnyIDProofDetails = TypeConversionUtility.ToStringWithNull(dr["AnyIDProofDetails"]);
                    obj_ML_Enrollment.IDProofNo = TypeConversionUtility.ToStringWithNull(dr["IDProofNo"]);
                    obj_ML_Enrollment.IssuingAuthority = TypeConversionUtility.ToStringWithNull(dr["IssuingAuthority"]);
                    obj_ML_Enrollment.RationCard = TypeConversionUtility.ToStringWithNull(dr["RationCard"]);
                    obj_ML_Enrollment.RationCardlinkedPDS = TypeConversionUtility.ToStringWithNull(dr["RationCardlinkedPDS"]);
                    obj_ML_Enrollment.BankAccountNo = TypeConversionUtility.ToStringWithNull(dr["BankAccountNo"]);
                    obj_ML_Enrollment.LinkedSocialSecuritySchemes = TypeConversionUtility.ToStringWithNull(dr["LinkedSocialSecuritySchemes"]);
                    obj_ML_Enrollment.WomenBelong = TypeConversionUtility.ToStringWithNull(dr["WomenBelong"]);
                    obj_ML_Enrollment.ValidCertificate = TypeConversionUtility.ToStringWithNull(dr["ValidCertificate"]);
                    obj_ML_Enrollment.MonthlyIndividualIncome = TypeConversionUtility.ToStringWithNull(dr["MonthlyIndividualIncome"]);
                    obj_ML_Enrollment.MonthlyHouseholdIncome = TypeConversionUtility.ToStringWithNull(dr["MonthlyHouseholdIncome"]);
                    obj_ML_Enrollment.Scheme = TypeConversionUtility.ToInteger(dr["Scheme"]);
                    obj_ML_Enrollment.EmployeeId = TypeConversionUtility.ToStringWithNull(dr["EmployeeId"]);
                    obj_ML_Enrollment.ReplacementEmployeeId = TypeConversionUtility.ToStringWithNull(dr["ReplacementEmployeeId"]);
                    obj_ML_Enrollment.ReplacementBeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["ReplacementBeneficiaryCode"]);
                    obj_ML_Enrollment.EnrollmentStatus = TypeConversionUtility.ToStringWithNull(dr["EnrollmentStatus"]);
                    obj_ML_Enrollment.CohortValue = TypeConversionUtility.ToStringWithNull(dr["CohortValue"]);
                }
            }
            return obj_ML_Enrollment;
        }


    }
}
