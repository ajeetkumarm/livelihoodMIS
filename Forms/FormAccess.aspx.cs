using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using DataLayer;

public partial class Forms_FormAccess : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_FormAccess obj_ML_FormAccess = new ML_FormAccess();
    BL_FormAccess obj_BL_FormAccess = new BL_FormAccess();

    string FormAccess;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchUserCategory();
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
    protected void ddlUserCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlProject.Items.Clear();
            ddlUsers.Items.Clear();
            chkForms.ClearSelection();


            obj_ML_Masters.QueryType = "UserProject";
            obj_ML_Masters.UserCategory = ddlUserCategory.SelectedValue;
            obj_ML_Masters.ProjectId = 0;
            DataTable DT = obj_BL_Masters.BL_ProjectAndEmailUsers(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlProject.DataSource = DT;
                ddlProject.DataValueField = "ProjectCode";
                ddlProject.DataTextField = "ProjectName";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, "--Select User Project--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "UserEmail";
            obj_ML_Masters.UserCategory = ddlUserCategory.SelectedValue;
            obj_ML_Masters.ProjectId = Convert.ToInt32(ddlProject.SelectedValue);
            DataTable DT = obj_BL_Masters.BL_ProjectAndEmailUsers(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlUsers.DataSource = DT;
                ddlUsers.DataValueField = "UserCode";
                ddlUsers.DataTextField = "Email";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, "--Select User Email--");
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
            if (Btn_Submit.Text == "Submit" || Btn_Submit.Text == "Update")
            {
                foreach (ListItem itemForms in chkForms.Items)
                {
                    if (itemForms.Selected)
                    {
                        FormAccess += itemForms.Value + ',';
                    }
                }
                if (FormAccess != null)
                {
                    FormAccess = FormAccess.TrimEnd(',');
                }

                obj_ML_FormAccess.UserCode = Convert.ToInt32(ddlUsers.SelectedValue);
                obj_ML_FormAccess.FormAccess = FormAccess;
                obj_ML_FormAccess.UpdatedBy = UserCode;
                int x = obj_BL_FormAccess.BL_UpdUserLoginWithFormAccess(obj_ML_FormAccess);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Form Access allow to selected user Successfully !');", true);

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
        ddlProject.Items.Clear();
        ddlUsers.Items.Clear();
        ddlUserCategory.SelectedIndex = 0;
        chkAll.Checked = false;
        chkForms.ClearSelection();
        Btn_Submit.Text = "Submit";
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_FormAccess.UserCategoryCode = Convert.ToInt32(ddlUserCategory.SelectedValue);
            obj_ML_FormAccess.UserProjectCode = Convert.ToInt32(ddlProject.SelectedValue);
            obj_ML_FormAccess.UserCode = Convert.ToInt32(ddlUsers.SelectedValue);
            DataTable DT = obj_BL_FormAccess.BL_FetchFormDetails(obj_ML_FormAccess);
            if (DT.Rows.Count > 0)
            {
                var Forms = DT.Rows[0]["FormAccess"].ToString();

                foreach (string Symptoms in Forms.Split(','))
                {
                    ListItem currentCheckBox = chkForms.Items.FindByValue(Symptoms.ToString());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
                    }
                }
                Btn_Submit.Text = "Update";
                //txtTelephoneNo.ReadOnly = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Check_UnCheckAll(object sender, EventArgs e)
    {
        foreach (ListItem item in chkForms.Items)
        {
            item.Selected = chkAll.Checked;
        }
    }

    protected void chkForms_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool isAllChecked = true;
        foreach (ListItem item in chkForms.Items)
        {
            if (!item.Selected)
            {
                isAllChecked = false;
                break;
            }
        }
        chkAll.Checked = isAllChecked;
    }

}