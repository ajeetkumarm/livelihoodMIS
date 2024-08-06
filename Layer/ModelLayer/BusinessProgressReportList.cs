using System;

namespace ModelLayer
{
    [Serializable]
    public class BusinessProgressReportList
    {
        public int RowNum { get; set; }
        public int EnrollmentId { get; set; }
        public int TotalCount { get; set; }
        public string BeneficiaryCode { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string WomenName { get; set; }
        public string StartingBusinessDate { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int? NoNewCustomer { get; set; }= null;
        public int? NoRepeatedCustomer { get; set; } = null;
        public string ServicesOfferedType { get; set; }
        public string ServicesProvidedDetails { get; set; }
        public string GovCustomerServices { get; set; }
        public string G2CServices { get; set; }
        public string IncomefromSell { get; set; }
        public string CashSellAmount { get; set; }
        public string CreditSellAmount { get; set; }
        public string TotalIncome { get; set; }
        public string Investment { get; set; }
        public string ExpenditurefromPurchase { get; set; }
        public bool CashExpenditure { get; set; }
        public bool CreditExpenditure { get; set; }
        public string TotalExpenditure { get; set; }
        public string LastMonthCredit { get; set; }
        public string CreditSettlement { get; set; }
        public string MonthlyProfitLoss { get; set; }
        public string PaymentReceived { get; set; }
        public string PaymentReceivedMode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedDisplay => CreatedOn != null ? TypeConversionUtility.ToDateTime(CreatedOn).ToString("dd/MM/yyyy") : string.Empty;
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedDisplay => UpdatedOn != null ? TypeConversionUtility.ToDateTime(UpdatedOn).ToString("dd/MM/yyyy") : string.Empty;
        


     //   StartingBusinessDate,[Year],[Month],NoNewCustomer,NoRepeatedCustomer,
     //ServicesOfferedType,ServicesProvidedDetails,GovCustomerServices,G2CServices,IncomefromSell,CashSellAmount,
     //CreditSellAmount,TotalIncome,Investment,ExpenditurefromPurchase,CashExpenditure,CreditExpenditure,
     //TotalExpenditure,LastMonthCredit,CreditSettlement,MonthlyProfitLoss,PaymentReceived,PaymentReceivedMode,
     //BPF.CreatedOn,BPF.UpdatedOn
    }
}
