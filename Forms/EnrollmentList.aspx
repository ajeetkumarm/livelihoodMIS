<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="EnrollmentList.aspx.cs" Inherits="EnrollmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="../assets/js/jquery.min.js"></script>--%>

    <script>
        function TraningNoAction() {
            $("#NoModal").click();
        }
        //function ViewDetails() {
        //    $("#ViewModal").click();
        //}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Enrollment List</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Enrollment List</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Enrollment List</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_EnrollmentList" runat="server">
                                        <HeaderTemplate>
                                            <thead class="table-light">
                                                <tr>
                                                    <th>S.No</th>
                                                    <th>Beneficiary Code</th>
                                                    <th>Women Name</th>
                                                    <th>Phone No</th>
                                                    <th>State</th>
                                                    <th>District</th>
                                                    <th>Block</th>
                                                    <th>Village</th>
                                                    <th>Registration Date</th>
                                                    <th>Are you Interested in EDP Training ?</th>
                                                    <th>Action</th>
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
                                                    <%# Eval("WomenName") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PhoneNo") %>
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
                                                    <%# Eval("RegistrationDate","{0:dd/MM/yyyy}") %>
                                                </td>
                                                <td>
                                                    <div class="d-flex order-actions">
                                                        <asp:Button ID="Btn_Yes" runat="server" CssClass="btn btn-sm btn-warning" Text="Yes" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_Yes_Click"
                                                            OnClientClick="if ( !confirm('Are you sure you want to take Action ? ')) return false;" />
                                                        &nbsp;
                                                        <asp:Button ID="Btn_No" runat="server" CssClass="btn btn-sm btn-danger" Text="No" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_No_Click" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <!-- Add Edit Button -->
                                                    <a href="Enrollment.aspx?EnrollmentId=<%#Eval("EnrollmentId")%>" class="btn btn-sm btn-success">Edit</a>

                                                    <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_Delete_Click"
                                                        OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" />
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

    <!-- Importer Details -->
    <button id="NoModal" type="button" style="display: none;" data-bs-toggle="modal" data-bs-target="#TrainingActionModal"></button>
    <div id="TrainingActionModal" class="modal fade" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="text-center fs-5" style="margin: auto;">EDP Training not interested reasons</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row align-items-center offset-2">
                        <label for="inputEmail3" class="col-sm-4 col-form-label">Please specify reasons :</label>
                        <div class=" offset-sm-1 col-sm-4">
                            <asp:DropDownList ID="ddlReasons" runat="server" CssClass="form-select">
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
                    <%--<div class="row align-items-center offset-3">
                        <label for="inputEmail3" class="col-sm-3 col-form-label">Company Name :</label>
                        <div class=" offset-sm-1 col-sm-4">
                            <asp:Label ID="lblCompanyName" CssClass="LabelCss" runat="server"></asp:Label>
                        </div>
                    </div>--%>
                </div>
                <div class="modal-footer py-1">
                    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                    &nbsp;
                    <asp:Button ID="Button6" CssClass="btn btn-secondary" data-bs-dismiss="modal" runat="server" Text="Close" />
                </div>
            </div>
        </div>
    </div>
    <!-- End -->
</asp:Content>

