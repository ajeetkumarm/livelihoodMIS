using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using BusinessLayer;
using ModelLayer;

/// <summary>
/// Summary description for BusinessProgress
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
[ScriptService]
public class BusinessProgress : WebService
{
    [WebMethod(EnableSession = true)]
    public BusinessProgressCustomer GetBusinessProgressDetail(int enrollmentId, int businessProgressId)
    {
        //BusinessProgressCustomer businessProgressCustomer = new BusinessProgressCustomer();
        //businessProgressCustomer.DigitalCategories = BusinessProgressCustomerRepository.GetCategoryAndServiceLineList();
        //businessProgressCustomer.EnrollMentId = enrollmentId;
        //string startingBusinessDate= BusinessProgressCustomerRepository.GetBusinessProgressStartingBusinessDate(enrollmentId);
        //if (!string.IsNullOrEmpty(startingBusinessDate))
        //{
        //    businessProgressCustomer.StartingBusinessDate = TypeConversionUtility.ToDateTime(startingBusinessDate).ToString();
        //}
        return BusinessProgressCustomerRepository.GetBusinessProgressCustomerByBusinessProgressId(enrollmentId, businessProgressId);
    }

    [WebMethod(EnableSession = true)]
    public object SaveBusinessProgress(BusinessProgressCustomer model)
    {
        var dbResponse = BusinessLayer.BusinessProgressCustomerRepository.SaveBusinessProgressCustomer(model);
        if (dbResponse)
        {
            return new { success = true, message = "Data saved successfully", businessProgressId = model.BusinessProgressId };
        }
        else
        {
            return new { success = false, message = "Failed to save data", businessProgressId = model.BusinessProgressId };
        }
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UploadFile()
    {
        var files = HttpContext.Current.Request.Files;
        string uploadPath = Server.MapPath("~/UploadedFile/BusinessProgress/");
        IList<FileUploadResponse> fileUploadResponses = new List<FileUploadResponse>();
        if (files != null && files.Count > 0)
        {
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string filePath = FileUploader.UploadFile(uploadPath, file);
                fileUploadResponses.Add(new FileUploadResponse
                {
                    FileName = filePath
                });
            }
        }
        var response = fileUploadResponses.FirstOrDefault();
        var jsonResponse = new JavaScriptSerializer().Serialize(response);

        HttpContext.Current.Response.ContentType = "application/json";
        HttpContext.Current.Response.Write(jsonResponse);
        // return fileUploadResponses.FirstOrDefault();
    }

    [WebMethod(EnableSession = true)]
    public BusinessProgessCustomerResponse GetBusinessProgressCustomerList(int enrollmentId, int draw, int pageNumber, int pageSize, string search)
    {

        var data = BusinessProgressCustomerRepository.GetBusinessProgressCustomerList(enrollmentId, pageNumber, pageSize, search).ToList();

        var resData = new BusinessProgessCustomerResponse()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }
    [WebMethod(EnableSession = true)]
    public bool CheckBusinessProgressCustomerDataExist(int businessProgressId, int enrollmentId, int year, string month)
    {
        return BusinessProgressCustomerRepository.CheckBusinessProgressCustomerDataExist(businessProgressId, enrollmentId, year, month);
    }

    [WebMethod(EnableSession = true)]
    public CustomListResponse<BusinessProgressList> GetBusinessProgressList(int draw, int pageNumber, int pageSize, string search)
    {
        string CreatedUser, projectCode;
        DataTable DT = Session["UserDetails"] as DataTable;
        CreatedUser = DT.Rows[0]["UserCode"].ToString();
        projectCode = DT.Rows[0]["ProjectCode"].ToString();
        BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();
        var data = obj_BL_Enrollment.GetBusinessProgressList(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), pageNumber, pageSize, search).ToList();

        var resData = new CustomListResponse<BusinessProgressList>()
        {
            draw = draw,
            recordsTotal = data.Count > 0 ? data[0].TotalCount : 0,
            recordsFiltered = data.Count,
            data = data
        };
        return resData;
    }
    [WebMethod(EnableSession = true)]
    public bool UpdateBusinessProgressStatus(BusinessProgressStatusDTO businessProgressStatus)
    {
        return BusinessProgressCustomerRepository.SaveBusinessProgressStatus(businessProgressStatus);
    }
    [WebMethod(EnableSession = true)]
    public BusinessProgressStatusDTO GetBusinessProgressStatus(int enrollmentId)
    {
        return BusinessProgressCustomerRepository.GetBusinessProgressStatus(enrollmentId);
    }
    [WebMethod(EnableSession = true)]
    public List<BusinessProgressCustomerCountEntity> GetBusinessProgressServiceLineCount(int enrollmentId)
    {
        return BusinessProgressCustomerRepository.GetBusinessProgressServiceLineCount(enrollmentId);
    }
}
