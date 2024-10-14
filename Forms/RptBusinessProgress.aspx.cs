using ModelLayer;
using System;
using System.Data;
using System.Web;

public partial class Forms_RptBusinessProgress : System.Web.UI.Page
{
    public int UserCategory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserDetails"] != null)
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            UserCategory = TypeConversionUtility.ToInteger(DT.Rows[0]["UserCategory"].ToString());
            if (!IsPostBack)
            {
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
}