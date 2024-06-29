﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;


public partial class Forms_RptTraining : System.Web.UI.Page
{
    ML_Reports obj_ML_Reports = new ML_Reports();
    BL_Reports obj_BL_Reports = new BL_Reports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            if (!IsPostBack)
            {
                BindTrainingList();
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
    private void BindTrainingList()
    {
        try
        {
            DataTable DTuser = Session["UserDetails"] as DataTable;
            string UserCode = DTuser.Rows[0]["UserCode"].ToString();
            string ProjectCode = DTuser.Rows[0]["ProjectCode"].ToString();

            obj_ML_Reports.CreatedUser = UserCode;
            obj_ML_Reports.ProjectCode = ProjectCode;
            DataTable DT = obj_BL_Reports.BL_RptTrainingDetails(obj_ML_Reports);
            if (DT.Rows.Count > 0)
            {
                rpt_Training.DataSource = DT;
                rpt_Training.DataBind();
            }
            else
            {
                rpt_Training.DataSource = null;
                rpt_Training.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
}