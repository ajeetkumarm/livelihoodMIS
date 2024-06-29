using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_EconomicStatus : System.Web.UI.Page
{
    ML_Economic obj_ML_Economic = new ML_Economic();
    BL_Economic obj_BL_Economic = new BL_Economic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EconomicStatusDetails();
        }
    }
    private void EconomicStatusDetails()
    {
        try
        {
            obj_ML_Economic.Qstring = "Detail";
            obj_ML_Economic.EconomicId = 0;
            obj_ML_Economic.EconomicStatus = "";
            obj_ML_Economic.CreatedBy = "";
            obj_ML_Economic.UpdatedBy = "";
            DataTable DT = obj_BL_Economic.BL_EconomicStatusDetails(obj_ML_Economic);
            if (DT.Rows.Count > 0)
            {
                rpt_EconomicStatusDetails.DataSource = DT;
                rpt_EconomicStatusDetails.DataBind();
            }
            else
            {
                rpt_EconomicStatusDetails.DataSource = null;
                rpt_EconomicStatusDetails.DataBind();
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
                obj_ML_Economic.Qstring = "Insert";
                obj_ML_Economic.EconomicId = 0;
                obj_ML_Economic.EconomicStatus = txtEconomicStatus.Text != "" ? txtEconomicStatus.Text : "";
                obj_ML_Economic.CreatedBy = UserCode;
                obj_ML_Economic.UpdatedBy = "";
                int x = obj_BL_Economic.BL_InsUpdDelEconomicStatus(obj_ML_Economic);
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
                obj_ML_Economic.Qstring = "Update";
                obj_ML_Economic.EconomicId = Convert.ToInt32(ViewState["EconomicId"]);
                obj_ML_Economic.EconomicStatus = txtEconomicStatus.Text != "" ? txtEconomicStatus.Text : "";
                obj_ML_Economic.CreatedBy = "";
                obj_ML_Economic.UpdatedBy = UserCode;
                int x = obj_BL_Economic.BL_InsUpdDelEconomicStatus(obj_ML_Economic);
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
                int EcoStatusId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Economic.Qstring = "Detail";
                obj_ML_Economic.EconomicId = EcoStatusId;
                obj_ML_Economic.EconomicStatus = "";
                obj_ML_Economic.CreatedBy = "";
                obj_ML_Economic.UpdatedBy = "";
                DataTable DT = obj_BL_Economic.BL_EconomicStatusDetails(obj_ML_Economic);
                if (DT.Rows.Count > 0)
                {
                    ViewState["EconomicId"] = DT.Rows[0]["EconomicId"].ToString();
                    txtEconomicStatus.Text = DT.Rows[0]["EconomicStatus"].ToString();
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
                int EcoStatusId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Economic.Qstring = "Delete";
                obj_ML_Economic.EconomicId = EcoStatusId;
                obj_ML_Economic.EconomicStatus = "";
                obj_ML_Economic.CreatedBy = "";
                obj_ML_Economic.UpdatedBy = "";
                int x = obj_BL_Economic.BL_InsUpdDelEconomicStatus(obj_ML_Economic);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    EconomicStatusDetails();
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
        EconomicStatusDetails();
        txtEconomicStatus.Text = "";
        Btn_Submit.Text = "Submit";
    }
}