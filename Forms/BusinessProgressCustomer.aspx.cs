using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;

public partial class Forms_BusinessProgressCustomer : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_BusinessProgress obj_ML_BusinessProgress = new ML_BusinessProgress();
    BL_BusinessProgress obj_BL_BusinessProgress = new BL_BusinessProgress();
    CL_DigitalService obj_CL_DigitalService = new CL_DigitalService();
    string aa;
    public int TotalIncome = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FetchDigitalCategory();
            //obj_CL_DigitalService = new CL_DigitalService();
            //ViewState["VS_obj_CL_DigitalService"] = obj_CL_DigitalService;
            //obj_CL_DigitalService.EndService_Xml = "</ServiceDetails>";
            //obj_CL_DigitalService.Root = "<root>";
            //obj_CL_DigitalService.CloseRoot = "</root>";
            //BindServiceDetailsonPageLoad();

            var data = BusinessProgressCustomerRepository.GetCategoryAndServiceLineList();
        }
        else
        {
            obj_CL_DigitalService = ViewState["VS_obj_CL_DigitalService"] as CL_DigitalService;
        }

    }

    
    //private void FetchDigitalCategory()
    //{
    //    try
    //    {
    //        obj_ML_Masters.QueryType = "DigiCat";
    //        obj_ML_Masters.StateId = 0;
    //        obj_ML_Masters.DistrictId = 0;
    //        obj_ML_Masters.BlockId = 0;
    //        obj_ML_Masters.VillageId = 0;
    //        obj_ML_Masters.DigitalCategoryId = 0;
    //        DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
    //        if (DT.Rows.Count > 0)
    //        {
    //            chkDigitalCategory.DataSource = DT;
    //            chkDigitalCategory.DataValueField = "CategoryId";
    //            chkDigitalCategory.DataTextField = "Category";
    //            chkDigitalCategory.DataBind();
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
    //    }
    //}

    //string i = "";
    //protected void chkDigitalCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        nilGrid();
    //        DataTable DT = new DataTable();
    //        DataTable DT2 = new DataTable();
    //        DropDownList ddlFooterServiceLine = ((DropDownList)GvService.FooterRow.FindControl("ddlFooterServiceLine"));
    //        foreach (ListItem item in chkDigitalCategory.Items)
    //        {
    //            if (item.Selected == true)
    //            {
    //                div_SerLine.Visible = true;
    //                obj_ML_Masters.QueryType = "DigiService";
    //                obj_ML_Masters.StateId = 0;
    //                obj_ML_Masters.DistrictId = 0;
    //                obj_ML_Masters.BlockId = 0;
    //                obj_ML_Masters.VillageId = 0;
    //                obj_ML_Masters.DigitalCategoryId = Convert.ToInt32(item.Value);
    //                DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
    //                i += item.Value + ",";

    //                DT2.Merge(DT);
    //                DT2.AcceptChanges();
    //                if (DT2.Rows.Count > 0)
    //                {
    //                    ddlFooterServiceLine.DataSource = DT2;
    //                    ddlFooterServiceLine.DataValueField = "ServiceId";
    //                    ddlFooterServiceLine.DataTextField = "ServiceLine";
    //                    ddlFooterServiceLine.DataBind();
    //                    ddlFooterServiceLine.Items.Insert(0, "--Select Service Line--");
    //                    ViewState["DT2"] = DT2;
    //                }
    //            }
    //        }
    //        ViewState["i"] = i.TrimEnd(',');
    //    }
    //    catch (Exception)
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
    //    }
    //}

    //protected void Btn_Submit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable DT = Session["UserDetails"] as DataTable;
    //        string UserCode = DT.Rows[0]["UserCode"].ToString();
    //        if (Btn_Submit.Text == "Submit")
    //        {
    //            string ServiceLine_Xml = obj_CL_DigitalService.Root + obj_CL_DigitalService.Service_XML + obj_CL_DigitalService.CloseRoot;
    //            obj_ML_BusinessProgress.BusinessProgressId = 0;
    //            obj_ML_BusinessProgress.EnrollMentId = Convert.ToInt32(Request.QueryString["EnrolId"]);
    //            obj_ML_BusinessProgress.StartingBusinessDate = txtBusinessStartingDate.Text != "" ? txtBusinessStartingDate.Text : "";

    //            obj_ML_BusinessProgress.Year = ddlYear.SelectedIndex > 0 ? ddlYear.SelectedValue : "";
    //            obj_ML_BusinessProgress.Month = ddlMonths.SelectedIndex > 0 ? ddlMonths.SelectedValue : "";
    //            obj_ML_BusinessProgress.NoNewCustomer = Convert.ToInt32(txtNewCustomer.Text != "" ? txtNewCustomer.Text : "0");
    //            obj_ML_BusinessProgress.NoRepeatedCustomer = Convert.ToInt32(txtRepeatedCustomer.Text != "" ? txtRepeatedCustomer.Text : "0");
    //            obj_ML_BusinessProgress.ServicesOfferedType = ddlServicesOfferedType.SelectedIndex > 0 ? ddlServicesOfferedType.SelectedValue : "";
    //            obj_ML_BusinessProgress.ServicesProvidedDetails = txtServicesDetails.Text != "" ? txtServicesDetails.Text : "";
    //            obj_ML_BusinessProgress.GovCustomerServices = txtGovCustServices.Text != "" ? txtGovCustServices.Text : "";
    //            obj_ML_BusinessProgress.G2CServices = txtG2CServices.Text != "" ? txtG2CServices.Text : "";


    //            obj_ML_BusinessProgress.IncomefromSell = ViewState["IncomeFromSell"].ToString();
    //            obj_ML_BusinessProgress.CashSellAmount = txtCashSellAmount.Text != "" ? txtCashSellAmount.Text : "";
    //            obj_ML_BusinessProgress.CreditSellAmount = txtCreditSellAmount.Text != "" ? txtCreditSellAmount.Text : "";
    //            obj_ML_BusinessProgress.TotalIncome = txtTotalIncome.Text != "" ? txtTotalIncome.Text : "";
    //            obj_ML_BusinessProgress.Investment = txtInvestment.Text != "" ? txtInvestment.Text : "";
    //            obj_ML_BusinessProgress.ExpenditurefromPurchase = ViewState["ExpFromPurchase"].ToString();
    //            obj_ML_BusinessProgress.CashExpenditure = txtCashExpenditureAmount.Text != "" ? txtCashExpenditureAmount.Text : "";
    //            obj_ML_BusinessProgress.CreditExpenditure = txtCreditExpenditureAmount.Text != "" ? txtCreditExpenditureAmount.Text : "";
    //            obj_ML_BusinessProgress.TotalExpenditure = txtTotalExpenditure.Text != "" ? txtTotalExpenditure.Text : "";
    //            obj_ML_BusinessProgress.LastMonthCredit = txtLastMonthCredit.Text != "" ? txtLastMonthCredit.Text : "";
    //            obj_ML_BusinessProgress.CreditSettlement = txtCreditSettlement.Text != "" ? txtCreditSettlement.Text : "";
    //            obj_ML_BusinessProgress.MonthlyProfitLoss = txtMonthlyProfitLoss.Text != "" ? txtMonthlyProfitLoss.Text : "";

    //            obj_ML_BusinessProgress.PaymentReceived = ViewState["PaymentReceived"].ToString();
    //            obj_ML_BusinessProgress.PaymentReceivedMode = txtPaymentRecivedMode.Text != "" ? txtPaymentRecivedMode.Text : "";
    //            obj_ML_BusinessProgress.CreatedBy = UserCode;
    //            obj_ML_BusinessProgress.UpdatedBy = "";
    //            obj_ML_BusinessProgress.XML_ServiceLine = ServiceLine_Xml;
    //            obj_ML_BusinessProgress.DigitalCategoryId =Convert.ToString(ViewState["i"]);
    //            obj_BL_BusinessProgress.BL_InsBusinessProgress(obj_ML_BusinessProgress);
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submit Successfully !');", true);
    //            Btn_Cancel_Click(sender, e);
    //        }
    //        else
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}
    //protected void Btn_Cancel_Click(object sender, EventArgs e)
    //{
    //    txtBusinessStartingDate.Text = "";
    //    ddlYear.SelectedIndex = 0;
    //    ddlMonths.SelectedIndex = 0;
    //    txtNewCustomer.Text = "";
    //    txtRepeatedCustomer.Text = "";
    //    ddlServicesOfferedType.SelectedIndex = 0;
    //    txtServicesDetails.Text = "";
    //    txtGovCustServices.Text = "";
    //    txtG2CServices.Text = "";
    //    chkIncomeSell.ClearSelection();
    //    txtCashSellAmount.Text = "";
    //    txtCreditSellAmount.Text = "";
    //    txtTotalIncome.Text = "";
    //    txtInvestment.Text = "";
    //    chkExpenditurePurchase.ClearSelection();
    //    txtCashExpenditureAmount.Text = "";
    //    txtCreditExpenditureAmount.Text = "";
    //    txtTotalExpenditure.Text = "";
    //    txtLastMonthCredit.Text = "";
    //    txtCreditSettlement.Text = "";
    //    txtMonthlyProfitLoss.Text = "";
    //    txtPaymentRecivedMode.Text = "";
    //    div_DigiCat.Visible = false;
    //    div_SerLine.Visible = false;
    //    div_SerProvided.Visible = false;
    //    chkPaymentReceived.ClearSelection();
    //    obj_CL_DigitalService.Service_XML = "";
    //    obj_CL_DigitalService.ServiceDetailsCount = 0;
    //    nilGrid();
    //    chkDigitalCategory.ClearSelection();
    //    ViewState["i"] = "";
    //}
    //protected void ddlServicesOfferedType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    obj_CL_DigitalService.Service_XML = "";
    //    obj_CL_DigitalService.ServiceDetailsCount = 0;
    //    nilGrid();
    //    if (ddlServicesOfferedType.SelectedValue == "Digital")
    //    {
    //        div_DigiCat.Visible = true;
    //        div_SerProvided.Visible = false;
    //        txtPaymentRecivedMode.Text = "";
    //        div_G2C.Visible = false;
    //        chkDigitalCategory.ClearSelection();
    //    }
    //    else if (ddlServicesOfferedType.SelectedValue == "Non-Digital")
    //    {
    //        div_DigiCat.Visible = false;
    //        div_SerLine.Visible = false;
    //        div_SerProvided.Visible = true;
    //        txtPaymentRecivedMode.Text = "";
    //        div_G2C.Visible = false;
    //    }
    //    else if (ddlServicesOfferedType.SelectedValue == "Both")
    //    {
    //        div_DigiCat.Visible = true;
    //        div_SerProvided.Visible = true;
    //        div_G2C.Visible = false;
    //        div_SerLine.Visible = false;
    //        chkDigitalCategory.ClearSelection();
    //    }
    //}
    //protected void chkPaymentReceived_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    var values = chkPaymentReceived.Items.Cast<ListItem>().Where(n => n.Selected).Select(n => n.Value).ToList();
    //    if (values.Count == 0)
    //    {
    //        txtPaymentRecivedMode.ReadOnly = false;
    //        txtPaymentRecivedMode.Text = "";
    //    }
    //    else
    //    {
    //        foreach (var item in values)
    //        {
    //            aa = aa + item[0].ToString();
    //            if (aa == "D" || aa == "N")
    //            {
    //                txtPaymentRecivedMode.Text = "100%";
    //                txtPaymentRecivedMode.ReadOnly = true;
    //            }
    //            else if (aa == "DN" || aa == "ND")
    //            {
    //                txtPaymentRecivedMode.ReadOnly = false;
    //                txtPaymentRecivedMode.Text = "";
    //            }
    //            else
    //            {
    //                txtPaymentRecivedMode.ReadOnly = false;
    //                txtPaymentRecivedMode.Text = "";
    //            }
    //        }
    //        ViewState["PaymentReceived"] = aa;
    //    }
    //}    
    //public void nilGrid()
    //{

    //    if (obj_CL_DigitalService.Service_XML == "" || obj_CL_DigitalService.Service_XML == null)
    //    {
    //        int columncount = GvService.Rows[0].Cells.Count;
    //        GvService.Rows[0].Cells.Clear();
    //        GvService.Rows[0].Cells.Add(new TableCell());
    //        GvService.Rows[0].Cells[0].ColumnSpan = columncount;
    //        GvService.Rows[0].Cells[0].Text = "No Records Added";
    //        GvService.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
    //        GvService.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
    //    }
    //}
    //public void BindServiceDetailsonPageLoad()
    //{
    //    string DescriptionXml_Grid = @"<root><ServiceDetails ServiceId='ServiceId' ServiceLine='ServiceLine' NoCustomers='NoCustomers' FilePath='FilePath' FileName='FileName' ServiceDetailsCount='0'/></root>";
    //    StringReader sr = new StringReader(DescriptionXml_Grid);
    //    XmlTextReader xtr = new XmlTextReader(sr);
    //    xtr.DtdProcessing = DtdProcessing.Prohibit;
    //    DataSet ds = new DataSet();
    //    ds.ReadXml(xtr);
    //    if (ds.Tables.Count != 0)
    //    {
    //        GvService.DataSource = ds;
    //        GvService.DataBind();
    //        int columncount = GvService.Rows[0].Cells.Count;
    //        GvService.Rows[0].Cells.Clear();
    //        GvService.Rows[0].Cells.Add(new TableCell());
    //        GvService.Rows[0].Cells[0].ColumnSpan = columncount;
    //        GvService.Rows[0].Cells[0].Text = "No Records Added";
    //        GvService.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
    //        GvService.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        GvService.DataSource = null;
    //        GvService.DataBind();
    //    }
    //}
    //protected void GvService_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "AddNew")
    //    {
    //        AddServiceLine();

    //        /* Bind Digital Services */
    //        DataTable DT2 = ViewState["DT2"] as DataTable;
    //        DropDownList ddlFooterServiceLine = ((DropDownList)GvService.FooterRow.FindControl("ddlFooterServiceLine"));
    //        ddlFooterServiceLine.DataSource = DT2;
    //        ddlFooterServiceLine.DataValueField = "ServiceId";
    //        ddlFooterServiceLine.DataTextField = "ServiceLine";
    //        ddlFooterServiceLine.DataBind();
    //        ddlFooterServiceLine.Items.Insert(0, "--Select Service Line--");
    //    }
    //}
    //public static string GenerateRandomNumericCode(int length)
    //{
    //    string characterSet = "0123456789012345";
    //    Random random = new Random();
    //    string randomCode = new string(
    //        Enumerable.Repeat(characterSet, length)
    //            .Select(set => set[random.Next(set.Length)])
    //            .ToArray());
    //    return randomCode;
    //}
    //public void AddServiceLine()
    //{
    //    nilGrid();
    //    try
    //    {
    //        string FileName = string.Empty;
    //        string FilePath = string.Empty;

    //        string ServiceId = (((DropDownList)GvService.FooterRow.FindControl("ddlFooterServiceLine")).SelectedValue);
    //        string ServiceLine = (((DropDownList)GvService.FooterRow.FindControl("ddlFooterServiceLine")).SelectedItem.Text);
    //        ServiceLine = ServiceLine.Substring(0, ServiceLine.Length).Replace("&", "and");
    //        string NoCustomers = (((TextBox)GvService.FooterRow.FindControl("txtFooterNoCustomers")).Text);
    //        FileUpload fileupload = ((FileUpload)GvService.FooterRow.FindControl("FooterUpload"));
    //        if (fileupload.HasFile)
    //        {

    //            FileName = GenerateRandomNumericCode(6) + Path.GetExtension(fileupload.PostedFile.FileName);
    //            FileName = FileName.Substring(0, FileName.Length).Replace("&", "and");
    //            FilePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DocPath"] + "/" + FileName);
    //            fileupload.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DocPath"] + "/" + FileName));
    //        }

    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<ServiceDetails ServiceId='" + ServiceId +
    //                     "' ServiceLine='" + ServiceLine +
    //                     "' NoCustomers='" + NoCustomers +
    //                     "' FilePath='" + FilePath +
    //                     "' FileName='" + FileName +
    //                     "' ServiceDetailsCount='" + obj_CL_DigitalService.ServiceDetailsCount.ToString() + "'/>");

    //        obj_CL_DigitalService.ServiceDetailsCount++;
    //        obj_CL_DigitalService.Service_XML += sb.ToString();
    //        sb.Clear();
    //        BindServiceDetails();

    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}
    //public void BindServiceDetails()
    //{
    //    string GridPageLoadXml_Grid = "<root>" + obj_CL_DigitalService.Service_XML + "</root>";
    //    StringReader sr = new StringReader(GridPageLoadXml_Grid);
    //    XmlTextReader xtr = new XmlTextReader(sr);
    //    xtr.DtdProcessing = DtdProcessing.Prohibit;
    //    DataSet ds = new DataSet();
    //    ds.ReadXml(xtr);
    //    if (ds.Tables.Count != 0)
    //    {
    //        GvService.DataSource = ds;
    //        GvService.DataBind();
    //    }
    //    else
    //    {
    //        GvService.DataSource = null;
    //        GvService.DataBind();
    //    }
    //}
    //protected void GvService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        string GridPageLoadXml_Grid = "<root>" + obj_CL_DigitalService.Service_XML + "</root>";
    //        StringReader sr = new StringReader(GridPageLoadXml_Grid);
    //        XmlTextReader xtr = new XmlTextReader(sr);
    //        xtr.DtdProcessing = DtdProcessing.Prohibit;
    //        XmlDocument xdoc = new XmlDocument();
    //        xdoc.LoadXml(GridPageLoadXml_Grid);
    //        foreach (XmlNode node in xdoc.SelectNodes("root/ServiceDetails"))
    //        {
    //            if (node.Attributes["ServiceDetailsCount"].Value == Convert.ToString(GvService.DataKeys[e.RowIndex].Values[0].ToString()))
    //            {
    //                node.ParentNode.RemoveChild(node);
    //            }
    //        }
    //        obj_CL_DigitalService.Service_XML = ((xdoc).DocumentElement).InnerXml;
    //        if (obj_CL_DigitalService.Service_XML != "")
    //        {
    //            BindServiceDetails();
    //        }
    //        else
    //        {
    //            BindServiceDetailsonPageLoad();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}
    //protected void chkIncomeSell_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    string IncPayment = "";
    //    var values = chkIncomeSell.Items.Cast<ListItem>().Where(n => n.Selected).Select(n => n.Value).ToList();
    //    if (values.Count == 0)
    //    {
    //        txtCashSellAmount.ReadOnly = true;
    //        txtCreditSellAmount.ReadOnly = true;
    //    }
    //    else
    //    {
    //        foreach (ListItem item in chkIncomeSell.Items)
    //        {
    //            if (item.Selected)
    //            {
    //                IncPayment += item.Text + ",";
    //                //IncPayment += item.Value + ",";

    //            }
    //        }
    //        IncPayment = IncPayment.TrimEnd(',');
    //        if (IncPayment == "Cash Sell")
    //        {
    //            txtCashSellAmount.ReadOnly = false;
    //            txtCreditSellAmount.ReadOnly = true;
    //        }
    //        if (IncPayment == "Credit Sell")
    //        {
    //            txtCreditSellAmount.ReadOnly = false;
    //            txtCashSellAmount.ReadOnly = true;
    //        }
    //        if (IncPayment == "Cash Sell,Credit Sell")
    //        {
    //            txtCashSellAmount.ReadOnly = false;
    //            txtCreditSellAmount.ReadOnly = false;
    //        }
    //        ViewState["IncomeFromSell"] = IncPayment;
    //    }
    //}

    //protected void chkExpenditurePurchase_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    string ExpPayment = "";
    //    var values = chkExpenditurePurchase.Items.Cast<ListItem>().Where(n => n.Selected).Select(n => n.Value).ToList();
    //    if (values.Count == 0)
    //    {
    //        txtCashExpenditureAmount.ReadOnly = true;
    //        txtCreditExpenditureAmount.ReadOnly = true;
    //    }
    //    else
    //    {
    //        foreach (ListItem item in chkExpenditurePurchase.Items)
    //        {
    //            if (item.Selected)
    //            {
    //                ExpPayment += item.Text + ",";

    //            }
    //        }
    //        ExpPayment = ExpPayment.TrimEnd(',');
    //        if (ExpPayment == "Cash Expenditure")
    //        {
    //            txtCashExpenditureAmount.ReadOnly = false;
    //            txtCreditExpenditureAmount.ReadOnly = true;
    //        }
    //        if (ExpPayment == "Credit Expenditure")
    //        {
    //            txtCreditExpenditureAmount.ReadOnly = false;
    //            txtCashExpenditureAmount.ReadOnly = true;
    //        }
    //        if (ExpPayment == "Cash Expenditure,Credit Expenditure")
    //        {
    //            txtCashExpenditureAmount.ReadOnly = false;
    //            txtCreditExpenditureAmount.ReadOnly = false;
    //        }
    //        ViewState["ExpFromPurchase"] = ExpPayment;
    //    }
    //}

    //protected void txtCashSellAmount_TextChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    TotalIncome = Convert.ToInt32(txtCashSellAmount.Text.Trim() != "" ? txtCashSellAmount.Text.Trim() : "0") + Convert.ToInt32(txtCreditSellAmount.Text.Trim() != "" ? txtCreditSellAmount.Text.Trim() : "0");     
    //    txtTotalIncome.Text = TotalIncome.ToString();

    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}

    //protected void txtCreditSellAmount_TextChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    int TotalIncome = Convert.ToInt32(txtCashSellAmount.Text.Trim() != "" ? txtCashSellAmount.Text.Trim() : "0") + Convert.ToInt32(txtCreditSellAmount.Text.Trim() != "" ? txtCreditSellAmount.Text.Trim() : "0");
    //    txtTotalIncome.Text = TotalIncome.ToString();

    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                      Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                      Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}

    //protected void txtCashExpenditureAmount_TextChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    int TotalExpenditure = Convert.ToInt32(txtCashExpenditureAmount.Text.Trim() != "" ? txtCashExpenditureAmount.Text.Trim() : "0") + Convert.ToInt32(txtCreditExpenditureAmount.Text.Trim() != "" ? txtCreditExpenditureAmount.Text.Trim() : "0");
    //    txtTotalExpenditure.Text = TotalExpenditure.ToString();

    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}

    //protected void txtCreditExpenditureAmount_TextChanged(object sender, EventArgs e)
    //{
    //    nilGrid();
    //    int TotalExpenditure = Convert.ToInt32(txtCashExpenditureAmount.Text.Trim() != "" ? txtCashExpenditureAmount.Text.Trim() : "0") + Convert.ToInt32(txtCreditExpenditureAmount.Text.Trim() != "" ? txtCreditExpenditureAmount.Text.Trim() : "0");
    //    txtTotalExpenditure.Text = TotalExpenditure.ToString();

    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                     Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                     Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}

    //protected void txtInvestment_TextChanged1(object sender, EventArgs e)
    //{
    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}

    //protected void txtCreditSettlement_TextChanged(object sender, EventArgs e)
    //{
    //    /* Profit and Loss Calculation */
    //    int ProfitLoss = (Convert.ToInt32(txtTotalIncome.Text.Trim() != "" ? txtTotalIncome.Text.Trim() : "0")) - (Convert.ToInt32(txtTotalExpenditure.Text.Trim() != "" ? txtTotalExpenditure.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtInvestment.Text.Trim() != "" ? txtInvestment.Text.Trim() : "0") +
    //                                    Convert.ToInt32(txtCreditSettlement.Text.Trim() != "" ? txtCreditSettlement.Text.Trim() : "0"));

    //    txtMonthlyProfitLoss.Text = ProfitLoss.ToString();
    //    if (txtMonthlyProfitLoss.Text.Contains("-"))
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtMonthlyProfitLoss.ForeColor = System.Drawing.Color.Black;
    //    }
    //}
}