using System;
using System.Collections.Generic;

namespace ModelLayer
{
    [Serializable]
    public class EnterpriesSetupList
    {
        public int EnrollmentId { get; set; }
        public string BeneficiaryCode { get; set; }
        public int Cast { get; set; }
        public int EconomicStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public int State { get; set; }
        public int District { get; set; }
        public string WomenName { get; set; }
        public string HusbandFatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo { get; set; }
        public string ThemeCode { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public int Block { get; set; }
        public string BlockName { get; set; }
        public int Village { get; set; }
        public string VillageName { get; set; }
        public string PartSHG { get; set; }
        public string SHGName { get; set; }
        public string SHGDate { get; set; }
        public int SHGType { get; set; }
        public int Education { get; set; }   
        public string AadhaarrCard { get; set; }
        public string AadhaarCardDetails { get; set; }
        public string AadhaarNo { get; set; }
        public string AnyIDProofDetails { get; set; }
        public string IDProofNo { get; set; }
        public string IssuingAuthority { get; set; }
        public string RationCard { get; set; }
        public string RationCardlinkedPDS { get; set; }
        public string BankAccountNo { get; set; }
        public string LinkedSocialSecuritySchemes { get; set; }
        public int Scheme { get; set; }
        public int IntrestedEDPTraining { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationDateText => TypeConversionUtility.ToDateTime(RegistrationDate).ToString("dd/MM/yyyy");
    }


    public class EnterpriesSetupResponse
    {
        public EnterpriesSetupResponse()
        {
            data= new List<EnterpriesSetupList>();
        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<EnterpriesSetupList> data { get; set; }
    }

    public class CustomListResponse<T>
    {
        public CustomListResponse()
        {
            data = new List<T>();
        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
    }
}
