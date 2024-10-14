<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="Enrollment.aspx.cs" Inherits="Forms_Enrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="radio"] {
            margin-left: 0.75rem;
        }
    </style>

    <script type="text/javascript">
        /* VALIDATION */
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please Enter Only Numeric Value:");
                return false;
            }
            return true;
        }

        function onlyAlpha(e) {
            var k = e.charCode;
            if (k == 0) {
                e.returnValue = true;
                return true;
            }
            else if ((k < 65 || k > 90) && (k < 97 || k > 122) && (k < 32 || k >= 33)) {
                e.returnValue = false;
                return false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Enrollment Form</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Enrollment</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Enrollment Form</h5>
                        <hr />
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Beneficiary Code</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtBeneficiaryCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Employee Id</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">State</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please Select State!" ControlToValidate="ddlState" InitialValue="0"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">District</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDistrict" runat="server" ErrorMessage="Please Select District!" ControlToValidate="ddlDistrict" InitialValue="0"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Block</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvBlock" runat="server" ErrorMessage="Please Select Block!" ControlToValidate="ddlBlock" InitialValue="0"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Village</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-select"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvVillage" runat="server" ErrorMessage="Please Select Village!" ControlToValidate="ddlVillage" InitialValue="0"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Enrollment Status <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlEnrollmentStatus" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlEnrollmentStatus_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="New">New</asp:ListItem>
                                    <asp:ListItem Value="Replacement">Replacement</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvEnrollmentStatus" runat="server" ErrorMessage="Please Enrollment Status!" ControlToValidate="ddlEnrollmentStatus" InitialValue="0"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1" id="divReplacementBeneficiaryCode" runat="server" visible="false">
                            <label class="col-sm-3 col-form-label">Replacement Beneficiary Code <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtReplacementBeneficiaryCode" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvReplacementBeneficiaryCode" runat="server" ErrorMessage="Please Enter Replacement Beneficiary Code!" ControlToValidate="txtReplacementBeneficiaryCode"
                                    ValidationGroup="Submit" Enabled="false" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1" id="divReplacementEmployeeId" runat="server" visible="false">
                            <label class="col-sm-3 col-form-label">Replacement Employee Id <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtReplacementEmployeeId" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvReplacementEmployeeId" runat="server" ErrorMessage="Please Enter Employee Id!" ControlToValidate="txtReplacementEmployeeId"
                                    ValidationGroup="Submit" Enabled="false" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Cohort</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCohort" runat="server" class="form-select">
                                    <asp:ListItem Value="">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Cohort-1">Cohort-1</asp:ListItem>
                                    <asp:ListItem Value="Cohort-2">Cohort-2</asp:ListItem>
                                    <asp:ListItem Value="Cohort-3">Cohort-3</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Name of Women <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtWomenName" runat="server" class="form-control" AutoComplete="off" OnTextChanged="txtWomenName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_WomenName" runat="server" ErrorMessage="Please Enter Women Name!" ControlToValidate="txtWomenName"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Name of Husband/ Father <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtHusbandFatherName" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_Husband" runat="server" ErrorMessage="Please Enter Husband/ Father name !" ControlToValidate="txtHusbandFatherName"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Name of Mother </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtMotherName" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfv_MotherName" runat="server" ErrorMessage="Please Enter Mother name !" ControlToValidate="txtMotherName"
                                    ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Phone Number <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" AutoComplete="off" MaxLength="10" OnTextChanged="txtPhoneNo_TextChanged" AutoPostBack="true" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" ErrorMessage="Please Enter Phone Number !" ControlToValidate="txtPhoneNo"
                                    ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Theme Code <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlTheme" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_Theme" runat="server" ErrorMessage="Please select Theme !" ControlToValidate="ddlTheme"
                                    ValidationGroup="Submit" ForeColor="Red" InitialValue="--Select Theme--" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Caste / Social</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCasteSocial" runat="server" class="form-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Economic Status</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlEconomicStatus" runat="server" class="form-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Marital Status</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" class="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Unmarried">Unmarried</asp:ListItem>
                                    <asp:ListItem Value="Married">Married</asp:ListItem>
                                    <asp:ListItem Value="Widow">Widow</asp:ListItem>
                                    <asp:ListItem Value="Single Mother">Single Mother</asp:ListItem>
                                    <asp:ListItem Value="Divorcee">Divorcee</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RadioButtonList ID="rblMaritalStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>--%>
                            </div>
                        </div>
                        <%--<div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Personal Smart Phone</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblPerSmartPhone" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>--%>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Date of Birth</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtDateBirth" runat="server" class="form-control" type="date" AutoComplete="off" AutoPostBack="true" OnTextChanged="txtDateBirth_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Age (Auto)</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAge" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Date of Registration</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="form-control" type="date" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Whether Part of any SHG</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblSHG" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblSHG_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_SHGName" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Name of SHG <span style="color: red;">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtShgName" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvShgName" runat="server" ErrorMessage="Please Enter Name of SHG!" ControlToValidate="txtShgName"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div id="div_SHGDate" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Date of SHG Formation</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtDateSHG" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDateOfSHGFormation" runat="server" ErrorMessage="Please Enter Date of SHG Formation!" ControlToValidate="txtDateSHG"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div id="div_SHGType" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Type of SHG</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlShgType" runat="server" CssClass="form-select"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvShgType" runat="server" ErrorMessage="Please Enter Type of SHG!" ControlToValidate="ddlShgType"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Education</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlEducation" runat="server" class="form-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">PwD ( Any Disability, please specify)</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblPwD" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblPwD_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_pwdSpecify" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Please Specify</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtPwDSpecify" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPwDSpecify" runat="server" ErrorMessage="Please Specify!" ControlToValidate="txtPwDSpecify"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Aadhaar Card</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblAdharCard" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblAdharCard_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_WillingAadhaar" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Willing to provide Aadhaar Card details</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblWillingAadhaardetails" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblWillingAadhaardetails_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_AadhaarNo" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Aadhaar Number</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAadhaarNo" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" MaxLength="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAadhaarNumber" runat="server" Enabled="false" ErrorMessage="Please Enter Aadhaar Number!" ControlToValidate="txtAadhaarNo"
                                    ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Provide details of any other ID proofs, recognized by Govt. of India</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlGovtOfIndiaIdProofs" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select ID Proofs--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Voter ID" Value="Voter ID"></asp:ListItem>
                                    <asp:ListItem Text="Aadhaar Card" Value="Aadhaar Card"></asp:ListItem>
                                    <asp:ListItem Text="Birth Certificate" Value="Birth Certificate"></asp:ListItem>
                                    <asp:ListItem Text="Bank Passbook" Value="Bank Passbook"></asp:ListItem>
                                    <asp:ListItem Text="Bank Statement" Value="Bank Statement"></asp:ListItem>
                                    <asp:ListItem Text="Electricity Bill" Value="Electricity Bill"></asp:ListItem>
                                    <asp:ListItem Text="Gas Bill" Value="Gas Bill"></asp:ListItem>
                                    <asp:ListItem Text="Water Bill" Value="Water Bill"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">ID Proof Number</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtIDProofNo" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Issuing Authority</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtIssuingAuthority" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Ration Card</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblRationCard" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Ration Card linked with PDS</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblRationCardlinkedPDS" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Bank Account (Personal)</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblBankAcPersonal" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Previously Linked with social security schemes</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblPreviouslyLinkedSocialSecuritySchemes" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblPreviouslyLinkedSocialSecuritySchemes_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_LinkedScheme" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Linked with Which scheme</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlLinkedScheme" runat="server" class="form-select"></asp:DropDownList>
                            </div>
                        </div>
                        <!-- Add new-->
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Criteria Women Belong</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCriteriaWomen" runat="server" class="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="State Livelihood Mission Girls (Above 18)">State Livelihood Mission Girls (Above 18)</asp:ListItem>
                                    <asp:ListItem Value="Industrial Training Institute Enrolled">Industrial Training Institute Enrolled</asp:ListItem>
                                    <asp:ListItem Value="Rural Self Employment Training Institutes Enrolled">Rural Self Employment Training Institutes Enrolled</asp:ListItem>
                                    <asp:ListItem Value="Microfinance Network">Microfinance Network</asp:ListItem>
                                    <asp:ListItem Value="Anganwadi Workers">Anganwadi Workers</asp:ListItem>
                                    <asp:ListItem Value="PRI Leaders">PRI Leaders</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Is having Valid Certificate</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblValidCertificate" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Monthly Individual Income </label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlMonthlyIndIncome" runat="server" class="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="< 2000 INR ">< 2000 INR </asp:ListItem>
                                    <asp:ListItem Value="Between INR 2001-5000">Between INR 2001-5000</asp:ListItem>
                                    <asp:ListItem Value="Between 5001-8000">Between 5001-8000</asp:ListItem>
                                    <asp:ListItem Value="Above INR 8000">Above INR 8000</asp:ListItem>
                                    <asp:ListItem Value="Nill">Nill</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Monthly Household Income</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlMonthlyHouseholdIncome" runat="server" class="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="< 2000 INR ">< 2000 INR </asp:ListItem>
                                    <asp:ListItem Value="Between INR 2001-5000">Between INR 2001-5000</asp:ListItem>
                                    <asp:ListItem Value="Between 5001-8000">Between 5001-8000</asp:ListItem>
                                    <asp:ListItem Value="Above INR 8000">Above INR 8000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="mb-3 row m-1" style="border: dashed; background-color: aliceblue">

                            <label class="col-sm-12 text-center ">
                                <span style="color: red;">*</span><b>
                                    <asp:CheckBox ID="chkcondition" runat="server" ValidationGroup="1" OnCheckedChanged="chkcondition_CheckedChanged" AutoPostBack="true" Class="chkcnd" />
                                    I hereby declare that I have obtained consent from the beneficiary for the collection, use, and processing of their personal data, and that I have thoroughly explained the purpose, storage mechanism, control, sharing policy, and beneficiary rights to them</b></label>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_SubmitForm" runat="server" CssClass="btn btn-primary" Enabled="false" Text="Submit Form" OnClick="Btn_SubmitForm_Click" ValidationGroup="Submit" />
                                    &nbsp;
                                    <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- End General Form Elements -->

                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_SubmitForm" />
            <asp:AsyncPostBackTrigger ControlID="chkcondition" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

