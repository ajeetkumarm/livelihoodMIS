using BusinessLayer;
using ModelLayer;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;

public partial class Forms_RptEnrollmentExport : System.Web.UI.Page
{
    int exportType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        exportType = TypeConversionUtility.ToInteger(Request.QueryString["ExportType"]);
        ExportEnrollmentDetailsToExcel();
        //ClosePage();
    }
    private void ClosePage()
    {
       // Response.Write("<script>window.close();</script>");
    }
    public void ExportEnrollmentDetailsToExcel()
    {
        try
        {
            string CreatedUser, projectCode;
            DataTable DT = Session["UserDetails"] as DataTable;
            if (DT == null)
            {
                Response.Redirect("/Login.aspx");
            }

            CreatedUser = DT.Rows[0]["UserCode"].ToString();
            projectCode = DT.Rows[0]["ProjectCode"].ToString();
            int UserCategory = Convert.ToInt32(DT.Rows[0]["UserCategory"].ToString());
            BL_Reports objReport = new BL_Reports();
            DataTable dataTable = new DataTable();

            string strSheetName = "Enrollment";
            string strFileName = "Report_Enrollment_" + DateTime.Now.ToLocalTime().ToString() + ".xlsx";

            if (exportType == 1)
            {
                dataTable = objReport.RptEnrollmentDetailDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "", UserCategory);
            }
            else if (exportType == 2)
            {
                strFileName = "Report_Training_" + DateTime.Now.ToLocalTime().ToString() + ".xlsx";
                strSheetName = "Training";
                dataTable = objReport.RptTrainingDetailsDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "");
            }
            else if (exportType == 3)
            {
                strFileName = "Report_Enterpries_Training_" + DateTime.Now.ToLocalTime().ToString() + ".xlsx";
                strSheetName = "Enterpries Training";
                dataTable = objReport.RptEnterpriesTrainingDetailsDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "");
            }
            else if (exportType == 4)
            {
                strFileName = "Report_Business_Progress_Training_" + DateTime.Now.ToLocalTime().ToString() + ".xlsx";
                strSheetName = "Business Progress";
                dataTable = objReport.RptBusinessProgressDetailsDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "", UserCategory);
            }
            else if (exportType == 5)
            {
                strFileName = "Report_Consolidated_" + DateTime.Now.ToLocalTime().ToString() + ".xlsx";
                strSheetName = "Business Progress";
                dataTable = objReport.RptConsolidatedDT(Convert.ToInt32(CreatedUser), Convert.ToInt32(projectCode), 0, int.MaxValue, "", UserCategory);
            }
            using (var workbook = new XSSFWorkbook())
            {
                ISheet sheet = workbook.CreateSheet(strSheetName);

                // Add header row
                IRow headerRow = sheet.CreateRow(0);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(dataTable.Columns[i].ColumnName);
                }

                // Add data rows
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    IRow dataRow = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataRow.CreateCell(j).SetCellValue(dataTable.Rows[i][j].ToString());
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.Write(stream);
                    byte[] excelData = stream.ToArray();

                    // Send the Excel file to the client
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename="+ strFileName);
                    Response.BinaryWrite(excelData);
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            //Response.End();
        }
        finally
        {
            //Response.End();
            ClosePage();
        }
    }
}