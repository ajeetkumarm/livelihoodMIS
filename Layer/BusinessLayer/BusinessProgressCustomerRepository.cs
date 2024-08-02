using System;
using System.Collections.Generic;
using System.Data;
using ModelLayer;
using DataLayer;
using System.Linq;

namespace BusinessLayer
{
    public class BusinessProgressCustomerRepository
    {
        public static List<BPCDigitalCategory> GetCategoryAndServiceLineList()
        {
            List<BPCDigitalCategory> list = new List<BPCDigitalCategory>();
            try
            {
                var dataSet = SqlBusinessProgressCustomer.GetCategoryAndServiceLineList();
                DataTable dtCategory = dataSet.Tables[0];
                DataTable dtCategoryServiceLine = dataSet.Tables[1];

                foreach (DataRow row in dtCategory.Rows)
                {
                    list.Add(new BPCDigitalCategory
                    {
                        CategoryId = Convert.ToInt32(row["CategoryId"]),
                        Category = row["Category"].ToString()
                    });
                }
                foreach (var item in list)
                {
                    foreach (DataRow row in dtCategoryServiceLine.Rows)
                    {
                        if (item.CategoryId == Convert.ToInt32(row["DigitalCategoryId"]))
                        {
                            string serviceUrl = TypeConversionUtility.ToStringWithNull(row["ServiceURL"]);
                            List<string> serviceURLs = new List<string>();

                            if(!string.IsNullOrEmpty(serviceUrl))
                            {
                                serviceURLs = serviceUrl.Split(',').ToList();
                            }
                            item.ServiceLines.Add(new BPCServiceLine
                            {
                                ServiceId = Convert.ToInt32(row["ServiceId"]),
                                DigitalCategoryId = Convert.ToInt32(row["DigitalCategoryId"]),
                                ServiceLine = row["ServiceLine"].ToString(),
                                ServiceURLs = serviceURLs,
                            });
                        }
                    }
                }
            }
            catch 
            {

            }
            return list;
        }
        public static bool SaveBusinessProgressCustomer(BusinessProgressCustomer obj_ML_BusinessProgress)
        {

            obj_ML_BusinessProgress.IncomefromSell = obj_ML_BusinessProgress.IncomeSellCash ? "Cash Sell" : "";
            if (obj_ML_BusinessProgress.IncomeCreditSell)
            {
                obj_ML_BusinessProgress.IncomefromSell = obj_ML_BusinessProgress.IncomefromSell + (string.IsNullOrEmpty(obj_ML_BusinessProgress.IncomefromSell) ? "Credit Sell" : ", Credit Sell");
            }

            obj_ML_BusinessProgress.ExpenditurefromPurchase = obj_ML_BusinessProgress.CheckCashExpenditure ? "Cash Expenditure" : "";
            if (obj_ML_BusinessProgress.CheckCreditExpenditure)
            {
                obj_ML_BusinessProgress.ExpenditurefromPurchase = obj_ML_BusinessProgress.ExpenditurefromPurchase + (string.IsNullOrEmpty(obj_ML_BusinessProgress.ExpenditurefromPurchase) ? "Credit Expenditure" : ", Credit Expenditure");
            }
            obj_ML_BusinessProgress.PaymentReceived = obj_ML_BusinessProgress.PaymentModeDigital ? "Digital" : "";
            if (obj_ML_BusinessProgress.PaymentModeNoneDigital)
            {
                obj_ML_BusinessProgress.PaymentReceived = obj_ML_BusinessProgress.PaymentReceived + (string.IsNullOrEmpty(obj_ML_BusinessProgress.PaymentReceived) ? "Non-Digital" : ", Non-Digital");
            }

            obj_ML_BusinessProgress.StartingBusinessDate= TypeConversionUtility.ToDateTime(obj_ML_BusinessProgress.StartingBusinessDate).ToString();

            return SqlBusinessProgressCustomer.SaveBusinessProgressCustomer(obj_ML_BusinessProgress);
        }
        public static List<BusinessProgessCustomerList> GetBusinessProgressCustomerList(int enrollmentId, int PageNumber, int PageSize, string SearchText)
        {
            return SqlBusinessProgressCustomer.GetBusinessProgressCustomerList(enrollmentId, PageNumber, PageSize, SearchText);
        }
        public static string GetBusinessProgressStartingBusinessDate(int enrollmentId)
        {
            return SqlBusinessProgressCustomer.GetBusinessProgressStartingBusinessDate(enrollmentId);
        }
        public static bool CheckBusinessProgressCustomerDataExist(int businessProgressId, int enrollmentId, int year, string month)
        {
            return SqlBusinessProgressCustomer.CheckBusinessProgressCustomerDataExist(businessProgressId, enrollmentId, year, month);
        }
    }
}
