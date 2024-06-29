using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelLayer;
using BusinessLayer;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    ML_UserLogin obj_ML_UserLogin = new ML_UserLogin();
    BL_UserLogin obj_BL_UserLogin = new BL_UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfRanValue.Value = GenerateRandomNumericCode(10);
        if (!IsPostBack)
        {
            ViewState["hdfRanValue"] = hdfRanValue.Value;
            //Fillcaptcha();
        }
    }
    public static string GenerateRandomNumericCode(int length)
    {
        string characterSet = "0123456789012345";
        Random random = new Random();
        string randomCode = new string(
            Enumerable.Repeat(characterSet, length)
                .Select(set => set[random.Next(set.Length)])
                .ToArray());
        return randomCode;
    }
    //private void Fillcaptcha()
    //{
    //    try
    //    {
    //        Random rdm = new Random();
    //        char[] allowChrs = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLOMNPQRSTUVWXYZ123456789".ToCharArray();
    //        string sResult = "";
    //        for (int i = 0; i < 7 - 1; i++)
    //        {
    //            sResult += allowChrs[rdm.Next(0, allowChrs.Length)];
    //        }
    //        ViewState["captcha"] = sResult.ToString();
    //        imgCaptcha.ImageUrl = "~/GenerateCaptcha.aspx?captcha=" + Convert.ToString(ViewState["captcha"]);
    //    }
    //    catch
    //    {

    //    }
    //}
    private string GetIpAddress()
    {
        string strIPAddress;
        strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (strIPAddress == "" || strIPAddress == null)
        {
            strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        return strIPAddress;
    }
    //protected void lnkRefresh_Click(object sender, EventArgs e)
    //{
    //    Fillcaptcha();
    //}
    public void alertBox(string Message)
    {
        string Script = "";
        Script += "\n<script language=JavaScript >\n";
        Script += "alert('" + Message + "'); \n";
        Script += "</script>";
        if (!this.IsStartupScriptRegistered("PopupWindow"))
        {
            this.RegisterStartupScript("PopupWindow", Script);
        }
    }
    protected void Btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtCaptcha.Text == ViewState["captcha"].ToString())
            //{
            obj_ML_UserLogin.UserEmail = txtUserEmail.Text.Trim();
            DataTable DT = obj_BL_UserLogin.BL_LoginUserDetails(obj_ML_UserLogin);
            if (DT.Rows.Count > 0)
            {
                Session["UserDetails"] = DT;
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                //Session["Email"] = dtUserDetails.Rows[0]["Email"];

                string password = DT.Rows[0]["PwdHash"].ToString();
                string IsActive = DT.Rows[0]["IsActive"].ToString();
                int UserCategory = Convert.ToInt16(DT.Rows[0]["UserCategory"].ToString());
                string encpass = DigestValidator.ency_pwd(ViewState["hdfRanValue"].ToString() + password);

                if (txtPassword.Text == encpass)
                {
                    if (IsActive == "1")
                    {
                        //CreateLog("Login Successfully !", DT.Rows[0]["LoginName"].ToString());

                        Response.Redirect("~/Forms/Dashboard.aspx", false);
                    }
                    else
                    {
                        Session["userDetails"] = null;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Your Account is InActive please contact to Admin !"));
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Your Account is InActive please contact to Admin !'); window.location.href = 'Login.aspx'", true);
                        //Fillcaptcha();
                        //txtCaptcha.Text = "";
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Invalid Password !"));
		    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Invalid Password !'); window.location.href = 'Login.aspx'", true);
                    //Fillcaptcha();
                    txtPassword.Text = "";
                    //txtCaptcha.Text = "";		    
                }
            }
            else
            {
                Session["userDetails"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Invalid Login User Id !"));
		//ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Invalid Login User Id !'); window.location.href = 'Login.aspx'", true);
                //Fillcaptcha();
                txtPassword.Text = "";
                //txtCaptcha.Text = "";
            }
            //}
            //else
            //{
            //    Session["userDetails"] = null;
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Invalid captcha code !"));
            //    Fillcaptcha();
            //    txtCaptcha.Text = "";
            //}
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('System Error ! Login Fail !');", true);
            Response.Write(ex.Message);
        }
    }
}