using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Education : System.Web.UI.Page
{
    ML_Education obj_ML_Education = new ML_Education();
    BL_Education obj_BL_Education = new BL_Education();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EducationDetails();
        }
    }
    private void EducationDetails()
    {
        try
        {
            obj_ML_Education.Qstring = "Detail";
            obj_ML_Education.EducationId = 0;
            obj_ML_Education.EducationName = "";
            obj_ML_Education.CreatedBy = "";
            obj_ML_Education.UpdatedBy = "";
            DataTable DT = obj_BL_Education.BL_EducationDetails(obj_ML_Education);
            if (DT.Rows.Count > 0)
            {
                rpt_EducationDetails.DataSource = DT;
                rpt_EducationDetails.DataBind();
            }
            else
            {
                rpt_EducationDetails.DataSource = null;
                rpt_EducationDetails.DataBind();
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
                obj_ML_Education.Qstring = "Insert";
                obj_ML_Education.EducationId = 0;
                obj_ML_Education.EducationName = txtEducation.Text != "" ? txtEducation.Text : "";
                obj_ML_Education.CreatedBy = UserCode;
                obj_ML_Education.UpdatedBy = "";
                int x = obj_BL_Education.BL_InsUpdDelEducation(obj_ML_Education);
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
                obj_ML_Education.Qstring = "Update";
                obj_ML_Education.EducationId = Convert.ToInt32(ViewState["EducationId"]);
                obj_ML_Education.EducationName = txtEducation.Text != "" ? txtEducation.Text : "";
                obj_ML_Education.CreatedBy = "";
                obj_ML_Education.UpdatedBy = UserCode;
                int x = obj_BL_Education.BL_InsUpdDelEducation(obj_ML_Education);
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
                int EducationId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Education.Qstring = "Detail";
                obj_ML_Education.EducationId = EducationId;
                obj_ML_Education.EducationName = "";
                obj_ML_Education.CreatedBy = "";
                obj_ML_Education.UpdatedBy = "";
                DataTable DT = obj_BL_Education.BL_EducationDetails(obj_ML_Education);
                if (DT.Rows.Count > 0)
                {
                    ViewState["EducationId"] = DT.Rows[0]["EducationId"].ToString();
                    txtEducation.Text = DT.Rows[0]["EducationName"].ToString();
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
                int EducationId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Education.Qstring = "Delete";
                obj_ML_Education.EducationId = EducationId;
                obj_ML_Education.EducationName = "";
                obj_ML_Education.CreatedBy = "";
                obj_ML_Education.UpdatedBy = "";
                int x = obj_BL_Education.BL_InsUpdDelEducation(obj_ML_Education);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    EducationDetails();
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
        EducationDetails();
        txtEducation.Text = "";
        Btn_Submit.Text = "Submit";
    }
}