<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="BusinessProgress.aspx.cs" Inherits="Forms_BusinessProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="checkbox"] {
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
        <h1>Business Progress</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Business Progress</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->

    <section class="section">
        <div class="card">
            <div class="card-body">
                <!-- General Form Elements -->
                <div class="mb-3 row m-1" visible="false">
                    <label class="col-sm-3 col-form-label">Date of Starting of Business</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtBusinessStartingDate" runat="server" class="form-control" AutoComplete="off" type="date"></asp:TextBox>
                    </div>
                </div>

                <span style="color: #0026ff; font-weight: bold;">* Reporting Period</span>

                <div class="mb-3 row m-1">
                    <label class="col-sm-3 col-form-label">Months</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMonths" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="Jan">Jan</asp:ListItem>
                            <asp:ListItem Value="Feb">Feb</asp:ListItem>
                            <asp:ListItem Value="March">March</asp:ListItem>
                            <asp:ListItem Value="April">April</asp:ListItem>
                            <asp:ListItem Value="May">May</asp:ListItem>
                            <asp:ListItem Value="June">June</asp:ListItem>
                            <asp:ListItem Value="July">July</asp:ListItem>
                            <asp:ListItem Value="Aug">Aug</asp:ListItem>
                            <asp:ListItem Value="Sep">Sep</asp:ListItem>
                            <asp:ListItem Value="Oct">Oct</asp:ListItem>
                            <asp:ListItem Value="Nov">Nov</asp:ListItem>
                            <asp:ListItem Value="Dec">Dec</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3 row m-1">
                    <label class="col-sm-3 col-form-label">Year</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                            <asp:ListItem Value="2023">2023</asp:ListItem>
                            <asp:ListItem Value="2024">2024</asp:ListItem>
                            <asp:ListItem Value="2025">2025</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <span style="color: #0026ff; font-weight: bold;">* Customer Related</span>

                <div class="mb-3 row m-1">
                    <label class="col-sm-3 col-form-label">No. of New customer</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtNewCustomer" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row m-1">
                    <label class="col-sm-3 col-form-label">No. of Repeated Customer</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtRepeatedCustomer" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                </div>

                <span style="color: #0026ff; font-weight: bold;">* Services Related</span>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="row">
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Type of services offered</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlServicesOfferedType" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlServicesOfferedType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Digital">Digital</asp:ListItem>
                                        <asp:ListItem Value="Non-Digital">Non-Digital</asp:ListItem>
                                        <asp:ListItem Value="Both">Both</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="div_DigiCat" runat="server" class="mb-3 row m-1" visible="false">
                                <label class="col-sm-3 col-form-label">Digital Category</label>
                                <div class="col-sm-6">
                                    <asp:CheckBoxList ID="chkDigitalCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" AutoPostBack="true"
                                        OnSelectedIndexChanged="chkDigitalCategory_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div id="div_SerLine" runat="server" class="mb-3 row m-1" visible="false">
                                <label class="col-sm-3 col-form-label">Service Line</label>
                                <div class="col-sm-6">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GvService" runat="server" AutoGenerateColumns="False" DataKeyNames="ServiceDetailsCount" OnRowCommand="GvService_RowCommand"
                                            OnRowDeleting="GvService_RowDeleting" ShowFooter="true" CssClass="table table-bordered table-striped table-hover">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/assets/img/Delete.png"
                                                            ToolTip="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="but_Add" runat="server" title="Add Row" ImageUrl="~/assets/img/Add.png" ValidationGroup="1"
                                                            CommandName="AddNew" />
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Service Line">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" ID="hdfServiceId" Value='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.ServiceId").ToString())%>'></asp:HiddenField>
                                                        <asp:Label ID="lblServiceLine" runat="server" Text='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.ServiceLine").ToString())%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlFooterServiceLine" runat="server" CssClass="form-select">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFVddlFooterServiceLine" runat="server" ControlToValidate="ddlFooterServiceLine" Display="Dynamic"
                                                            ErrorMessage="Please Select !" InitialValue="--Select Service Line--" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="300px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No of Customers">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNoCustomers" runat="server" Text='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.NoCustomers").ToString())%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFooterNoCustomers" runat="server" onkeypress="return isNumberKey(event)" class="form-control textBorder" autocomplete="off"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVtxtFooterNoCustomers" runat="server" ErrorMessage="Please Enter !" Display="Dynamic"
                                                            ValidationGroup="1" ControlToValidate="txtFooterNoCustomers" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Upload Document">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbFileName" runat="server" Text='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.FileName").ToString())%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:FileUpload ID="FooterUpload" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="300px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div id="div_SerProvided" runat="server" class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Kindly provide details of services provided</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtServicesDetails" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">If related to government to customer services mention the number</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtGovCustServices" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div id="div_G2C" runat="server" class="mb-3 row m-1" visible="false">
                                <label class="col-sm-3 col-form-label">Please provide services details with G2C</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtG2CServices" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <span style="color: #0026ff; font-weight: bold;">* Income Statement</span>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Income from Sell</label>
                            <div class="col-sm-6">
                                <asp:CheckBoxList ID="chkIncomeSell" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="chkIncomeSell_SelectedIndexChanged">
                                    <asp:ListItem Value="Cash Sell">Cash Sell</asp:ListItem>
                                    <asp:ListItem Value="Credit Sell">Credit Sell</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Cash Sell Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCashSellAmount" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" ReadOnly="true" AutoPostBack="true" OnTextChanged="txtCashSellAmount_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Sell Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCreditSellAmount" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" ReadOnly="true" AutoPostBack="true" OnTextChanged="txtCreditSellAmount_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Total Income</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtTotalIncome" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Investment</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtInvestment" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtInvestment_TextChanged1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Expenditure from Purchase</label>
                            <div class="col-sm-6">
                                <asp:CheckBoxList ID="chkExpenditurePurchase" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="chkExpenditurePurchase_SelectedIndexChanged">
                                    <asp:ListItem Value="Cash Expenditure">Cash Expenditure</asp:ListItem>
                                    <asp:ListItem Value="Credit Expenditure">Credit Expenditure</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Cash Expenditure Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCashExpenditureAmount" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" ReadOnly="true" AutoPostBack="true" OnTextChanged="txtCashExpenditureAmount_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Expenditure Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCreditExpenditureAmount" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" ReadOnly="true" AutoPostBack="true" OnTextChanged="txtCreditExpenditureAmount_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Total Expenditure</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtTotalExpenditure" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Last Month Credit</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtLastMonthCredit" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Settlement</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCreditSettlement" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtCreditSettlement_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Net Monthly Profit/Loss</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtMonthlyProfitLoss" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <span style="color: #0026ff; font-weight: bold;">* Others</span>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">How payment are received</label>
                            <div class="col-sm-6">
                                <asp:CheckBoxList ID="chkPaymentReceived" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="chkPaymentReceived_SelectedIndexChanged">
                                    <asp:ListItem Value="Digital">Digital</asp:ListItem>
                                    <asp:ListItem Value="Non-Digital">Non-Digital</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Please specify % of payment received for each mode</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtPaymentRecivedMode" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="row">
                    <div class="mb-3 row m-1">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Btn_Submit_Click" />
                            &nbsp;
                            <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                        </div>
                    </div>
                </div>

                <!-- End General Form Elements -->
            </div>
        </div>
    </section>

</asp:Content>

