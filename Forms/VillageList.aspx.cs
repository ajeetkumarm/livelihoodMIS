using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using ModelLayer;
using PagerControl;

public partial class Forms_VillageList : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_Village obj_ML_Village = new ML_Village();
    BL_Village obj_BL_Village = new BL_Village();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            VillageDetails();
        }
    }

    private void VillageDetails()
    {
        try
        {
            string villageName = "";
            var startPage = !String.IsNullOrEmpty(Request.QueryString[WebConstant.QueryString.PagerQueryString]) ? TypeConversionUtility.ToInteger(Request.QueryString[WebConstant.QueryString.PagerQueryString]) : 1;
            var pageLength = !String.IsNullOrEmpty(Request.QueryString[WebConstant.QueryString.PageLengthQueryString]) ? TypeConversionUtility.ToInteger(Request.QueryString[WebConstant.QueryString.PageLengthQueryString]) : WebConstant.PageLength;

            if (!string.IsNullOrWhiteSpace(Request.QueryString[WebConstant.QueryString.IsSearchQueryString]))
            {
                txtSearch.Text = Convert.ToString(Request.QueryString[WebConstant.QueryString.IsSearchQueryString]);
                villageName = txtSearch.Text;
            }





            var noOfPages = 0;



            var villageList = obj_BL_Village.GetVillages(startPage, pageLength, villageName);
            if (villageList != null)
            {
                var totalRecords = villageList[0].TotalCount;
                var pageCheck = totalRecords % pageLength;
                if (pageCheck > 0)
                {
                    noOfPages = (totalRecords / pageLength) + 1;
                }
                else
                {
                    noOfPages = totalRecords / pageLength;
                }
                rpt_VillageDetails.DataSource = villageList;
                rpt_VillageDetails.DataBind();
                PagerBuilder.BuildPager(startPage, pageLength, noOfPages, totalRecords, false, litPager, WebConstant.PagerTextBoxId, WebConstant.QueryString.PagerQueryString);
            }
            else
            {
                rpt_VillageDetails.DataSource = null;
                rpt_VillageDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }

    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int VillageId = Convert.ToInt32(btn.CommandArgument);
                
               Response.Redirect("~/Forms/Village.aspx?VillageId=" + VillageId);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('System error !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int VillageId = Convert.ToInt32(btn.CommandArgument);
                obj_ML_Village.Qstring = "Delete";
                obj_ML_Village.StateId = 0;
                obj_ML_Village.DistrictId = 0;
                obj_ML_Village.BlockId = 0;
                obj_ML_Village.VillageId = VillageId;
                obj_ML_Village.VillageName = "";
                obj_ML_Village.CreatedBy = "";
                obj_ML_Village.UpdatedBy = "";
                int x = obj_BL_Village.BL_InsUpdDelVillage(obj_ML_Village);
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Record Deleted Successfully !');", true);
                    VillageDetails();
                    //btn_Cancel_Click(sender, e);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('System error !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            MakeQueryString();
        }
        catch (Exception)
        {
        }
    }

    private void MakeQueryString()
    {
        var stringBuilder = new StringBuilder();
        var currentHandler = (Page)HttpContext.Current.CurrentHandler;
        var currentPage = currentHandler.AppRelativeVirtualPath;
        stringBuilder.AppendFormat("{0}?", currentPage);
       
        if (!string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            stringBuilder.AppendFormat("{0}={1}&", WebConstant.QueryString.IsSearchQueryString, txtSearch.Text);
        }
        
        var redirectUrl = stringBuilder.ToString().TrimEnd('?', '&');
        Response.Redirect(redirectUrl);
    }
    private void ExportToExcel()
    {
        try
        {
            var dt = obj_BL_Village.GetVillageListExport();
            if (dt.Rows.Count > 0)
            {
                GridView gv = new GridView();
                gv.DataSource = dt;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=VillageList.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Data not found !');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Btn_Export_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}