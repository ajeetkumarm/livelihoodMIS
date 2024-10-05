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
                            enrollmentInfo.EmployeeId = TypeConversionUtility.ToStringWithNull(dr["EmployeeId"]);
                            enrollmentInfo.ReplacementEmployeeId = TypeConversionUtility.ToStringWithNull(dr["ReplacementEmployeeId"]);
                            enrollmentInfo.ReplacementBeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["ReplacementBeneficiaryCode"]);
                            enrollmentInfo.EnrollmentStatus = TypeConversionUtility.ToStringWithNull(dr["EnrollmentStatus"]);
                            enrollmentInfo.CohortValue = TypeConversionUtility.ToStringWithNull(dr["CohortValue"]);
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
        public List<EnterpriesTrainingReportList> RptEnterpriesTrainingDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            List<EnterpriesTrainingReportList> enterpriesTrainingList = new List<EnterpriesTrainingReportList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Rpt_EnterpriesTrainingForm_List", con))
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
                            EnterpriesTrainingReportList enterpriesTrainingInfo = new EnterpriesTrainingReportList();
                            enterpriesTrainingInfo.RowNum = TypeConversionUtility.ToInteger(dr["RowNum"]);
                            enterpriesTrainingInfo.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            enterpriesTrainingInfo.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            enterpriesTrainingInfo.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            enterpriesTrainingInfo.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            enterpriesTrainingInfo.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            enterpriesTrainingInfo.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            enterpriesTrainingInfo.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            enterpriesTrainingInfo.ProjectCode = TypeConversionUtility.ToInteger(dr["ProjectCode"]);
                            enterpriesTrainingInfo.ProjectName = TypeConversionUtility.ToStringWithNull(dr["ProjectName"]);
                            enterpriesTrainingInfo.UserName = TypeConversionUtility.ToStringWithNull(dr["UserName"]);
                            enterpriesTrainingInfo.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            enterpriesTrainingInfo.StartBusiness = TypeConversionUtility.ToStringWithNull(dr["StartBusiness"]);
                            enterpriesTrainingInfo.BusinessReasons = TypeConversionUtility.ToStringWithNull(dr["BusinessReasons"]);
                            enterpriesTrainingInfo.Business = TypeConversionUtility.ToStringWithNull(dr["Business"]);
                            enterpriesTrainingInfo.BusinessWhen = TypeConversionUtility.ToStringWithNull(dr["BusinessWhen"]);
                            enterpriesTrainingInfo.StatusBusiness = TypeConversionUtility.ToStringWithNull(dr["StatusBusiness"]);
                            enterpriesTrainingInfo.VillagePopulation = TypeConversionUtility.ToStringWithNull(dr["VillagePopulation"]);
                            enterpriesTrainingInfo.BusinessIdea = TypeConversionUtility.ToStringWithNull(dr["BusinessIdea"]);
                            enterpriesTrainingInfo.BusinessType = TypeConversionUtility.ToStringWithNull(dr["BusinessType"]);
                            enterpriesTrainingInfo.ProcureBusiness = TypeConversionUtility.ToStringWithNull(dr["ProcureBusiness"]);
                            enterpriesTrainingInfo.CurrentBusiness = TypeConversionUtility.ToStringWithNull(dr["CurrentBusiness"]);
                            enterpriesTrainingInfo.RegularFinancialBusiness = TypeConversionUtility.ToStringWithNull(dr["RegularFinancialBusiness"]);
                            enterpriesTrainingInfo.HowRegularFinancial = TypeConversionUtility.ToStringWithNull(dr["HowRegularFinancial"]);
                            enterpriesTrainingInfo.SettingBusinessType = TypeConversionUtility.ToStringWithNull(dr["SettingBusinessType"]);
                            enterpriesTrainingInfo.MonthlyRent = TypeConversionUtility.ToStringWithNull(dr["MonthlyRent"]);

                            enterpriesTrainingInfo.ExpandBusiness = TypeConversionUtility.ToStringWithNull(dr["ExpandBusiness"]);
                            enterpriesTrainingInfo.PotentialCustomers = TypeConversionUtility.ToStringWithNull(dr["PotentialCustomers"]);
                            enterpriesTrainingInfo.BusinessDistance = TypeConversionUtility.ToStringWithNull(dr["BusinessDistance"]);
                            enterpriesTrainingInfo.ExpectedFootfall = TypeConversionUtility.ToStringWithNull(dr["ExpectedFootfall"]);
                            enterpriesTrainingInfo.HowFarBussiness = TypeConversionUtility.ToStringWithNull(dr["HowFarBussiness"]);
                            enterpriesTrainingInfo.PlanningBusiness = TypeConversionUtility.ToStringWithNull(dr["PlanningBusiness"]);
                            enterpriesTrainingInfo.SupportBusiness = TypeConversionUtility.ToStringWithNull(dr["SupportBusiness"]);
                            enterpriesTrainingInfo.SupportType = TypeConversionUtility.ToStringWithNull(dr["SupportType"]);
                            enterpriesTrainingInfo.NotProvidedSupport = TypeConversionUtility.ToStringWithNull(dr["NotProvidedSupport"]);
                            enterpriesTrainingInfo.PaidWorker = TypeConversionUtility.ToStringWithNull(dr["PaidWorker"]);
                            enterpriesTrainingInfo.DigitalInclusion = TypeConversionUtility.ToStringWithNull(dr["DigitalInclusion"]);
                            enterpriesTrainingInfo.DigitalInclusionDate = TypeConversionUtility.ToStringWithNull(dr["DigitalInclusionDate"]);
                            enterpriesTrainingInfo.OwnSmartPhone = TypeConversionUtility.ToStringWithNull(dr["OwnSmartPhone"]);
                            enterpriesTrainingInfo.UseSmartPhone = TypeConversionUtility.ToStringWithNull(dr["UseSmartPhone"]);
                            enterpriesTrainingInfo.SupplyChain = TypeConversionUtility.ToStringWithNull(dr["SupplyChain"]);
                            enterpriesTrainingInfo.IsCompleteEntTraining = TypeConversionUtility.ToInteger(dr["IsCompleteEntTraining"]);

                            if (dr["CreatedOn"] != DBNull.Value)
                            {
                                enterpriesTrainingInfo.CreatedOn = TypeConversionUtility.ToDateTime(dr["CreatedOn"]);
                            }

                            if (dr["UpdatedOn"] != DBNull.Value)
                            {
                                enterpriesTrainingInfo.UpdatedOn = TypeConversionUtility.ToDateTime(dr["UpdatedOn"]);
                            }

                            enterpriesTrainingList.Add(enterpriesTrainingInfo);
                        }
                    }

                }
            }
                return enterpriesTrainingList;
        }
        public List<BusinessProgressReportList> RptBusinessProgressDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            List<BusinessProgressReportList> enterpriesTrainingList = new List<BusinessProgressReportList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Rpt_BusinessProgressForm_List", con))
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
                            BusinessProgressReportList enterpriesTrainingInfo = new BusinessProgressReportList();
                            enterpriesTrainingInfo.RowNum = TypeConversionUtility.ToInteger(dr["RowNum"]);
                            enterpriesTrainingInfo.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            enterpriesTrainingInfo.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            enterpriesTrainingInfo.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            enterpriesTrainingInfo.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            enterpriesTrainingInfo.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            enterpriesTrainingInfo.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            enterpriesTrainingInfo.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            enterpriesTrainingInfo.ProjectCode = TypeConversionUtility.ToInteger(dr["ProjectCode"]);
                            enterpriesTrainingInfo.ProjectName = TypeConversionUtility.ToStringWithNull(dr["ProjectName"]);
                            enterpriesTrainingInfo.UserName = TypeConversionUtility.ToStringWithNull(dr["UserName"]);
                            enterpriesTrainingInfo.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);
                            enterpriesTrainingInfo.StartingBusinessDate = TypeConversionUtility.ToStringWithNull(dr["StartingBusinessDate"]);
                            enterpriesTrainingInfo.Year = TypeConversionUtility.ToStringWithNull(dr["Year"]);
                            enterpriesTrainingInfo.Month = TypeConversionUtility.ToStringWithNull(dr["Month"]);
                            enterpriesTrainingInfo.NoNewCustomer = TypeConversionUtility.ToInteger(dr["NoNewCustomer"]);
                            enterpriesTrainingInfo.NoRepeatedCustomer = TypeConversionUtility.ToInteger(dr["NoRepeatedCustomer"]);
                            enterpriesTrainingInfo.ServicesOfferedType = TypeConversionUtility.ToStringWithNull(dr["ServicesOfferedType"]);
                            enterpriesTrainingInfo.ServicesProvidedDetails = TypeConversionUtility.ToStringWithNull(dr["ServicesProvidedDetails"]);
                            enterpriesTrainingInfo.GovCustomerServices = TypeConversionUtility.ToStringWithNull(dr["GovCustomerServices"]);
                            enterpriesTrainingInfo.G2CServices = TypeConversionUtility.ToStringWithNull(dr["G2CServices"]);
                            enterpriesTrainingInfo.IncomefromSell = TypeConversionUtility.ToStringWithNull(dr["IncomefromSell"]);
                            enterpriesTrainingInfo.CashSellAmount = TypeConversionUtility.ToStringWithNull(dr["CashSellAmount"]);
                            enterpriesTrainingInfo.CreditSellAmount = TypeConversionUtility.ToStringWithNull(dr["CreditSellAmount"]);
                            enterpriesTrainingInfo.TotalIncome = TypeConversionUtility.ToStringWithNull(dr["TotalIncome"]);
                            enterpriesTrainingInfo.Investment = TypeConversionUtility.ToStringWithNull(dr["Investment"]);
                            enterpriesTrainingInfo.ExpenditurefromPurchase = TypeConversionUtility.ToStringWithNull(dr["ExpenditurefromPurchase"]);
                            enterpriesTrainingInfo.CashExpenditure = TypeConversionUtility.ToBoolean(dr["CashExpenditure"]);
                            enterpriesTrainingInfo.CreditExpenditure = TypeConversionUtility.ToBoolean(dr["CreditExpenditure"]);
                            enterpriesTrainingInfo.TotalExpenditure = TypeConversionUtility.ToStringWithNull(dr["TotalExpenditure"]);
                            enterpriesTrainingInfo.LastMonthCredit = TypeConversionUtility.ToStringWithNull(dr["LastMonthCredit"]);
                            enterpriesTrainingInfo.CreditSettlement = TypeConversionUtility.ToStringWithNull(dr["CreditSettlement"]);
                            enterpriesTrainingInfo.MonthlyProfitLoss = TypeConversionUtility.ToStringWithNull(dr["MonthlyProfitLoss"]);
                            enterpriesTrainingInfo.PaymentReceived = TypeConversionUtility.ToStringWithNull(dr["PaymentReceived"]);
                            enterpriesTrainingInfo.PaymentReceivedMode = TypeConversionUtility.ToStringWithNull(dr["PaymentReceivedMode"]);

                            if (dr["CreatedOn"] != DBNull.Value)
                            {
                                enterpriesTrainingInfo.CreatedOn = TypeConversionUtility.ToDateTime(dr["CreatedOn"]);
                            }

                            if (dr["UpdatedOn"] != DBNull.Value)
                            {
                                enterpriesTrainingInfo.UpdatedOn = TypeConversionUtility.ToDateTime(dr["UpdatedOn"]);
                            }
                            enterpriesTrainingList.Add(enterpriesTrainingInfo);
                        }
                    }
                }
            }
            return enterpriesTrainingList;
        }
        public List<ConsolidateReportList> RptConsolidated(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            List<ConsolidateReportList> enrollmentList = new List<ConsolidateReportList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Rpt_consolidated_List", con))
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
                            ConsolidateReportList enrollmentInfo = new ConsolidateReportList();

                            #region "Enrollment Details"
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
                            enrollmentInfo.EmployeeId = TypeConversionUtility.ToStringWithNull(dr["EmployeeId"]);
                            enrollmentInfo.ReplacementEmployeeId = TypeConversionUtility.ToStringWithNull(dr["ReplacementEmployeeId"]);
                            enrollmentInfo.ReplacementBeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["ReplacementBeneficiaryCode"]);
                            enrollmentInfo.EnrollmentStatus = TypeConversionUtility.ToStringWithNull(dr["EnrollmentStatus"]);
                            enrollmentInfo.CohortValue = TypeConversionUtility.ToStringWithNull(dr["CohortValue"]);

                            #endregion

                            #region "EDP Training Details"
                            enrollmentInfo.IsLifeSkillsTraining = TypeConversionUtility.ToStringWithNull(dr["IsLifeSkillsTraining"]);
                            enrollmentInfo.RCSCDate = TypeConversionUtility.ToStringWithNull(dr["RCSCDate"]);

                            if (!string.IsNullOrEmpty(enrollmentInfo.RCSCDate))
                            {
                                enrollmentInfo.RCSCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.RCSCDate).ToString("dd/MM/yyyy");
                            }

                            enrollmentInfo.WRPCDate = TypeConversionUtility.ToStringWithNull(dr["WRPCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.WRPCDate))
                            {
                                enrollmentInfo.WRPCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.WRPCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.HNCDate = TypeConversionUtility.ToStringWithNull(dr["HNCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.HNCDate))
                            {
                                enrollmentInfo.HNCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.HNCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.FLCDate = TypeConversionUtility.ToStringWithNull(dr["FLCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.FLCDate))
                            {
                                enrollmentInfo.FLCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.FLCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.EDTSDate = TypeConversionUtility.ToStringWithNull(dr["EDTSDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.EDTSDate))
                            {
                                enrollmentInfo.EDTSDate = TypeConversionUtility.ToDateTime(enrollmentInfo.EDTSDate).ToString("dd/MM/yyyy");
                            }

                            enrollmentInfo.LEAPDate = TypeConversionUtility.ToStringWithNull(dr["LEAPDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.LEAPDate))
                            {
                                enrollmentInfo.LEAPDate = TypeConversionUtility.ToDateTime(enrollmentInfo.LEAPDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.ESISDate = TypeConversionUtility.ToStringWithNull(dr["ESISDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.ESISDate))
                            {
                                enrollmentInfo.ESISDate = TypeConversionUtility.ToDateTime(enrollmentInfo.ESISDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.BMTCDate = TypeConversionUtility.ToStringWithNull(dr["BMTCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.BMTCDate))
                            {
                                enrollmentInfo.BMTCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.BMTCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.MMTCDate = TypeConversionUtility.ToStringWithNull(dr["MMTCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.MMTCDate))
                            {
                                enrollmentInfo.MMTCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.MMTCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.EDPTCDate = TypeConversionUtility.ToStringWithNull(dr["EDPTCDate"]);
                            if (!string.IsNullOrEmpty(enrollmentInfo.EDPTCDate))
                            {
                                enrollmentInfo.EDPTCDate = TypeConversionUtility.ToDateTime(enrollmentInfo.EDPTCDate).ToString("dd/MM/yyyy");
                            }
                            enrollmentInfo.IsTrainingCompleted = TypeConversionUtility.ToInteger(dr["IsTrainingCompleted"]);
                            #endregion

                            #region "Enterprise Training Details"
                            enrollmentInfo.StartBusiness = TypeConversionUtility.ToStringWithNull(dr["StartBusiness"]);
                            enrollmentInfo.BusinessReasons = TypeConversionUtility.ToStringWithNull(dr["BusinessReasons"]);
                            enrollmentInfo.Business = TypeConversionUtility.ToStringWithNull(dr["Business"]);
                            enrollmentInfo.BusinessWhen = TypeConversionUtility.ToStringWithNull(dr["BusinessWhen"]);
                            enrollmentInfo.StatusBusiness = TypeConversionUtility.ToStringWithNull(dr["StatusBusiness"]);
                            enrollmentInfo.VillagePopulation = TypeConversionUtility.ToStringWithNull(dr["VillagePopulation"]);
                            enrollmentInfo.BusinessIdea = TypeConversionUtility.ToStringWithNull(dr["BusinessIdea"]);
                            enrollmentInfo.BusinessType = TypeConversionUtility.ToStringWithNull(dr["BusinessType"]);
                            enrollmentInfo.ProcureBusiness = TypeConversionUtility.ToStringWithNull(dr["ProcureBusiness"]);
                            enrollmentInfo.CurrentBusiness = TypeConversionUtility.ToStringWithNull(dr["CurrentBusiness"]);
                            enrollmentInfo.RegularFinancialBusiness = TypeConversionUtility.ToStringWithNull(dr["RegularFinancialBusiness"]);
                            enrollmentInfo.HowRegularFinancial = TypeConversionUtility.ToStringWithNull(dr["HowRegularFinancial"]);
                            enrollmentInfo.SettingBusinessType = TypeConversionUtility.ToStringWithNull(dr["SettingBusinessType"]);
                            enrollmentInfo.MonthlyRent = TypeConversionUtility.ToStringWithNull(dr["MonthlyRent"]);
                            enrollmentInfo.ExpandBusiness = TypeConversionUtility.ToStringWithNull(dr["ExpandBusiness"]);
                            enrollmentInfo.PotentialCustomers = TypeConversionUtility.ToStringWithNull(dr["PotentialCustomers"]);
                            enrollmentInfo.BusinessDistance = TypeConversionUtility.ToStringWithNull(dr["BusinessDistance"]);
                            enrollmentInfo.ExpectedFootfall = TypeConversionUtility.ToStringWithNull(dr["ExpectedFootfall"]);
                            enrollmentInfo.HowFarBussiness = TypeConversionUtility.ToStringWithNull(dr["HowFarBussiness"]);
                            enrollmentInfo.PlanningBusiness = TypeConversionUtility.ToStringWithNull(dr["PlanningBusiness"]);
                            enrollmentInfo.SupportBusiness = TypeConversionUtility.ToStringWithNull(dr["SupportBusiness"]);
                            enrollmentInfo.SupportType = TypeConversionUtility.ToStringWithNull(dr["SupportType"]);
                            enrollmentInfo.NotProvidedSupport = TypeConversionUtility.ToStringWithNull(dr["NotProvidedSupport"]);
                            enrollmentInfo.PaidWorker = TypeConversionUtility.ToStringWithNull(dr["PaidWorker"]);
                            enrollmentInfo.DigitalInclusion = TypeConversionUtility.ToStringWithNull(dr["DigitalInclusion"]);
                            enrollmentInfo.DigitalInclusionDate = TypeConversionUtility.ToStringWithNull(dr["DigitalInclusionDate"]);
                            enrollmentInfo.OwnSmartPhone = TypeConversionUtility.ToStringWithNull(dr["OwnSmartPhone"]); 
                            enrollmentInfo.UseSmartPhone = TypeConversionUtility.ToStringWithNull(dr["UseSmartPhone"]);
                            enrollmentInfo.SupplyChain = TypeConversionUtility.ToStringWithNull(dr["SupplyChain"]);
                            enrollmentInfo.IsCompleteEntTraining = TypeConversionUtility.ToInteger(dr["IsCompleteEntTraining"]);
                            #endregion

                            enrollmentList.Add(enrollmentInfo);
                        }
                    }
                }
            }
            return enrollmentList;
        }
    }
}
