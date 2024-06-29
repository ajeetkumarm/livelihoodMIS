using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Block : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_Block obj_ML_Block = new ML_Block();
    BL_Block obj_BL_Block = new BL_Block();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchState(0);
            BlockDetails();
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
    private void FetchDistrict(int StateId,int DistrictId)
    {
        try
        {
            obj_ML_Masters.QueryType = "District";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = DistrictId;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlDistrict.DataSource = DT;
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select District--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchDistrict(Convert.ToInt32(ddlState.SelectedValue), 0);
    }    
    private void BlockDetails()
    {
        try
        {
            obj_ML_Block.Qstring = "Detail";
            obj_ML_Block.StateId = 0;
            obj_ML_Block.DistrictId = 0;
            obj_ML_Block.BlockId = 0;
            obj_ML_Block.BlockName = "";
            obj_ML_Block.CreatedBy = "";
            obj_ML_Block.UpdatedBy = "";
            DataTable DT = obj_BL_Block.BL_BLockDetails(obj_ML_Block);
            if (DT.Rows.Count > 0)
            {
                rpt_BlockDetails.DataSource = DT;
                rpt_BlockDetails.DataBind();
            }
            else
            {
                rpt_BlockDetails.DataSource = null;
                rpt_BlockDetails.DataBind();
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
                obj_ML_Block.Qstring = "Insert";
                obj_ML_Block.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_Block.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                obj_ML_Block.BlockName = txtBlockName.Text != "" ? txtBlockName.Text : "";
                obj_ML_Block.CreatedBy = UserCode;
                obj_ML_Block.UpdatedBy = "";
                int x = obj_BL_Block.BL_InsUpdDelBlock(obj_ML_Block);
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
                obj_ML_Block.Qstring = "Update";
                obj_ML_Block.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_Block.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                obj_ML_Block.BlockId = Convert.ToInt32(ViewState["BlockId"]);
                obj_ML_Block.BlockName = txtBlockName.Text != "" ? txtBlockName.Text : "";
                obj_ML_Block.CreatedBy = "";
                obj_ML_Block.UpdatedBy = UserCode;
                int x = obj_BL_Block.BL_InsUpdDelBlock(obj_ML_Block);
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
        BlockDetails();
        ddlState.SelectedIndex = 0;
        ddlDistrict.Items.Clear();
        txtBlockName.Text = "";
        Btn_Submit.Text = "Submit";
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int BlockId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Block.Qstring = "Detail";
                obj_ML_Block.StateId = 0;
                obj_ML_Block.DistrictId = 0;
                obj_ML_Block.BlockId = BlockId;
                obj_ML_Block.BlockName = "";
                obj_ML_Block.CreatedBy = "";
                obj_ML_Block.UpdatedBy = "";
                DataTable DT = obj_BL_Block.BL_BLockDetails(obj_ML_Block);
                if (DT.Rows.Count > 0)
                {
                    //int StateId = Convert.ToInt32(DT.Rows[0]["StateId"].ToString());
                    FetchState(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()));
                    ddlState.SelectedValue = DT.Rows[0]["StateId"].ToString();
                    ddlDistrict.SelectedValue = DT.Rows[0]["DistrictId"].ToString();
                    FetchDistrict(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()), Convert.ToInt32(DT.Rows[0]["DistrictId"].ToString()));


                    ViewState["BlockId"] = DT.Rows[0]["BlockId"].ToString();
                    txtBlockName.Text = DT.Rows[0]["BlockName"].ToString();
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
                int BlockId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Block.Qstring = "Delete";
                obj_ML_Block.StateId = 0;
                obj_ML_Block.DistrictId = 0;
                obj_ML_Block.BlockId = BlockId;
                obj_ML_Block.BlockName = "";
                obj_ML_Block.CreatedBy = "";
                obj_ML_Block.UpdatedBy = "";
                int x = obj_BL_Block.BL_InsUpdDelBlock(obj_ML_Block);
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