using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Forms_States : System.Web.UI.Page
{
    ML_State obj_ML_State = new ML_State();
    BL_State obj_BL_State = new BL_State();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StateDetails();
        }
    }

    private void StateDetails()
    {
        try
        {
            obj_ML_State.Qstring = "Detail";
            obj_ML_State.StateId = 0;
            obj_ML_State.StateName = "";
            obj_ML_State.CreatedBy = "";
            obj_ML_State.UpdatedBy = "";
            DataTable DT = obj_BL_State.BL_StateDetails(obj_ML_State);
            if (DT.Rows.Count > 0)
            {
                rpt_StateDetails.DataSource = DT;
                rpt_StateDetails.DataBind();
            }
            else
            {
                rpt_StateDetails.DataSource = null;
                rpt_StateDetails.DataBind();
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
                obj_ML_State.Qstring = "Insert";
                obj_ML_State.StateId = 0;
                obj_ML_State.StateName = txtStateName.Text != "" ? txtStateName.Text : "";
                obj_ML_State.CreatedBy = UserCode;
                obj_ML_State.UpdatedBy = "";
                int x = obj_BL_State.BL_InsState(obj_ML_State);
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
                obj_ML_State.Qstring = "Update";
                obj_ML_State.StateId = Convert.ToInt32(ViewState["StateID"]);
                obj_ML_State.StateName = txtStateName.Text != "" ? txtStateName.Text : "";
                obj_ML_State.CreatedBy = "";
                obj_ML_State.UpdatedBy = UserCode;
                int x = obj_BL_State.BL_UpdState(obj_ML_State);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            StateDetails();
            txtStateName.Text = "";
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
                int StateId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_State.Qstring = "Detail";
                obj_ML_State.StateId = StateId;
                obj_ML_State.StateName = "";
                obj_ML_State.CreatedBy = "";
                obj_ML_State.UpdatedBy = "";
                DataTable DT = obj_BL_State.BL_StateDetails(obj_ML_State);
                if (DT.Rows.Count > 0)
                {
                    ViewState["StateID"]= DT.Rows[0]["StateId"].ToString();
                    //hdfStateId.Value = DT.Rows[0]["StateId"].ToString();
                    txtStateName.Text = DT.Rows[0]["StateName"].ToString();
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
                int StateId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_State.Qstring = "Delete";
                obj_ML_State.StateId = StateId;
                obj_ML_State.StateName = "";
                obj_ML_State.CreatedBy = "";
                obj_ML_State.UpdatedBy = "";
                int x = obj_BL_State.BL_StateDelete(obj_ML_State);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    StateDetails();
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
        txtStateName.Text = "";
        Btn_Submit.Text = "Submit";
    }
}