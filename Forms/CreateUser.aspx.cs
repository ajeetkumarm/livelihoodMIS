using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_CreateUser : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_UserLogin obj_ML_UserLogin = new ML_UserLogin();
    BL_UserLogin obj_BL_UserLogin = new BL_UserLogin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchUserDetails();
            FetchState(0);
            FetchUserCategory();
            FetchPartner();
            FetchProjectLocation();
        }
    }
    private void FetchUserDetails()
    {
        try
        {
            obj_ML_UserLogin.QType = "UserDetails";
            obj_ML_UserLogin.UserCode = 0;
            DataTable DT = obj_BL_UserLogin.BL_UserActInactiveDetails(obj_ML_UserLogin);
            if (DT.Rows.Count > 0)
            {
                rpt_UserDetails.DataSource = DT;
                rpt_UserDetails.DataBind();
            }
            else
            {
                rpt_UserDetails.DataSource = null;
                rpt_UserDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
    private void FetchUserCategory()
    {
        try
        {
            obj_ML_Masters.QueryType = "UserCat";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlUserCategory.DataSource = DT;
                ddlUserCategory.DataValueField = "CategoryId";
                ddlUserCategory.DataTextField = "Category";
                ddlUserCategory.DataBind();
                ddlUserCategory.Items.Insert(0, "--Select User Category--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
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
            obj_ML_Masters.PartnerId = 0;
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
            obj_ML_Masters.PartnerId = 0;
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
    private void FetchBlock(int StateId, int DistrictId, int BlockId)
    {
        try
        {
            obj_ML_Masters.QueryType = "Block";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = DistrictId;
            obj_ML_Masters.BlockId = BlockId;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
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
    private void FetchVillage(int StateId, int DistrictId, int BlockId, int VillageId)
    {
        try
        {
            obj_ML_Masters.QueryType = "Village";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = DistrictId;
            obj_ML_Masters.BlockId = BlockId;
            obj_ML_Masters.VillageId = VillageId;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlVillage.DataSource = DT;
                ddlVillage.DataValueField = "VillageId";
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, "--Select Village--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchPartner()
    {
        try
        {
            obj_ML_Masters.QueryType = "Partner";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlPartner.DataSource = DT;
                ddlPartner.DataValueField = "PartnerId";
                ddlPartner.DataTextField = "PartnerName";
                ddlPartner.DataBind();
                ddlPartner.Items.Insert(0, "--Select Partner--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchProject(int PartnerId)
    {
        try
        {
            obj_ML_Masters.QueryType = "Project";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            //obj_ML_Masters.PartnerId = Convert.ToInt32(ddlPartner.SelectedValue);
            obj_ML_Masters.PartnerId = PartnerId;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlProject.DataSource = DT;
                ddlProject.DataValueField = "ProjectId";
                ddlProject.DataTextField = "ProjectName";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, "--Select Project--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlPartner_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchProject(Convert.ToInt32(ddlPartner.SelectedValue));

        //try
        //{
        //    obj_ML_Masters.QueryType = "Project";
        //    obj_ML_Masters.StateId = 0;
        //    obj_ML_Masters.DistrictId = 0;
        //    obj_ML_Masters.BlockId = 0;
        //    obj_ML_Masters.VillageId = 0;
        //    obj_ML_Masters.DigitalCategoryId = 0;
        //    obj_ML_Masters.PartnerId = Convert.ToInt32(ddlPartner.SelectedValue);
        //    DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
        //    if (DT.Rows.Count > 0)
        //    {
        //        ddlProject.DataSource = DT;
        //        ddlProject.DataValueField = "ProjectId";
        //        ddlProject.DataTextField = "ProjectName";
        //        ddlProject.DataBind();
        //        ddlProject.Items.Insert(0, "--Select Project--");
        //    }
        //}
        //catch (Exception)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        //}
    }
    private void FetchProjectLocation()
    {
        try
        {
            obj_ML_Masters.QueryType = "ProjectLocation";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlLocation.DataSource = DT;
                ddlLocation.DataValueField = "ProjectId";
                ddlLocation.DataTextField = "ProjectName";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, "--Select Project Location--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "District";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "Block";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
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
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "Village";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            obj_ML_Masters.BlockId = Convert.ToInt32(ddlBlock.SelectedValue);
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            obj_ML_Masters.PartnerId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlVillage.DataSource = DT;
                ddlVillage.DataValueField = "VillageId";
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, "--Select Village--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
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
                string NewPwd = SHAValidator.SHAValid(txtMobileNo.Text);  /* hdfRanValue.Value */
                obj_ML_UserLogin.UserCode = 0;
                obj_ML_UserLogin.StateCode = Convert.ToInt32(ddlState.SelectedIndex > 0 ? ddlState.SelectedValue : "0");
                obj_ML_UserLogin.DistrictCode = Convert.ToInt32(ddlDistrict.SelectedIndex > 0 ? ddlDistrict.SelectedValue : "0");
                obj_ML_UserLogin.BlockCode = Convert.ToInt32(ddlBlock.SelectedIndex > 0 ? ddlBlock.SelectedValue : "0");
                obj_ML_UserLogin.VillageCode = Convert.ToInt32(ddlVillage.SelectedIndex > 0 ? ddlVillage.SelectedValue : "0");
                obj_ML_UserLogin.PartnerCode = Convert.ToInt32(ddlPartner.SelectedIndex > 0 ? ddlPartner.SelectedValue : "0");
                obj_ML_UserLogin.ProjectCode = Convert.ToInt32(ddlProject.SelectedIndex > 0 ? ddlProject.SelectedValue : "0");
                obj_ML_UserLogin.LocationCode = Convert.ToInt32(ddlLocation.SelectedIndex > 0 ? ddlLocation.SelectedValue : "0");
                obj_ML_UserLogin.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                obj_ML_UserLogin.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                obj_ML_UserLogin.ContactNo = txtMobileNo.Text != "" ? txtMobileNo.Text : "";
                obj_ML_UserLogin.UserEmail = txtEmail.Text != "" ? txtEmail.Text : "";
                obj_ML_UserLogin.LoginName = txtEmail.Text != "" ? txtEmail.Text : "";
                obj_ML_UserLogin.PwdHash = NewPwd;
                obj_ML_UserLogin.UserCategory = ddlUserCategory.SelectedIndex > 0 ? ddlUserCategory.SelectedValue : "0";
                obj_ML_UserLogin.CreatedBy = UserCode;
                obj_ML_UserLogin.UpdatedBy = "";
                int x = obj_BL_UserLogin.BL_InsUpdUser(obj_ML_UserLogin);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Created Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            else
            {
                //string NewPwd = SHAValidator.SHAValid(txtMobileNo.Text);
                obj_ML_UserLogin.UserCode = Convert.ToInt32(ViewState["UserCode"]);
                obj_ML_UserLogin.StateCode = Convert.ToInt32(ddlState.SelectedIndex > 0 ? ddlState.SelectedValue : "0");
                obj_ML_UserLogin.DistrictCode = Convert.ToInt32(ddlDistrict.SelectedIndex > 0 ? ddlDistrict.SelectedValue : "0");
                obj_ML_UserLogin.BlockCode = Convert.ToInt32(ddlBlock.SelectedIndex > 0 ? ddlBlock.SelectedValue : "0");
                obj_ML_UserLogin.VillageCode = Convert.ToInt32(ddlVillage.SelectedIndex > 0 ? ddlVillage.SelectedValue : "0");
                obj_ML_UserLogin.PartnerCode = Convert.ToInt32(ddlPartner.SelectedIndex > 0 ? ddlPartner.SelectedValue : "0");
                obj_ML_UserLogin.ProjectCode = Convert.ToInt32(ddlProject.SelectedIndex > 0 ? ddlProject.SelectedValue : "0");
                obj_ML_UserLogin.LocationCode = Convert.ToInt32(ddlLocation.SelectedIndex > 0 ? ddlLocation.SelectedValue : "0");
                obj_ML_UserLogin.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                obj_ML_UserLogin.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                obj_ML_UserLogin.ContactNo = txtMobileNo.Text != "" ? txtMobileNo.Text : "";
                obj_ML_UserLogin.UserEmail = txtEmail.Text != "" ? txtEmail.Text : "";
                obj_ML_UserLogin.LoginName = txtEmail.Text != "" ? txtEmail.Text : "";
                //obj_ML_UserLogin.PwdHash = NewPwd;
                obj_ML_UserLogin.UserCategory = ddlUserCategory.SelectedIndex > 0 ? ddlUserCategory.SelectedValue : "0";
                obj_ML_UserLogin.CreatedBy = "";
                obj_ML_UserLogin.UpdatedBy = UserCode;
                int x = obj_BL_UserLogin.BL_InsUpdUser(obj_ML_UserLogin);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Update Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            Btn_Cancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        ddlState.SelectedIndex = 0;
        ddlDistrict.Items.Clear();
        ddlBlock.Items.Clear();
        ddlVillage.Items.Clear();
        ddlPartner.SelectedIndex = 0;
        ddlProject.Items.Clear();
        ddlLocation.SelectedIndex = 0;
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobileNo.Text = "";
        txtEmail.Text = "";
        ddlUserCategory.SelectedIndex = 0;
        FetchUserDetails();
        Btn_Submit.Text = "Submit";
        txtEmail.ReadOnly = false;
    }
    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                Btn_Cancel_Click(sender, e);
                int UserCode = Convert.ToInt32(btn.CommandArgument);
                obj_ML_UserLogin.QType = "UserDetails";
                obj_ML_UserLogin.UserCode = UserCode;
                DataTable DT = obj_BL_UserLogin.BL_UserActInactiveDetails(obj_ML_UserLogin);
                if (DT.Rows.Count > 0)
                {

                    ViewState["UserCode"] = DT.Rows[0]["UserCode"].ToString();
                    ddlUserCategory.SelectedValue = DT.Rows[0]["UserCategory"].ToString();
                    FetchState(0);
                    ddlState.SelectedValue = DT.Rows[0]["StateCode"].ToString();
                    FetchDistrict(Convert.ToInt32(DT.Rows[0]["StateCode"].ToString()), 0);
                    ddlDistrict.SelectedValue = DT.Rows[0]["DistrictCode"].ToString();
                    FetchBlock(Convert.ToInt32(DT.Rows[0]["StateCode"].ToString()), Convert.ToInt32(DT.Rows[0]["DistrictCode"].ToString()), 0);
                    ddlBlock.SelectedValue = DT.Rows[0]["BlockCode"].ToString();
                    FetchVillage(Convert.ToInt32(DT.Rows[0]["StateCode"].ToString()), Convert.ToInt32(DT.Rows[0]["DistrictCode"].ToString()), Convert.ToInt32(DT.Rows[0]["BlockCode"].ToString()), 0);
                    ddlVillage.SelectedValue = DT.Rows[0]["VillageCode"].ToString();
                    ddlPartner.SelectedValue = DT.Rows[0]["PartnerCode"].ToString();
                    FetchProject(Convert.ToInt32(DT.Rows[0]["PartnerCode"].ToString()));
                    ddlProject.SelectedValue = DT.Rows[0]["ProjectCode"].ToString();
                    ddlLocation.SelectedValue = DT.Rows[0]["LocationCode"].ToString();
                    txtFirstName.Text = DT.Rows[0]["FirstName"].ToString();
                    txtLastName.Text = DT.Rows[0]["LastName"].ToString();
                    txtEmail.Text = DT.Rows[0]["Email"].ToString();
                    txtMobileNo.Text = DT.Rows[0]["ContactNo"].ToString();
                    txtEmail.ReadOnly = true;
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
    protected void Btn_InActive_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int UserCode = Convert.ToInt32(btn.CommandArgument);
                obj_ML_UserLogin.QType = "ActInact";
                obj_ML_UserLogin.UserCode = UserCode;
                DataTable DT = obj_BL_UserLogin.BL_UserActInactiveDetails(obj_ML_UserLogin);
                if (DT.Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('User InActive Successfully !');", true);
                    FetchUserDetails();
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