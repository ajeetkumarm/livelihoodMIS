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
    public class DL_BusinessProgress
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public void DL_InsBusinessProgress(ML_BusinessProgress obj_ML_BusinessProgress)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Connection = con;
            sqlcmd.CommandText = "USP_InsBusinessProgress";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
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
            sqlcmd.Parameters.AddWithValue("@XML_ServiceLine", obj_ML_BusinessProgress.XML_ServiceLine);
            sqlcmd.Parameters.AddWithValue("@DigitalCategoryId", obj_ML_BusinessProgress.DigitalCategoryId);
            sqlcmd.Parameters.Add("@OutputBusinessProgressId", SqlDbType.Int);
            sqlcmd.Parameters["@OutputBusinessProgressId"].Direction = ParameterDirection.Output;

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            sqlcmd.ExecuteNonQuery();
            //obj_ML_BusinessProgress.OutputBusinessProgressId = Convert.ToInt32(sqlcmd.Parameters["@OutputBusinessProgressId"].Value);
        }
        public DataTable DL_BusinessProgressDetails(ML_BusinessProgress obj_ML_BusinessProgress)
        {
            SqlParameter[] par = { new SqlParameter("@QueryType", obj_ML_BusinessProgress.Year) };
            return SqlHelper.ExecuteDataset(con, "USP_RptBusinessProgress", par).Tables[0];
        }
        
    }
}