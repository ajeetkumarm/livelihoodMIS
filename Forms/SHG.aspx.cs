using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Forms_SHG : System.Web.UI.Page
{
    ML_SHG obj_ML_SHG = new ML_SHG();
    BL_SHG obj_BL_SHG = new BL_SHG();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SHGDetails();
        }
    }
    private void SHGDetails()
    {
        try
        {
            obj_ML_SHG.Qstring = "Detail";
            obj_ML_SHG.ShgId = 0;
            obj_ML_SHG.ShgName = "";
            obj_ML_SHG.CreatedBy = "";
            obj_ML_SHG.UpdatedBy = "";
            DataTable DT = obj_BL_SHG.BL_SHGDetails(obj_ML_SHG);
            if (DT.Rows.Count > 0)
            {
                rpt_ShgDetails.DataSource = DT;
                rpt_ShgDetails.DataBind();
            }
            else
            {
                rpt_ShgDetails.DataSource = null;
                rpt_ShgDetails.DataBind();
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
                obj_ML_SHG.Qstring = "Insert";
                obj_ML_SHG.ShgId = 0;
                obj_ML_SHG.ShgName = txtSHGName.Text != "" ? txtSHGName.Text : "";
                obj_ML_SHG.CreatedBy = UserCode;
                obj_ML_SHG.UpdatedBy = "";
                int x = obj_BL_SHG.BL_InsUpdDelSHG(obj_ML_SHG);
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
                obj_ML_SHG.Qstring = "Update";
                obj_ML_SHG.ShgId = Convert.ToInt32(ViewState["SHGId"]);
                obj_ML_SHG.ShgName = txtSHGName.Text != "" ? txtSHGName.Text : "";
                obj_ML_SHG.CreatedBy = "";
                obj_ML_SHG.UpdatedBy = UserCode;
                int x = obj_BL_SHG.BL_InsUpdDelSHG(obj_ML_SHG);
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
                int ShgId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_SHG.Qstring = "Detail";
                obj_ML_SHG.ShgId = ShgId;
                obj_ML_SHG.ShgName = "";
                obj_ML_SHG.CreatedBy = "";
                obj_ML_SHG.UpdatedBy = "";
                DataTable DT = obj_BL_SHG.BL_SHGDetails(obj_ML_SHG);
                if (DT.Rows.Count > 0)
                {
                    ViewState["SHGId"] = DT.Rows[0]["SHGId"].ToString();
                    txtSHGName.Text = DT.Rows[0]["SHGName"].ToString();
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
                int ShgId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_SHG.Qstring = "Delete";
                obj_ML_SHG.ShgId = ShgId;
                obj_ML_SHG.ShgName = "";
                obj_ML_SHG.CreatedBy = "";
                obj_ML_SHG.UpdatedBy = "";
                int x = obj_BL_SHG.BL_InsUpdDelSHG(obj_ML_SHG);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    SHGDetails();
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
        SHGDetails();
        txtSHGName.Text = "";
        Btn_Submit.Text = "Submit";
    }
}