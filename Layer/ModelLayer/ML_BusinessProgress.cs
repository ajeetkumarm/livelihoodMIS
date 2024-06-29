using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ML_BusinessProgress
    {
        public string ProjectCode { get; set; }
        public int BusinessProgressId { get; set; }
        public int EnrollMentId { get; set; }
        public string StartingBusinessDate { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int NoNewCustomer { get; set; }
        public int NoRepeatedCustomer { get; set; }
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
        public string @XML_DigitalCategory { get; set; }
        public string @XML_ServiceLine { get; set; }

       public int OutputBusinessProgressId = 0;

       public string DigitalCategoryId { get; set; }

    }
}
