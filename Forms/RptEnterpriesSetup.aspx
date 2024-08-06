<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptEnterpriesSetup.aspx.cs" Inherits="Forms_RptEnterpriesSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>
    <script src="/assets/js/angular/ReportEnterpriesSetup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Enterpries Training Report</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Reports</li>
                <li class="breadcrumb-item active">Enterpries Training Report</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body" ng-app="reportEnterpriesSetupTrainingApp" ng-controller="reportEnterpriesSetupTrainingController">
                <h5 class="card-title">Enterpries Training Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="reportEnterpriesSetupTable" class="table table-striped table-bordered nowrap">
                                    <thead class="table-light">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Beneficiary Code</th>
                                            <th>State</th>
                                            <th>District</th>
                                            <th>Block</th>
                                            <th>Village</th>
                                            <th>Project</th>
                                            <th>UserName (FE)</th>
                                            <th>Women Name</th>
                                            <th>Start Business</th>
                                            <th>Business Reasons</th>
                                            <th>Business</th>
                                            <th>Business When</th>
                                            <th>Status Business</th>
                                            <th>Village Population</th>
                                            <th>Business Idea</th>
                                            <th>Business Type</th>
                                            <th>Procure Business</th>
                                            <th>Current Business</th>
                                            <th>Regular Financial Business</th>
                                            <th>How Regular Financial</th>
                                            <th>Setting Business Type</th>
                                            <th>Monthly Rent</th>
                                            <th>Expand Business</th>
                                            <th>Potential Customers</th>
                                            <th>Business Distance</th>
                                            <th>Expected Foot fall</th>
                                            <th>How Far Bussiness</th>
                                            <th>Support Business</th>
                                            <th>Support Type</th>
                                            <th>Not Provided Support</th>
                                            <th>Paid Worker</th>
                                            <th>Digital Inclusion</th>
                                            <th>Digital Inclusion Date</th>
                                            <th>Own Smart Phone</th>
                                            <th>Use Smart Phone</th>
                                            <th>Supply Chain</th>
                                            <th>Submited On</th>
                                        </tr>
                                    </thead>

                                </table>

                                <%--<asp:Repeater ID="rpt_EnterprisesSetup" runat="server">
                                    <HeaderTemplate>

                                        <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSrNo" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
                                            </td>
                                            <td>
                                                <%# Eval("BeneficiaryCode") %>
                                            </td>
                                            <td>
                                                <%# Eval("StateName") %>
                                            </td>
                                            <td>
                                                <%# Eval("DistrictName") %>
                                            </td>
                                            <td>
                                                <%# Eval("BlockName") %>
                                            </td>
                                            <td>
                                                <%# Eval("VillageName") %>
                                            </td>
                                            <td>
                                                <%# Eval("ProjectName") %>
                                            </td>
                                            <td>
                                                <%# Eval("UserName") %>
                                            </td>
                                            <td>
                                                <%# Eval("WomenName") %>
                                            </td>
                                            <td>
                                                <%# Eval("StartBusiness") %>
                                            </td>
                                            <td>
                                                <%# Eval("BusinessReasons") %>
                                            </td>
                                            <td>
                                                <%# Eval("Business") %>
                                            </td>
                                            <td>
                                                <%# Eval("BusinessWhen") %>
                                            </td>
                                            <td>
                                                <%# Eval("StatusBusiness") %>
                                            </td>
                                            <td>
                                                <%# Eval("VillagePopulation") %>
                                            </td>
                                            <td>
                                                <%# Eval("BusinessIdea") %>
                                            </td>
                                            <td>
                                                <%# Eval("BusinessType") %>
                                            </td>
                                            <td>
                                                <%# Eval("ProcureBusiness") %>
                                            </td>
                                            <td>
                                                <%# Eval("CurrentBusiness") %>
                                            </td>
                                            <td>
                                                <%# Eval("RegularFinancialBusiness") %>
                                            </td>
                                            <td>
                                                <%# Eval("HowRegularFinancial") %>  
                                            </td>
                                            <td>
                                                <%# Eval("SettingBusinessType") %>  
                                            </td>
                                            <td>
                                                <%# Eval("MonthlyRent") %>  
                                            </td>
                                            <td>
                                                <%# Eval("ExpandBusiness") %>  
                                            </td>
                                            <td>
                                                <%# Eval("PotentialCustomers") %>
                                            </td>
                                            <td>
                                                <%# Eval("BusinessDistance") %>  
                                            </td>
                                            <td>
                                                <%# Eval("ExpectedFootfall") %>  
                                            </td>
                                            <td>
                                                <%# Eval("HowFarBussiness") %>  
                                            </td>
                                            <td>
                                                <%# Eval("SupportBusiness") %>  
                                            </td>
                                            <td>
                                                <%# Eval("SupportType") %>
                                            </td>
                                            <td>
                                                <%# Eval("NotProvidedSupport") %>  
                                            </td>
                                            <td>
                                                <%# Eval("PaidWorker") %>  
                                            </td>
                                            <td>
                                                <%# Eval("DigitalInclusion") %>  
                                            </td>
                                            <td>
                                                <%# Eval("DigitalInclusionDate") %>  
                                            </td>
                                            <td>
                                                <%# Eval("OwnSmartPhone") %>
                                            </td>
                                            <td>
                                                <%# Eval("UseSmartPhone") %>  
                                            </td>
                                            <td>
                                                <%# Eval("SupplyChain") %>  
                                            </td>
                                            <td>
                                                <%# Eval("CreatedOn","{0:yyyy/MM/dd}") %>
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                    </FooterTemplate>
                                </asp:Repeater>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

