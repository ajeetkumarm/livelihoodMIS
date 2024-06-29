<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptEnrollment.aspx.cs" Inherits="Forms_RptEnrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <div class="card-body">
                <h5 class="card-title">Enrollment Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_Enrollment" runat="server">
                                        <HeaderTemplate>
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
                                                    <th>Husband/Father Name</th>
                                                    <th>Mother Name</th>
                                                    <th>Phone No.</th>
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
                                                    <%# Eval("HusbandFatherName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("MotherName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PhoneNo") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ThemeCode") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CastName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("EconomicStatus") %>
                                                </td>
                                                <td>
                                                    <%# Eval("MaritalStatus") %>
                                                </td>
                                                <td>
                                                    <%# Eval("BirthDate","{0:dd/MM/yyyy}") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Age") %>
                                                </td>
                                                <td>
                                                    <%# Eval("RegistrationDate","{0:dd/MM/yyyy}") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PartSHG") %>
                                                </td>
                                                <td>
                                                    <%# Eval("SHGName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("SHGDate","{0:dd/MM/yyyy}") %>
                                                </td>
                                                <td>
                                                    <%# Eval("SHGType") %>
                                                </td>
                                                <td>
                                                    <%# Eval("EducationName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PwD") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PwDSpecify") %>
                                                </td>
                                                <td>
                                                    <%# Eval("AadhaarrCard") %>
                                                </td>
                                                <td>
                                                    <%# Eval("AadhaarCardDetails") %>
                                                </td>
                                                <td>
                                                    <%# Eval("AadhaarNo") %>
                                                </td>
                                                <td>
                                                    <%# Eval("AnyIDProofDetails") %>
                                                </td>
                                                <td>
                                                    <%# Eval("IDProofNo") %>
                                                </td>
                                                <td>
                                                    <%# Eval("IssuingAuthority") %>
                                                </td>
                                                <td>
                                                    <%# Eval("RationCard") %>
                                                </td>
                                                <td>
                                                    <%# Eval("RationCardlinkedPDS") %>
                                                </td>
                                                <td>
                                                    <%# Eval("BankAccountNo") %>
                                                </td>
                                                <td>
                                                    <%# Eval("LinkedSocialSecuritySchemes") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Reasons") %>
                                                </td>
                                                <td>
                                                    <%# Eval("WomenBelong") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ValidCertificate") %>
                                                </td>
                                                <td>
                                                    <%# Eval("MonthlyIndividualIncome") %>
                                                </td>
                                                <td>
                                                    <%# Eval("MonthlyHouseholdIncome") %>
                                                </td>
                                                <td>
                                                    <%# Eval("SchemeName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CreatedOn","{0:yyyy-MM-dd}") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

