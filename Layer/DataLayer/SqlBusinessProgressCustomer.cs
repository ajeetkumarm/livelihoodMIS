using ModelLayer;
using System;
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
                jsonDigitalCategory = Newtonsoft.Json.JsonConvert.SerializeObject(selectedDigitalCategories.Select(x => new { CategoryId = x.CategoryId }).ToList());
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
    }
}
