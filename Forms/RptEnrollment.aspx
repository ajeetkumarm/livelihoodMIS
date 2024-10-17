<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptEnrollment.aspx.cs" Inherits="Forms_RptEnrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var UserCategory = <%= UserCategory %>;
    </script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>

    <script src="/assets/js/angular/ReportEnrollment.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Enrollment Report</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Reports</li>
                <li class="breadcrumb-item active">Enrollment Report</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body" ng-app="reportEnrollmentApp" ng-controller="reportEnrollmentController">
                <h5 class="card-title">Enrollment Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="reportEnrollmentTable" class="table table-striped table-bordered nowrap">
                                    <thead class="table-light">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Beneficiary Code</th>
                                            <th>Employee Id</th>
                                            <th>State</th>
                                            <th>District</th>
                                            <th>Block</th>
                                            <th>Village</th>
                                            <th>Project</th>
                                            <% if (UserCategory != 9)
                                                { %>
                                            <th>UserName (FE)</th>
                                            <% } %>
                                            <th>Enrollment Status</th>
                                            <th>Replacement Employee Id</th>
                                            <th>Replacement Beneficiary Code</th>
                                            <th>Cohort</th>

                                            <% if (UserCategory != 9)
                                                { %>
                                            <th>Women Name</th>
                                            <th>Husband/Father Name</th>
                                            <th>Mother Name</th>
                                            <th>Phone No.</th>
                                            <% } %>

                                            <th>Theme Code</th>
                                            <th>Cast</th>
                                            <th>Economic Status</th>
                                            <th>Marital Status</th>
                                            <th>Birth Date</th>
                                            <th>Age</th>
                                            <th>Registration Date</th>
                                            <th>Part SHG</th>
                                            <th>SHG Name</th>
                                            <th>SHG Date</th>
                                            <th>SHG Type</th>
                                            <th>SHG Id</th>
                                            <th>Education</th>
                                            <th>PwD</th>
                                            <th>PwD Specify</th>
                                            <th>Aadhaar Card</th>
                                            <th>Aadhaar Card Details</th>
                                            <th>Aadhaar No.</th>
                                            <th>Any ID Proof Details</th>
                                            <th>ID Proof No.</th>
                                            <th>Issuing Authority</th>
                                            <th>Ration Card</th>
                                            <th>Ration Card linked PDS</th>
                                            <th>Bank Account No.</th>
                                            <th>Linked Social Security Schemes</th>
                                            <th>Reasons</th>
                                            <th>Women Belong </th>
                                            <th>Valid Certificate</th>
                                            <th>Monthly Individual Income</th>
                                            <th>Monthly Household Income</th>
                                            <th>Scheme</th>
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

