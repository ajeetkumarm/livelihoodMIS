using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using ModelLayer;

public partial class Forms_Enrollment : System.Web.UI.Page
{
    ML_Masters obj_ML_Masters = new ML_Masters();
    BL_Masters obj_BL_Masters = new BL_Masters();
    ML_Enrollment obj_ML_Enrollment = new ML_Enrollment();
    BL_Enrollment obj_BL_Enrollment = new BL_Enrollment();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DateTime dob = Convert.ToDateTime("1988/12/20");
            //string text = CalculateYourAge(dob);
            FetchTheme();
            FetchState(0);
            FetchSHG();
            FetchCast();
            FetchEconomicStatus();
            FetchEducation();
            FetchScheme();
        }
    }
    private void FetchTheme()
    {
        try
        {
            obj_ML_Masters.QueryType = "Theme";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlTheme.DataSource = DT;
                ddlTheme.DataValueField = "ThemeShortName";
                ddlTheme.DataTextField = "ThemeName";
                ddlTheme.DataBind();
                ddlTheme.Items.Insert(0, "--Select Theme--");
                ddlTheme.SelectedIndex = 1;
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchState(int StateId)
    {
        try
        {
            obj_ML_Masters.QueryType = "State";
            obj_ML_Masters.StateId = StateId;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlState.DataSource = DT;
                ddlState.DataValueField = "StateId";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "District";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlDistrict.DataSource = DT;
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select District--","0"));
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "Block";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlBlock.DataSource = DT;
                ddlBlock.DataValueField = "BlockId";
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataBind();
                ddlBlock.Items.Insert(0, new ListItem("--Select Block--", "0"));
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obj_ML_Masters.QueryType = "Village";
            obj_ML_Masters.StateId = Convert.ToInt32(ddlState.SelectedValue);
            obj_ML_Masters.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            obj_ML_Masters.BlockId = Convert.ToInt32(ddlBlock.SelectedValue);
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlVillage.DataSource = DT;
                ddlVillage.DataValueField = "VillageId";
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, new ListItem("--Select Village--", "0"));
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchSHG()
    {
        try
        {
            obj_ML_Masters.QueryType = "SHG";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlShgType.DataSource = DT;
                ddlShgType.DataValueField = "SHGId";
                ddlShgType.DataTextField = "SHGName";
                ddlShgType.DataBind();
                ddlShgType.Items.Insert(0, "--Select SHG--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchCast()
    {
        try
        {
            obj_ML_Masters.QueryType = "Cast";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlCasteSocial.DataSource = DT;
                ddlCasteSocial.DataValueField = "CastId";
                ddlCasteSocial.DataTextField = "CastName";
                ddlCasteSocial.DataBind();
                ddlCasteSocial.Items.Insert(0, "--Select Cast--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchEconomicStatus()
    {
        try
        {
            obj_ML_Masters.QueryType = "EcoStatus";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlEconomicStatus.DataSource = DT;
                ddlEconomicStatus.DataValueField = "EconomicId";
                ddlEconomicStatus.DataTextField = "EconomicStatus";
                ddlEconomicStatus.DataBind();
                ddlEconomicStatus.Items.Insert(0, "--Select Economic Status--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchEducation()
    {
        try
        {
            obj_ML_Masters.QueryType = "Education";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlEducation.DataSource = DT;
                ddlEducation.DataValueField = "EducationId";
                ddlEducation.DataTextField = "EducationName";
                ddlEducation.DataBind();
                ddlEducation.Items.Insert(0, "--Select Education--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    private void FetchScheme()
    {
        try
        {
            obj_ML_Masters.QueryType = "Scheme";
            obj_ML_Masters.StateId = 0;
            obj_ML_Masters.DistrictId = 0;
            obj_ML_Masters.BlockId = 0;
            obj_ML_Masters.VillageId = 0;
            obj_ML_Masters.DigitalCategoryId = 0;
            DataTable DT = obj_BL_Masters.BL_AllMasters(obj_ML_Masters);
            if (DT.Rows.Count > 0)
            {
                ddlLinkedScheme.DataSource = DT;
                ddlLinkedScheme.DataValueField = "SchemeId";
                ddlLinkedScheme.DataTextField = "SchemeName";
                ddlLinkedScheme.DataBind();
                ddlLinkedScheme.Items.Insert(0, "--Select Scheme--");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBeneficaryCode();
    }
    protected void txtWomenName_TextChanged(object sender, EventArgs e)
    {
        GetBeneficaryCode();
    }

    protected void txtPhoneNo_TextChanged(object sender, EventArgs e)
    {
        GetBeneficaryCode();
    }
    private void GetBeneficaryCode()
    {
        string fName = txtWomenName.Text.Trim();
        if (fName.Contains(" "))
        {
            fName = fName.Substring(0, fName.IndexOf(" "));
        }
        else
        {
            fName = txtWomenName.Text.Trim();
        }
        string FatherFname = Convert.ToString(txtHusbandFatherName.Text).Trim();

        if (FatherFname.Contains(" "))
        {
            FatherFname = FatherFname.Substring(0, FatherFname.IndexOf(" "));
        }
        else
        {
            FatherFname = txtHusbandFatherName.Text.Trim();
        }
        txtBeneficiaryCode.Text = Convert.ToString(txtPhoneNo.Text).Trim() + fName + FatherFname + Convert.ToString(ddlTheme.SelectedValue);
    }

    protected void txtDateBirth_TextChanged(object sender, EventArgs e)
    {
        txtAge.Text = CalculateYourAge(Convert.ToDateTime(txtDateBirth.Text.Trim()));
    }
    static string CalculateYourAge(DateTime Dob)
    {      
        DateTime Now = DateTime.Now;
        int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        //DateTime PastYearDate = Dob.AddYears(Years);
        //int Months = 0;
        //for (int i = 1; i <= 12; i++)
        //{
        //    if (PastYearDate.AddMonths(i) == Now)
        //    {
        //        Months = i;
        //        break;
        //    }
        //    else if (PastYearDate.AddMonths(i) >= Now)
        //    {
        //        Months = i - 1;
        //        break;
        //    }
        //}
        //int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
        //int Hours = Now.Subtract(PastYearDate).Hours;
        //int Minutes = Now.Subtract(PastYearDate).Minutes;
        //int Seconds = Now.Subtract(PastYearDate).Seconds;
        //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",Years, Months, Days, Hours, Seconds);
        return String.Format("{0}",Years);
       
    }    
    protected void Btn_SubmitForm_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DT = Session["UserDetails"] as DataTable;
            string UserCode = DT.Rows[0]["UserCode"].ToString();
            if (Btn_SubmitForm.Text == "Submit Form")
            {
                obj_ML_Enrollment.BeneficiaryCode = txtBeneficiaryCode.Text != "" ? txtBeneficiaryCode.Text : "";
                obj_ML_Enrollment.WomenName = txtWomenName.Text != "" ? txtWomenName.Text : "";
                obj_ML_Enrollment.HusbandFatherName = txtHusbandFatherName.Text != "" ? txtHusbandFatherName.Text : "";
                obj_ML_Enrollment.MotherName = txtMotherName.Text != "" ? txtMotherName.Text : "";
                obj_ML_Enrollment.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : "";
                obj_ML_Enrollment.ThemeCode = ddlTheme.SelectedIndex > 0 ? ddlTheme.SelectedValue : "";
                obj_ML_Enrollment.Cast = Convert.ToInt32(ddlCasteSocial.SelectedIndex > 0 ? ddlCasteSocial.SelectedValue : "0");
                obj_ML_Enrollment.EconomicStatus = Convert.ToInt32(ddlEconomicStatus.SelectedIndex > 0 ? ddlEconomicStatus.SelectedValue : "0");
                obj_ML_Enrollment.MaritalStatus = ddlMaritalStatus.SelectedIndex > 0 ? ddlMaritalStatus.SelectedValue : "";
                //obj_ML_Enrollment.PersonalSmartPhone =rblPerSmartPhone.SelectedValue;
                obj_ML_Enrollment.BirthDate = txtDateBirth.Text != "" ? txtDateBirth.Text : "";
                obj_ML_Enrollment.Age = Convert.ToInt32(txtAge.Text != "" ? txtAge.Text : "0");
                obj_ML_Enrollment.RegistrationDate = txtRegistrationDate.Text != "" ? txtRegistrationDate.Text : "";
                obj_ML_Enrollment.State = Convert.ToInt32(ddlState.SelectedIndex > 0 ? ddlState.SelectedValue : "0");
                obj_ML_Enrollment.District = Convert.ToInt32(ddlDistrict.SelectedIndex > 0 ? ddlDistrict.SelectedValue : "0");
                obj_ML_Enrollment.Block = Convert.ToInt32(ddlBlock.SelectedIndex > 0 ? ddlBlock.SelectedValue : "0");
                obj_ML_Enrollment.Village = Convert.ToInt32(ddlVillage.SelectedIndex > 0 ? ddlVillage.SelectedValue : "0");
                obj_ML_Enrollment.PartSHG = rblSHG.SelectedValue;
                obj_ML_Enrollment.SHGName = txtShgName.Text != "" ? txtShgName.Text : "";
                obj_ML_Enrollment.SHGDate = txtDateSHG.Text != "" ? txtDateSHG.Text : "";
                obj_ML_Enrollment.SHGType = Convert.ToInt32(ddlShgType.SelectedIndex > 0 ? ddlShgType.SelectedValue : "0");
                obj_ML_Enrollment.Education = Convert.ToInt32(ddlEducation.SelectedIndex > 0 ? ddlEducation.SelectedValue : "0");
                obj_ML_Enrollment.PwD = rblPwD.SelectedValue;
                obj_ML_Enrollment.PwDSpecify = txtPwDSpecify.Text != "" ? txtPwDSpecify.Text : "";
                obj_ML_Enrollment.AadhaarrCard = rblAdharCard.SelectedValue;
                obj_ML_Enrollment.AadhaarCardDetails = rblWillingAadhaardetails.SelectedValue;
                obj_ML_Enrollment.AadhaarNo = txtAadhaarNo.Text != "" ? txtAadhaarNo.Text : "";
                obj_ML_Enrollment.AnyIDProofDetails = Convert.ToString(ddlGovtOfIndiaIdProofs.SelectedValue);
                obj_ML_Enrollment.IDProofNo = txtIDProofNo.Text != "" ? txtIDProofNo.Text : "";
                obj_ML_Enrollment.IssuingAuthority = txtIssuingAuthority.Text != "" ? txtIssuingAuthority.Text : "";
                obj_ML_Enrollment.RationCard = rblRationCard.SelectedValue;
                obj_ML_Enrollment.RationCardlinkedPDS = rblRationCardlinkedPDS.SelectedValue;
                obj_ML_Enrollment.BankAccountNo = rblBankAcPersonal.SelectedValue;
                obj_ML_Enrollment.LinkedSocialSecuritySchemes = rblPreviouslyLinkedSocialSecuritySchemes.SelectedValue;                
                obj_ML_Enrollment.WomenBelong = ddlCriteriaWomen.SelectedIndex > 0 ? ddlCriteriaWomen.SelectedValue : "";
                obj_ML_Enrollment.ValidCertificate = rblValidCertificate.SelectedValue;
                obj_ML_Enrollment.MonthlyIndividualIncome = ddlMonthlyIndIncome.SelectedIndex > 0 ? ddlMonthlyIndIncome.SelectedValue : "";
                obj_ML_Enrollment.MonthlyHouseholdIncome = ddlMonthlyHouseholdIncome.SelectedIndex > 0 ? ddlMonthlyHouseholdIncome.SelectedValue : "";
                obj_ML_Enrollment.Scheme = Convert.ToInt32(ddlLinkedScheme.SelectedIndex > 0 ? ddlLinkedScheme.SelectedValue : "0");
                obj_ML_Enrollment.CreatedBy = UserCode;
                int x = obj_BL_Enrollment.BL_InsEnrollment(obj_ML_Enrollment);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Form Submit Successfully !');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
                }
            }
            Btn_Cancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error !');", true);
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        txtBeneficiaryCode.Text = "";
        txtWomenName.Text = "";
        txtHusbandFatherName.Text = "";
        txtMotherName.Text = "";
        txtPhoneNo.Text = "";
        ddlTheme.SelectedIndex = 0;
        ddlCasteSocial.SelectedIndex = 0;
        ddlEconomicStatus.SelectedIndex = 0;
        ddlMaritalStatus.SelectedIndex = 0;
        txtDateBirth.Text = "";
        txtAge.Text = "";
        txtRegistrationDate.Text = "";
        ddlState.SelectedIndex = 0;
        ddlDistrict.Items.Clear();
        ddlBlock.Items.Clear();
        ddlVillage.Items.Clear();
        rblSHG.ClearSelection();
        txtShgName.Text = "";
        txtDateSHG.Text = "";
        ddlShgType.SelectedIndex = 0;
        ddlEducation.SelectedIndex = 0;
        rblPwD.ClearSelection();
        txtPwDSpecify.Text = "";
        rblAdharCard.ClearSelection();
        rblWillingAadhaardetails.ClearSelection();
        txtAadhaarNo.Text = "";
        ddlGovtOfIndiaIdProofs.SelectedIndex = 0;
        txtIDProofNo.Text = "";
        txtIssuingAuthority.Text = "";
        rblRationCard.ClearSelection();
        rblRationCardlinkedPDS.ClearSelection();
        rblBankAcPersonal.ClearSelection();
        rblPreviouslyLinkedSocialSecuritySchemes.ClearSelection();
        rblPreviouslyLinkedSocialSecuritySchemes.SelectedValue = "No";
        ddlCriteriaWomen.SelectedIndex = 0;
        rblValidCertificate.ClearSelection();
        ddlMonthlyIndIncome.SelectedIndex = 0;
        ddlMonthlyHouseholdIncome.SelectedIndex = 0;
        ddlLinkedScheme.SelectedIndex = 0;
        rblPwD.SelectedValue = "No";
        rblSHG.SelectedValue = "No";
        div_SHGName.Visible = false;
        div_SHGDate.Visible = false;
        div_SHGType.Visible = false;

        rblAdharCard.SelectedValue = "No";
        div_WillingAadhaar.Visible = false;
        div_AadhaarNo.Visible = false;
        

    }
    protected void rblSHG_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSHG.SelectedValue=="Yes")
        {
            div_SHGName.Visible = true;
            div_SHGDate.Visible = true;
            div_SHGType.Visible = true;
        }
        else
        {
            div_SHGName.Visible = false;
            txtShgName.Text = "";
            div_SHGDate.Visible = false;
            txtDateSHG.Text = "";
            div_SHGType.Visible = false;
            ddlShgType.SelectedIndex = 0;
        }
    }
    protected void rblPreviouslyLinkedSocialSecuritySchemes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPreviouslyLinkedSocialSecuritySchemes.SelectedValue=="Yes")
        {
            div_LinkedScheme.Visible = true;
        }
        else
        {
            div_LinkedScheme.Visible = false;
            ddlLinkedScheme.SelectedIndex = 0;
        }
    }
    protected void rblPwD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPwD.SelectedValue == "Yes")
        {
            div_pwdSpecify.Visible = true;
        }
        else
        {
            div_pwdSpecify.Visible = false;
            txtPwDSpecify.Text = "";
        }
    }
    protected void rblAdharCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblAdharCard.SelectedValue == "Yes")
        {
            div_WillingAadhaar.Visible = true;
            //div_AadhaarNo.Visible = true;
        }
        else
        {
            div_WillingAadhaar.Visible = false;
            rblWillingAadhaardetails.SelectedValue = "No";
            txtAadhaarNo.Text = "";
            div_AadhaarNo.Visible = false;
        }
    }
    protected void rblWillingAadhaardetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblWillingAadhaardetails.SelectedValue == "Yes")
        {
            div_AadhaarNo.Visible = true;
            rfvAadhaarNumber.Enabled = true;
        }
        else
        {
            rfvAadhaarNumber.Enabled=false;
            div_AadhaarNo.Visible = false;
            txtAadhaarNo.Text = "";
        }
    }

    
}
