using System;
using System.Collections.Generic;

namespace ModelLayer
{
    [Serializable]
    public class BusinessProgessCustomerList
    {
        public int BusinessProgressId { get; set; }
        public int EnrollmentId { get; set; }
        public string BeneficiaryCode { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string WomenName { get; set; }
        public string StartingBusinessDate { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int NoNewCustomer { get; set; }
        public int NoRepeatedCustomer { get; set; }
        public string ServicesOfferedType { get; set; }
        public string ServicesProvidedDetails { get; set; }
        public int GovCustomerServices  { get; set; }
        public string G2CServices { get; set; }
        public string IncomefromSell { get; set; }
        public string CashSellAmount { get; set; }
        public string CreditSellAmount  { get; set; }
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
        public DateTime CreatedOn { get; set; }
        public string CreatedOnText => CreatedOn.ToString("dd/MM/yyyy");
        public DateTime UpdatedOn { get; set; }
        public int TotalCount { get; set; }
        public int RowNum { get; set; }
        public int TotalVillagesCovered { get; set; }
    }

    public class BusinessProgessCustomerResponse
    {
        public BusinessProgessCustomerResponse()
        {
            data = new List<BusinessProgessCustomerList>();
        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<BusinessProgessCustomerList> data { get; set; }
    }
}
