using BusinessLayer;
using ModelLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


/// <summary>
/// Summary description for Report
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
[ScriptService]
public class Report : WebService
{

    [WebMethod(EnableSession = true)]
    public CustomListResponse<EnrollmentReportList> GetEnrollmentDetails(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Reports objReport = new BL_Reports();
        var data = objReport.RptEnrollmentDetails(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new CustomListResponse<EnrollmentReportList>()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }

    [WebMethod(EnableSession = true)]
    public CustomListResponse<TrainingReportList> GetTrainingDetails(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Reports objReport = new BL_Reports();
        var data = objReport.RptTrainingDetails(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new CustomListResponse<TrainingReportList>()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }

    [WebMethod(EnableSession = true)]
    public CustomListResponse<EnterpriesTrainingReportList> GetEnterpriesTrainingDetails(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Reports objReport = new BL_Reports();
        var data = objReport.RptEnterpriesTrainingDetails(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new CustomListResponse<EnterpriesTrainingReportList>()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }
    [WebMethod(EnableSession = true)]
    public CustomListResponse<BusinessProgressReportList> GetRptBusinessProgressDetails(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Reports objReport = new BL_Reports();
        var data = objReport.RptBusinessProgressDetails(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new CustomListResponse<BusinessProgressReportList>()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }
}
