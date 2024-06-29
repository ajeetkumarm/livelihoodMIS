<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="EnterpriseStartUpgrate.aspx.cs" Inherits="Forms_EnterpriseStartUpgrate" %>

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
        <h1>Starting/Upgrading – Enterprise Setup</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Enterpries Setup</li>
            </ol>
        </nav>
    </div>
    <a href="EnterpriesSetup.aspx"></a>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">

                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Are you willing to start/upgrade business?</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblStartBusiness" runat="server" RepeatDirection="Horizontal" CssClass="pe-4"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblStartBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_Reasons" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Please Specify Reasons</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlNoReasons" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Not Interested">Not Interested</asp:ListItem>
                                    <asp:ListItem Value="Time Availability">Time Availability</asp:ListItem>
                                    <asp:ListItem Value="Household Chores">Household Chores</asp:ListItem>
                                    <asp:ListItem Value="May be Migrating Soon">May be Migrating Soon</asp:ListItem>
                                    <asp:ListItem Value="Family is Not Allowing">Family is Not Allowing</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_Business" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Business</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="New Business">New Business (Nano) </asp:ListItem>
                                    <asp:ListItem Value="Upgrade Business">Scale/Upgrade Business</asp:ListItem>
                                    <asp:ListItem Value="Innovative Business">Innovative Business</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_When" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">When</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlWhen" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Immediately">Immediately</asp:ListItem>
                                    <asp:ListItem Value="Within One Month">Within One Month</asp:ListItem>
                                    <asp:ListItem Value="Within Three Months">Within Three Months</asp:ListItem>
                                    <asp:ListItem Value="Within Six Months">Within Six Months</asp:ListItem>
                                    <asp:ListItem Value="Not Yet Decided">Not Yet Decided</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <!-- New Add--->
                        <div id="div_StatusBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Present Status of Business</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlStatusBusiness" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Blooming">Blooming</asp:ListItem>
                                    <asp:ListItem Value="Growth Potential">Growth Potential</asp:ListItem>
                                    <asp:ListItem Value="Need Support">Need Support</asp:ListItem>
                                    <asp:ListItem Value="Incurring losses">Incurring losses</asp:ListItem>
                                    <asp:ListItem Value="Shut Down">Shut Down</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div id="div_VillagePopulation" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Please specify the population of your village</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtVillagePopulation" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvVillagePopulation" runat="server" ErrorMessage="Required." ControlToValidate="txtVillagePopulation"
                                    ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div id="div_BusinessIdea" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Have you thought of any idea regarding your business?</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblBusinessIdea" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBusinessIdea_SelectedIndexChanged">
                                    <%--<asp:RadioButtonList ID="rblBusinessIdea" runat="server" RepeatDirection="Horizontal" >--%>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_BusinessType" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Type of Business</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlBusinessType" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Grocery">Grocery</asp:ListItem>
                                    <asp:ListItem Value="Cosmetic & Stationery">Cosmetic & Stationery</asp:ListItem>
                                    <asp:ListItem Value="Tailoring">Tailoring</asp:ListItem>
                                    <asp:ListItem Value="Garment">Garment</asp:ListItem>
                                    <asp:ListItem Value="Beauty Parlor">Beauty Parlor</asp:ListItem>
                                    <asp:ListItem Value="Dairy">Dairy</asp:ListItem>
                                    <asp:ListItem Value="Bakery/Food">Bakery/Food</asp:ListItem>
                                    <asp:ListItem Value="Vegetable Selling">Vegetable Selling</asp:ListItem>
                                    <asp:ListItem Value="Digital Business">Digital Business</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div id="div_ProcureBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How do you procure stocks for the business?</label>
                            <div class="col-sm-6">
                                <div class="table-responsive">
                                    <asp:GridView ID="GvProcureBusiness" runat="server" AutoGenerateColumns="False" DataKeyNames="ProcureBusinessCount" OnRowCommand="GvProcureBusiness_RowCommand"
                                        OnRowDeleting="GvProcureBusiness_RowDeleting" ShowFooter="true" CssClass="table table-bordered table-striped table-hover">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assets/img/Delete.png"
                                                        ToolTip="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="but_Add" runat="server" title="Add Row" ImageUrl="~/assets/img/Add.png" ValidationGroup="1" CommandName="AddNew" />
                                                </FooterTemplate>
                                                <HeaderStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Procure stocks">
                                                <ItemTemplate>
                                                    <%--<asp:HiddenField runat="server" ID="hdfProcureBusinessId" Value='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.ProcureBusinessId").ToString())%>'></asp:HiddenField>--%>
                                                    <asp:Label ID="lblProcureBusiness" runat="server" Text='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.ProcureBusiness").ToString())%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlFooterProcureBusiness" runat="server" CssClass="form-select">
                                                        <asp:ListItem Value="0">--Select Procure stocks--</asp:ListItem>
                                                        <asp:ListItem Value="Self">Self</asp:ListItem>
                                                        <asp:ListItem Value="Family Support">Family Support</asp:ListItem>
                                                        <asp:ListItem Value="Seller Reaches Us">Seller Reaches Us</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlFooterProcureBusiness" runat="server" ControlToValidate="ddlFooterProcureBusiness" Display="Dynamic"
                                                        ErrorMessage="Please Select !" InitialValue="0" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Distance Travel For Stock Procurement">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistanceStockProcurement" runat="server" Text='<%#  System.Web.HttpUtility.HtmlEncode(DataBinder.Eval(Container, "DataItem.DistanceStockProcurement").ToString())%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlFooterDistanceStockProcurement" runat="server" CssClass="form-select">
                                                        <asp:ListItem Value="0">--Select Distance--</asp:ListItem>
                                                        <asp:ListItem Value="0-2 kms">0-2 kms</asp:ListItem>
                                                        <asp:ListItem Value="3-5 kms">3-5 kms</asp:ListItem>
                                                        <asp:ListItem Value="6-8 kms">6-8 kms</asp:ListItem>
                                                        <asp:ListItem Value="9 kms and above">9 kms and above</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlFooterDistanceStockProcurement" runat="server" ControlToValidate="ddlFooterDistanceStockProcurement" Display="Dynamic"
                                                        ErrorMessage="Please Select !" InitialValue="0" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <div id="div_CurrentBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">What is your current business?</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCurrentBusiness" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Grocery">Grocery</asp:ListItem>
                                    <asp:ListItem Value="Cosmetic & Stationery">Cosmetic & Stationery</asp:ListItem>
                                    <asp:ListItem Value="Tailoring">Tailoring</asp:ListItem>
                                    <asp:ListItem Value="Garment">Garment</asp:ListItem>
                                    <asp:ListItem Value="Beauty Parlor">Beauty Parlor</asp:ListItem>
                                    <asp:ListItem Value="Dairy">Dairy</asp:ListItem>
                                    <asp:ListItem Value="Bakery/Food">Bakery/Food</asp:ListItem>
                                    <asp:ListItem Value="Vegetable Selling">Vegetable Selling</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_RegFinBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Do you have a regular financial flow (Investment) for your business?</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblRegularFinancialBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblRegularFinancialBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_How" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlHow" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Self Financed">Self Financed</asp:ListItem>
                                    <asp:ListItem Value="Banks">Banks</asp:ListItem>
                                    <asp:ListItem Value="Family and Friends">Family and Friends</asp:ListItem>
                                    <asp:ListItem Value="Self Help Group">Self Help Group</asp:ListItem>
                                    <asp:ListItem Value="Moneylender">Moneylender</asp:ListItem>
                                    <asp:ListItem Value="MFI">MFI</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_SettingBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">What type of space you have for setting up the business</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblSettingBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblSettingBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Rented">Rented</asp:ListItem>
                                    <asp:ListItem Value="Owned">Owned</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_MonthlyRent" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Approx Monthly Rent</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtMonthlyRent" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>



                        <div id="div_ExpandBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How are you planning to expand/scale your business?</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlExpandScaleBusiness" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Self Financed">Self Financed</asp:ListItem>
                                    <asp:ListItem Value="Banks">Banks</asp:ListItem>
                                    <asp:ListItem Value="Family and Friends">Family and Friends</asp:ListItem>
                                    <asp:ListItem Value="Self Help Group">Self Help Group</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_PotentialCustomers" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Do you understand your potential market/customers?</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblPotentialCustomers" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblPotentialCustomers_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_DistanceBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Estimated Distance of business from village (In KMs)</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlDistanceBusiness" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Same Location">Same Location</asp:ListItem>
                                    <asp:ListItem Value="0-2 kms">0-2 kms</asp:ListItem>
                                    <asp:ListItem Value="3-5 kms">3-5 kms</asp:ListItem>
                                    <asp:ListItem Value="6-8 kms">6-8 kms</asp:ListItem>
                                    <asp:ListItem Value="9-12 kms">9-12 kms</asp:ListItem>
                                    <asp:ListItem Value="9 kms and above">13 kms and above</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_footfall" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Expected daily footfall</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtExpectedFootfall" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_BusinessExisting" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How far is same type of business existing?</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlBusinessExisting" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Same Location">Same Location</asp:ListItem>
                                    <asp:ListItem Value="0-2 kms">0-2 kms</asp:ListItem>
                                    <asp:ListItem Value="3-5 kms">3-5 kms</asp:ListItem>
                                    <asp:ListItem Value="6-8 kms">6-8 kms</asp:ListItem>
                                    <asp:ListItem Value="9-12 kms">9-12 kms</asp:ListItem>
                                    <asp:ListItem Value="9 kms and above">13 kms and above</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_PromoteBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How are you planning to promote your business?</label>
                            <div class="col-sm-6">
                                <asp:CheckBoxList ID="chkPromoteBusiness" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" CssClass="form-control">
                                    <asp:ListItem Value="Door to Door campaign">Door to door campaign</asp:ListItem>
                                    <asp:ListItem Value="Outdoor campaigns and events">Outdoor campaigns and events</asp:ListItem>
                                    <asp:ListItem Value="Banners/Posters/Hoardings">Banners/Posters/Hoardings</asp:ListItem>
                                    <asp:ListItem Value="Personal Contacts">Personal Contacts</asp:ListItem>
                                    <asp:ListItem Value="Local opinion makers">Local opinion makers</asp:ListItem>
                                </asp:CheckBoxList>


                                <%--<asp:DropDownList ID="ddlPlanningBusiness" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>                                    
                                </asp:DropDownList>--%>
                            </div>
                        </div>
                        <div id="div_SuportBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Do you require any advance support for your business</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblAdvSupBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblAdvSupBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_SupportType" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Type of Support</label>
                            <div class="col-sm-6">
                                <asp:CheckBoxList ID="chkSupportType" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" CssClass="form-control">
                                    <asp:ListItem Value="Financial Support">Financial Support</asp:ListItem>
                                    <asp:ListItem Value="Human Resource Support">Human Resource Support</asp:ListItem>
                                    <asp:ListItem Value="Training Support">Training Support</asp:ListItem>
                                    <asp:ListItem Value="Government Partnership and Liasioning">Government Partnership and Liasioning</asp:ListItem>
                                    <asp:ListItem Value="Technical Support">Technical Support</asp:ListItem>
                                    <asp:ListItem Value="Market Reach and Linkages">Market Reach and Linkages</asp:ListItem>
                                    <asp:ListItem Value="Diversify to more products/services">Diversify to more products/services</asp:ListItem>
                                    <asp:ListItem Value="More Investment">More Investment</asp:ListItem>
                                    <asp:ListItem Value="More Branches">More Branches</asp:ListItem>
                                    <asp:ListItem Value="More Stock">More Stock</asp:ListItem>
                                    <asp:ListItem Value="More Employees">More Employees</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div id="div_NotSupportBusiness" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">What if the required support is not provided?</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlSupportNotProvide" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Will operate the business on its own">Will operate the business on its own</asp:ListItem>
                                    <asp:ListItem Value="Will explore other opportunities">Will explore other opportunities</asp:ListItem>
                                    <asp:ListItem Value="Will not operate the business">Will not operate the business</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <!--Add New-->


                        <div id="div_PaidWorkers" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">How many paid workers have you employed/will employee at your enterprise</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtPaidWorkers" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_DigitalTrnNo" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Digital inclusion training Number</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtDigitalTrnNo" runat="server" class="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_DigitalInclusionDate" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Date of Digital inclusion training conducted</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtDigitalInclusionDate" runat="server" class="form-control" AutoComplete="off" type="date"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_SmartPhone" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Do you have your own smart-phone? </label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblSmartPhone" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_SmartPhoneActivity" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Do you use Smart phone or tab or computer for your business activities? </label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblSmartPhoneActivity" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="div_SupplyChain" runat="server" class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Supply chain model created </label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblSupplyChain" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>




                        <div class="row">
                            <div class="mb-3 row m-1">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="Submit" OnClick="Btn_Submit_Click" />
                                    &nbsp;
                                    <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

