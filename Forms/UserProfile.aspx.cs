using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProfileDetails();
        }
    }

    private void ProfileDetails()
    {
        try
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            string UserCode = DT.Rows[0]["UserCode"].ToString();
            lblUserFullName.Text = DT.Rows[0]["FullName"].ToString();
            lblUserRole.Text = DT.Rows[0]["Category"].ToString();
            lblUserName.Text = DT.Rows[0]["FullName"].ToString();
            lblUserType.Text = DT.Rows[0]["Category"].ToString();
            //lblOfficeAddress.Text = DT.Rows[0]["OfficeAddress"].ToString();
            lblPhoneNo.Text = DT.Rows[0]["ContactNo"].ToString();
            lblUserEmail.Text = DT.Rows[0]["Email"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}