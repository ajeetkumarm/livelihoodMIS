using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_UserCategory : System.Web.UI.Page
{
    ML_UserCategory obj_ML_UserCategory = new ML_UserCategory();
    BL_UserCategory obj_BL_UserCategory = new BL_UserCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserCategoryDetails();
        }
    }
    private void UserCategoryDetails()
    {
        try
        {
            obj_ML_UserCategory.Qstring = "Detail";
            obj_ML_UserCategory.CategoryId = 0;
            obj_ML_UserCategory.Category = "";
            obj_ML_UserCategory.CreatedBy = "";
            obj_ML_UserCategory.UpdatedBy = "";
            DataTable DT = obj_BL_UserCategory.BL_UserCategoryDetails(obj_ML_UserCategory);
            if (DT.Rows.Count > 0)
            {
                rpt_UserCategoryDetails.DataSource = DT;
                rpt_UserCategoryDetails.DataBind();
            }
            else
            {
                rpt_UserCategoryDetails.DataSource = null;
                rpt_UserCategoryDetails.DataBind();
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
                obj_ML_UserCategory.Qstring = "Insert";
                obj_ML_UserCategory.CategoryId = 0;
                obj_ML_UserCategory.Category = txtUserCategory.Text != "" ? txtUserCategory.Text : "";
                obj_ML_UserCategory.CreatedBy = UserCode;
                obj_ML_UserCategory.UpdatedBy = "";
                int x = obj_BL_UserCategory.BL_InsUpdDelUserCategory(obj_ML_UserCategory);
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
                obj_ML_UserCategory.Qstring = "Update";
                obj_ML_UserCategory.CategoryId = Convert.ToInt32(ViewState["CategoryId"]);
                obj_ML_UserCategory.Category = txtUserCategory.Text != "" ? txtUserCategory.Text : "";
                obj_ML_UserCategory.CreatedBy = "";
                obj_ML_UserCategory.UpdatedBy = UserCode;
                int x = obj_BL_UserCategory.BL_InsUpdDelUserCategory(obj_ML_UserCategory);
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
                int UserCatId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_UserCategory.Qstring = "Detail";
                obj_ML_UserCategory.CategoryId = UserCatId;
                obj_ML_UserCategory.Category = "";
                obj_ML_UserCategory.CreatedBy = "";
                obj_ML_UserCategory.UpdatedBy = "";
                DataTable DT = obj_BL_UserCategory.BL_UserCategoryDetails(obj_ML_UserCategory);
                if (DT.Rows.Count > 0)
                {
                    ViewState["CategoryId"] = DT.Rows[0]["CategoryId"].ToString();
                    txtUserCategory.Text = DT.Rows[0]["Category"].ToString();
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
                int UserCatId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_UserCategory.Qstring = "Delete";
                obj_ML_UserCategory.CategoryId = UserCatId;
                obj_ML_UserCategory.Category = "";
                obj_ML_UserCategory.CreatedBy = "";
                obj_ML_UserCategory.UpdatedBy = "";
                int x = obj_BL_UserCategory.BL_InsUpdDelUserCategory(obj_ML_UserCategory);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    UserCategoryDetails();
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
        UserCategoryDetails();
        txtUserCategory.Text = "";
        Btn_Submit.Text = "Submit";
    }
}