using System;
using System.Web.UI;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Training : System.Web.UI.Page
{
    BL_Training obj_BL_Training = new BL_Training();
    ML_Training obj_ML_Training = new ML_Training();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchTrainingDetails();
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
                txtRCSCDate.Text = DT.Rows[0]["RCSCDate"].ToString();
                txtWRPCDate.Text = DT.Rows[0]["WRPCDate"].ToString();
                txtHNCDate.Text = DT.Rows[0]["HNCDate"].ToString();
                txtFLCDAte.Text = DT.Rows[0]["FLCDate"].ToString();
                txtEDTSDate.Text = DT.Rows[0]["EDTSDate"].ToString();
                txtLEAPDate.Text = DT.Rows[0]["LEAPDate"].ToString();
                txtESISTDate.Text = DT.Rows[0]["ESISDate"].ToString();
                txtBMTCDate.Text = DT.Rows[0]["BMTCDate"].ToString();
                txtMMTCDate.Text = DT.Rows[0]["MMTCDate"].ToString();
                txtEDPTCDate.Text = DT.Rows[0]["EDPTCDate"].ToString();
                txtInductionTraingDay1.Text = DT.Rows[0]["InductionTrainingDay1"].ToString();
                txtInductionTraingDay2.Text = DT.Rows[0]["InductionTrainingDay2"].ToString();
                txtDigitalSkillTrainingDay1.Text = DT.Rows[0]["DigitalSkillTrainingDay1"].ToString();
                txtDigitalSkillTrainingDay2.Text = DT.Rows[0]["DigitalSkillTrainingDay2"].ToString();
                txtDigitalSkillTrainingDay3.Text = DT.Rows[0]["DigitalSkillTrainingDay3"].ToString();
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
        if (rblIsLifeSkills.SelectedValue=="Yes")
        {
            divLst.Visible = true;
            divEdt.Visible = true;
        }
        else
        {
           divLst.Visible = false;
           divEdt.Visible = true;
        }
    }
}