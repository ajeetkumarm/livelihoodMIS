using System;
using System.Web.UI;
using System.Data;
using BusinessLayer;
using ModelLayer;
using System.Activities.Expressions;

public partial class Forms_Training : System.Web.UI.Page
{
    BL_Training obj_BL_Training = new BL_Training();
    ML_Training obj_ML_Training = new ML_Training();
    int projectId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get session value
            if (Session["UserDetails"] != null)
            {
                DataTable DT = Session["UserDetails"] as DataTable;
                projectId = TypeConversionUtility.ToInteger(DT.Rows[0]["ProjectCode"]);
                divDigitalSkillTraining.Visible = false;
                divInductionTraining.Visible = false;
                if (projectId == 5)
                {
                    divDigitalSkillTraining.Visible = true;
                    divInductionTraining.Visible = true;
                }
            }

            FetchTrainingDetails();
            divEdpDetails.Visible = false;
            if (projectId == 5)
            {
                divEdt.Visible = false;
                divEdpDetails.Visible = true;
            }
        }
    }

    private void FetchTrainingDetails()
    {
        try
        {
            obj_ML_Training.EnrollmentId = Convert.ToInt32(Request.QueryString["EnrolId"]);
            DataTable DT = obj_BL_Training.BL_FieldTraining(obj_ML_Training);
            if (DT.Rows.Count > 0)
            {
                ViewState["TrainingId"]= DT.Rows[0]["TrainingId"].ToString();
                rblIsLifeSkills.SelectedValue = DT.Rows[0]["IsLifeSkillsTraining"].ToString();
                txtRCSCDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["RCSCDate"]);
                txtWRPCDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["WRPCDate"]);
                txtHNCDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["HNCDate"]);
                txtFLCDAte.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["FLCDate"]);
                txtEDTSDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["EDTSDate"]);
                txtLEAPDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["LEAPDate"]);
                txtESISTDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["ESISDate"]);
                txtBMTCDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["BMTCDate"]);
                txtMMTCDate.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["MMTCDate"]);
                txtEDPTCDate.Text = TypeConversionUtility.ToStringWithNull  (DT.Rows[0]["EDPTCDate"]);
                txtInductionTraingDay1.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["InductionTrainingDay1"]);
                txtInductionTraingDay2.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["InductionTrainingDay2"]);
                txtDigitalSkillTrainingDay1.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["DigitalSkillTrainingDay1"]);
                txtDigitalSkillTrainingDay2.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["DigitalSkillTrainingDay2"]);
                txtDigitalSkillTrainingDay3.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["DigitalSkillTrainingDay3"]);
                txtEDPIntroDay1.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["EDPIntroDay1"]);
                txtBusinessPlanDay2.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["BusinessPlanDay2"]);
                txtFinancialLiteracyDay3.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["FinancialLiteracyDay3"]);
                txtFinancialTermsDay4.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["FinancialTermsDay4"]);
                txtBusinessManagementDay5.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["BusinessManagementDay5"]);
                // Check null value
                if (TypeConversionUtility.ToStringWithNull(DT.Rows[0]["IsInductionTraining"]) == "") 
                {
                    rblIsInductionTraining.SelectedValue = "No";
                }
                else
                {
                    rblIsInductionTraining.SelectedValue = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["IsInductionTraining"]);
                }
                if (TypeConversionUtility.ToStringWithNull(DT.Rows[0]["IsDigitalSkillTraining"]) == "")
                {
                    rblIsDigitalSkillTraining.SelectedValue = "No";
                }
                else
                {
                    rblIsDigitalSkillTraining.SelectedValue = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["IsDigitalSkillTraining"]);
                }
                
                Btn_Submit.Text = "Update";
                if (rblIsLifeSkills.SelectedValue == "Yes")
                {
                   divLst.Visible = true;
                   divEdt.Visible = true;
                }
                else
                {
                    divLst.Visible = false;
                    divEdt.Visible = true;
                }
                rblIsLifeSkills.Enabled = false;
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
            //}
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            string UserCode = DT.Rows[0]["UserCode"].ToString();


            obj_ML_Training.InductionTrainingDay1 = txtInductionTraingDay1.Text != "" ? txtInductionTraingDay1.Text : "";
            obj_ML_Training.InductionTrainingDay2 = txtInductionTraingDay2.Text != "" ? txtInductionTraingDay2.Text : "";
            obj_ML_Training.DigitalSkillTrainingDay1 = txtDigitalSkillTrainingDay1.Text != "" ? txtDigitalSkillTrainingDay1.Text : "";
            obj_ML_Training.DigitalSkillTrainingDay2 = txtDigitalSkillTrainingDay2.Text != "" ? txtDigitalSkillTrainingDay2.Text : "";
            obj_ML_Training.DigitalSkillTrainingDay3 = txtDigitalSkillTrainingDay3.Text != "" ? txtDigitalSkillTrainingDay3.Text : "";
            obj_ML_Training.IsInductionTraining = rblIsInductionTraining.SelectedValue;
            obj_ML_Training.IsDigitalSkillTraining = rblIsDigitalSkillTraining.SelectedValue;
            obj_ML_Training.EDPIntroDay1 = txtEDPIntroDay1.Text != "" ? txtEDPIntroDay1.Text : "";
            obj_ML_Training.BusinessPlanDay2 = txtBusinessPlanDay2.Text != "" ? txtBusinessPlanDay2.Text : "";
            obj_ML_Training.FinancialLiteracyDay3 = txtFinancialLiteracyDay3.Text != "" ? txtFinancialLiteracyDay3.Text : "";
            obj_ML_Training.FinancialTermsDay4 = txtFinancialTermsDay4.Text != "" ? txtFinancialTermsDay4.Text : "";
            obj_ML_Training.BusinessManagementDay5 = txtBusinessManagementDay5.Text != "" ? txtBusinessManagementDay5.Text : "";

            if (Btn_Submit.Text == "Submit")
            {
                obj_ML_Training.EnrollmentId = Convert.ToInt32(Request.QueryString["EnrolId"]);
                obj_ML_Training.IsLifeSkillsTraining = rblIsLifeSkills.SelectedValue;
                obj_ML_Training.RCSCDate = txtRCSCDate.Text != "" ? txtRCSCDate.Text : "";
                obj_ML_Training.WRPCDate = txtWRPCDate.Text != "" ? txtWRPCDate.Text : "";
                obj_ML_Training.HNCDate = txtHNCDate.Text != "" ? txtHNCDate.Text : "";
                obj_ML_Training.FLCDate = txtFLCDAte.Text != "" ? txtFLCDAte.Text : "";
                obj_ML_Training.EDTSDate = txtEDTSDate.Text != "" ? txtEDTSDate.Text : "";
                obj_ML_Training.LEAPDate = txtLEAPDate.Text != "" ? txtLEAPDate.Text : "";
                obj_ML_Training.ESISDate = txtESISTDate.Text != "" ? txtESISTDate.Text : "";
                obj_ML_Training.BMTCDate = txtBMTCDate.Text != "" ? txtBMTCDate.Text : "";
                obj_ML_Training.MMTCDate = txtMMTCDate.Text != "" ? txtMMTCDate.Text : "";
                obj_ML_Training.EDPTCDate = txtEDPTCDate.Text != "" ? txtEDPTCDate.Text : "";
                obj_ML_Training.CreatedBy = UserCode;



                int x = obj_BL_Training.BL_InsUpdTraining(obj_ML_Training);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submit Successfully !');", true);
                    FetchTrainingDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            else
            {
                obj_ML_Training.TrainingId = Convert.ToInt32(ViewState["TrainingId"].ToString());
                obj_ML_Training.IsLifeSkillsTraining = rblIsLifeSkills.SelectedValue;
                obj_ML_Training.RCSCDate = txtRCSCDate.Text != "" ? txtRCSCDate.Text : "";
                obj_ML_Training.WRPCDate = txtWRPCDate.Text != "" ? txtWRPCDate.Text : "";
                obj_ML_Training.HNCDate = txtHNCDate.Text != "" ? txtHNCDate.Text : "";
                obj_ML_Training.FLCDate = txtFLCDAte.Text != "" ? txtFLCDAte.Text : "";
                obj_ML_Training.EDTSDate = txtEDTSDate.Text != "" ? txtEDTSDate.Text : "";
                obj_ML_Training.LEAPDate = txtLEAPDate.Text != "" ? txtLEAPDate.Text : "";
                obj_ML_Training.ESISDate = txtESISTDate.Text != "" ? txtESISTDate.Text : "";
                obj_ML_Training.BMTCDate = txtBMTCDate.Text != "" ? txtBMTCDate.Text : "";
                obj_ML_Training.MMTCDate = txtMMTCDate.Text != "" ? txtMMTCDate.Text : "";
                obj_ML_Training.EDPTCDate = txtEDPTCDate.Text != "" ? txtEDPTCDate.Text : "";
                obj_ML_Training.UpdatedBy = UserCode;
                int x = obj_BL_Training.BL_InsUpdTraining(obj_ML_Training);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Updated Successfully !');", true);
                    FetchTrainingDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {

    }

    protected void rblIsLifeSkills_SelectedIndexChanged(object sender, EventArgs e)
    {
        divEdpDetails.Visible = false;
        if (rblIsLifeSkills.SelectedValue=="Yes")
        {
            divLst.Visible = true;
            divEdt.Visible = true;
            divInductionTraining.Visible = true;
            divDigitalSkillTraining.Visible = true;
        }
        else
        {
           divLst.Visible = false;
           divEdt.Visible = true;
           divInductionTraining.Visible = false;
           divDigitalSkillTraining.Visible = false;
        }

        if (projectId == 5)
        {
            divEdt.Visible = false;
            divEdpDetails.Visible = true;
        }
    }
    protected void rblIsDigitalSkillTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblIsDigitalSkillTraining.SelectedValue == "Yes")
        {
            divDigitalSkillTrainingDay.Visible = true;
        }
        else
        {
            divDigitalSkillTrainingDay.Visible = false;
            txtDigitalSkillTrainingDay1.Text = "";
            txtDigitalSkillTrainingDay2.Text = "";
            txtDigitalSkillTrainingDay3.Text = "";
        }
    }
    protected void rblIsInductionTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblIsInductionTraining.SelectedValue == "Yes")
        {
            divInductionTrainingDay.Visible = true;
        }
        else
        {
            divInductionTrainingDay.Visible = false;
            txtInductionTraingDay1.Text = "";
            txtInductionTraingDay2.Text = "";
        }
    }
}