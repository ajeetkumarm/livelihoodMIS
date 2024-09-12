using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_OldBusinessProgressList : System.Web.UI.Page
{
    ML_Enrollment obj_ML_Enrollment = new ML_Enrollment();
    BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();
    string CreatedUser, projectCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            if (!IsPostBack)
            {
                DataTable DT = Session["UserDetails"] as DataTable;
                CreatedUser = DT.Rows[0]["UserCode"].ToString();
                projectCode = DT.Rows[0]["ProjectCode"].ToString();
                if (CreatedUser == "1")
                {
                    BindBusinessProgress(CreatedUser, "");
                }
                else
                {
                    BindBusinessProgress(CreatedUser, projectCode);
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
    private void BindBusinessProgress(string CreatedUser, string projectid)
    {
        try
        {
            obj_ML_Enrollment.QType = "BusinessProgress";
            obj_ML_Enrollment.CreatedUser = Convert.ToInt32(CreatedUser);
            obj_ML_Enrollment.ProjectCode = projectid;
            DataTable DT = obj_BL_Enrollment.BL_EnrollmentDetails(obj_ML_Enrollment);
            if (DT.Rows.Count > 0)
            {
                rpt_BusinessProgress.DataSource = DT;
                rpt_BusinessProgress.DataBind();
            }
            else
            {
                rpt_BusinessProgress.DataSource = null;
                rpt_BusinessProgress.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }

    protected void Btn_AddBusinessProgress_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int EnrollmentId = Convert.ToInt32(btn.CommandArgument);
                //Response.Redirect("BusinessProgress.aspx?EnrolId=" + EnrollmentId + "", false);
                Response.Redirect("BusinessProgressCustomerList.aspx?EnrolId=" + EnrollmentId + "", false);
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
}