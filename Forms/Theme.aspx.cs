using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Forms_Theme : System.Web.UI.Page
{
    ML_Theme obj_ML_Theme = new ML_Theme();
    BL_Theme obj_BL_Theme = new BL_Theme();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ThemeDetails();
        }
    }
    private void ThemeDetails()
    {
        try
        {
            obj_ML_Theme.Qstring = "Detail";
            obj_ML_Theme.ThemeId = 0;
            obj_ML_Theme.ThemeName = "";
            obj_ML_Theme.ThemeShortName = "";
            obj_ML_Theme.CreatedBy = "";
            obj_ML_Theme.UpdatedBy = "";
            DataTable DT = obj_BL_Theme.BL_ThemeDetails(obj_ML_Theme);
            if (DT.Rows.Count > 0)
            {
                rpt_ThemeDetails.DataSource = DT;
                rpt_ThemeDetails.DataBind();
            }
            else
            {
                rpt_ThemeDetails.DataSource = null;
                rpt_ThemeDetails.DataBind();
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
                obj_ML_Theme.Qstring = "Insert";
                obj_ML_Theme.ThemeId = 0;
                obj_ML_Theme.ThemeName = txtThemeName.Text != "" ? txtThemeName.Text : "";
                obj_ML_Theme.ThemeShortName = txtThemeSrtName.Text != "" ? txtThemeSrtName.Text : "";
                obj_ML_Theme.CreatedBy = UserCode;
                obj_ML_Theme.UpdatedBy = "";
                int x = obj_BL_Theme.BL_InsUpdDelTheme(obj_ML_Theme);
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
                obj_ML_Theme.Qstring = "Update";
                obj_ML_Theme.ThemeId = Convert.ToInt32(ViewState["ThemeId"]);
                obj_ML_Theme.ThemeName = txtThemeName.Text != "" ? txtThemeName.Text : "";
                obj_ML_Theme.ThemeShortName = txtThemeSrtName.Text != "" ? txtThemeSrtName.Text : "";
                obj_ML_Theme.CreatedBy = "";
                obj_ML_Theme.UpdatedBy = UserCode;
                int x = obj_BL_Theme.BL_InsUpdDelTheme(obj_ML_Theme);
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
                int ThemeId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Theme.Qstring = "Detail";
                obj_ML_Theme.ThemeId = ThemeId;
                obj_ML_Theme.ThemeName = "";
                obj_ML_Theme.ThemeShortName = "";
                obj_ML_Theme.CreatedBy = "";
                obj_ML_Theme.UpdatedBy = "";
                DataTable DT = obj_BL_Theme.BL_ThemeDetails(obj_ML_Theme);
                if (DT.Rows.Count > 0)
                {
                    ViewState["ThemeId"] = DT.Rows[0]["ThemeId"].ToString();
                    txtThemeName.Text = DT.Rows[0]["ThemeName"].ToString();
                    txtThemeSrtName.Text = DT.Rows[0]["ThemeShortName"].ToString();
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
                int ThemeId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Theme.Qstring = "Delete";
                obj_ML_Theme.ThemeId = ThemeId;
                obj_ML_Theme.ThemeName = "";
                obj_ML_Theme.ThemeShortName = "";
                obj_ML_Theme.CreatedBy = "";
                obj_ML_Theme.UpdatedBy = "";
                int x = obj_BL_Theme.BL_InsUpdDelTheme(obj_ML_Theme);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    ThemeDetails();
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
        ThemeDetails();
        txtThemeName.Text = "";
        txtThemeSrtName.Text = "";
        Btn_Submit.Text = "Submit";
    }
}
