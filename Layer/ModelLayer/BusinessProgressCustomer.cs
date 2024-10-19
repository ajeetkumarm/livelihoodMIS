using System;
using System.Collections.Generic;

namespace ModelLayer
{
    [Serializable]
    public class BusinessProgressCustomer
    {
        public BusinessProgressCustomer()
        {
            DigitalCategories = new List<BPCDigitalCategory>();
        }
        public string ProjectCode { get; set; }
        public int BusinessProgressId { get; set; }
        public int EnrollMentId { get; set; }
        public string StartingBusinessDate { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int? NoNewCustomer { get; set; }= null;
        public int? NoRepeatedCustomer { get; set; } = null;
        public string ServicesOfferedType { get; set; }
        public int DigitalCategory { get; set; }
        public int ServiceLine { get; set; }
        public string ServicesProvidedDetails { get; set; }
        public string GovCustomerServices { get; set; }
        public string G2CServices { get; set; }
        public string IncomefromSell { get; set; }
        public string CashSellAmount { get; set; }
        public string CreditSellAmount { get; set; }
        public string TotalIncome { get; set; }
        public string Investment { get; set; }
        public string ExpenditurefromPurchase { get; set; }
        public bool CheckCashExpenditure { get; set; }
        public bool CheckCreditExpenditure { get; set; }
        public string CashExpenditure { get; set; }
        public string CreditExpenditure { get; set; }
        public string TotalExpenditure { get; set; }
        public string LastMonthCredit { get; set; }
        public string CreditSettlement { get; set; }
        public string MonthlyProfitLoss { get; set; }
        public string PaymentReceived { get; set; }
        public string PaymentReceivedMode { get; set; }
        public string VillageDistance { get; set; }
        public string ExpectedFootfall { get; set; }
        public string SameTypeBusinessDistance { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IncomeSellCash { get; set; }
        public bool IncomeCreditSell { get; set; }
        public bool PaymentModeDigital { get; set; }
        public bool PaymentModeNoneDigital { get; set; }
        public List<BPCDigitalCategory> DigitalCategories { get; set; }
        public int TotalVillagesCovered { get; set; }
    }
    [Serializable]
    public class BPCDigitalCategory
    {
        public BPCDigitalCategory()
        {
            ServiceLines = new List<BPCServiceLine>();
            SubCategories = new List<BPCDigitalSubCategory>();
        }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsSelected { get; set; }
        public List<BPCDigitalSubCategory> SubCategories { get; set; }
        public List<BPCServiceLine> ServiceLines { get; set; }
    }

    public class BPCDigitalSubCategory
    {
        public BPCDigitalSubCategory()
        {
            ServiceURLs = new List<string>();
        }
        public int ServiceId { get; set; }
        public int DigitalCategoryId { get; set; }
        public string ServiceLine { get; set; }
        public List<string> ServiceURLs { get; set; }
    }

    [Serializable]
    public class BPCServiceLine
    {
        public BPCServiceLine()
        {
            ServiceURLs = new List<string>();
        }
        public int? ServiceId { get; set; }
        public int? DigitalCategoryId { get; set; }
        public string ServiceLine { get; set; }
        public int? CustomersNo { get; set; }
        public string UplodedFileName { get; set; }
        public bool IsSelected { get; set; }
        public bool DisplayView => !string.IsNullOrEmpty(UplodedFileName);

        public List<string> ServiceURLs { get; set; }
    }
}