using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class EnrollmentList : System.Web.UI.Page
{
    ML_Enrollment obj_ML_Enrollment = new ML_Enrollment();
    BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();
    string CreatedUser, projectCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            CreatedUser = DT.Rows[0]["UserCode"].ToString();
            projectCode = DT.Rows[0]["ProjectCode"].ToString();

            if (!IsPostBack)
            {
                if (CreatedUser == "1")
                {
                    BindEnrollmentList(CreatedUser, "");
                }
                else
                {
                    BindEnrollmentList(CreatedUser, projectCode);
                }
            }
        }
        else
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Redirect("../Login.aspx");
        }
    }

    private void BindEnrollmentList(string CreatedUser, string projectid)
    {
        try
        {
            obj_ML_Enrollment.QType = "EnrollmentList";
            obj_ML_Enrollment.CreatedUser = Convert.ToInt32(CreatedUser);
            obj_ML_Enrollment.ProjectCode = projectid;
            DataTable DT = obj_BL_Enrollment.BL_EnrollmentDetails(obj_ML_Enrollment);
            if (DT.Rows.Count > 0)
            {
                rpt_EnrollmentList.DataSource = DT;
                rpt_EnrollmentList.DataBind();
            }
            else
            {
                rpt_EnrollmentList.DataSource = null;
                rpt_EnrollmentList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }

    protected void Btn_Yes_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int EnrollmentId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Enrollment.QType = "Yes";
                obj_ML_Enrollment.EnrollmentId = EnrollmentId;
                obj_ML_Enrollment.Reasons = "";
                int x = obj_BL_Enrollment.BL_UpdEDPTraning(obj_ML_Enrollment);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Successfully !');", true);
                    //BindEnrollmentList(CreatedUser, projectCode);
                    if (CreatedUser == "1")
                    {
                        BindEnrollmentList(CreatedUser, "");
                    }
                    else
                    {
                        BindEnrollmentList(CreatedUser, projectCode);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }

    protected void Btn_No_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                ViewState["EnrollmentId"] = Convert.ToInt32(btn.CommandArgument);
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "TraningNoAction();", true);
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
            obj_ML_Enrollment.QType = "No";
            obj_ML_Enrollment.EnrollmentId = Convert.ToInt32(ViewState["EnrollmentId"]);
            obj_ML_Enrollment.Reasons = ddlReasons.SelectedValue;
            int x = obj_BL_Enrollment.BL_UpdEDPTraning(obj_ML_Enrollment);
            if (x > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Successfully !');", true);
                BindEnrollmentList(CreatedUser, projectCode);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int EnrollmentId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Enrollment.EnrollmentId = EnrollmentId;
                int x = obj_BL_Enrollment.BL_DeleteEnrollmentForm(obj_ML_Enrollment);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Deleted Successfully !');", true);
                    if (CreatedUser == "1")
                    {
                        BindEnrollmentList(CreatedUser, "");
                    }
                    else
                    {
                        BindEnrollmentList(CreatedUser, projectCode);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
}