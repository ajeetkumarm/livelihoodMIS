using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System;


namespace DataLayer
{
    public class DL_Reports
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);

        public DataTable DL_RptEnrollmentDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_EnrollmentForm", par).Tables[0];
        }
        public DataTable DL_RptTrainingDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_TrainingForm", par).Tables[0];
        }
        public DataTable DL_RptEnterpriesTrainingDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_EnterpriesTrainingForm", par).Tables[0];
        }
        public DataTable DL_RptBusinessProgressDetails(ML_Reports obj_ML_Reports)
        {
            SqlParameter[] par = { new SqlParameter("@CreatedUser", obj_ML_Reports.CreatedUser),
                                   new SqlParameter("@Project", obj_ML_Reports.ProjectCode)
            };
            return SqlHelper.ExecuteDataset(con, "Rpt_BusinessProgressForm", par).Tables[0];
        }

        public List<EnrollmentReportList> RptEnrollmentDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            List<EnrollmentReportList> enrollmentList = new List<EnrollmentReportList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Rpt_EnrollmentForm_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                    cmd.Parameters.AddWithValue("@Project", projectCode);
                    cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    cmd.Parameters.AddWithValue("@Search", SearchText);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EnrollmentReportList enrollmentInfo = new EnrollmentReportList();
                            enrollmentInfo.RowNum = TypeConversionUtility.ToInteger(dr["RowNum"]);
                            enrollmentInfo.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            enrollmentInfo.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            enrollmentInfo.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            enrollmentInfo.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            enrollmentInfo.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            enrollmentInfo.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            enrollmentInfo.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            enrollmentInfo.ProjectCode = TypeConversionUtility.ToInteger(dr["ProjectCode"]);
                            enrollmentInfo.ProjectName = TypeConversionUtility.ToStringWithNull(dr["ProjectName"]);
                            enrollmentInfo.UserName = TypeConversionUtility.ToStringWithNull(dr["UserName"]);
                            enrollmentInfo.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            enrollmentInfo.HusbandFatherName = TypeConversionUtility.ToStringWithNull(dr["HusbandFatherName"]);
                            enrollmentInfo.MotherName = TypeConversionUtility.ToStringWithNull(dr["MotherName"]);
                            enrollmentInfo.PhoneNo = TypeConversionUtility.ToStringWithNull(dr["PhoneNo"]);
                            enrollmentInfo.ThemeCode = TypeConversionUtility.ToStringWithNull(dr["ThemeCode"]);
                            enrollmentInfo.Cast = TypeConversionUtility.ToInteger(dr["Cast"]);
                            enrollmentInfo.CastName = TypeConversionUtility.ToStringWithNull(dr["CastName"]);
                            enrollmentInfo.EconomicStatus = TypeConversionUtility.ToStringWithNull(dr["EconomicStatus"]);
                            enrollmentInfo.MaritalStatus = TypeConversionUtility.ToStringWithNull(dr["MaritalStatus"]);
                            enrollmentInfo.BirthDate = TypeConversionUtility.ToStringWithNull(dr["BirthDate"]);
                            enrollmentInfo.Age = TypeConversionUtility.ToInteger(dr["Age"]);
                            enrollmentInfo.PartSHG = TypeConversionUtility.ToStringWithNull(dr["PartSHG"]);
                            enrollmentInfo.SHGName = TypeConversionUtility.ToStringWithNull(dr["SHGName"]);
                            enrollmentInfo.SHGType = TypeConversionUtility.ToInteger(dr["SHGType"]);
                            enrollmentInfo.RegistrationDate = TypeConversionUtility.ToStringWithNull(dr["RegistrationDate"]);
                            enrollmentInfo.SHGDate = TypeConversionUtility.ToStringWithNull(dr["SHGDate"]);
                            enrollmentInfo.Education = TypeConversionUtility.ToInteger(dr["Education"]);
                            enrollmentInfo.EducationName = TypeConversionUtility.ToStringWithNull(dr["EducationName"]);
                            enrollmentInfo.PwD = TypeConversionUtility.ToStringWithNull(dr["PwD"]);
                            enrollmentInfo.PwDSpecify = TypeConversionUtility.ToStringWithNull(dr["PwDSpecify"]);
                            enrollmentInfo.AadhaarrCard = TypeConversionUtility.ToStringWithNull(dr["AadhaarrCard"]);
                            enrollmentInfo.AadhaarCardDetails = TypeConversionUtility.ToStringWithNull(dr["AadhaarCardDetails"]);
                            enrollmentInfo.AadhaarNo = TypeConversionUtility.ToStringWithNull(dr["AadhaarNo"]);
                            enrollmentInfo.AnyIDProofDetails = TypeConversionUtility.ToStringWithNull(dr["AnyIDProofDetails"]);
                            enrollmentInfo.IDProofNo = TypeConversionUtility.ToStringWithNull(dr["IDProofNo"]);
                            enrollmentInfo.IssuingAuthority = TypeConversionUtility.ToStringWithNull(dr["IssuingAuthority"]);
                            enrollmentInfo.RationCard = TypeConversionUtility.ToStringWithNull(dr["RationCard"]);
                            enrollmentInfo.RationCardlinkedPDS = TypeConversionUtility.ToStringWithNull(dr["RationCardlinkedPDS"]);
                            enrollmentInfo.BankAccountNo = TypeConversionUtility.ToStringWithNull(dr["BankAccountNo"]);
                            enrollmentInfo.LinkedSocialSecuritySchemes = TypeConversionUtility.ToStringWithNull(dr["LinkedSocialSecuritySchemes"]);
                            enrollmentInfo.Reasons = TypeConversionUtility.ToStringWithNull(dr["Reasons"]);
                            enrollmentInfo.WomenBelong = TypeConversionUtility.ToStringWithNull(dr["WomenBelong"]);
                            enrollmentInfo.ValidCertificate = TypeConversionUtility.ToStringWithNull(dr["ValidCertificate"]);
                            enrollmentInfo.MonthlyIndividualIncome = TypeConversionUtility.ToStringWithNull(dr["MonthlyIndividualIncome"]);
                            enrollmentInfo.MonthlyHouseholdIncome = TypeConversionUtility.ToStringWithNull(dr["MonthlyHouseholdIncome"]);
                            enrollmentInfo.Scheme = TypeConversionUtility.ToStringWithNull(dr["Scheme"]);
                            enrollmentInfo.SchemeName = TypeConversionUtility.ToStringWithNull(dr["SchemeName"]);

                            if (dr["CreatedOn"] != DBNull.Value)
                            {
                                enrollmentInfo.CreatedOn = TypeConversionUtility.ToDateTime(dr["CreatedOn"]);
                            }

                            if (dr["UpdatedOn"] != DBNull.Value)
                            {
                                enrollmentInfo.UpdatedOn = TypeConversionUtility.ToDateTime(dr["UpdatedOn"]);
                            }
                            enrollmentList.Add(enrollmentInfo);
                        }
                    }
                }
            }
            return enrollmentList;
        }

        public List<TrainingReportList> RptTrainingDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            List<TrainingReportList> trainingList = new List<TrainingReportList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Rpt_TrainingForm_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                    cmd.Parameters.AddWithValue("@Project", projectCode);
                    cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    cmd.Parameters.AddWithValue("@Search", SearchText);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TrainingReportList trainingInfo = new TrainingReportList();
                            trainingInfo.RowNum = TypeConversionUtility.ToInteger(dr["RowNum"]);
                            trainingInfo.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            trainingInfo.TrainingId = TypeConversionUtility.ToInteger(dr["TrainingId"]);
                            trainingInfo.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            trainingInfo.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            trainingInfo.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            trainingInfo.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            trainingInfo.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            trainingInfo.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            trainingInfo.ProjectCode = TypeConversionUtility.ToInteger(dr["ProjectCode"]);
                            trainingInfo.ProjectName = TypeConversionUtility.ToStringWithNull(dr["ProjectName"]);
                            trainingInfo.UserName = TypeConversionUtility.ToStringWithNull(dr["UserName"]);
                            trainingInfo.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            trainingInfo.IsLifeSkillsTraining = TypeConversionUtility.ToStringWithNull(dr["IsLifeSkillsTraining"]);
                            trainingInfo.RCSCDate = TypeConversionUtility.ToStringWithNull(dr["RCSCDate"]);

                            if (!string.IsNullOrEmpty(trainingInfo.RCSCDate))
                            {
                                trainingInfo.RCSCDate = TypeConversionUtility.ToDateTime(trainingInfo.RCSCDate).ToString("dd/MM/yyyy");
                            }

                            trainingInfo.WRPCDate = TypeConversionUtility.ToStringWithNull(dr["WRPCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.WRPCDate))
                            {
                                trainingInfo.WRPCDate = TypeConversionUtility.ToDateTime(trainingInfo.WRPCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.HNCDate = TypeConversionUtility.ToStringWithNull(dr["HNCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.HNCDate))
                            {
                                trainingInfo.HNCDate = TypeConversionUtility.ToDateTime(trainingInfo.HNCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.FLCDate = TypeConversionUtility.ToStringWithNull(dr["FLCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.FLCDate))
                            {
                                trainingInfo.FLCDate = TypeConversionUtility.ToDateTime(trainingInfo.FLCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.EDTSDate = TypeConversionUtility.ToStringWithNull(dr["EDTSDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.EDTSDate))
                            {
                                trainingInfo.EDTSDate = TypeConversionUtility.ToDateTime(trainingInfo.EDTSDate).ToString("dd/MM/yyyy");
                            }

                            trainingInfo.LEAPDate = TypeConversionUtility.ToStringWithNull(dr["LEAPDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.LEAPDate))
                            {
                                trainingInfo.LEAPDate = TypeConversionUtility.ToDateTime(trainingInfo.LEAPDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.ESISDate = TypeConversionUtility.ToStringWithNull(dr["ESISDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.ESISDate))
                            {
                                trainingInfo.ESISDate = TypeConversionUtility.ToDateTime(trainingInfo.ESISDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.BMTCDate = TypeConversionUtility.ToStringWithNull(dr["BMTCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.BMTCDate))
                            {
                                trainingInfo.BMTCDate = TypeConversionUtility.ToDateTime(trainingInfo.BMTCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.MMTCDate = TypeConversionUtility.ToStringWithNull(dr["MMTCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.MMTCDate))
                            {
                                trainingInfo.MMTCDate = TypeConversionUtility.ToDateTime(trainingInfo.MMTCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.EDPTCDate = TypeConversionUtility.ToStringWithNull(dr["EDPTCDate"]);
                            if (!string.IsNullOrEmpty(trainingInfo.EDPTCDate))
                            {
                                trainingInfo.EDPTCDate = TypeConversionUtility.ToDateTime(trainingInfo.EDPTCDate).ToString("dd/MM/yyyy");
                            }
                            trainingInfo.IsTrainingCompleted = TypeConversionUtility.ToInteger(dr["IsTrainingCompleted"]);

                            if (dr["CreatedOn"] != DBNull.Value)
                            {
                                trainingInfo.CreatedOn = TypeConversionUtility.ToDateTime(dr["CreatedOn"]);
                            }

                            if (dr["UpdatedOn"] != DBNull.Value)
                            {
                                trainingInfo.UpdatedOn = TypeConversionUtility.ToDateTime(dr["UpdatedOn"]);
                            }
                            trainingList.Add(trainingInfo);
                        }
                        
                    }
                }
            }
            return trainingList;
        }

    }
}
