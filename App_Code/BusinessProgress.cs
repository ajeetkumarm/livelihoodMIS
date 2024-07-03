using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
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
    public BusinessProgressCustomer GetBusinessProgressDetail()
    {
        BusinessProgressCustomer businessProgressCustomer = new BusinessProgressCustomer();
        businessProgressCustomer.DigitalCategories = BusinessLayer.BusinessProgressCustomerRepository.GetCategoryAndServiceLineList();
        return businessProgressCustomer;
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
}
