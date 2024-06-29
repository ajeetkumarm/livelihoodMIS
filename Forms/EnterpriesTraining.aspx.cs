using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_EnterpriesTraining : System.Web.UI.Page
{
    ML_EnterprisesTraining obj_ML_EnterprisesTraining = new ML_EnterprisesTraining();
    BL_EnterprisesTraining obj_BL_EnterprisesTraining = new BL_EnterprisesTraining();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void rblStartBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblStartBusiness.SelectedValue=="Yes")
        {
            pnl_Lst.Visible = true;
            div_Ressons.Visible = false;
            ddlNoReasons.SelectedValue = "0";
        }
        else
        {
            pnl_Lst.Visible = false;
            div_Ressons.Visible = true;
            ddlBusinessType.SelectedValue = "0";
            div_Other.Visible = false;
            txtOther.Text = "";
        }
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            string UserCode = DT.Rows[0]["UserCode"].ToString();
            if (Btn_Submit.Text == "Submit")
            {
                obj_ML_EnterprisesTraining.EntTrainingId = 0;
                obj_ML_EnterprisesTraining.EnrollmentId = Convert.ToInt32(Request.QueryString["EnrolId"]);
                obj_ML_EnterprisesTraining.StartBusiness = rblStartBusiness.SelectedValue;
                // obj_ML_EnterprisesTraining.ImprovedBusiness = rblStartedImprovedBusiness.SelectedValue;
                // obj_ML_EnterprisesTraining.BusinessDetails = rblStartedImprovedDetails.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessType = ddlBusinessType.SelectedIndex > 0 ? ddlBusinessType.SelectedValue : "";
                // obj_ML_EnterprisesTraining.OtherBusiness = txtOther.Text != "" ? txtOther.Text : "";
                // obj_ML_EnterprisesTraining.AdvSupportBusiness = rblAdvSupportBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessReasons = ddlNoReasons.SelectedIndex > 0 ? ddlNoReasons.SelectedValue : "";
                obj_ML_EnterprisesTraining.CreatedBy = UserCode;
                obj_ML_EnterprisesTraining.UpdatedBy = "";
                int x = obj_BL_EnterprisesTraining.BL_InsUpdEntTraining(obj_ML_EnterprisesTraining);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submit Successfully !');", true);
                    Response.Redirect("~/Forms/EnterpriesSetup.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            //else
            //{
            //    obj_ML_Training.TrainingId = Convert.ToInt32(ViewState["TrainingId"].ToString());
            //    obj_ML_Training.IsLifeSkillsTraining = rblIsLifeSkills.SelectedValue;
            //    obj_ML_Training.RCSCDate = txtRCSCDate.Text != "" ? txtRCSCDate.Text : "";
            //    obj_ML_Training.WRPCDate = txtWRPCDate.Text != "" ? txtWRPCDate.Text : "";
            //    obj_ML_Training.HNCDate = txtHNCDate.Text != "" ? txtHNCDate.Text : "";
            //    obj_ML_Training.FLCDate = txtFLCDAte.Text != "" ? txtFLCDAte.Text : "";
            //    obj_ML_Training.EDTSDate = txtEDTSDate.Text != "" ? txtEDTSDate.Text : "";
            //    obj_ML_Training.LEAPDate = txtLEAPDate.Text != "" ? txtLEAPDate.Text : "";
            //    obj_ML_Training.ESISDate = txtESISTDate.Text != "" ? txtESISTDate.Text : "";
            //    obj_ML_Training.BMTCDate = txtBMTCDate.Text != "" ? txtBMTCDate.Text : "";
            //    obj_ML_Training.MMTCDate = txtMMTCDate.Text != "" ? txtMMTCDate.Text : "";
            //    obj_ML_Training.EDPTCDate = txtEDPTCDate.Text != "" ? txtEDPTCDate.Text : "";
            //    obj_ML_Training.UpdatedBy = UserCode;
            //    int x = obj_BL_Training.BL_InsUpdTraining(obj_ML_Training);
            //    if (x > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Updated Successfully !');", true);

            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
            //    }
            //}
            Btn_Cancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        rblStartBusiness.ClearSelection();
        rblStartedImprovedDetails.ClearSelection();
        ddlBusinessType.SelectedIndex = 0;
        txtOther.Text = "";
        rblAdvSupportBusiness.ClearSelection();
        ddlNoReasons.SelectedIndex = 0;
    }

    protected void ddlBusinessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBusinessType.SelectedValue== "Other")
        {
            div_Other.Visible = true;
        }
        else
        {
            div_Other.Visible = false;
        }
    }
}