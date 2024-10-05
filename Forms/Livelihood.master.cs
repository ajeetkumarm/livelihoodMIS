using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Livelihood : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            if (!IsPostBack)
            {
                DataTable DT = Session["UserDetails"] as DataTable;
                UserRole();
                lblUserName.Text = DT.Rows[0]["FullName"].ToString();
                lblDropUser.Text = DT.Rows[0]["FullName"].ToString();
                lblUserType.Text = DT.Rows[0]["Category"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("../Login.aspx");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

    }

    private void UserRole()
    {
        DataTable DT = Session["UserDetails"] as DataTable;
        int UserCategory = Convert.ToInt16(DT.Rows[0]["UserCategory"].ToString());
        var Forms = DT.Rows[0]["FormAccess"].ToString();

        foreach (string FormId in Forms.Split(','))
        {
            string ControlId = FormId.ToString();
            if (ControlId == "1")
            {
                li_1.Visible = true;
                li_R1.Visible = true;
            }
            else if (ControlId == "2")
            {
                li_2.Visible = true;
                li_R1.Visible = true;
            }
            else if (ControlId == "3")
            {
                li_3.Visible = true;
                li_R2.Visible = true;
            }
            else if (ControlId == "4")
            {
                li_4.Visible = true;
                li_R3.Visible = true;
            }
            else if (ControlId == "5")
            {
                li_5.Visible = true;
                li_R4.Visible = true;
            }
            else if (ControlId == "6")
            {
                li_R5.Visible = true;
            }
        }
        if (UserCategory == 1)
        {
            li_Master.Visible = true;
            li_1.Visible = true;
            li_2.Visible = true;
            li_3.Visible = true;
            li_4.Visible = true;
            li_5.Visible = true;
            li_R1.Visible = true;
            li_R2.Visible = true;
            li_R3.Visible = true;
            li_R4.Visible = true;
            li_R5.Visible = true;
        }

        if (UserCategory == 8)
        {
            liFormSection.Visible = liReportSection.Visible = liDashboard.Visible= false;
            liBusinessProgresss.Visible = true;
        }

    }

    protected void lnkbtn_LogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.Redirect("../Login.aspx");
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }

    protected void lnkbtn_SignOut_Click(object sender, EventArgs e)
    {
        lnkbtn_LogOut_Click(sender, e);
    }
}
