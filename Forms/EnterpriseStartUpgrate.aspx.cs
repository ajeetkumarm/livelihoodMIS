using System;
using System.Collections.Generic;
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

public partial class Forms_EnterpriseStartUpgrate : System.Web.UI.Page
{
    ML_EnterprisesTraining obj_ML_EnterprisesTraining = new ML_EnterprisesTraining();
    BL_EnterprisesTraining obj_BL_EnterprisesTraining = new BL_EnterprisesTraining();
    CL_DigitalService obj_CL_DigitalService = new CL_DigitalService();
    string SupportType, PromoteBusiness;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obj_CL_DigitalService = new CL_DigitalService();
            ViewState["VS_obj_CL_ProcureBusiness"] = obj_CL_DigitalService;
            obj_CL_DigitalService.EndService_Xml = "</ProcureBusiness>";
            obj_CL_DigitalService.Root = "<root>";
            obj_CL_DigitalService.CloseRoot = "</root>";
            BindProcureBussinessonPageLoad();
        }
        else
        {
            obj_CL_DigitalService = ViewState["VS_obj_CL_ProcureBusiness"] as CL_DigitalService;
        }
    }    
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            string UserCode = DT.Rows[0]["UserCode"].ToString();
            if (Btn_Submit.Text == "Submit")
            {
                /* multiple selection For How are you planning to promote your business */
                foreach (ListItem itemPromoteBusiness in chkPromoteBusiness.Items)
                {
                    if (itemPromoteBusiness.Selected)
                    {
                        PromoteBusiness += itemPromoteBusiness.Value + ',';
                    }
                }
                if (PromoteBusiness != null)
                {
                    PromoteBusiness = PromoteBusiness.TrimEnd(',');
                }

                /* multiple selection For Type of Support */
                foreach (ListItem itemSupportType in chkSupportType.Items)
                {
                    if (itemSupportType.Selected)
                    {
                        SupportType += itemSupportType.Value + ',';
                    }
                }
                if (SupportType != null)
                {
                    SupportType = SupportType.TrimEnd(',');
                }

                /* Collect Grid Data with cooma (,) seperator */
                string ProcureBusiness = "";
                DataTable dtLocalC = new DataTable();
                dtLocalC.Columns.Add("ProcureBusiness");
                dtLocalC.Columns.Add("DistanceStockProcurement");

                DataRow drLocal = null;
                foreach (GridViewRow row in GvProcureBusiness.Rows)
                {
                    drLocal = dtLocalC.NewRow();
                    Label lblProcureBusiness = (Label)row.FindControl("lblProcureBusiness");
                    Label lblDistanceStockProcurement = (Label)row.FindControl("lblDistanceStockProcurement");
                    drLocal["ProcureBusiness"] = HttpUtility.HtmlEncode(lblProcureBusiness.Text.Trim());
                    drLocal["DistanceStockProcurement"] = HttpUtility.HtmlEncode(lblDistanceStockProcurement.Text.Trim());
                    dtLocalC.Rows.Add(drLocal);
                }
                for (int i = 0; dtLocalC.Rows.Count > i; i++)
                {
                    ProcureBusiness += dtLocalC.Rows[i]["ProcureBusiness"].ToString() + "(" + dtLocalC.Rows[i]["DistanceStockProcurement"] + ")" + ",";
                }
                /* End Collect Grid Data with cooma (,) seperator */

                obj_ML_EnterprisesTraining.EntTrainingId = 0;
                obj_ML_EnterprisesTraining.EnrollmentId = Convert.ToInt32(Request.QueryString["EnrolId"]);
                obj_ML_EnterprisesTraining.StartBusiness = rblStartBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessReasons = ddlNoReasons.SelectedIndex > 0 ? ddlNoReasons.SelectedValue : "";
                obj_ML_EnterprisesTraining.Business = rblBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessWhen = ddlWhen.SelectedIndex > 0 ? ddlWhen.SelectedValue : "";
                obj_ML_EnterprisesTraining.StatusBusiness = ddlStatusBusiness.SelectedIndex > 0 ? ddlStatusBusiness.SelectedValue : "";
                obj_ML_EnterprisesTraining.VillagePopulation = txtVillagePopulation.Text != "" ? txtVillagePopulation.Text : "";
                obj_ML_EnterprisesTraining.BusinessIdea = rblBusinessIdea.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessType = ddlBusinessType.SelectedIndex > 0 ? ddlBusinessType.SelectedValue : "";
                obj_ML_EnterprisesTraining.ProcureBusiness = ProcureBusiness.TrimEnd(',');
                obj_ML_EnterprisesTraining.CurrentBusiness = ddlCurrentBusiness.SelectedIndex > 0 ? ddlCurrentBusiness.SelectedValue : "";
                obj_ML_EnterprisesTraining.RegularFinancialBusiness = rblRegularFinancialBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.HowRegularFinancial = ddlHow.SelectedIndex > 0 ? ddlHow.SelectedValue : "";
                obj_ML_EnterprisesTraining.SettingBusinessType = rblSettingBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.MonthlyRent = txtMonthlyRent.Text != "" ? txtMonthlyRent.Text : "";
                obj_ML_EnterprisesTraining.ExpandBusiness = ddlExpandScaleBusiness.SelectedIndex > 0 ? ddlExpandScaleBusiness.SelectedValue : "";
                obj_ML_EnterprisesTraining.PotentialCustomers = rblPotentialCustomers.SelectedValue;
                obj_ML_EnterprisesTraining.BusinessDistance = ddlDistanceBusiness.SelectedIndex > 0 ? ddlDistanceBusiness.SelectedValue : ""; 
                obj_ML_EnterprisesTraining.ExpectedFootfall = txtExpectedFootfall.Text != "" ? txtExpectedFootfall.Text : "";
                obj_ML_EnterprisesTraining.HowFarBussiness = ddlBusinessExisting.SelectedIndex > 0 ? ddlBusinessExisting.SelectedValue : "";
                obj_ML_EnterprisesTraining.PlanningBusiness = PromoteBusiness;
                obj_ML_EnterprisesTraining.SupportBusiness = rblAdvSupBusiness.SelectedValue;
                obj_ML_EnterprisesTraining.SupportType = SupportType;
                obj_ML_EnterprisesTraining.NotProvidedSupport = ddlSupportNotProvide.SelectedIndex > 0 ? ddlSupportNotProvide.SelectedValue : "";

                obj_ML_EnterprisesTraining.PaidWorker = txtPaidWorkers.Text != "" ? txtPaidWorkers.Text : "";
                obj_ML_EnterprisesTraining.DigitalInclusion = txtDigitalTrnNo.Text != "" ? txtDigitalTrnNo.Text : "";
                obj_ML_EnterprisesTraining.DigitalInclusionDate = txtDigitalInclusionDate.Text != "" ? txtDigitalInclusionDate.Text : "";
                obj_ML_EnterprisesTraining.OwnSmartPhone = rblSmartPhone.SelectedValue;
                obj_ML_EnterprisesTraining.UseSmartPhone = rblSmartPhoneActivity.SelectedValue;
                obj_ML_EnterprisesTraining.SupplyChain = rblSupplyChain.SelectedValue;

                obj_ML_EnterprisesTraining.CreatedBy = UserCode;
                obj_ML_EnterprisesTraining.UpdatedBy = "";
                int x = obj_BL_EnterprisesTraining.BL_InsUpdEntTraining(obj_ML_EnterprisesTraining);
                if (x > 0)
                {
                    // Add Entrepreneur as User
                    BL_UserLogin obj_BL_UserLogin = new BL_UserLogin();
                    obj_BL_UserLogin.EntrepreneurRegisterAsUser(obj_ML_EnterprisesTraining.EnrollmentId);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submit Successfully !'); window.location.href = 'EnterpriesSetup.aspx'", true);
                    //Response.Redirect("~/Forms/EnterpriesSetup.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }           
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        nilGrid();
        obj_CL_DigitalService.Service_XML = "";
        obj_CL_DigitalService.ProcureBusinessCount = 0;

        rblStartBusiness.ClearSelection();
        div_Reasons.Visible = false;
        ddlNoReasons.SelectedIndex = 0;
        rblBusiness.ClearSelection();
        ddlWhen.SelectedIndex = 0;
        ddlStatusBusiness.SelectedIndex = 0;
        txtVillagePopulation.Text = "";
        rblBusinessIdea.ClearSelection();
        ddlBusinessType.SelectedIndex = 0;
        rblRegularFinancialBusiness.ClearSelection();
        ddlHow.SelectedIndex = 0;
        rblSettingBusiness.ClearSelection();
        txtMonthlyRent.Text = "";
        rblPotentialCustomers.ClearSelection();
        ddlDistanceBusiness.SelectedIndex = 0;
        txtExpectedFootfall.Text = "";
        ddlBusinessExisting.SelectedIndex = 0;
        chkPromoteBusiness.ClearSelection();
        rblAdvSupBusiness.ClearSelection();
        chkSupportType.ClearSelection();
        ddlSupportNotProvide.SelectedIndex = 0;
        txtPaidWorkers.Text = "";
        txtDigitalTrnNo.Text = "";
        txtDigitalInclusionDate.Text = "";
        rblSmartPhone.ClearSelection();
        rblSmartPhoneActivity.ClearSelection();
        rblSupplyChain.ClearSelection();

        div_Business.Visible = false;
        div_When.Visible = false;
        div_VillagePopulation.Visible = false;
        div_BusinessIdea.Visible = false;
        div_BusinessType.Visible = false;
        div_CurrentBusiness.Visible = false;
        div_RegFinBusiness.Visible = false;
        div_How.Visible = false;
        div_ExpandBusiness.Visible = false;
        div_PotentialCustomers.Visible = false;
        div_DistanceBusiness.Visible = false;
        div_footfall.Visible = false;
        div_BusinessExisting.Visible = false;
        div_PromoteBusiness.Visible = false;
        div_SuportBusiness.Visible = false;
        div_SupportType.Visible = false;
        div_NotSupportBusiness.Visible = false;
    }
    protected void rblStartBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblStartBusiness.SelectedValue == "Yes")
        {
            div_Business.Visible = true;
            div_Reasons.Visible = false;
            ddlNoReasons.SelectedIndex = 0; 
        }
        else
        {
            div_Reasons.Visible = true;
            rblBusiness.ClearSelection();
            ddlWhen.SelectedIndex = 0;
            txtVillagePopulation.Text = "";
            rblBusinessIdea.ClearSelection();
            ddlBusinessType.SelectedIndex = 0;
            rblRegularFinancialBusiness.ClearSelection();
            ddlHow.SelectedIndex = 0;
            rblPotentialCustomers.ClearSelection();
            ddlDistanceBusiness.SelectedIndex = 0;
            txtExpectedFootfall.Text = "";
            ddlBusinessExisting.SelectedIndex = 0;
            //ddlPlanningBusiness.SelectedIndex = 0;
            rblAdvSupBusiness.ClearSelection();
            //ddlSupportType.SelectedIndex = 0;
            ddlSupportNotProvide.SelectedIndex = 0;


            div_Business.Visible = false;
            div_ProcureBusiness.Visible = false;
            div_When.Visible = false;
            div_VillagePopulation.Visible = false;
            div_BusinessIdea.Visible = false;
            div_BusinessType.Visible = false;
            div_CurrentBusiness.Visible = false;
            div_RegFinBusiness.Visible = false;
            div_How.Visible = false;
            div_SettingBusiness.Visible= false;
            div_ExpandBusiness.Visible = false;
            div_PotentialCustomers.Visible = false;
            div_DistanceBusiness.Visible = false;
            div_footfall.Visible = false;
            div_BusinessExisting.Visible = false;
            div_PromoteBusiness.Visible = false;
            div_SuportBusiness.Visible = false;
            div_SupportType.Visible = false;
            div_NotSupportBusiness.Visible = false;

            div_PaidWorkers.Visible = false;
            txtPaidWorkers.Text = "";
            div_DigitalTrnNo.Visible = false;
            txtDigitalTrnNo.Text = "";
            div_DigitalInclusionDate.Visible = false;
            txtDigitalInclusionDate.Text = "";
            div_SmartPhone.Visible = false;
            rblSmartPhone.ClearSelection();
            div_SmartPhoneActivity.Visible = false;
            rblSmartPhoneActivity.ClearSelection();
            div_SupplyChain.Visible = false;
            rblSupplyChain.ClearSelection();

            div_StatusBusiness.Visible = false;
            ddlStatusBusiness.SelectedIndex = 0;
        }
    }
    protected void rblBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblBusiness.SelectedValue== "New Business" || rblBusiness.SelectedValue == "Innovative Business")
        {
            div_When.Visible = true;
            div_VillagePopulation.Visible = true;
            div_BusinessIdea.Visible = true;
            div_PotentialCustomers.Visible = false;
            div_DistanceBusiness.Visible = false;
            div_footfall.Visible = false;
            div_BusinessExisting.Visible = false;
            div_PromoteBusiness.Visible = false;
            div_SuportBusiness.Visible = false;
            div_SupportType.Visible = false;
            div_NotSupportBusiness.Visible = false;

            ddlWhen.SelectedIndex = 0;
            txtVillagePopulation.Text = "";
            rblBusinessIdea.ClearSelection();
            ddlBusinessType.SelectedIndex = 0;
            rblRegularFinancialBusiness.ClearSelection();
            ddlHow.SelectedIndex = 0;
            
            ddlDistanceBusiness.SelectedIndex = 0;
            txtExpectedFootfall.Text = "";
            ddlBusinessExisting.SelectedIndex = 0;
            //ddlPlanningBusiness.SelectedIndex = 0;
            rblAdvSupBusiness.ClearSelection();
            //ddlSupportType.SelectedIndex = 0;
            ddlSupportNotProvide.SelectedIndex = 0;
            div_ProcureBusiness.Visible = false;
            div_StatusBusiness.Visible = false;
            ddlStatusBusiness.SelectedIndex = 0;    
        }
        else
        {
            div_When.Visible = true;
            div_VillagePopulation.Visible = true;
            div_CurrentBusiness.Visible = true;
            div_ExpandBusiness.Visible = true;
            div_RegFinBusiness.Visible = true;
            div_BusinessIdea.Visible = false;
            div_BusinessType.Visible = false;
            div_How.Visible = false;
            div_DistanceBusiness.Visible = false;
            div_footfall.Visible = false;
            div_BusinessExisting.Visible = false;
            div_PromoteBusiness.Visible = false;
            div_SuportBusiness.Visible = false;
            div_SupportType.Visible = false;
            div_NotSupportBusiness.Visible = false;

            ddlWhen.SelectedIndex = 0;
            txtVillagePopulation.Text = "";
            rblBusinessIdea.ClearSelection();
            ddlBusinessType.SelectedIndex = 0;
            rblRegularFinancialBusiness.ClearSelection();
            ddlHow.SelectedIndex = 0;
            ddlDistanceBusiness.SelectedIndex = 0;
            txtExpectedFootfall.Text = "";
            ddlBusinessExisting.SelectedIndex = 0;
            //ddlPlanningBusiness.SelectedIndex = 0;
            rblAdvSupBusiness.ClearSelection();
            //ddlSupportType.SelectedIndex = 0;
            ddlSupportNotProvide.SelectedIndex = 0;
            div_ProcureBusiness.Visible = true;
            div_StatusBusiness.Visible = true;
        }
        nilGrid();
        obj_CL_DigitalService.Service_XML = "";
        obj_CL_DigitalService.ProcureBusinessCount = 0;
        rblPotentialCustomers.ClearSelection();
        rblSettingBusiness.ClearSelection();
        txtMonthlyRent.Text = "";
    }
    protected void rblBusinessIdea_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblBusinessIdea.SelectedValue=="Yes")
        {
            div_BusinessType.Visible = true;
            div_CurrentBusiness.Visible = false;
            div_RegFinBusiness.Visible = true;
            div_ProcureBusiness.Visible = true;
        }
        else
        {
            div_BusinessType.Visible = true;
            div_CurrentBusiness.Visible = false;
            div_RegFinBusiness.Visible = true;
            div_ProcureBusiness.Visible = true;

            ////////
            //div_BusinessType.Visible = false;
            //div_RegFinBusiness.Visible = false;
            ddlBusinessType.SelectedIndex = 0;
            rblRegularFinancialBusiness.ClearSelection();
            div_How.Visible = false;
            ddlHow.SelectedIndex = 0;
            div_PotentialCustomers.Visible = false;
            rblPotentialCustomers.ClearSelection();
            div_footfall.Visible = false;
            txtExpectedFootfall.Text = "";
            div_DistanceBusiness.Visible = false;
            ddlDistanceBusiness.SelectedIndex = 0;
            div_BusinessExisting.Visible = false;
            ddlBusinessExisting.SelectedIndex = 0;
            div_PromoteBusiness.Visible = false;
            //ddlPlanningBusiness.SelectedIndex = 0;
            div_SuportBusiness.Visible = false;
            rblAdvSupBusiness.ClearSelection();
            div_SupportType.Visible = false;
            //ddlSupportType.SelectedIndex = 0;
            div_NotSupportBusiness.Visible = false;
            ddlSupportNotProvide.SelectedIndex = 0;
            //div_ProcureBusiness.Visible = false;
            obj_CL_DigitalService.Service_XML = "";
            obj_CL_DigitalService.ProcureBusinessCount = 0;
        }
    }
    protected void rblRegularFinancialBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblRegularFinancialBusiness.SelectedValue=="Yes")
        {
            div_How.Visible = true;
            div_PotentialCustomers.Visible = true;
            if (rblBusiness.SelectedValue== "Upgrade Business")
            {
                div_How.Visible = false;
                ddlHow.SelectedIndex = 0;
            }
            div_SettingBusiness.Visible = true;
        }
        else
        {
            div_How.Visible = true;
            div_PotentialCustomers.Visible = true;
            if (rblBusiness.SelectedValue == "Upgrade Business")
            {
                div_How.Visible = false;
                ddlHow.SelectedIndex = 0;
            }
            div_SettingBusiness.Visible = true;

            /////////////////////////


            //div_How.Visible = false;
            ddlHow.SelectedIndex = 0;
            //div_PotentialCustomers.Visible = false;
            rblPotentialCustomers.ClearSelection();
            div_footfall.Visible = false;
            txtExpectedFootfall.Text = "";
            div_DistanceBusiness.Visible = false;
            ddlDistanceBusiness.SelectedIndex = 0;
            div_BusinessExisting.Visible = false;
            ddlBusinessExisting.SelectedIndex = 0;
            div_PromoteBusiness.Visible = false;
            //ddlPlanningBusiness.SelectedIndex = 0;
            div_SuportBusiness.Visible = false;
            rblAdvSupBusiness.ClearSelection();
            div_SupportType.Visible = false;
            //ddlSupportType.SelectedIndex = 0;
            div_NotSupportBusiness.Visible = false;
            ddlSupportNotProvide.SelectedIndex = 0;
            //div_SettingBusiness.Visible = false;
            rblSettingBusiness.ClearSelection();
            div_MonthlyRent.Visible = false;
            txtMonthlyRent.Text = "";
        }
    }
    protected void rblPotentialCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblPotentialCustomers.SelectedValue=="Yes")
        {
            div_footfall.Visible = true;
            div_DistanceBusiness.Visible = true;
            div_BusinessExisting.Visible = true;
            div_PromoteBusiness.Visible = true;
            div_SuportBusiness.Visible = true;
        }
        else
        {
            div_footfall.Visible = true;
            div_DistanceBusiness.Visible = true;
            div_BusinessExisting.Visible = true;
            div_PromoteBusiness.Visible = true;
            div_SuportBusiness.Visible = true;
            ///////////////////////

            //div_footfall.Visible = false;
            txtExpectedFootfall.Text = "";
            //div_DistanceBusiness.Visible = false;
            ddlDistanceBusiness.SelectedIndex = 0;
            //div_BusinessExisting.Visible = false;
            ddlBusinessExisting.SelectedIndex = 0;
            //div_PromoteBusiness.Visible = false;
            //ddlPlanningBusiness.SelectedIndex = 0;
            //div_SuportBusiness.Visible = false;
            rblAdvSupBusiness.ClearSelection();

            div_SupportType.Visible = false;
            //ddlSupportType.SelectedIndex = 0;
            div_NotSupportBusiness.Visible = false;
            ddlSupportNotProvide.SelectedIndex = 0;
        }
    }
    protected void rblAdvSupBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblAdvSupBusiness.SelectedValue=="Yes")
        {
            div_SupportType.Visible = true;
            div_NotSupportBusiness.Visible = true;
            div_PaidWorkers.Visible = true;
            div_DigitalTrnNo.Visible = true;
            div_DigitalInclusionDate.Visible = true;
            div_SmartPhone.Visible = true;
            div_SmartPhoneActivity.Visible = true;
            div_SupplyChain.Visible = true;
        }
        else
        {
            div_SupportType.Visible = true;
            div_NotSupportBusiness.Visible = true;
            div_PaidWorkers.Visible = true;
            div_DigitalTrnNo.Visible = true;
            div_DigitalInclusionDate.Visible = true;
            div_SmartPhone.Visible = true;
            div_SmartPhoneActivity.Visible = true;
            div_SupplyChain.Visible = true;

            /////////////////////////

            //div_SupportType.Visible = false;
            //ddlSupportType.SelectedIndex = 0;
            //div_NotSupportBusiness.Visible = false;
            ddlSupportNotProvide.SelectedIndex = 0;
            //div_PaidWorkers.Visible = false;
            txtPaidWorkers.Text = "";
            //div_DigitalTrnNo.Visible = false;
            txtDigitalTrnNo.Text = "";
            //div_DigitalInclusionDate.Visible = false;
            txtDigitalInclusionDate.Text = "";
            //div_SmartPhone.Visible = false;
            rblSmartPhone.ClearSelection();
            //div_SmartPhoneActivity.Visible = false;
            rblSmartPhoneActivity.ClearSelection();
            //div_SupplyChain.Visible = false;
            rblSupplyChain.ClearSelection();
        }
    }
    public void nilGrid()
    {
        if (obj_CL_DigitalService.Service_XML == "" || obj_CL_DigitalService.Service_XML == null)
        {
            int columncount = GvProcureBusiness.Rows[0].Cells.Count;
            GvProcureBusiness.Rows[0].Cells.Clear();
            GvProcureBusiness.Rows[0].Cells.Add(new TableCell());
            GvProcureBusiness.Rows[0].Cells[0].ColumnSpan = columncount;
            GvProcureBusiness.Rows[0].Cells[0].Text = "No Records Added";
            GvProcureBusiness.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            GvProcureBusiness.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        }
    }
    public void BindProcureBussinessonPageLoad()
    {
        string DescriptionXml_Grid = @"<root><ProcureBusiness ProcureBusiness='ProcureBusiness' DistanceStockProcurement='DistanceStockProcurement' ProcureBusinessCount='0'/></root>";
        StringReader sr = new StringReader(DescriptionXml_Grid);
        XmlTextReader xtr = new XmlTextReader(sr);
        xtr.DtdProcessing = DtdProcessing.Prohibit;
        DataSet ds = new DataSet();
        ds.ReadXml(xtr);
        if (ds.Tables.Count != 0)
        {
            GvProcureBusiness.DataSource = ds;
            GvProcureBusiness.DataBind();
            int columncount = GvProcureBusiness.Rows[0].Cells.Count;
            GvProcureBusiness.Rows[0].Cells.Clear();
            GvProcureBusiness.Rows[0].Cells.Add(new TableCell());
            GvProcureBusiness.Rows[0].Cells[0].ColumnSpan = columncount;
            GvProcureBusiness.Rows[0].Cells[0].Text = "No Records Added";
            GvProcureBusiness.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            GvProcureBusiness.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            GvProcureBusiness.DataSource = null;
            GvProcureBusiness.DataBind();
        }
    }
    protected void GvProcureBusiness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddNew")
        {
            AddServiceLine();

            /* Bind Digital Services */
            //DataTable DT2 = ViewState["DT2"] as DataTable;
            //DropDownList ddlFooterServiceLine = ((DropDownList)GvService.FooterRow.FindControl("ddlFooterServiceLine"));
            //ddlFooterServiceLine.DataSource = DT2;
            //ddlFooterServiceLine.DataValueField = "ServiceId";
            //ddlFooterServiceLine.DataTextField = "ServiceLine";
            //ddlFooterServiceLine.DataBind();
            //ddlFooterServiceLine.Items.Insert(0, "--Select Service Line--");
        }
    }    
    public void AddServiceLine()
    {
        nilGrid();
        try
        {
            string ProcureBusiness = (((DropDownList)GvProcureBusiness.FooterRow.FindControl("ddlFooterProcureBusiness")).SelectedItem.Text);
            string DistanceStockProcurement = (((DropDownList)GvProcureBusiness.FooterRow.FindControl("ddlFooterDistanceStockProcurement")).Text);

            StringBuilder sb = new StringBuilder();
            sb.Append("<ProcureBusiness ProcureBusiness='" + ProcureBusiness +
                         "' DistanceStockProcurement='" + DistanceStockProcurement +
                         "' ProcureBusinessCount='" + obj_CL_DigitalService.ProcureBusinessCount.ToString() + "'/>");

            obj_CL_DigitalService.ProcureBusinessCount++;
            obj_CL_DigitalService.Service_XML += sb.ToString();
            sb.Clear();
            BindProcureBusinessDetails();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void BindProcureBusinessDetails()
    {
        string GridPageLoadXml_Grid = "<root>" + obj_CL_DigitalService.Service_XML + "</root>";
        StringReader sr = new StringReader(GridPageLoadXml_Grid);
        XmlTextReader xtr = new XmlTextReader(sr);
        xtr.DtdProcessing = DtdProcessing.Prohibit;
        DataSet ds = new DataSet();
        ds.ReadXml(xtr);
        if (ds.Tables.Count != 0)
        {
            GvProcureBusiness.DataSource = ds;
            GvProcureBusiness.DataBind();
        }
        else
        {
            GvProcureBusiness.DataSource = null;
            GvProcureBusiness.DataBind();
        }
    }
    protected void GvProcureBusiness_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string GridPageLoadXml_Grid = "<root>" + obj_CL_DigitalService.Service_XML + "</root>";
            StringReader sr = new StringReader(GridPageLoadXml_Grid);
            XmlTextReader xtr = new XmlTextReader(sr);
            xtr.DtdProcessing = DtdProcessing.Prohibit;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(GridPageLoadXml_Grid);
            foreach (XmlNode node in xdoc.SelectNodes("root/ProcureBusiness"))
            {
                if (node.Attributes["ProcureBusinessCount"].Value == Convert.ToString(GvProcureBusiness.DataKeys[e.RowIndex].Values[0].ToString()))
                {
                    node.ParentNode.RemoveChild(node);
                }
            }
            obj_CL_DigitalService.Service_XML = ((xdoc).DocumentElement).InnerXml;
            if (obj_CL_DigitalService.Service_XML != "")
            {
                BindProcureBusinessDetails();
            }
            else
            {
                BindProcureBussinessonPageLoad();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void rblSettingBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        nilGrid();
        if (rblSettingBusiness.SelectedValue== "Rented")
        {
            div_MonthlyRent.Visible = true;
        }
        else
        {
            div_MonthlyRent.Visible = false;
            txtMonthlyRent.Text = "";
        }
    }
    
}