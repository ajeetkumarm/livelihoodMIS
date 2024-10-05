using System;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;

namespace DataLayer
{
    public class DL_EnterprisesTraining
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdEntTraining(ML_EnterprisesTraining obj_ML_EnterprisesTraining)
        {
            SqlParameter[] par ={ new SqlParameter("@EntTrainingId", obj_ML_EnterprisesTraining.EntTrainingId),
                                  new SqlParameter("@EnrollmentId", obj_ML_EnterprisesTraining.EnrollmentId),
                                  new SqlParameter("@StartBusiness", obj_ML_EnterprisesTraining.StartBusiness),
                                  new SqlParameter("@BusinessReasons", obj_ML_EnterprisesTraining.BusinessReasons),
                                  new SqlParameter("@Business", obj_ML_EnterprisesTraining.Business),
                                  new SqlParameter("@BusinessWhen", obj_ML_EnterprisesTraining.BusinessWhen),
                                  new SqlParameter("@StatusBusiness", obj_ML_EnterprisesTraining.StatusBusiness),
                                  new SqlParameter("@VillagePopulation", obj_ML_EnterprisesTraining.VillagePopulation),
                                  new SqlParameter("@BusinessIdea", obj_ML_EnterprisesTraining.BusinessIdea),
                                  new SqlParameter("@BusinessType", obj_ML_EnterprisesTraining.BusinessType),
                                  new SqlParameter("@ProcureBusiness", obj_ML_EnterprisesTraining.ProcureBusiness),
                                  new SqlParameter("@CurrentBusiness", obj_ML_EnterprisesTraining.CurrentBusiness),
                                  new SqlParameter("@RegularFinancialBusiness", obj_ML_EnterprisesTraining.RegularFinancialBusiness),
                                  new SqlParameter("@HowRegularFinancial", obj_ML_EnterprisesTraining.HowRegularFinancial),
                                  new SqlParameter("@SettingBusinessType", obj_ML_EnterprisesTraining.SettingBusinessType),
                                  new SqlParameter("@MonthlyRent", obj_ML_EnterprisesTraining.MonthlyRent),
                                  new SqlParameter("@ExpandBusiness", obj_ML_EnterprisesTraining.ExpandBusiness),
                                  new SqlParameter("@PotentialCustomers", obj_ML_EnterprisesTraining.PotentialCustomers),
                                  new SqlParameter("@BusinessDistance", obj_ML_EnterprisesTraining.BusinessDistance),
                                  new SqlParameter("@ExpectedFootfall", obj_ML_EnterprisesTraining.ExpectedFootfall),
                                  new SqlParameter("@HowFarBussiness", obj_ML_EnterprisesTraining.HowFarBussiness),
                                  new SqlParameter("@PlanningBusiness", obj_ML_EnterprisesTraining.PlanningBusiness),
                                  new SqlParameter("@SupportBusiness", obj_ML_EnterprisesTraining.SupportBusiness),
                                  new SqlParameter("@SupportType", obj_ML_EnterprisesTraining.SupportType),
                                  new SqlParameter("@NotProvidedSupport", obj_ML_EnterprisesTraining.NotProvidedSupport),

                                  new SqlParameter("@PaidWorker", obj_ML_EnterprisesTraining.PaidWorker),
                                  new SqlParameter("@DigitalInclusion", obj_ML_EnterprisesTraining.DigitalInclusion),
                                  new SqlParameter("@DigitalInclusionDate", obj_ML_EnterprisesTraining.DigitalInclusionDate),
                                  new SqlParameter("@OwnSmartPhone", obj_ML_EnterprisesTraining.OwnSmartPhone),
                                  new SqlParameter("@UseSmartPhone", obj_ML_EnterprisesTraining.UseSmartPhone),
                                  new SqlParameter("@SupplyChain", obj_ML_EnterprisesTraining.SupplyChain),

                                  new SqlParameter("@CreatedBy", obj_ML_EnterprisesTraining.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_EnterprisesTraining.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_InsUpdEntTraining", par);
        }
        public ML_EnterprisesTraining GetDetailByEnrollmentId(int enrollmentId)
        {
            ML_EnterprisesTraining obj_ML_EnterprisesTraining = new ML_EnterprisesTraining();
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", enrollmentId) };
            DataSet ds = SqlHelper.ExecuteDataset(con, "USP_GetDetailByEnrollmentId", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                obj_ML_EnterprisesTraining.EntTrainingId = Convert.ToInt32(ds.Tables[0].Rows[0]["EntTrainingId"]);
                obj_ML_EnterprisesTraining.EnrollmentId = Convert.ToInt32(ds.Tables[0].Rows[0]["EnrollmentId"]);
                obj_ML_EnterprisesTraining.StartBusiness = Convert.ToString(ds.Tables[0].Rows[0]["StartBusiness"]);
                obj_ML_EnterprisesTraining.BusinessReasons = Convert.ToString(ds.Tables[0].Rows[0]["BusinessReasons"]);
                obj_ML_EnterprisesTraining.Business = Convert.ToString(ds.Tables[0].Rows[0]["Business"]);
                obj_ML_EnterprisesTraining.BusinessWhen = Convert.ToString(ds.Tables[0].Rows[0]["BusinessWhen"]);
                obj_ML_EnterprisesTraining.StatusBusiness = Convert.ToString(ds.Tables[0].Rows[0]["StatusBusiness"]);
                obj_ML_EnterprisesTraining.VillagePopulation = Convert.ToString(ds.Tables[0].Rows[0]["VillagePopulation"]);
                obj_ML_EnterprisesTraining.BusinessIdea = Convert.ToString(ds.Tables[0].Rows[0]["BusinessIdea"]);
                obj_ML_EnterprisesTraining.BusinessType = Convert.ToString(ds.Tables[0].Rows[0]["BusinessType"]);
                obj_ML_EnterprisesTraining.ProcureBusiness = Convert.ToString(ds.Tables[0].Rows[0]["ProcureBusiness"]);
                obj_ML_EnterprisesTraining.CurrentBusiness = Convert.ToString(ds.Tables[0].Rows[0]["CurrentBusiness"]);
                obj_ML_EnterprisesTraining.RegularFinancialBusiness = Convert.ToString(ds.Tables[0].Rows[0]["RegularFinancialBusiness"]);
                obj_ML_EnterprisesTraining.HowRegularFinancial = Convert.ToString(ds.Tables[0].Rows[0]["HowRegularFinancial"]);
                obj_ML_EnterprisesTraining.SettingBusinessType = Convert.ToString(ds.Tables[0].Rows[0]["SettingBusinessType"]);
                obj_ML_EnterprisesTraining.MonthlyRent = Convert.ToString(ds.Tables[0].Rows[0]["MonthlyRent"]);
                obj_ML_EnterprisesTraining.ExpandBusiness = Convert.ToString(ds.Tables[0].Rows[0]["ExpandBusiness"]);
                obj_ML_EnterprisesTraining.PotentialCustomers = Convert.ToString(ds.Tables[0].Rows[0]["PotentialCustomers"]);
                obj_ML_EnterprisesTraining.BusinessDistance = Convert.ToString(ds.Tables[0].Rows[0]["BusinessDistance"]);
                obj_ML_EnterprisesTraining.ExpectedFootfall = Convert.ToString(ds.Tables[0].Rows[0]["ExpectedFootfall"]);
                obj_ML_EnterprisesTraining.HowFarBussiness = Convert.ToString(ds.Tables[0].Rows[0]["HowFarBussiness"]);
                obj_ML_EnterprisesTraining.PlanningBusiness = Convert.ToString(ds.Tables[0].Rows[0]["PlanningBusiness"]);
                obj_ML_EnterprisesTraining.SupportBusiness = Convert.ToString(ds.Tables[0].Rows[0]["SupportBusiness"]);
                obj_ML_EnterprisesTraining.SupportType = Convert.ToString(ds.Tables[0].Rows[0]["SupportType"]);
                obj_ML_EnterprisesTraining.NotProvidedSupport = Convert.ToString(ds.Tables[0].Rows[0]["NotProvidedSupport"]);
            }
            return obj_ML_EnterprisesTraining;
        }
    }
}
