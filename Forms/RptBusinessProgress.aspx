<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptBusinessProgress.aspx.cs" Inherits="Forms_RptBusinessProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var UserCategory = <%= UserCategory %>;
    </script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>
    <script src="/assets/js/angular/ReportBusinessProgress.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Business Progress Report</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Reports</li>
                <li class="breadcrumb-item active">Business Progress Report</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body" ng-app="reportBusinessProgressApp" ng-controller="reportBusinessProgressController">
                <h5 class="card-title">Business Progress Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="reportBusinessProgressTable" class="table table-striped table-bordered nowrap">
                                    <thead class="table-light">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Beneficiary Code</th>
                                            <th>State</th>
                                            <th>District</th>
                                            <th>Block</th>
                                            <th>Village</th>
                                            <th>Project</th>
                                            <% if (UserCategory != 9)
                                                { %>
                                            <th>UserName (FE)</th>
                                            <th>Women Name</th>
                                            <% } %>
                                            <th>Starting Business Date</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>No New Customer</th>
                                            <th>No Repeated Customer</th>
                                            <th>Services Offered Type</th>
                                            <th>Services Provided Details</th>
                                            <th>Gov Customer Services</th>
                                            <th>G2C Services</th>
                                            <th>Income from Sell</th>
                                            <th>Cash Sell Amount</th>
                                            <th>Credit Sell Amount</th>
                                            <th>Total Income</th>
                                            <th>Investment</th>
                                            <th>Expenditure from Purchase</th>
                                            <th>Cash Expenditure</th>
                                            <th>Credit Expenditure</th>
                                            <th>Total Expenditure</th>
                                            <th>Last Month Credit</th>
                                            <th>Credit Settlement</th>
                                            <th>Monthly Profit Loss</th>
                                            <th>Payment Received</th>
                                            <th>Payment Received Mode</th>
                                            <th>Submited On</th>
                                        </tr>
                                    </thead>
                                </table>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

