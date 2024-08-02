using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_DigitalService : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_DigitalService obj_ML_DigitalService = new ML_DigitalService();
    BL_DigitalService obj_BL_DigitalService = new BL_DigitalService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchDigitalCategory(0);
            DigitalServiceDetails();
        }
    }
    private void FetchDigitalCategory(int DigiCatId)
    {
        try
        {
            obj_ML_Masters.QueryType = "DigiCat";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlDigitalService.DataSource = DT;
                ddlDigitalService.DataValueField = "CategoryId";
                ddlDigitalService.DataTextField = "Category";
                ddlDigitalService.DataBind();
                ddlDigitalService.Items.Insert(0, "--Select Digital Category--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void DigitalServiceDetails()
    {
        try
        {
            obj_ML_DigitalService.Qstring = "Detail";
            obj_ML_DigitalService.ServiceId = 0;
            obj_ML_DigitalService.DigitalCategoryId = 0;
            obj_ML_DigitalService.ServiceLine = "";
            obj_ML_DigitalService.CreatedBy = "";
            obj_ML_DigitalService.UpdatedBy = "";
            DataTable DT = obj_BL_DigitalService.BL_DigitalServiceDetails(obj_ML_DigitalService);
            if (DT.Rows.Count > 0)
            {
                rpt_DigitalServiceDetails.DataSource = DT;
                rpt_DigitalServiceDetails.DataBind();
            }
            else
            {
                rpt_DigitalServiceDetails.DataSource = null;
                rpt_DigitalServiceDetails.DataBind();
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

            obj_ML_DigitalService.ServiceURL = TypeConversionUtility.ToStringWithNull(txtServiceURL.Text);
            obj_ML_DigitalService.DisplayOrder = TypeConversionUtility.ToInteger(txtDisplayOrder.Text);

            if (Btn_Submit.Text == "Submit")
            {
                obj_ML_DigitalService.Qstring = "Insert";
                obj_ML_DigitalService.ServiceId = 0;
                obj_ML_DigitalService.DigitalCategoryId = Convert.ToInt32(ddlDigitalService.SelectedValue);
                obj_ML_DigitalService.ServiceLine = txtServiceLine.Text != "" ? txtServiceLine.Text : "";
                obj_ML_DigitalService.CreatedBy = UserCode;
                obj_ML_DigitalService.UpdatedBy = "";
                int x = obj_BL_DigitalService.BL_InsUpdDelDigitalService(obj_ML_DigitalService);
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
                obj_ML_DigitalService.Qstring = "Update";
                obj_ML_DigitalService.ServiceId = Convert.ToInt32(ViewState["ServiceId"]);
                obj_ML_DigitalService.DigitalCategoryId = Convert.ToInt32(ddlDigitalService.SelectedValue);
                obj_ML_DigitalService.ServiceLine = txtServiceLine.Text != "" ? txtServiceLine.Text : "";
                obj_ML_DigitalService.CreatedBy = "";
                obj_ML_DigitalService.UpdatedBy = UserCode;
                int x = obj_BL_DigitalService.BL_InsUpdDelDigitalService(obj_ML_DigitalService);
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
        FetchDigitalCategory(0);
        DigitalServiceDetails();
        ddlDigitalService.SelectedIndex = 0;
        txtServiceLine.Text = "";
        txtServiceURL.Text = "";
        txtDisplayOrder.Text = "";
        Btn_Submit.Text = "Submit";
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int ServiceId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_DigitalService.Qstring = "Detail";
                obj_ML_DigitalService.ServiceId = ServiceId;
                obj_ML_DigitalService.DigitalCategoryId = 0;
                obj_ML_DigitalService.ServiceLine = "";
                obj_ML_DigitalService.CreatedBy = "";
                obj_ML_DigitalService.UpdatedBy = "";
                DataTable DT = obj_BL_DigitalService.BL_DigitalServiceDetails(obj_ML_DigitalService);
                if (DT.Rows.Count > 0)
                {
                    //int StateId = Convert.ToInt32(DT.Rows[0]["StateId"].ToString());
                    FetchDigitalCategory(Convert.ToInt32(DT.Rows[0]["DigitalCategoryId"].ToString()));
                    ViewState["ServiceId"] = DT.Rows[0]["ServiceId"].ToString();
                    ddlDigitalService.SelectedValue = DT.Rows[0]["DigitalCategoryId"].ToString();                    
                    txtServiceLine.Text = DT.Rows[0]["ServiceLine"].ToString();
                    txtServiceURL.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["ServiceURL"]);
                    txtDisplayOrder.Text = TypeConversionUtility.ToStringWithNull(DT.Rows[0]["DisplayOrder"]);
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
                int ServiceId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_DigitalService.Qstring = "Delete";
                obj_ML_DigitalService.ServiceId = ServiceId;
                obj_ML_DigitalService.DigitalCategoryId = 0;
                obj_ML_DigitalService.ServiceLine = "";
                obj_ML_DigitalService.CreatedBy = "";
                obj_ML_DigitalService.UpdatedBy = "";
                int x = obj_BL_DigitalService.BL_InsUpdDelDigitalService(obj_ML_DigitalService);
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