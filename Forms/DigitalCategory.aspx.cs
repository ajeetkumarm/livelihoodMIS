using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_DigitalCategory : System.Web.UI.Page
{
    ML_DigitalCategory obj_ML_DigitalCategory = new ML_DigitalCategory();
    BL_DigitalCategory obj_BL_DigitalCategory = new BL_DigitalCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           DigitalCategoryDetails();
        }
    }
    private void DigitalCategoryDetails()
    {
        try
        {
            obj_ML_DigitalCategory.Qstring = "Detail";
            obj_ML_DigitalCategory.CategoryId = 0;
            obj_ML_DigitalCategory.Category = "";
            obj_ML_DigitalCategory.CreatedBy = "";
            obj_ML_DigitalCategory.UpdatedBy = "";
            DataTable DT = obj_BL_DigitalCategory.BL_DigitalCategoryDetails(obj_ML_DigitalCategory);
            if (DT.Rows.Count > 0)
            {
                rpt_DigitalCategoryDetails.DataSource = DT;
                rpt_DigitalCategoryDetails.DataBind();
            }
            else
            {
                rpt_DigitalCategoryDetails.DataSource = null;
                rpt_DigitalCategoryDetails.DataBind();
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
                obj_ML_DigitalCategory.Qstring = "Insert";
                obj_ML_DigitalCategory.CategoryId = 0;
                obj_ML_DigitalCategory.Category = txtDigitalCategory.Text != "" ? txtDigitalCategory.Text : "";
                obj_ML_DigitalCategory.CreatedBy = UserCode;
                obj_ML_DigitalCategory.UpdatedBy = "";
                int x = obj_BL_DigitalCategory.BL_InsUpdDelDigitalCategory(obj_ML_DigitalCategory);
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
                obj_ML_DigitalCategory.Qstring = "Update";
                obj_ML_DigitalCategory.CategoryId = Convert.ToInt32(ViewState["CategoryId"]);
                obj_ML_DigitalCategory.Category = txtDigitalCategory.Text != "" ? txtDigitalCategory.Text : "";
                obj_ML_DigitalCategory.CreatedBy = "";
                obj_ML_DigitalCategory.UpdatedBy = UserCode;
                int x = obj_BL_DigitalCategory.BL_InsUpdDelDigitalCategory(obj_ML_DigitalCategory);
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
                int DigiCatId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_DigitalCategory.Qstring = "Detail";
                obj_ML_DigitalCategory.CategoryId = DigiCatId;
                obj_ML_DigitalCategory.Category = "";
                obj_ML_DigitalCategory.CreatedBy = "";
                obj_ML_DigitalCategory.UpdatedBy = "";
                DataTable DT = obj_BL_DigitalCategory.BL_DigitalCategoryDetails(obj_ML_DigitalCategory);
                if (DT.Rows.Count > 0)
                {
                    ViewState["CategoryId"] = DT.Rows[0]["CategoryId"].ToString();
                    txtDigitalCategory.Text = DT.Rows[0]["Category"].ToString();
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
                obj_ML_DigitalCategory.Qstring = "Delete";
                obj_ML_DigitalCategory.CategoryId = UserCatId;
                obj_ML_DigitalCategory.Category = "";
                obj_ML_DigitalCategory.CreatedBy = "";
                obj_ML_DigitalCategory.UpdatedBy = "";
                int x = obj_BL_DigitalCategory.BL_InsUpdDelDigitalCategory(obj_ML_DigitalCategory);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    DigitalCategoryDetails();
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
        DigitalCategoryDetails();
        txtDigitalCategory.Text = "";
        Btn_Submit.Text = "Submit";
    }
}