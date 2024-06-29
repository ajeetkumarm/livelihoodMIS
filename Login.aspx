<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Women Empowerment-Login</title>
    <!-- Google Fonts -->

    <!-- Vendor CSS Files -->

    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="assets/vendor/quill/quill.snow.css" rel="stylesheet" />
    <link href="assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
    <link href="assets/vendor/simple-datatables/style.css" rel="stylesheet" />

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet" />
    <!-- For Login-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/sha256.js"></script>
    <script src="assets/js/UtilityFunctions.js"></script>

    <script type="text/javascript">
        function EncryptPass() {
            var Pass = document.getElementById('<%=txtPassword.ClientID %>').value;
            var User = document.getElementById('<%=txtUserEmail.ClientID %>').value;

            if (Pass == null || Pass == "" || User == null || User == "") {
                return false;
            }
            else {
                document.getElementById('<%=txtPassword.ClientID %>').value = HashText(document.getElementById('<%=txtPassword.ClientID %>').value)
                document.getElementById('<%=txtPassword.ClientID %>').value = HashText(document.getElementById('<%=hdfRanValue.ClientID %>').value + document.getElementById('<%=txtPassword.ClientID %>').value)
                //alert(document.getElementById('<%=txtPassword.ClientID %>').value);
                return true
            }

        }
    </script>
    <style type="text/css">
        .login-bg-overlay {
            width: 100%;
            height: 420px;
            position: absolute;
            top: 0;
            right: 0;
            left: 0;
            background-color: #8436a8;
            background-image: linear-gradient( 310deg,#7928ca,#ff0080);
        }
        .au-sign-in-basic {
            background-image: url(assets/img/back.jpg);
            -background-position: center;
            -background-size: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdfRanValue" runat="server" />
	<div class="login-bg-overlay au-sign-in-basic"></div>
        <main>
            <div class="container">
                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">
                                <div class="d-flex justify-content-center py-2 text-white" style="z-index:4">
                                    <a href="index.html" class="logo d-f lex align-items-center w-auto text-center">                                        
                                        <h1 class="text-white"><img src="assets/img/Humana-logo.png" class="img-fluid" alt="" style="max-height: 90px;" />HUMANA</h1>
                                        <h4 style="color: #e16f00;">PEOPLE TO PEOPLE INDIA</h4>
                                        <span class="text-white">Women Empowerment Initiative</span>
                                    </a>
                                </div>
                                <!-- End Logo -->
                                <div class="card mb-3">
                                    <div class="card-body">
                                        <div class="pt-4 pb-2">
                                            <h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5>
                                            <p class="text-center small">Enter your username & password to login</p>
                                        </div>
                                        <div class="row g-3 needs-validation" novalidate>
                                            <div class="col-12">
                                                <label for="yourUsername" class="form-label">User Email</label>
                                                <div class="input-group has-validation">
                                                    <span class="input-group-text"><i class="bx bx-envelope"></i></span>
                                                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control" autocomplete="off" required></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <label for="yourPassword" class="form-label">Password</label>
                                                <div class="input-group has-validation">
                                                    <span class="input-group-text"><i class="bx bx-key"></i></span>
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" autocomplete="off" TextMode="Password" required></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <%--<div class="input-group mb-4">
                                                    <div class="col-6">
                                                        <asp:TextBox ID="txtCaptcha" runat="server" autocomplete="off" CssClass="form-control" placeholder="Enter Captcha" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                    <div class="col-4">
                                                        &nbsp;
                                                        <asp:Image ID="imgCaptcha" runat="server" Style="width: 86px;" />
                                                    </div>
                                                    <div class="col-2">
                                                        <asp:LinkButton ID="lnkRefresh" runat="server" CssClass="btn btn-outline-secondary" OnClick="lnkRefresh_Click"><i class="bx bx-refresh"></i></asp:LinkButton>
                                                    </div>
                                                </div>--%>
                                                <div class="col-12">
                                                    <asp:Button ID="Btn_Login" runat="server" CssClass="btn btn-primary w-100" Text="Login" OnClientClick="javascript:EncryptPass();" OnClick="Btn_Login_Click" />
                                                </div>
                                                <br /><br />
                                                <div class="col-12">
                                                    <p class="small mb-0">Don't have account? <a href="#">Create an account</a></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br /><br /><br /><br /><br />
                        <footer id="footer" class="footer py-2 lh-1" style="margin-left: 0;">
                            <div class="copyright">
                                &copy; Copyright <strong><span>HUMANA</span></strong>
                                PEOPLE TO PEOPLE INDIA
                            </div>
                            <div class="credits">
                                Designed by HUMANA, PEOPLE TO PEOPLE INDIA
                            </div>
                        </footer>
                </section>

            </div>
        </main>




    </form>
</body>
</html>
