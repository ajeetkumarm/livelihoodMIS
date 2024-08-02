using System;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    
    
    protected void Btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            
            obj_ML_UserLogin.UserEmail = txtUserEmail.Text.Trim();
            DataTable DT = obj_BL_UserLogin.BL_LoginUserDetails(obj_ML_UserLogin);
            if (DT.Rows.Count > 0)
            {
                Session["UserDetails"] = DT;
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                string password = DT.Rows[0]["PwdHash"].ToString();
                string IsActive = DT.Rows[0]["IsActive"].ToString();
                int UserCategory = Convert.ToInt16(DT.Rows[0]["UserCategory"].ToString());
                string encpass = DigestValidator.ency_pwd(ViewState["hdfRanValue"].ToString() + password);

                if (txtPassword.Text == encpass)
                {
                    if (IsActive == "1")
                    {
                        string strRedirectPage = "~/Forms/Dashboard.aspx";
                        if (UserCategory == 8)
                        {
                            strRedirectPage = "~/Forms/BusinessProgressCustomerList.aspx";
                        }

                        Response.Redirect(strRedirectPage, false);
                    }
                    else
                    {
                        Session["userDetails"] = null;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Your Account is InActive please contact to Admin !"));
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Invalid Password !'); window.location.href = 'Login.aspx'", true);
                    txtPassword.Text = "";
                }
            }
            else
            {
                Session["userDetails"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Invalid Login User Id !"));
                txtPassword.Text = "";
            }
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}