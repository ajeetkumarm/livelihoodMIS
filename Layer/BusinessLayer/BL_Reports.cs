using System.Collections.Generic;
using DataLayer;
using ModelLayer;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;
using System;

namespace BusinessLayer
{
    public class BL_Reports
    {
        DL_Reports obj_DL_Reports = new DL_Reports();

        public DataTable BL_RptEnrollmentDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptEnrollmentDetails(obj_ML_Reports);
        }
        public DataTable BL_RptTrainingDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptTrainingDetails(obj_ML_Reports);
        }
        public DataTable BL_RptEnterpriesTrainingDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptEnterpriesTrainingDetails(obj_ML_Reports);
        }
        public DataTable BL_RptBusinessProgressDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptBusinessProgressDetails(obj_ML_Reports);
        }
        public List<EnrollmentReportList> RptEnrollmentDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            return obj_DL_Reports.RptEnrollmentDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
        }
        public DataTable RptEnrollmentDetailDT(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            var data = RptEnrollmentDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
            DataTable dt = new DataTable();

            dt.Columns.Add("S.No", typeof(int));
            dt.Columns.Add("Beneficiary Code", typeof(string));
            dt.Columns.Add("Employee Id", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
            dt.Columns.Add("Enrollment Status", typeof(string));
            dt.Columns.Add("Replacement Employee Id", typeof(string));
            dt.Columns.Add("Replacement Beneficiary Code", typeof(string));
            dt.Columns.Add("Cohort", typeof(string));
            dt.Columns.Add("Women Name", typeof(string));
            dt.Columns.Add("Husband / Father Name", typeof(string));
            dt.Columns.Add("Mother Name", typeof(string));
            dt.Columns.Add("Phone No.", typeof(string));
            dt.Columns.Add("Theme Code", typeof(string));
            dt.Columns.Add("Cast", typeof(string));
            dt.Columns.Add("Economic Status", typeof(string));
            dt.Columns.Add("Marital Status", typeof(string));
            dt.Columns.Add("Birth Date", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Registration Date", typeof(string));
            dt.Columns.Add("Part SHG", typeof(string));
            dt.Columns.Add("SHG Name", typeof(string));
            dt.Columns.Add("SHG Date", typeof(string));
            dt.Columns.Add("SHG Type", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("PwD", typeof(string));
            dt.Columns.Add("PwD Specify", typeof(string));
            dt.Columns.Add("Aadhaar Card", typeof(string));
            dt.Columns.Add("Aadhaar Card Details", typeof(string));
            dt.Columns.Add("Aadhaar No.", typeof(string));
            dt.Columns.Add("Any ID Proof Details", typeof(string));
            dt.Columns.Add("ID Proof No.", typeof(string));
            dt.Columns.Add("Issuing Authority", typeof(string));
            dt.Columns.Add("Ration Card", typeof(string));
            dt.Columns.Add("Ration Card linked PDS", typeof(string));
            dt.Columns.Add("Bank Account No.", typeof(string));
            dt.Columns.Add("Linked Social Security Schemes", typeof(string));
            dt.Columns.Add("Reasons", typeof(string));
            dt.Columns.Add("Women Belong", typeof(string));
            dt.Columns.Add("Valid Certificate", typeof(string));
            dt.Columns.Add("Monthly Individual Income", typeof(string));
            dt.Columns.Add("Monthly Household Income", typeof(string));
            dt.Columns.Add("Scheme", typeof(string));
            dt.Columns.Add("Submited On", typeof(string));

            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["S.No"] = item.RowNum;
                dr["Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.BeneficiaryCode);
                dr["Employee Id"] = TypeConversionUtility.ToStringWithNull(item.EmployeeId);
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
                dr["Enrollment Status"] = TypeConversionUtility.ToStringWithNull(item.EnrollmentStatus);
                dr["Replacement Employee Id"] = TypeConversionUtility.ToStringWithNull(item.ReplacementEmployeeId);
                dr["Replacement Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.ReplacementBeneficiaryCode);
                dr["Cohort"] = TypeConversionUtility.ToStringWithNull(item.CohortValue);
                dr["Women Name"] = TypeConversionUtility.ToStringWithNull(item.WomenName);
                dr["Husband / Father Name"] = TypeConversionUtility.ToStringWithNull(item.HusbandFatherName);
                dr["Mother Name"] = TypeConversionUtility.ToStringWithNull(item.MotherName);
                dr["Phone No."] = TypeConversionUtility.ToStringWithNull(item.PhoneNo);
                dr["Theme Code"] = TypeConversionUtility.ToStringWithNull(item.ThemeCode);
                dr["Cast"] = TypeConversionUtility.ToStringWithNull(item.Cast);
                dr["Economic Status"] = TypeConversionUtility.ToStringWithNull(item.EconomicStatus);
                dr["Marital Status"] = TypeConversionUtility.ToStringWithNull(item.MaritalStatus);
                dr["Birth Date"] = TypeConversionUtility.ToStringWithNull(item.BirthDateDisplay);
                dr["Age"] = TypeConversionUtility.ToStringWithNull(item.Age);
                dr["Registration Date"] = TypeConversionUtility.ToStringWithNull(item.RegistrationDateDisplay);
                dr["Part SHG"] = TypeConversionUtility.ToStringWithNull(item.PartSHG);
                dr["SHG Name"] = TypeConversionUtility.ToStringWithNull(item.SHGName);
                dr["SHG Date"] = TypeConversionUtility.ToStringWithNull(item.SHGDateDisplay);
                dr["SHG Type"] = TypeConversionUtility.ToStringWithNull(item.SHGType);
                dr["Education"] = TypeConversionUtility.ToStringWithNull(item.Education);
                dr["PwD"] = TypeConversionUtility.ToStringWithNull(item.PwD);
                dr["PwD Specify"] = TypeConversionUtility.ToStringWithNull(item.PwDSpecify);
                dr["Aadhaar Card"] = TypeConversionUtility.ToStringWithNull(item.AadhaarrCard);
                dr["Aadhaar Card Details"] = TypeConversionUtility.ToStringWithNull(item.AadhaarCardDetails);
                dr["Aadhaar No."] = TypeConversionUtility.ToStringWithNull(item.AadhaarNo);
                dr["Any ID Proof Details"] = TypeConversionUtility.ToStringWithNull(item.AnyIDProofDetails);
                dr["ID Proof No."] = TypeConversionUtility.ToStringWithNull(item.IDProofNo);
                dr["Issuing Authority"] = TypeConversionUtility.ToStringWithNull(item.IssuingAuthority);
                dr["Ration Card"] = TypeConversionUtility.ToStringWithNull(item.RationCard);
                dr["Ration Card linked PDS"] = TypeConversionUtility.ToStringWithNull(item.RationCardlinkedPDS);
                dr["Bank Account No."] = TypeConversionUtility.ToStringWithNull(item.BankAccountNo);
                dr["Linked Social Security Schemes"] = TypeConversionUtility.ToStringWithNull(item.LinkedSocialSecuritySchemes);
                dr["Reasons"] = TypeConversionUtility.ToStringWithNull(item.Reasons);
                dr["Women Belong"] = TypeConversionUtility.ToStringWithNull(item.WomenBelong);
                dr["Valid Certificate"] = TypeConversionUtility.ToStringWithNull(item.ValidCertificate);
                dr["Monthly Individual Income"] = TypeConversionUtility.ToStringWithNull(item.MonthlyIndividualIncome);
                dr["Monthly Household Income"] = TypeConversionUtility.ToStringWithNull(item.MonthlyHouseholdIncome);
                dr["Scheme"] = TypeConversionUtility.ToStringWithNull(item.Scheme);
                dr["Submited On"] = TypeConversionUtility.ToStringWithNull(item.CreatedDisplay);

                dt.Rows.Add(dr);
            }
            return dt;
        }
        public List<TrainingReportList> RptTrainingDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            return obj_DL_Reports.RptTrainingDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
        }
        public DataTable RptTrainingDetailsDT(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            var data = RptTrainingDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
            DataTable dt = new DataTable();

            dt.Columns.Add("S.No", typeof(int));
            dt.Columns.Add("Beneficiary Code", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
            dt.Columns.Add("Women Name", typeof(string));
            dt.Columns.Add("Is Life Skills Training", typeof(string));
            dt.Columns.Add("RCSC Date", typeof(string));
            dt.Columns.Add("WRPC Date", typeof(string));
            dt.Columns.Add("HNC Date", typeof(string));
            dt.Columns.Add("FLC Date", typeof(string));
            dt.Columns.Add("EDTS Date", typeof(string));
            dt.Columns.Add("LEAP Date", typeof(string));
            dt.Columns.Add("ESIS Date", typeof(string));
            dt.Columns.Add("BMTC Date", typeof(string));
            dt.Columns.Add("MMTC Date", typeof(string));
            dt.Columns.Add("EDPT CDate", typeof(string));
            dt.Columns.Add("Submited On", typeof(string));

            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["S.No"] = item.RowNum;
                dr["Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.BeneficiaryCode);
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
                dr["Women Name"] = TypeConversionUtility.ToStringWithNull(item.WomenName);
                dr["Is Life Skills Training"] = TypeConversionUtility.ToStringWithNull(item.IsLifeSkillsTraining);
                dr["RCSC Date"] = TypeConversionUtility.ToStringWithNull(item.RCSCDate);
                dr["WRPC Date"] = TypeConversionUtility.ToStringWithNull(item.WRPCDate);
                dr["HNC Date"] = TypeConversionUtility.ToStringWithNull(item.HNCDate);
                dr["FLC Date"] = TypeConversionUtility.ToStringWithNull(item.FLCDate);
                dr["EDTS Date"] = TypeConversionUtility.ToStringWithNull(item.EDTSDate);
                dr["LEAP Date"] = TypeConversionUtility.ToStringWithNull(item.LEAPDate);
                dr["ESIS Date"] = TypeConversionUtility.ToStringWithNull(item.ESISDate);
                dr["BMTC Date"] = TypeConversionUtility.ToStringWithNull(item.BMTCDate);
                dr["MMTC Date"] = TypeConversionUtility.ToStringWithNull(item.MMTCDate);
                dr["EDPT CDate"] = TypeConversionUtility.ToStringWithNull(item.EDPTCDate);
                dr["Submited On"] = TypeConversionUtility.ToStringWithNull(item.CreatedDisplay);

                dt.Rows.Add(dr);
            }
            return dt;
        }
        public List<EnterpriesTrainingReportList> RptEnterpriesTrainingDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            return obj_DL_Reports.RptEnterpriesTrainingDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
        }
        public DataTable RptEnterpriesTrainingDetailsDT(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            var data = RptEnterpriesTrainingDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
            DataTable dt = new DataTable();

            dt.Columns.Add("S.No", typeof(int));
            dt.Columns.Add("Beneficiary Code", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
            dt.Columns.Add("Women Name", typeof(string));
            dt.Columns.Add("Start Business", typeof(string));
            dt.Columns.Add("Business Reasons", typeof(string));
            dt.Columns.Add("Business", typeof(string));
            dt.Columns.Add("Business When", typeof(string));
            dt.Columns.Add("Status Business", typeof(string));
            dt.Columns.Add("Village Population", typeof(string));
            dt.Columns.Add("Business Idea", typeof(string));
            dt.Columns.Add("Business Type", typeof(string));
            dt.Columns.Add("Procure Business", typeof(string));
            dt.Columns.Add("Current Business", typeof(string));
            dt.Columns.Add("Regular Financial Business", typeof(string));
            dt.Columns.Add("How Regular Financial", typeof(string));
            dt.Columns.Add("Setting Business Type", typeof(string));
            dt.Columns.Add("Monthly Rent", typeof(string));
            dt.Columns.Add("Expand Business", typeof(string));
            dt.Columns.Add("Potential Customers", typeof(string));
            dt.Columns.Add("Business Distance", typeof(string));
            dt.Columns.Add("Expected Footfall", typeof(string));
            dt.Columns.Add("How Far Bussiness", typeof(string));
            dt.Columns.Add("Planning Business", typeof(string));
            dt.Columns.Add("Support Business", typeof(string));
            dt.Columns.Add("Support Type", typeof(string));
            dt.Columns.Add("Not Provided Support", typeof(string));
            dt.Columns.Add("Paid Worker", typeof(string));
            dt.Columns.Add("Digital Inclusion", typeof(string));
            dt.Columns.Add("Digital Inclusion Date", typeof(string));
            dt.Columns.Add("Own Smart Phone", typeof(string));
            dt.Columns.Add("Use Smart Phone", typeof(string));
            dt.Columns.Add("Supply Chain", typeof(string));
            dt.Columns.Add("Submited On", typeof(string));

            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["S.No"] = item.RowNum;
                dr["Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.BeneficiaryCode);
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
                dr["Women Name"] = TypeConversionUtility.ToStringWithNull(item.WomenName);
                dr["Start Business"] = TypeConversionUtility.ToStringWithNull(item.StartBusiness);
                dr["Business Reasons"] = TypeConversionUtility.ToStringWithNull(item.BusinessReasons);
                dr["Business"] = TypeConversionUtility.ToStringWithNull(item.Business);
                dr["Business When"] = TypeConversionUtility.ToStringWithNull(item.BusinessWhen);
                dr["Status Business"] = TypeConversionUtility.ToStringWithNull(item.StatusBusiness);
                dr["Village Population"] = TypeConversionUtility.ToStringWithNull(item.VillagePopulation);
                dr["Business Idea"] = TypeConversionUtility.ToStringWithNull(item.BusinessIdea);
                dr["Business Type"] = TypeConversionUtility.ToStringWithNull(item.BusinessType);
                dr["Procure Business"] = TypeConversionUtility.ToStringWithNull(item.ProcureBusiness);
                dr["Current Business"] = TypeConversionUtility.ToStringWithNull(item.CurrentBusiness);
                dr["Regular Financial Business"] = TypeConversionUtility.ToStringWithNull(item.RegularFinancialBusiness);
                dr["How Regular Financial"] = TypeConversionUtility.ToStringWithNull(item.HowRegularFinancial);
                dr["Setting Business Type"] = TypeConversionUtility.ToStringWithNull(item.SettingBusinessType);
                dr["Monthly Rent"] = TypeConversionUtility.ToStringWithNull(item.MonthlyRent);
                dr["Expand Business"] = TypeConversionUtility.ToStringWithNull(item.ExpandBusiness);
                dr["Potential Customers"] = TypeConversionUtility.ToStringWithNull(item.PotentialCustomers);
                dr["Business Distance"] = TypeConversionUtility.ToStringWithNull(item.BusinessDistance);
                dr["Expected Footfall"] = TypeConversionUtility.ToStringWithNull(item.ExpectedFootfall);
                dr["How Far Bussiness"] = TypeConversionUtility.ToStringWithNull(item.HowFarBussiness);
                dr["Planning Business"] = TypeConversionUtility.ToStringWithNull(item.PlanningBusiness);
                dr["Support Business"] = TypeConversionUtility.ToStringWithNull(item.SupportBusiness);
                dr["Support Type"] = TypeConversionUtility.ToStringWithNull(item.SupportType);
                dr["Not Provided Support"] = TypeConversionUtility.ToStringWithNull(item.NotProvidedSupport);
                dr["Paid Worker"] = TypeConversionUtility.ToStringWithNull(item.PaidWorker);
                dr["Digital Inclusion"] = TypeConversionUtility.ToStringWithNull(item.DigitalInclusion);
                dr["Digital Inclusion Date"] = TypeConversionUtility.ToStringWithNull(item.DigitalInclusionDate);
                dr["Own Smart Phone"] = TypeConversionUtility.ToStringWithNull(item.OwnSmartPhone);
                dr["Use Smart Phone"] = TypeConversionUtility.ToStringWithNull(item.UseSmartPhone);
                dr["Supply Chain"] = TypeConversionUtility.ToStringWithNull(item.SupplyChain);
                dr["Submited On"] = TypeConversionUtility.ToStringWithNull(item.CreatedDisplay);
                dt.Rows.Add(dr);
            }
            return dt;

        }
        public List<BusinessProgressReportList> RptBusinessProgressDetails(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            return obj_DL_Reports.RptBusinessProgressDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
        }
        public DataTable RptBusinessProgressDetailsDT(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            var data = RptBusinessProgressDetails(createdUser, projectCode, PageNumber, PageSize, SearchText);
            DataTable dt = new DataTable();

            dt.Columns.Add("S.No", typeof(int));
            dt.Columns.Add("Beneficiary Code", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
            dt.Columns.Add("Women Name", typeof(string));
            dt.Columns.Add("Starting Business Date", typeof(string));
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("No New Customer", typeof(string));
            dt.Columns.Add("No Repeated Customer", typeof(string));
            dt.Columns.Add("Services Offered Type", typeof(string));
            dt.Columns.Add("Services Provided Details", typeof(string));
            dt.Columns.Add("Gov Customer Services", typeof(string));
            dt.Columns.Add("G2C Services", typeof(string));
            dt.Columns.Add("Income from Sell", typeof(string));
            dt.Columns.Add("Cash Sell Amount", typeof(string));
            dt.Columns.Add("Credit Sell Amount", typeof(string));
            dt.Columns.Add("Total Income", typeof(string));
            dt.Columns.Add("Investment", typeof(string));
            dt.Columns.Add("Expenditure from Purchase", typeof(string));
            dt.Columns.Add("Cash Expenditure", typeof(string));
            dt.Columns.Add("Credit Expenditure", typeof(string));
            dt.Columns.Add("Total Expenditure", typeof(string));
            dt.Columns.Add("Last Month Credit", typeof(string));
            dt.Columns.Add("Credit Settlement", typeof(string));
            dt.Columns.Add("Monthly Profit Loss", typeof(string));
            dt.Columns.Add("Payment Received", typeof(string));
            dt.Columns.Add("Payment Received Mode", typeof(string));
            dt.Columns.Add("Submited On", typeof(string));



            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["S.No"] = item.RowNum;
                dr["Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.BeneficiaryCode);
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
                dr["Women Name"] = TypeConversionUtility.ToStringWithNull(item.WomenName);
                dr["Starting Business Date"] = TypeConversionUtility.ToStringWithNull(item.StartingBusinessDate);
                dr["Year"] = TypeConversionUtility.ToStringWithNull(item.Year);
                dr["Month"] = TypeConversionUtility.ToStringWithNull(item.Month);
                dr["No New Customer"] = TypeConversionUtility.ToStringWithNull(item.NoNewCustomer);
                dr["No Repeated Customer"] = TypeConversionUtility.ToStringWithNull(item.NoRepeatedCustomer);
                dr["Services Offered Type"] = TypeConversionUtility.ToStringWithNull(item.ServicesOfferedType);
                dr["Services Provided Details"] = TypeConversionUtility.ToStringWithNull(item.ServicesProvidedDetails);
                dr["Gov Customer Services"] = TypeConversionUtility.ToStringWithNull(item.GovCustomerServices);
                dr["G2C Services"] = TypeConversionUtility.ToStringWithNull(item.G2CServices);
                dr["Income from Sell"] = TypeConversionUtility.ToStringWithNull(item.IncomefromSell);
                dr["Cash Sell Amount"] = TypeConversionUtility.ToStringWithNull(item.CashSellAmount);
                dr["Credit Sell Amount"] = TypeConversionUtility.ToStringWithNull(item.CreditSellAmount);
                dr["Total Income"] = TypeConversionUtility.ToStringWithNull(item.TotalIncome);
                dr["Investment"] = TypeConversionUtility.ToStringWithNull(item.Investment);
                dr["Expenditure from Purchase"] = TypeConversionUtility.ToStringWithNull(item.ExpenditurefromPurchase);
                dr["Cash Expenditure"] = TypeConversionUtility.ToStringWithNull(item.CashExpenditure);
                dr["Credit Expenditure"] = TypeConversionUtility.ToStringWithNull(item.CreditExpenditure);
                dr["Total Expenditure"] = TypeConversionUtility.ToStringWithNull(item.TotalExpenditure);
                dr["Last Month Credit"] = TypeConversionUtility.ToStringWithNull(item.LastMonthCredit);
                dr["Credit Settlement"] = TypeConversionUtility.ToStringWithNull(item.CreditSettlement);
                dr["Monthly Profit Loss"] = TypeConversionUtility.ToStringWithNull(item.MonthlyProfitLoss);
                dr["Payment Received"] = TypeConversionUtility.ToStringWithNull(item.PaymentReceived);
                dr["Payment Received Mode"] = TypeConversionUtility.ToStringWithNull(item.PaymentReceivedMode);
                dr["Submited On"] = TypeConversionUtility.ToStringWithNull(item.CreatedDisplay);
                dt.Rows.Add(dr);
            }
            return dt;

        }
        public List<ConsolidateReportList> RptConsolidated(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            return obj_DL_Reports.RptConsolidated(createdUser, projectCode, PageNumber, PageSize, SearchText);
        }
        public DataTable RptConsolidatedDT(int createdUser, int projectCode, int PageNumber, int PageSize, string SearchText)
        {
            var data = RptConsolidated(createdUser, projectCode, PageNumber, PageSize, SearchText);
            DataTable dt = new DataTable();

            #region "Enrollment Column"
            dt.Columns.Add("S.No", typeof(int));
            dt.Columns.Add("Beneficiary Code", typeof(string));
            dt.Columns.Add("Employee Id", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
            dt.Columns.Add("Enrollment Status", typeof(string));
            dt.Columns.Add("Replacement Employee Id", typeof(string));
            dt.Columns.Add("Replacement Beneficiary Code", typeof(string));
            dt.Columns.Add("Cohort", typeof(string));
            dt.Columns.Add("Women Name", typeof(string));
            dt.Columns.Add("Husband / Father Name", typeof(string));
            dt.Columns.Add("Mother Name", typeof(string));
            dt.Columns.Add("Phone No.", typeof(string));
            dt.Columns.Add("Theme Code", typeof(string));
            dt.Columns.Add("Cast", typeof(string));
            dt.Columns.Add("Economic Status", typeof(string));
            dt.Columns.Add("Marital Status", typeof(string));
            dt.Columns.Add("Birth Date", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Registration Date", typeof(string));
            dt.Columns.Add("Part SHG", typeof(string));
            dt.Columns.Add("SHG Name", typeof(string));
            dt.Columns.Add("SHG Date", typeof(string));
            dt.Columns.Add("SHG Type", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("PwD", typeof(string));
            dt.Columns.Add("PwD Specify", typeof(string));
            dt.Columns.Add("Aadhaar Card", typeof(string));
            dt.Columns.Add("Aadhaar Card Details", typeof(string));
            dt.Columns.Add("Aadhaar No.", typeof(string));
            dt.Columns.Add("Any ID Proof Details", typeof(string));
            dt.Columns.Add("ID Proof No.", typeof(string));
            dt.Columns.Add("Issuing Authority", typeof(string));
            dt.Columns.Add("Ration Card", typeof(string));
            dt.Columns.Add("Ration Card linked PDS", typeof(string));
            dt.Columns.Add("Bank Account No.", typeof(string));
            dt.Columns.Add("Linked Social Security Schemes", typeof(string));
            dt.Columns.Add("Reasons", typeof(string));
            dt.Columns.Add("Women Belong", typeof(string));
            dt.Columns.Add("Valid Certificate", typeof(string));
            dt.Columns.Add("Monthly Individual Income", typeof(string));
            dt.Columns.Add("Monthly Household Income", typeof(string));
            dt.Columns.Add("Scheme", typeof(string));
            dt.Columns.Add("Submited On", typeof(string));
            #endregion

            #region "Training Column"
            dt.Columns.Add("Is Life Skills Training", typeof(string));
            dt.Columns.Add("RCSC Date", typeof(string));
            dt.Columns.Add("WRPC Date", typeof(string));
            dt.Columns.Add("HNC Date", typeof(string));
            dt.Columns.Add("FLC Date", typeof(string));
            dt.Columns.Add("EDTS Date", typeof(string));
            dt.Columns.Add("LEAP Date", typeof(string));
            dt.Columns.Add("ESIS Date", typeof(string));
            dt.Columns.Add("BMTC Date", typeof(string));
            dt.Columns.Add("MMTC Date", typeof(string));
            dt.Columns.Add("EDPT CDate", typeof(string));
            #endregion

            #region "Enterpries Training Column"
            dt.Columns.Add("Start Business", typeof(string));
            dt.Columns.Add("Business Reasons", typeof(string));
            dt.Columns.Add("Business", typeof(string));
            dt.Columns.Add("Business When", typeof(string));
            dt.Columns.Add("Status Business", typeof(string));
            dt.Columns.Add("Village Population", typeof(string));
            dt.Columns.Add("Business Idea", typeof(string));
            dt.Columns.Add("Business Type", typeof(string));
            dt.Columns.Add("Procure Business", typeof(string));
            dt.Columns.Add("Current Business", typeof(string));
            dt.Columns.Add("Regular Financial Business", typeof(string));
            dt.Columns.Add("How Regular Financial", typeof(string));
            dt.Columns.Add("Setting Business Type", typeof(string));
            dt.Columns.Add("Monthly Rent", typeof(string));
            dt.Columns.Add("Expand Business", typeof(string));
            dt.Columns.Add("Potential Customers", typeof(string));
            dt.Columns.Add("Business Distance", typeof(string));
            dt.Columns.Add("Expected Footfall", typeof(string));
            dt.Columns.Add("How Far Bussiness", typeof(string));
            dt.Columns.Add("Planning Business", typeof(string));
            dt.Columns.Add("Support Business", typeof(string));
            dt.Columns.Add("Support Type", typeof(string));
            dt.Columns.Add("Not Provided Support", typeof(string));
            dt.Columns.Add("Paid Worker", typeof(string));
            dt.Columns.Add("Digital Inclusion", typeof(string));
            dt.Columns.Add("Digital Inclusion Date", typeof(string));
            dt.Columns.Add("Own Smart Phone", typeof(string));
            dt.Columns.Add("Use Smart Phone", typeof(string));
            dt.Columns.Add("Supply Chain", typeof(string));
            #endregion
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();

                #region "Enrollment Data Binding"
                dr["S.No"] = item.RowNum;
                dr["Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.BeneficiaryCode);
                dr["Employee Id"] = TypeConversionUtility.ToStringWithNull(item.EmployeeId);
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
                dr["Enrollment Status"] = TypeConversionUtility.ToStringWithNull(item.EnrollmentStatus);
                dr["Replacement Employee Id"] = TypeConversionUtility.ToStringWithNull(item.ReplacementEmployeeId);
                dr["Replacement Beneficiary Code"] = TypeConversionUtility.ToStringWithNull(item.ReplacementBeneficiaryCode);
                dr["Cohort"] = TypeConversionUtility.ToStringWithNull(item.CohortValue);
                dr["Women Name"] = TypeConversionUtility.ToStringWithNull(item.WomenName);
                dr["Husband / Father Name"] = TypeConversionUtility.ToStringWithNull(item.HusbandFatherName);
                dr["Mother Name"] = TypeConversionUtility.ToStringWithNull(item.MotherName);
                dr["Phone No."] = TypeConversionUtility.ToStringWithNull(item.PhoneNo);
                dr["Theme Code"] = TypeConversionUtility.ToStringWithNull(item.ThemeCode);
                dr["Cast"] = TypeConversionUtility.ToStringWithNull(item.Cast);
                dr["Economic Status"] = TypeConversionUtility.ToStringWithNull(item.EconomicStatus);
                dr["Marital Status"] = TypeConversionUtility.ToStringWithNull(item.MaritalStatus);
                dr["Birth Date"] = TypeConversionUtility.ToStringWithNull(item.BirthDateDisplay);
                dr["Age"] = TypeConversionUtility.ToStringWithNull(item.Age);
                dr["Registration Date"] = TypeConversionUtility.ToStringWithNull(item.RegistrationDateDisplay);
                dr["Part SHG"] = TypeConversionUtility.ToStringWithNull(item.PartSHG);
                dr["SHG Name"] = TypeConversionUtility.ToStringWithNull(item.SHGName);
                dr["SHG Date"] = TypeConversionUtility.ToStringWithNull(item.SHGDateDisplay);
                dr["SHG Type"] = TypeConversionUtility.ToStringWithNull(item.SHGType);
                dr["Education"] = TypeConversionUtility.ToStringWithNull(item.Education);
                dr["PwD"] = TypeConversionUtility.ToStringWithNull(item.PwD);
                dr["PwD Specify"] = TypeConversionUtility.ToStringWithNull(item.PwDSpecify);
                dr["Aadhaar Card"] = TypeConversionUtility.ToStringWithNull(item.AadhaarrCard);
                dr["Aadhaar Card Details"] = TypeConversionUtility.ToStringWithNull(item.AadhaarCardDetails);
                dr["Aadhaar No."] = TypeConversionUtility.ToStringWithNull(item.AadhaarNo);
                dr["Any ID Proof Details"] = TypeConversionUtility.ToStringWithNull(item.AnyIDProofDetails);
                dr["ID Proof No."] = TypeConversionUtility.ToStringWithNull(item.IDProofNo);
                dr["Issuing Authority"] = TypeConversionUtility.ToStringWithNull(item.IssuingAuthority);
                dr["Ration Card"] = TypeConversionUtility.ToStringWithNull(item.RationCard);
                dr["Ration Card linked PDS"] = TypeConversionUtility.ToStringWithNull(item.RationCardlinkedPDS);
                dr["Bank Account No."] = TypeConversionUtility.ToStringWithNull(item.BankAccountNo);
                dr["Linked Social Security Schemes"] = TypeConversionUtility.ToStringWithNull(item.LinkedSocialSecuritySchemes);
                dr["Reasons"] = TypeConversionUtility.ToStringWithNull(item.Reasons);
                dr["Women Belong"] = TypeConversionUtility.ToStringWithNull(item.WomenBelong);
                dr["Valid Certificate"] = TypeConversionUtility.ToStringWithNull(item.ValidCertificate);
                dr["Monthly Individual Income"] = TypeConversionUtility.ToStringWithNull(item.MonthlyIndividualIncome);
                dr["Monthly Household Income"] = TypeConversionUtility.ToStringWithNull(item.MonthlyHouseholdIncome);
                dr["Scheme"] = TypeConversionUtility.ToStringWithNull(item.Scheme);
                dr["Submited On"] = TypeConversionUtility.ToStringWithNull(item.CreatedDisplay);
                #endregion

                #region "Training Data Binding"
                dr["Is Life Skills Training"] = TypeConversionUtility.ToStringWithNull(item.IsLifeSkillsTraining);
                dr["RCSC Date"] = TypeConversionUtility.ToStringWithNull(item.RCSCDate);
                dr["WRPC Date"] = TypeConversionUtility.ToStringWithNull(item.WRPCDate);
                dr["HNC Date"] = TypeConversionUtility.ToStringWithNull(item.HNCDate);
                dr["FLC Date"] = TypeConversionUtility.ToStringWithNull(item.FLCDate);
                dr["EDTS Date"] = TypeConversionUtility.ToStringWithNull(item.EDTSDate);
                dr["LEAP Date"] = TypeConversionUtility.ToStringWithNull(item.LEAPDate);
                dr["ESIS Date"] = TypeConversionUtility.ToStringWithNull(item.ESISDate);
                dr["BMTC Date"] = TypeConversionUtility.ToStringWithNull(item.BMTCDate);
                dr["MMTC Date"] = TypeConversionUtility.ToStringWithNull(item.MMTCDate);
                dr["EDPT CDate"] = TypeConversionUtility.ToStringWithNull(item.EDPTCDate);
                #endregion

                #region "Enterpries Training Data Binding"
                dr["Start Business"] = TypeConversionUtility.ToStringWithNull(item.StartBusiness);
                dr["Business Reasons"] = TypeConversionUtility.ToStringWithNull(item.BusinessReasons);
                dr["Business"] = TypeConversionUtility.ToStringWithNull(item.Business);
                dr["Business When"] = TypeConversionUtility.ToStringWithNull(item.BusinessWhen);
                dr["Status Business"] = TypeConversionUtility.ToStringWithNull(item.StatusBusiness);
                dr["Village Population"] = TypeConversionUtility.ToStringWithNull(item.VillagePopulation);
                dr["Business Idea"] = TypeConversionUtility.ToStringWithNull(item.BusinessIdea);
                dr["Business Type"] = TypeConversionUtility.ToStringWithNull(item.BusinessType);
                dr["Procure Business"] = TypeConversionUtility.ToStringWithNull(item.ProcureBusiness);
                dr["Current Business"] = TypeConversionUtility.ToStringWithNull(item.CurrentBusiness);
                dr["Regular Financial Business"] = TypeConversionUtility.ToStringWithNull(item.RegularFinancialBusiness);
                dr["How Regular Financial"] = TypeConversionUtility.ToStringWithNull(item.HowRegularFinancial);
                dr["Setting Business Type"] = TypeConversionUtility.ToStringWithNull(item.SettingBusinessType);
                dr["Monthly Rent"] = TypeConversionUtility.ToStringWithNull(item.MonthlyRent);
                dr["Expand Business"] = TypeConversionUtility.ToStringWithNull(item.ExpandBusiness);
                dr["Potential Customers"] = TypeConversionUtility.ToStringWithNull(item.PotentialCustomers);
                dr["Business Distance"] = TypeConversionUtility.ToStringWithNull(item.BusinessDistance);
                dr["Expected Footfall"] = TypeConversionUtility.ToStringWithNull(item.ExpectedFootfall);
                dr["How Far Bussiness"] = TypeConversionUtility.ToStringWithNull(item.HowFarBussiness);
                dr["Planning Business"] = TypeConversionUtility.ToStringWithNull(item.PlanningBusiness);
                dr["Support Business"] = TypeConversionUtility.ToStringWithNull(item.SupportBusiness);
                dr["Support Type"] = TypeConversionUtility.ToStringWithNull(item.SupportType);
                dr["Not Provided Support"] = TypeConversionUtility.ToStringWithNull(item.NotProvidedSupport);
                dr["Paid Worker"] = TypeConversionUtility.ToStringWithNull(item.PaidWorker);
                dr["Digital Inclusion"] = TypeConversionUtility.ToStringWithNull(item.DigitalInclusion);
                dr["Digital Inclusion Date"] = TypeConversionUtility.ToStringWithNull(item.DigitalInclusionDate);
                dr["Own Smart Phone"] = TypeConversionUtility.ToStringWithNull(item.OwnSmartPhone);
                dr["Use Smart Phone"] = TypeConversionUtility.ToStringWithNull(item.UseSmartPhone);
                dr["Supply Chain"] = TypeConversionUtility.ToStringWithNull(item.SupplyChain);
                #endregion

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
