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

    //[WebMethod(EnableSession = true)]

    //public void ExportEnrollmentDetailsToExcel()
    //{
    //    string CreatedUser, projectCode;
    //    DataTable DT = Session["UserDetails"] as DataTable;
    //    CreatedUser = DT.Rows[0]["UserCode"].ToString();
    //    projectCode = DT.Rows[0]["ProjectCode"].ToString();
    //    BL_Reports objReport = new BL_Reports();
    //    DataTable dataTable = objReport.RptEnrollmentDetailDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "");

    //    using (var workbook = new XSSFWorkbook() )
    //    {
    //        ISheet sheet = workbook.CreateSheet("Sheet1");

    //        // Add header row
    //        IRow headerRow = sheet.CreateRow(0);
    //        for (int i = 0; i < dataTable.Columns.Count; i++)
    //        {
    //            headerRow.CreateCell(i).SetCellValue(dataTable.Columns[i].ColumnName);
    //        }

    //        // Add data rows
    //        for (int i = 0; i < dataTable.Rows.Count; i++)
    //        {
    //            IRow dataRow = sheet.CreateRow(i + 1);
    //            for (int j = 0; j < dataTable.Columns.Count; j++)
    //            {
    //                dataRow.CreateCell(j).SetCellValue(dataTable.Rows[i][j].ToString());
    //            }
    //        }

    //        using (var stream = new MemoryStream())
    //        {
    //            workbook.Write(stream);
    //            byte[] excelData = stream.ToArray();

    //            // Send the Excel file to the client
    //            Context.Response.Clear();
    //            Context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //            Context.Response.AddHeader("content-disposition", "attachment; filename=Sample.xlsx");
    //            Context.Response.BinaryWrite(excelData);
    //            Context.Response.End();
    //        }
    //    }

    //    //using (var workbook = new XLWorkbook())
    //    //{
    //    //    var worksheet = workbook.Worksheets.Add(dtEnrollment, "Enrollment Details");

    //    //    using (var stream = new MemoryStream())
    //    //    {
    //    //        workbook.SaveAs(stream);
    //    //        byte[] excelData = stream.ToArray();

    //    //        // Send the Excel file to the client
    //    //        Context.Response.Clear();
    //    //        Context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    //        Context.Response.AddHeader("content-disposition", "attachment; filename=Enrollment_Details.xlsx");
    //    //        Context.Response.BinaryWrite(excelData);
    //    //        Context.Response.End();
    //    //    }
    //    //}

    //    //using (ExcelPackage package = new ExcelPackage())
    //    //{
    //    //    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Enrollment Details");
    //    //    worksheet.Cells["A1"].LoadFromDataTable(dtEnrollment, true);
    //    //    HttpContext.Current.Response.Clear();
    //    //    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=EnrollmentDetails.xlsx");
    //    //    HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
    //    //    HttpContext.Current.Response.End();
    //    //}
    //}
}
