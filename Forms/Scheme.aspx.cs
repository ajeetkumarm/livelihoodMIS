using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Scheme : System.Web.UI.Page
{
    ML_Scheme obj_ML_Scheme = new ML_Scheme();
    BL_Scheme obj_BL_Scheme = new BL_Scheme();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SchemeDetails();
        }
    }
    private void SchemeDetails()
    {
        try
        {
            obj_ML_Scheme.Qstring = "Detail";
            obj_ML_Scheme.SchemeId = 0;
            obj_ML_Scheme.SchemeName = "";
            obj_ML_Scheme.CreatedBy = "";
            obj_ML_Scheme.UpdatedBy = "";
            DataTable DT = obj_BL_Scheme.BL_SchemeDetails(obj_ML_Scheme);
            if (DT.Rows.Count > 0)
            {
                rpt_SchemeDetails.DataSource = DT;
                rpt_SchemeDetails.DataBind();
            }
            else
            {
                rpt_SchemeDetails.DataSource = null;
                rpt_SchemeDetails.DataBind();
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
                obj_ML_Scheme.Qstring = "Insert";
                obj_ML_Scheme.SchemeId = 0;
                obj_ML_Scheme.SchemeName = txtScheme.Text != "" ? txtScheme.Text : "";
                obj_ML_Scheme.CreatedBy = UserCode;
                obj_ML_Scheme.UpdatedBy = "";
                int x = obj_BL_Scheme.BL_InsUpdDelScheme(obj_ML_Scheme);
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
                obj_ML_Scheme.Qstring = "Update";
                obj_ML_Scheme.SchemeId = Convert.ToInt32(ViewState["SchemeId"]);
                obj_ML_Scheme.SchemeName = txtScheme.Text != "" ? txtScheme.Text : "";
                obj_ML_Scheme.CreatedBy = "";
                obj_ML_Scheme.UpdatedBy = UserCode;
                int x = obj_BL_Scheme.BL_InsUpdDelScheme(obj_ML_Scheme);
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
                int SchemeId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Scheme.Qstring = "Detail";
                obj_ML_Scheme.SchemeId = SchemeId;
                obj_ML_Scheme.SchemeName = "";
                obj_ML_Scheme.CreatedBy = "";
                obj_ML_Scheme.UpdatedBy = "";
                DataTable DT = obj_BL_Scheme.BL_SchemeDetails(obj_ML_Scheme);
                if (DT.Rows.Count > 0)
                {
                    ViewState["SchemeId"] = DT.Rows[0]["SchemeId"].ToString();
                    txtScheme.Text = DT.Rows[0]["SchemeName"].ToString();
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
                int SchemeId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Scheme.Qstring = "Delete";
                obj_ML_Scheme.SchemeId = SchemeId;
                obj_ML_Scheme.SchemeName = "";
                obj_ML_Scheme.CreatedBy = "";
                obj_ML_Scheme.UpdatedBy = "";
                int x = obj_BL_Scheme.BL_InsUpdDelScheme(obj_ML_Scheme);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    SchemeDetails();
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
        SchemeDetails();
        txtScheme.Text = "";
        Btn_Submit.Text = "Submit";
    }
}