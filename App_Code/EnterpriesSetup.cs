using BusinessLayer;
using ModelLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for BusinessProgress
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
[ScriptService]
public class EnterpriesSetup : WebService
{

    [WebMethod(EnableSession = true)]
    public EnterpriesSetupResponse GetEnterpriesSetupList(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();
        var data= obj_BL_Enrollment.GetEnterpriseSetupList(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new EnterpriesSetupResponse()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }
    [WebMethod(EnableSession = true)]
    public bool EnterpriseSetupMoveToEDPTraining(int enrollmentId)
    {
        string CreatedUser;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();
        return obj_BL_Enrollment.EnterpriseSetupMoveToEDPTraining(enrollmentId, TypeConversionUtility.ToInteger(CreatedUser));
    }
}
