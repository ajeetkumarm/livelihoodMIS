using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Cast : System.Web.UI.Page
{
    ML_Cast obj_ML_Cast = new ML_Cast();
    BL_Cast obj_BL_Cast = new BL_Cast();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CastDetails();
        }
    }
    private void CastDetails()
    {
        try
        {
            obj_ML_Cast.Qstring = "Detail";
            obj_ML_Cast.CastId = 0;
            obj_ML_Cast.CastName = "";
            obj_ML_Cast.CreatedBy = "";
            obj_ML_Cast.UpdatedBy = "";
            DataTable DT = obj_BL_Cast.BL_CastDetails(obj_ML_Cast);
            if (DT.Rows.Count > 0)
            {
                rpt_CastDetails.DataSource = DT;
                rpt_CastDetails.DataBind();
            }
            else
            {
                rpt_CastDetails.DataSource = null;
                rpt_CastDetails.DataBind();
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
                obj_ML_Cast.Qstring = "Insert";
                obj_ML_Cast.CastId = 0;
                obj_ML_Cast.CastName = txtCastSocial.Text != "" ? txtCastSocial.Text : "";
                obj_ML_Cast.CreatedBy = UserCode;
                obj_ML_Cast.UpdatedBy = "";
                int x = obj_BL_Cast.BL_InsUpdDelCast(obj_ML_Cast);
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
                obj_ML_Cast.Qstring = "Update";
                obj_ML_Cast.CastId = Convert.ToInt32(ViewState["CastId"]);
                obj_ML_Cast.CastName = txtCastSocial.Text != "" ? txtCastSocial.Text : "";
                obj_ML_Cast.CreatedBy = "";
                obj_ML_Cast.UpdatedBy = UserCode;
                int x = obj_BL_Cast.BL_InsUpdDelCast(obj_ML_Cast);
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
                int CastId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Cast.Qstring = "Detail";
                obj_ML_Cast.CastId = CastId;
                obj_ML_Cast.CastName = "";
                obj_ML_Cast.CreatedBy = "";
                obj_ML_Cast.UpdatedBy = "";
                DataTable DT = obj_BL_Cast.BL_CastDetails(obj_ML_Cast);
                if (DT.Rows.Count > 0)
                {
                    ViewState["CastId"] = DT.Rows[0]["CastId"].ToString();
                    txtCastSocial.Text = DT.Rows[0]["CastName"].ToString();
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
                int CastId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Cast.Qstring = "Delete";
                obj_ML_Cast.CastId = CastId;
                obj_ML_Cast.CastName = "";
                obj_ML_Cast.CreatedBy = "";
                obj_ML_Cast.UpdatedBy = "";
                int x = obj_BL_Cast.BL_InsUpdDelCast(obj_ML_Cast);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    CastDetails();
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
        CastDetails();
        txtCastSocial.Text = "";
        Btn_Submit.Text = "Submit";
    }
}