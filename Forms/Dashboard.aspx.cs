﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Dashboard : System.Web.UI.Page
{
    ML_Dashboard obj_ML_Dashboard = new ML_Dashboard();
    BL_Dashboard obj_BL_Dashboard = new BL_Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            if (!IsPostBack)
            {
                DataTable DTUser = Session["UserDetails"] as DataTable;
                string UserId = DTUser.Rows[0]["UserCode"].ToString();
                string ProjectId = DTUser.Rows[0]["ProjectCode"].ToString();
                int UserCategory = Convert.ToInt32(DTUser.Rows[0]["UserCategory"].ToString());
                FetchProject();
                if (UserId == "1")
                {
                    DashboardCount(UserId, "");
                }
                else
                {
                    ddlProject.SelectedValue = ProjectId.ToString();
                    ddlProject.Enabled = false;
                    DashboardCount(UserId, ddlProject.SelectedValue);
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

    private void FetchProject()
    {
        try
        {
            DataTable DTUser = Session["UserDetails"] as DataTable;
            string UserCode = DTUser.Rows[0]["UserCode"].ToString();

            obj_ML_Dashboard.CreatedUser = UserCode;
            DataTable DT = obj_BL_Dashboard.BL_FetchProject(obj_ML_Dashboard);
            if (DT.Rows.Count > 0)
            {
                ddlProject.DataSource = DT;
                ddlProject.DataValueField = "ProjectId";
                ddlProject.DataTextField = "ProjectName";
                ddlProject.DataBind();
                // ddlProject.Items.Insert(0, "--Select Project--");
                ddlProject.Items.Insert(0, new ListItem("All", "0"));
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }

    private void DashboardCount(string UserCode, string ProjectId)
    {
        try
        {
            obj_ML_Dashboard.CreatedUser = UserCode;
            obj_ML_Dashboard.ProjectCode = ProjectId;
            DataSet DS = obj_BL_Dashboard.BL_DashboardCount(obj_ML_Dashboard);



            // if (DT.Rows.Count > 0)
            //{
            lblTotalEnrollment.Text = DS.Tables[0].Rows[0]["TotalEnrollment"].ToString();
            lblTotalEDPTraining.Text = DS.Tables[1].Rows[0]["TotalEDPTraining"].ToString();
            lblTotalEnterprisesSetup.Text = DS.Tables[2].Rows[0]["TotalEnterpriesTraining"].ToString();
            lblTotalBusinessProgress.Text = DS.Tables[3].Rows[0]["TotalBusinessProgress"].ToString();
            //}
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
            //}
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable DTUser = Session["UserDetails"] as DataTable;
            string UserId = DTUser.Rows[0]["UserCode"].ToString();
            string ProjectId = DTUser.Rows[0]["ProjectCode"].ToString();
            string UserCategory = DTUser.Rows[0]["UserCategory"].ToString();
            if (UserCategory == "1")
            {
                DashboardCount(UserId, ddlProject.SelectedValue);
            }
            else if (UserCategory == "6" || UserCategory == "5" || UserCategory == "4" || UserCategory == "3" || UserCategory == "2" || UserCategory == "7")
            {
                DashboardCount(UserId, ddlProject.SelectedValue);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}