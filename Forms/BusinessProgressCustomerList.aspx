<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="BusinessProgressCustomerList.aspx.cs" Inherits="Forms_BusinessProgressCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>
    <script src="/assets/js/angular/businessProgressCustomerList.js"></script>

    <script>
        app.value("enrollmentId", <%= EnrollmentId%>);
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="card-body" ng-app="businessProgressCustomerListApp" ng-controller="businessProgressCustomerListController">
                <h5 class="card-title">Business Progress
                    <a href="BusinessProgressCustomer.aspx" id="aAddNew" runat="server" class="btn btn-primary float-end">Add New</a>
                </h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="enterpriesSetupDataTable" class="table table-striped table-bordered nowrap">
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
                                            <th>Starting Business Date</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>No New Customer</th>
                                            <th>No Repeated Customer</th>
                                            <th>Services Offered Type</th>
                                            <th>Services Provided Details</th>
                                            <th>Gov CustomerServices</th>
                                            <th>G2CServices</th>
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

