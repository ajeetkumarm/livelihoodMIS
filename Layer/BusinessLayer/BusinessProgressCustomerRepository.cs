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

        public static BusinessProgressCustomer GetBusinessProgressCustomerByBusinessProgressId(int enrollmentId, int businessProgressId)
        {

            BusinessProgressCustomer businessProgressCustomer = new BusinessProgressCustomer();
            businessProgressCustomer.DigitalCategories = GetCategoryAndServiceLineList();
            if(businessProgressId==0)
            {
                businessProgressCustomer.EnrollMentId = enrollmentId;
                string startingBusinessDate = GetBusinessProgressStartingBusinessDate(enrollmentId);
                if (!string.IsNullOrEmpty(startingBusinessDate))
                {
                    businessProgressCustomer.StartingBusinessDate = TypeConversionUtility.ToDateTime(startingBusinessDate).ToString();
                }
            }
            else
            {
                var dataSet = SqlBusinessProgressCustomer.GetBusinessProgressCustomerByBusinessProgressId(businessProgressId);
                DataTable dtBusinessProgress = dataSet.Tables[0];
                DataTable dtBusinessProgressCategories = dataSet.Tables[1];
                DataTable dtBusinessProgressServices = dataSet.Tables[2];

                if(dtBusinessProgress.Rows.Count>0)
                {
                    businessProgressCustomer. BusinessProgressId = TypeConversionUtility.ToInteger(dtBusinessProgress.Rows[0]["BusinessProgressId"]);
                    businessProgressCustomer.EnrollMentId = TypeConversionUtility.ToInteger(dtBusinessProgress.Rows[0]["EnrollMentId"]);
                    businessProgressCustomer.StartingBusinessDate = TypeConversionUtility.ToDateTime(dtBusinessProgress.Rows[0]["StartingBusinessDate"]).ToString();
                    
                    businessProgressCustomer.Month = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["Month"]);
                    businessProgressCustomer.Year = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["Year"]);
                    businessProgressCustomer.NoNewCustomer = TypeConversionUtility.ToInteger(dtBusinessProgress.Rows[0]["NoNewCustomer"]);
                    businessProgressCustomer.NoRepeatedCustomer = TypeConversionUtility.ToInteger(dtBusinessProgress.Rows[0]["NoRepeatedCustomer"]);
                    businessProgressCustomer.ServicesOfferedType = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["ServicesOfferedType"]);
                    businessProgressCustomer.ServicesProvidedDetails = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["ServicesProvidedDetails"]);
                    businessProgressCustomer.GovCustomerServices = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["GovCustomerServices"]);
                    businessProgressCustomer.G2CServices = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["G2CServices"]);
                    businessProgressCustomer.IncomefromSell = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["IncomefromSell"]);

                    if(businessProgressCustomer.IncomefromSell.Contains("Cash Sell"))
                    {
                        businessProgressCustomer.IncomeSellCash = true;
                    }
                    if (businessProgressCustomer.IncomefromSell.Contains("Credit Sell"))
                    {
                        businessProgressCustomer.IncomeCreditSell = true;
                    }

                    businessProgressCustomer.CashSellAmount = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["CashSellAmount"]);
                    businessProgressCustomer.CreditSellAmount = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["CreditSellAmount"]);
                    businessProgressCustomer.TotalIncome = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["TotalIncome"]);
                    businessProgressCustomer.Investment = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["Investment"]);
                    businessProgressCustomer.ExpenditurefromPurchase = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["ExpenditurefromPurchase"]);
                    if(businessProgressCustomer.ExpenditurefromPurchase.Contains("Cash Expenditure"))
                    {
                        businessProgressCustomer.CheckCashExpenditure = true;
                    }
                    if (businessProgressCustomer.ExpenditurefromPurchase.Contains("Credit Expenditure"))
                    {
                        businessProgressCustomer.CheckCreditExpenditure = true;
                    }


                    businessProgressCustomer.CashExpenditure = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["CashExpenditure"]);
                    businessProgressCustomer.CreditExpenditure = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["CreditExpenditure"]);
                    businessProgressCustomer.TotalExpenditure = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["TotalExpenditure"]);
                    businessProgressCustomer.LastMonthCredit = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["LastMonthCredit"]);
                    businessProgressCustomer.CreditSettlement = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["CreditSettlement"]);
                    businessProgressCustomer.MonthlyProfitLoss = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["MonthlyProfitLoss"]);
                    businessProgressCustomer.PaymentReceived = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["PaymentReceived"]);
                    if (businessProgressCustomer.PaymentReceived.Contains("Digital"))
                    {
                        businessProgressCustomer.PaymentModeDigital = true;
                    }
                    if (businessProgressCustomer.PaymentReceived.Contains("Non-Digital"))
                    {
                        businessProgressCustomer.PaymentModeNoneDigital = true;
                    }
                    businessProgressCustomer.PaymentReceivedMode = TypeConversionUtility.ToStringWithNull(dtBusinessProgress.Rows[0]["PaymentReceivedMode"]);
                    businessProgressCustomer.TotalVillagesCovered = TypeConversionUtility.ToInteger(dtBusinessProgress.Rows[0]["TotalVillagesCovered"]);
                }

                if (dtBusinessProgressCategories.Rows.Count > 0)
                {
                    foreach (DataRow row in dtBusinessProgressCategories.Rows)
                    {
                        int digitalCategoryId = TypeConversionUtility.ToInteger(row["DigitalCategoryId"]);
                        var digitalCategory = businessProgressCustomer.DigitalCategories.FirstOrDefault(x => x.CategoryId == digitalCategoryId);
                        if (digitalCategory != null)
                        {
                            digitalCategory.IsSelected = true;
                        }
                    }
                }
                List<BPCServiceLine> serviceLines = new List<BPCServiceLine>();
                if (dtBusinessProgressServices.Rows.Count > 0)
                {
                    foreach (DataRow item in dtBusinessProgressServices.Rows)
                    {
                        serviceLines.Add(new BPCServiceLine
                        {
                            ServiceId = TypeConversionUtility.ToInteger(item["ServiceLineId"]),
                            CustomersNo = TypeConversionUtility.ToInteger(item["CustomersNo"]),
                            UplodedFileName = TypeConversionUtility.ToStringWithNull(item["UplodedFileName"]),
                            DigitalCategoryId = TypeConversionUtility.ToInteger(item["DigitalCategoryId"])

                        });
                    }
                }
                foreach (var item in businessProgressCustomer.DigitalCategories)
                {
                    item.ServiceLines = serviceLines.Where(x => x.DigitalCategoryId == item.CategoryId).ToList();
                    item.ServiceLines.ForEach(x => x.ServiceURLs = item.SubCategories.FirstOrDefault(j => j.ServiceId == x.ServiceId).ServiceURLs);

                    if(item.ServiceLines.Count==0)
                    {
                        item.ServiceLines.Add(new BPCServiceLine());
                    }
                }
            }
            return businessProgressCustomer;
        }

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
                            item.SubCategories.Add(new BPCDigitalSubCategory
                            {
                                ServiceId = Convert.ToInt32(row["ServiceId"]),
                                DigitalCategoryId = Convert.ToInt32(row["DigitalCategoryId"]),
                                ServiceLine = row["ServiceLine"].ToString(),
                                ServiceURLs = serviceURLs,
                            });
                        }
                    }
                    // Add 1 row with empty values
                    item.ServiceLines.Add(new BPCServiceLine());
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
        public static bool SaveBusinessProgressStatus(BusinessProgressStatusDTO model)
        {
            return SqlBusinessProgressCustomer.SaveBusinessProgressStatus(model);
        }
        public static BusinessProgressStatusDTO GetBusinessProgressStatus(int enrollmentId)
        {
            var model = SqlBusinessProgressCustomer.GetBusinessProgressStatus(enrollmentId);
            if (model == null)
            {
                model = new BusinessProgressStatusDTO();
                model.BusinessStatus = 1;
            }
            else if (model.BusinessStatus == 0)
            {
                model.BusinessStatus = 1;
            }
            return model;
        }
        public static List<BusinessProgressCustomerCountEntity> GetBusinessProgressServiceLineCount(int enrollmentId)
        {
            return SqlBusinessProgressCustomer.GetBusinessProgressServiceLineCount(enrollmentId);
        }
    }
}
