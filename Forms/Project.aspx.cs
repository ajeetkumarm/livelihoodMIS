using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Project : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_Project obj_ML_Project = new ML_Project();
    BL_Project obj_BL_Project = new BL_Project();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchPartner();
            ProjectDetails();
        }
    }
    private void FetchPartner()
    {
        try
        {
            obj_ML_Masters.QueryType = "Partner";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlPartner.DataSource = DT;
                ddlPartner.DataValueField = "PartnerId";
                ddlPartner.DataTextField = "PartnerName";
                ddlPartner.DataBind();
                ddlPartner.Items.Insert(0, "--Select Partner--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void ProjectDetails()
    {
        try
        {
            obj_ML_Project.Qstring = "Detail";
            obj_ML_Project.ProjectId = 0;
            obj_ML_Project.PartnerId = 0;
            obj_ML_Project.ProjectName = "";
            obj_ML_Project.CreatedBy = "";
            obj_ML_Project.UpdatedBy = "";
            DataTable DT = obj_BL_Project.BL_ProjectDetails(obj_ML_Project);
            if (DT.Rows.Count > 0)
            {
                rpt_ProjectDetails.DataSource = DT;
                rpt_ProjectDetails.DataBind();
            }
            else
            {
                rpt_ProjectDetails.DataSource = null;
                rpt_ProjectDetails.DataBind();
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
                obj_ML_Project.Qstring = "Insert";
                obj_ML_Project.ProjectId = 0;
                obj_ML_Project.PartnerId = Convert.ToInt32(ddlPartner.SelectedValue);
                obj_ML_Project.ProjectName = txtProject.Text != "" ? txtProject.Text : "";
                obj_ML_Project.CreatedBy = UserCode;
                obj_ML_Project.UpdatedBy = "";
                int x = obj_BL_Project.BL_InsUpdDelProject(obj_ML_Project);
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
                obj_ML_Project.Qstring = "Update";
                obj_ML_Project.ProjectId = Convert.ToInt32(ViewState["ProjectId"]);
                obj_ML_Project.PartnerId = Convert.ToInt32(ddlPartner.SelectedValue);
                obj_ML_Project.ProjectName = txtProject.Text != "" ? txtProject.Text : "";
                obj_ML_Project.CreatedBy = "";
                obj_ML_Project.UpdatedBy = UserCode;
                int x = obj_BL_Project.BL_InsUpdDelProject(obj_ML_Project);
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
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        FetchPartner();
        ProjectDetails();
        ddlPartner.SelectedIndex = 0;
        txtProject.Text = "";
        Btn_Submit.Text = "Submit";
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int ProjectId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Project.Qstring = "Detail";
                obj_ML_Project.ProjectId = ProjectId;
                obj_ML_Project.PartnerId = 0;
                obj_ML_Project.ProjectName = "";
                obj_ML_Project.CreatedBy = "";
                obj_ML_Project.UpdatedBy = "";
                DataTable DT = obj_BL_Project.BL_ProjectDetails(obj_ML_Project);
                if (DT.Rows.Count > 0)
                {
                    //FetchPartner(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()));
                    ddlPartner.SelectedValue = DT.Rows[0]["PartnerId"].ToString();
                    ViewState["ProjectId"] = DT.Rows[0]["ProjectId"].ToString();
                    txtProject.Text = DT.Rows[0]["ProjectName"].ToString();
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
                obj_ML_Project.Qstring = "Delete";
                obj_ML_Project.ProjectId = ProjectId;
                obj_ML_Project.PartnerId = 0;
                obj_ML_Project.ProjectName = "";
                obj_ML_Project.CreatedBy = "";
                obj_ML_Project.UpdatedBy = "";
                int x = obj_BL_Project.BL_InsUpdDelProject(obj_ML_Project);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    btn_Cancel_Click(sender, e);
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
}