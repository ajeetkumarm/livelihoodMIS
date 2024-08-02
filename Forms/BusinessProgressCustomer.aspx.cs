using System;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_BusinessProgressCustomer : System.Web.UI.Page
{
    public int EnrollmentId = 0;
    public int UserCategory = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        EnrollmentId = TypeConversionUtility.ToInteger(Request.QueryString["EnrolId"]);
        DataTable DT = Session["UserDetails"] as DataTable;
       
        if (DT != null && DT.Rows.Count > 0)
        {
            UserCategory = Convert.ToInt16(DT.Rows[0]["UserCategory"].ToString());
        }
        else
        {
            Response.Redirect("/Login.aspx");
        }

        if (EnrollmentId == 0)
        {
            EnrollmentId = TypeConversionUtility.ToInteger(DT.Rows[0]["EnrollmentId"]);
        }

        if (EnrollmentId == 0 && UserCategory != 8)
        {
            Response.Redirect("BusinessProgressList.aspx");
        }
        //if (!IsPostBack)
        //{
        //    var data = BusinessProgressCustomerRepository.GetCategoryAndServiceLineList();
        //}
    }
}