using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_VillageOld : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_Village obj_ML_Village = new ML_Village();
    BL_Village obj_BL_Village = new BL_Village();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchState(0);
            VillageDetails();
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
    private void FetchDistrict(int StateId, int DistrictId)
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
    private void FetchBlock(int StateId, int DistrictId,int BlockId)
    {
        try
        {
            obj_ML_Masters.QueryType = "Block";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = DistrictId;
            obj_ML_Masters.BlockId = BlockId;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlBlock.DataSource = DT;
                ddlBlock.DataValueField = "BlockId";
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataBind();
                ddlBlock.Items.Insert(0, "--Select Block--");
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchBlock(Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlDistrict.SelectedValue), 0);
    }
    private void VillageDetails()
    {
        try
        {
            obj_ML_Village.Qstring = "Detail";
            obj_ML_Village.StateId = 0;
            obj_ML_Village.DistrictId = 0;
            obj_ML_Village.BlockId = 0;
            obj_ML_Village.VillageId = 0;
            obj_ML_Village.VillageName = "";
            obj_ML_Village.CreatedBy = "";
            obj_ML_Village.UpdatedBy = "";
            DataTable DT = obj_BL_Village.BL_VillageDetails(obj_ML_Village);
            if (DT.Rows.Count > 0)
            {
                rpt_VillageDetails.DataSource = DT;
                rpt_VillageDetails.DataBind();
            }
            else
            {
                rpt_VillageDetails.DataSource = null;
                rpt_VillageDetails.DataBind();
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
                obj_ML_Village.Qstring = "Insert";
                obj_ML_Village.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_Village.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                obj_ML_Village.BlockId = Convert.ToInt32(ddlBlock.SelectedValue);
                obj_ML_Village.VillageName = txtVillageName.Text != "" ? txtVillageName.Text : "";
                obj_ML_Village.CreatedBy = UserCode;
                obj_ML_Village.UpdatedBy = "";
                int x = obj_BL_Village.BL_InsUpdDelVillage(obj_ML_Village);
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
                obj_ML_Village.Qstring = "Update";
                obj_ML_Village.StateId = Convert.ToInt32(ddlState.SelectedValue);
                obj_ML_Village.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                obj_ML_Village.BlockId = Convert.ToInt32(ddlBlock.SelectedValue);
                obj_ML_Village.VillageId = Convert.ToInt32(ViewState["VillageId"]);
                obj_ML_Village.VillageName = txtVillageName.Text != "" ? txtVillageName.Text : "";
                obj_ML_Village.CreatedBy = "";
                obj_ML_Village.UpdatedBy = UserCode;
                int x = obj_BL_Village.BL_InsUpdDelVillage(obj_ML_Village);
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
        VillageDetails();
        ddlState.SelectedIndex = 0;
        ddlDistrict.Items.Clear();
        ddlBlock.Items.Clear();
        txtVillageName.Text = "";
        Btn_Submit.Text = "Submit";
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int VillageId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Village.Qstring = "Detail";
                obj_ML_Village.StateId = 0;
                obj_ML_Village.DistrictId = 0;
                obj_ML_Village.BlockId = 0;
                obj_ML_Village.VillageId = VillageId;
                obj_ML_Village.VillageName = "";
                obj_ML_Village.CreatedBy = "";
                obj_ML_Village.UpdatedBy = "";
                DataTable DT = obj_BL_Village.BL_VillageDetails(obj_ML_Village);
                if (DT.Rows.Count > 0)
                {
                    //int StateId = Convert.ToInt32(DT.Rows[0]["StateId"].ToString());
                    FetchState(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()));
                    ddlState.SelectedValue = DT.Rows[0]["StateId"].ToString();
                    ddlDistrict.SelectedValue = DT.Rows[0]["DistrictId"].ToString();
                    ddlBlock.SelectedValue = DT.Rows[0]["BlockId"].ToString();
                    FetchDistrict(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()), Convert.ToInt32(DT.Rows[0]["DistrictId"].ToString()));
                    FetchBlock(Convert.ToInt32(DT.Rows[0]["StateId"].ToString()), Convert.ToInt32(DT.Rows[0]["DistrictId"].ToString()), Convert.ToInt32(DT.Rows[0]["BlockId"].ToString()));

                    ViewState["VillageId"] = DT.Rows[0]["VillageId"].ToString();
                    txtVillageName.Text = DT.Rows[0]["VillageName"].ToString();
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
                int VillageId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Village.Qstring = "Delete";
                obj_ML_Village.StateId = 0;
                obj_ML_Village.DistrictId = 0;
                obj_ML_Village.BlockId = 0;
                obj_ML_Village.VillageId = VillageId;
                obj_ML_Village.VillageName = "";
                obj_ML_Village.CreatedBy = "";
                obj_ML_Village.UpdatedBy = "";
                int x = obj_BL_Village.BL_InsUpdDelVillage(obj_ML_Village);
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