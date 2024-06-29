using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_District : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_District obj_ML_District = new ML_District();
    BL_District obj_BL_District = new BL_District();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchState(0);
            DistrictDetails();
        }
    }
    private void FetchState(int StateId)
    {
        try
        {
            obj_ML_Masters.QueryType = "State";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlState.DataSource = DT;
                ddlState.DataValueField = "StateId";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "--Select State--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void DistrictDetails()
    {
        try
        {
            obj_ML_District.Qstring = "Detail";
            obj_ML_District.StateId = 0;
            obj_ML_District.DistrictId = 0;
            obj_ML_District.DistrictName = "";
            obj_ML_District.CreatedBy = "";
            obj_ML_District.UpdatedBy = "";
            DataTable DT = obj_BL_District.BL_DistrictDetails(obj_ML_District);
            if (DT.Rows.Count > 0)
            {
                rpt_DistrictDetails.DataSource = DT;
                rpt_DistrictDetails.DataBind();
            }
            else
            {
                rpt_DistrictDetails.DataSource = null;
                rpt_DistrictDetails.DataBind();
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
                obj_ML_District.Qstring = "Insert";
                obj_ML_District.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_District.DistrictName = txtDistrictName.Text != "" ? txtDistrictName.Text : "";
                obj_ML_District.CreatedBy = UserCode;
                obj_ML_District.UpdatedBy = "";
                int x = obj_BL_District.BL_InsUpdDelDistrict(obj_ML_District);
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
                obj_ML_District.Qstring = "Update";
                obj_ML_District.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_District.DistrictId = Convert.ToInt32(ViewState["DistrictId"]);
                obj_ML_District.DistrictName = txtDistrictName.Text != "" ? txtDistrictName.Text : "";
                obj_ML_District.CreatedBy = "";
                obj_ML_District.UpdatedBy = UserCode;
                int x = obj_BL_District.BL_InsUpdDelDistrict(obj_ML_District);
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
        FetchState(0);
        DistrictDetails();
        ddlState.SelectedIndex = 0;
        txtDistrictName.Text = "";
        Btn_Submit.Text = "Submit";
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int DistrictId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_District.Qstring = "Detail";
                obj_ML_District.StateId = 0;
                obj_ML_District.DistrictId = DistrictId;
                obj_ML_District.DistrictName = "";
                obj_ML_District.CreatedBy = "";
                obj_ML_District.UpdatedBy = "";
                DataTable DT = obj_BL_District.BL_DistrictDetails(obj_ML_District);
                if (DT.Rows.Count > 0)
                {
                    //int StateId = Convert.ToInt32(DT.Rows[0]["StateId"].ToString());
                    FetchState(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()));
                    ddlState.SelectedValue = DT.Rows[0]["StateId"].ToString();
                    ViewState["DistrictId"] = DT.Rows[0]["DistrictId"].ToString();
                    txtDistrictName.Text = DT.Rows[0]["DistrictName"].ToString();
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
                int DistrictId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_District.Qstring = "Delete";
                obj_ML_District.StateId = 0;
                obj_ML_District.DistrictId = DistrictId;
                obj_ML_District.DistrictName = "";
                obj_ML_District.CreatedBy = "";
                obj_ML_District.UpdatedBy = "";
                int x = obj_BL_District.BL_InsUpdDelDistrict(obj_ML_District);
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