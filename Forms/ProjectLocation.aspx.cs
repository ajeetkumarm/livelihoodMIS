using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_ProjectLocation : System.Web.UI.Page
{
    ML_ProjectLocation obj_ML_ProjectLocation = new ML_ProjectLocation();
    BL_ProjectLocation obj_BL_ProjectLocation = new BL_ProjectLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProjectDetails();
        }
    }
    private void ProjectDetails()
    {
        try
        {
            obj_ML_ProjectLocation.Qstring = "Detail";
            obj_ML_ProjectLocation.ProjectId = 0;
            obj_ML_ProjectLocation.ProjectName = "";
            obj_ML_ProjectLocation.CreatedBy = "";
            obj_ML_ProjectLocation.UpdatedBy = "";
            DataTable DT = obj_BL_ProjectLocation.BL_ProjectLoctionDetails(obj_ML_ProjectLocation);
            if (DT.Rows.Count > 0)
            {
                rpt_ProjectLocationDetails.DataSource = DT;
                rpt_ProjectLocationDetails.DataBind();
            }
            else
            {
                rpt_ProjectLocationDetails.DataSource = null;
                rpt_ProjectLocationDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
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
                obj_ML_ProjectLocation.Qstring = "Insert";
                obj_ML_ProjectLocation.ProjectId = 0;
                obj_ML_ProjectLocation.ProjectName = txtProjectLocation.Text != "" ? txtProjectLocation.Text : "";
                obj_ML_ProjectLocation.CreatedBy = UserCode;
                obj_ML_ProjectLocation.UpdatedBy = "";
                int x = obj_BL_ProjectLocation.BL_InsUpdDelProjectLoction(obj_ML_ProjectLocation);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submited Successfully !');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            else
            {
                obj_ML_ProjectLocation.Qstring = "Update";
                obj_ML_ProjectLocation.ProjectId = Convert.ToInt32(ViewState["ProjectId"]);
                obj_ML_ProjectLocation.ProjectName = txtProjectLocation.Text != "" ? txtProjectLocation.Text : "";
                obj_ML_ProjectLocation.CreatedBy = UserCode;
                obj_ML_ProjectLocation.UpdatedBy = "";
                int x = obj_BL_ProjectLocation.BL_InsUpdDelProjectLoction(obj_ML_ProjectLocation);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            btn_Cancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int ProjectId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_ProjectLocation.Qstring = "Detail";
                obj_ML_ProjectLocation.ProjectId = ProjectId;
                obj_ML_ProjectLocation.ProjectName = "";
                obj_ML_ProjectLocation.CreatedBy = "";
                obj_ML_ProjectLocation.UpdatedBy = "";
                DataTable DT = obj_BL_ProjectLocation.BL_ProjectLoctionDetails(obj_ML_ProjectLocation);
                if (DT.Rows.Count > 0)
                {
                    ViewState["ProjectId"] = DT.Rows[0]["ProjectId"].ToString();
                    txtProjectLocation.Text = DT.Rows[0]["ProjectName"].ToString();
                    Btn_Submit.Text = "Update";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('System error !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int ProjectId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_ProjectLocation.Qstring = "Delete";
                obj_ML_ProjectLocation.ProjectId = ProjectId;
                obj_ML_ProjectLocation.ProjectName = "";
                obj_ML_ProjectLocation.CreatedBy = "";
                obj_ML_ProjectLocation.UpdatedBy = "";
                int x = obj_BL_ProjectLocation.BL_InsUpdDelProjectLoction(obj_ML_ProjectLocation);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    ProjectDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('System error !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        ProjectDetails();
        txtProjectLocation.Text = "";
        Btn_Submit.Text = "Submit";
    }
}