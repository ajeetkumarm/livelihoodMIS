using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class SqlBusinessProgressCustomer
    {
        public static DataSet GetCategoryAndServiceLineList()
        {
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_DigitalCategoryAndServiceLine_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }
        public static bool SaveBusinessProgressCustomer(BusinessProgressCustomer obj_ML_BusinessProgress)
        {
            bool isCategoryAdded = false;
            bool isServiceLineAdded = false;
            string jsonDigitalCategory = string.Empty;
            string jsonServiceLine = string.Empty;
            var selectedDigitalCategories = obj_ML_BusinessProgress.DigitalCategories.FindAll(x => x.IsSelected == true);
            if(selectedDigitalCategories.Count > 0)
            {
                isCategoryAdded = true;
                jsonDigitalCategory = Newtonsoft.Json.JsonConvert.SerializeObject(selectedDigitalCategories.Select(x => new { DigitalCategoryId = x.CategoryId }).ToList());
            }

            var serviceLine = obj_ML_BusinessProgress.DigitalCategories.FindAll(x => x.IsSelected == true).SelectMany(x => x.ServiceLines).ToList().FindAll(x=> x.CustomersNo>0);
            if(serviceLine.Count > 0)
            {
                isServiceLineAdded = true;
                jsonServiceLine = Newtonsoft.Json.JsonConvert.SerializeObject(serviceLine);
            }
            
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand sqlcmd = new SqlCommand("usp_BusinessProgressCustomer_Save", con))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@BusinessProgressId", obj_ML_BusinessProgress.BusinessProgressId);
                    sqlcmd.Parameters.AddWithValue("@EnrollmentId", Convert.ToInt32(obj_ML_BusinessProgress.EnrollMentId));
                    sqlcmd.Parameters.AddWithValue("@StartingBusinessDate", obj_ML_BusinessProgress.StartingBusinessDate);
                    sqlcmd.Parameters.AddWithValue("@Year", obj_ML_BusinessProgress.Year);
                    sqlcmd.Parameters.AddWithValue("@Month", obj_ML_BusinessProgress.Month);
                    sqlcmd.Parameters.AddWithValue("@NoNewCustomer", obj_ML_BusinessProgress.NoNewCustomer);
                    sqlcmd.Parameters.AddWithValue("@NoRepeatedCustomer", obj_ML_BusinessProgress.NoRepeatedCustomer);
                    sqlcmd.Parameters.AddWithValue("@ServicesOfferedType", obj_ML_BusinessProgress.ServicesOfferedType);
                    sqlcmd.Parameters.AddWithValue("@ServicesProvidedDetails", obj_ML_BusinessProgress.ServicesProvidedDetails);
                    sqlcmd.Parameters.AddWithValue("@GovCustomerServices", obj_ML_BusinessProgress.GovCustomerServices);
                    sqlcmd.Parameters.AddWithValue("@G2CServices", obj_ML_BusinessProgress.G2CServices);
                    sqlcmd.Parameters.AddWithValue("@IncomefromSell", obj_ML_BusinessProgress.IncomefromSell);
                    sqlcmd.Parameters.AddWithValue("@CashSellAmount", obj_ML_BusinessProgress.CashSellAmount);
                    sqlcmd.Parameters.AddWithValue("@CreditSellAmount", obj_ML_BusinessProgress.CreditSellAmount);
                    sqlcmd.Parameters.AddWithValue("@TotalIncome", obj_ML_BusinessProgress.TotalIncome);
                    sqlcmd.Parameters.AddWithValue("@Investment", obj_ML_BusinessProgress.Investment);
                    sqlcmd.Parameters.AddWithValue("@ExpenditurefromPurchase", obj_ML_BusinessProgress.ExpenditurefromPurchase);
                    sqlcmd.Parameters.AddWithValue("@CashExpenditure", obj_ML_BusinessProgress.CashExpenditure);
                    sqlcmd.Parameters.AddWithValue("@CreditExpenditure", obj_ML_BusinessProgress.CreditExpenditure);
                    sqlcmd.Parameters.AddWithValue("@TotalExpenditure", obj_ML_BusinessProgress.TotalExpenditure);
                    sqlcmd.Parameters.AddWithValue("@LastMonthCredit", obj_ML_BusinessProgress.LastMonthCredit);
                    sqlcmd.Parameters.AddWithValue("@CreditSettlement", obj_ML_BusinessProgress.CreditSettlement);
                    sqlcmd.Parameters.AddWithValue("@MonthlyProfitLoss", obj_ML_BusinessProgress.MonthlyProfitLoss);
                    sqlcmd.Parameters.AddWithValue("@PaymentReceived", obj_ML_BusinessProgress.PaymentReceived);
                    sqlcmd.Parameters.AddWithValue("@PaymentReceivedMode", obj_ML_BusinessProgress.PaymentReceivedMode);
                    sqlcmd.Parameters.AddWithValue("@CreatedBy", obj_ML_BusinessProgress.CreatedBy);
                    sqlcmd.Parameters.AddWithValue("@UpdatedBy", obj_ML_BusinessProgress.UpdatedBy);
                    sqlcmd.Parameters.AddWithValue("@JsonDigitalCategory", jsonDigitalCategory);
                    sqlcmd.Parameters.AddWithValue("@JsonServiceLine", jsonServiceLine);
                    sqlcmd.Parameters.AddWithValue("@IsCategoryAdded", isCategoryAdded);
                    sqlcmd.Parameters.AddWithValue("@IsServiceLineAdded", isServiceLineAdded);

                    var businessProgressId = sqlcmd.ExecuteScalar();
                    obj_ML_BusinessProgress.BusinessProgressId = TypeConversionUtility.ToInteger(businessProgressId);
                    return obj_ML_BusinessProgress.BusinessProgressId > 0;
                }
            }
        }

        public static List<BusinessProgessCustomerList> GetBusinessProgressCustomerList(int enrollmentId, int PageNumber, int PageSize, string SearchText)
        {

            List<BusinessProgessCustomerList> lstBusinessProgressCustomer = new List<BusinessProgessCustomerList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetBusinessProgressFormByEnrollmentId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    cmd.Parameters.AddWithValue("@SearchText", SearchText);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            BusinessProgessCustomerList objBusinessProgressCustomer = new BusinessProgessCustomerList();
                            objBusinessProgressCustomer.BusinessProgressId = TypeConversionUtility.ToInteger(dr["BusinessProgressId"]);
                            objBusinessProgressCustomer.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            objBusinessProgressCustomer.BeneficiaryCode = TypeConversionUtility.ToStringWithNull(dr["BeneficiaryCode"]);
                            objBusinessProgressCustomer.StateName = TypeConversionUtility.ToStringWithNull(dr["StateName"]);
                            objBusinessProgressCustomer.DistrictName = TypeConversionUtility.ToStringWithNull(dr["DistrictName"]);
                            objBusinessProgressCustomer.BlockName = TypeConversionUtility.ToStringWithNull(dr["BlockName"]);
                            objBusinessProgressCustomer.VillageName = TypeConversionUtility.ToStringWithNull(dr["VillageName"]);
                            objBusinessProgressCustomer.ProjectName = TypeConversionUtility.ToStringWithNull(dr["ProjectName"]);
                            objBusinessProgressCustomer.UserName = TypeConversionUtility.ToStringWithNull(dr["UserName"]);
                            objBusinessProgressCustomer.WomenName = TypeConversionUtility.ToStringWithNull(dr["WomenName"]);

                            string startingBusinessDate = TypeConversionUtility.ToStringWithNull(dr["StartingBusinessDate"]);
                            if (!string.IsNullOrEmpty(startingBusinessDate))
                            {
                                objBusinessProgressCustomer.StartingBusinessDate = startingBusinessDate != null ? Convert.ToDateTime(startingBusinessDate).ToString("dd/MM/yyyy") : "";
                            }
                            objBusinessProgressCustomer.Year = TypeConversionUtility.ToStringWithNull(dr["Year"]);
                            objBusinessProgressCustomer.Month = TypeConversionUtility.ToStringWithNull(dr["Month"]);
                            objBusinessProgressCustomer.NoNewCustomer = TypeConversionUtility.ToInteger(dr["NoNewCustomer"]);
                            objBusinessProgressCustomer.NoRepeatedCustomer = TypeConversionUtility.ToInteger(dr["NoRepeatedCustomer"]);
                            objBusinessProgressCustomer.ServicesOfferedType = TypeConversionUtility.ToStringWithNull(dr["ServicesOfferedType"]);
                            objBusinessProgressCustomer.ServicesProvidedDetails = TypeConversionUtility.ToStringWithNull(dr["ServicesProvidedDetails"]);
                            objBusinessProgressCustomer.GovCustomerServices = TypeConversionUtility.ToInteger(dr["GovCustomerServices"]);
                            objBusinessProgressCustomer.G2CServices = TypeConversionUtility.ToStringWithNull(dr["G2CServices"]);
                            objBusinessProgressCustomer.IncomefromSell = TypeConversionUtility.ToStringWithNull(dr["IncomefromSell"]);
                            objBusinessProgressCustomer.CashSellAmount = TypeConversionUtility.ToStringWithNull(dr["CashSellAmount"]);
                            objBusinessProgressCustomer.CreditSellAmount = TypeConversionUtility.ToStringWithNull(dr["CreditSellAmount"]);
                            objBusinessProgressCustomer.TotalIncome = TypeConversionUtility.ToStringWithNull(dr["TotalIncome"]);
                            objBusinessProgressCustomer.Investment = TypeConversionUtility.ToStringWithNull(dr["Investment"]);
                            objBusinessProgressCustomer.ExpenditurefromPurchase = TypeConversionUtility.ToStringWithNull(dr["ExpenditurefromPurchase"]);
                            objBusinessProgressCustomer.CashExpenditure = TypeConversionUtility.ToStringWithNull(dr["CashExpenditure"]);
                            objBusinessProgressCustomer.CreditExpenditure = TypeConversionUtility.ToStringWithNull(dr["CreditExpenditure"]);
                            objBusinessProgressCustomer.TotalExpenditure = TypeConversionUtility.ToStringWithNull(dr["TotalExpenditure"]);
                            objBusinessProgressCustomer.LastMonthCredit = TypeConversionUtility.ToStringWithNull(dr["LastMonthCredit"]);
                            objBusinessProgressCustomer.CreditSettlement = TypeConversionUtility.ToStringWithNull(dr["CreditSettlement"]);
                            objBusinessProgressCustomer.MonthlyProfitLoss = TypeConversionUtility.ToStringWithNull(dr["MonthlyProfitLoss"]);
                            objBusinessProgressCustomer.PaymentReceived = TypeConversionUtility.ToStringWithNull(dr["PaymentReceived"]);
                            objBusinessProgressCustomer.PaymentReceivedMode = TypeConversionUtility.ToStringWithNull(dr["PaymentReceivedMode"]);
                            objBusinessProgressCustomer.CreatedOn = TypeConversionUtility.ToDateTime(dr["CreatedOn"]);
                            objBusinessProgressCustomer.UpdatedOn = TypeConversionUtility.ToDateTime(dr["UpdatedOn"]);
                            objBusinessProgressCustomer.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            objBusinessProgressCustomer.RowNum = TypeConversionUtility.ToInteger(dr["RowNum"]);
                            lstBusinessProgressCustomer.Add(objBusinessProgressCustomer);

                        }
                    }
                }
            }
            return lstBusinessProgressCustomer;
        }

        public static string GetBusinessProgressStartingBusinessDate(int enrollmentId)
        {
            string startingBusinessDate = string.Empty;
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetBusinessProgressForm_StartingBusinessDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    startingBusinessDate = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            return startingBusinessDate;
        }
        public static bool CheckBusinessProgressCustomerDataExist(int businessProgressId, int enrollmentId, int year, string month)
        {
            bool isExist = false;
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_CheckBusinessProgressCustomerDataExist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BusinessProgressId", businessProgressId);
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);
                    isExist = TypeConversionUtility.ToInteger(cmd.ExecuteScalar()) > 0;
                }
            }
            return isExist;
        }

        public static bool SaveBusinessProgressStatus(BusinessProgressStatusDTO model)
        {
            bool saved = false;
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("BusinessProgressStatus_Save", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", model.EnrollmentId);
                    cmd.Parameters.AddWithValue("@BusinessStatus", model.BusinessStatus);
                    cmd.Parameters.AddWithValue("@BusinessStatusDate", model.BusinessStatusDate);
                    cmd.Parameters.AddWithValue("@BusinessStatusReason", model.BusinessStatusReason);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy);
                    saved = TypeConversionUtility.ToInteger(cmd.ExecuteNonQuery()) > 0;
                }
            }
            return saved;
        }
        public static BusinessProgressStatusDTO GetBusinessProgressStatus(int enrollmentId)
        {
            BusinessProgressStatusDTO model = new BusinessProgressStatusDTO();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_BusinessProgressStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QueryType", 1);
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            model.EnrollmentId = TypeConversionUtility.ToInteger(dr["EnrollmentId"]);
                            model.BusinessStatus = TypeConversionUtility.ToInteger(dr["BusinessStatus"]);
                            model.BusinessStatusDate = TypeConversionUtility.ToStringWithNull(dr["BusinessStatusDate"]);
                            model.BusinessStatusReason = TypeConversionUtility.ToStringWithNull(dr["BusinessStatusReason"]);
                        }
                    }
                }
            }
            return model;
        }

        public static DataSet GetBusinessProgressCustomerByBusinessProgressId(int businessProgressId)
        {
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetBusinessProgressCustomerByBusinessProgressId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BusinessProgressId", businessProgressId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }
        public static List<BusinessProgressCustomerCountEntity> GetBusinessProgressServiceLineCount(int enrollmentId)
        {
            List<BusinessProgressCustomerCountEntity> lstBusinessProgressCustomerCount = new List<BusinessProgressCustomerCountEntity>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_BusinessProgressServiceLineCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            BusinessProgressCustomerCountEntity objBusinessProgressCustomerCount = new BusinessProgressCustomerCountEntity();
                            objBusinessProgressCustomerCount.Category = TypeConversionUtility.ToStringWithNull(dr["Category"]);
                            objBusinessProgressCustomerCount.TotalCount = TypeConversionUtility.ToInteger(dr["TotalCount"]);
                            lstBusinessProgressCustomerCount.Add(objBusinessProgressCustomerCount);
                        }
                    }
                }
            }
            return lstBusinessProgressCustomerCount;
        }
    }
}
