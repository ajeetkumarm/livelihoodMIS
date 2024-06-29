using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Forms_Partner : System.Web.UI.Page
{
    ML_Partner obj_ML_Partner=new ML_Partner();
    BL_Partner obj_BL_Partner = new BL_Partner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PartnerDetails();
        }
    }
    private void PartnerDetails()
    {
        try
        {
            obj_ML_Partner.Qstring     = "Detail";
            obj_ML_Partner.PartnerId   = 0;
            obj_ML_Partner.PartnerName = "";
            obj_ML_Partner.CreatedBy   = "";
            obj_ML_Partner.UpdatedBy   = "";
            DataTable DT = obj_BL_Partner.BL_PartnerDetails(obj_ML_Partner);
            if (DT.Rows.Count > 0)
            {
                rpt_PartnerDetails.DataSource = DT;
                rpt_PartnerDetails.DataBind();
            }
            else
            {
                rpt_PartnerDetails.DataSource = null;
                rpt_PartnerDetails.DataBind();
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
                obj_ML_Partner.Qstring     = "Insert";
                obj_ML_Partner.PartnerId   = 0;
                obj_ML_Partner.PartnerName = txtPartner.Text != "" ? txtPartner.Text : "";
                obj_ML_Partner.CreatedBy   = UserCode;
                obj_ML_Partner.UpdatedBy   = "";
                int x = obj_BL_Partner.BL_InsUpdDelPartner(obj_ML_Partner);
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
                obj_ML_Partner.Qstring = "Update";
                obj_ML_Partner.PartnerId = Convert.ToInt32(ViewState["PartnerId"]);
                obj_ML_Partner.PartnerName = txtPartner.Text != "" ? txtPartner.Text : "";
                obj_ML_Partner.CreatedBy = "";
                obj_ML_Partner.UpdatedBy = UserCode;
                int x = obj_BL_Partner.BL_InsUpdDelPartner(obj_ML_Partner);                
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            PartnerDetails();
            txtPartner.Text = "";
            Btn_Submit.Text = "Submit";
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
                int PartnerId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Partner.Qstring = "Detail";
                obj_ML_Partner.PartnerId = PartnerId;
                obj_ML_Partner.PartnerName = "";
                obj_ML_Partner.CreatedBy = "";
                obj_ML_Partner.UpdatedBy = "";
                DataTable DT = obj_BL_Partner.BL_PartnerDetails(obj_ML_Partner);
                if (DT.Rows.Count > 0)
                {
                    ViewState["PartnerId"] = DT.Rows[0]["PartnerId"].ToString();
                    txtPartner.Text = DT.Rows[0]["PartnerName"].ToString();
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
                int PartnerId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Partner.Qstring = "Delete";
                obj_ML_Partner.PartnerId = PartnerId;
                obj_ML_Partner.PartnerName = "";
                obj_ML_Partner.CreatedBy = "";
                obj_ML_Partner.UpdatedBy = "";
                int x = obj_BL_Partner.BL_InsUpdDelPartner(obj_ML_Partner);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    PartnerDetails();
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
        txtPartner.Text = "";
        Btn_Submit.Text = "Submit";
    }
    //protected void Btn_Submit_Click(object sender, EventArgs e)
    //{

    //}

    //protected void btn_Cancel_Click(object sender, EventArgs e)
    //{

    //}

    //protected void Btn_Edit_Click(object sender, EventArgs e)
    //{

    //}

    //protected void Btn_Delete_Click(object sender, EventArgs e)
    //{

    //}
}