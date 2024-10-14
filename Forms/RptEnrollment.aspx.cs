﻿using System;
using System.Data;
using System.Web;
using BusinessLayer;
using ModelLayer;

public partial class Forms_RptEnrollment : System.Web.UI.Page
{
    ML_Reports obj_ML_Reports=new ML_Reports();
    BL_Reports obj_BL_Reports=new BL_Reports();
    public int UserCategory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            UserCategory = TypeConversionUtility.ToInteger(DT.Rows[0]["UserCategory"].ToString());
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
   
}