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
        DL_Reports obj_DL_Reports=new DL_Reports();

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
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Block", typeof(string));
            dt.Columns.Add("Village", typeof(string));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("User Name(FE)", typeof(string));
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
                dr["State"] = TypeConversionUtility.ToStringWithNull(item.StateName);
                dr["District"] = TypeConversionUtility.ToStringWithNull(item.DistrictName);
                dr["Block"] = TypeConversionUtility.ToStringWithNull(item.BlockName);
                dr["Village"] = TypeConversionUtility.ToStringWithNull(item.VillageName);
                dr["Project"] = TypeConversionUtility.ToStringWithNull(item.ProjectName);
                dr["User Name(FE)"] = TypeConversionUtility.ToStringWithNull(item.UserName);
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
    }
}
