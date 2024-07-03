using System;
using BusinessLayer;
using ModelLayer;

public partial class Forms_BusinessProgressCustomer : System.Web.UI.Page
{
    public int EnrollmentId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        EnrollmentId = TypeConversionUtility.ToInteger(Request.QueryString["EnrolId"]);
        if (EnrollmentId == 0)
        {
            Response.Redirect("BusinessProgressList.aspx");
        }
        if (!IsPostBack)
        {
            var data = BusinessProgressCustomerRepository.GetCategoryAndServiceLineList();
        }
    }
}