<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="OldEnterpriesSetup.aspx.cs" Inherits="Forms_OldEnterpriesSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Enterprise Setup</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Enterprise Setup</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Enterprise Setup</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_EntSetupList" runat="server">
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
                                                        <asp:Button ID="Btn_Update" runat="server" CssClass="btn btn-sm btn-success" Text="Update" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_Update_Click" />
                                                        <%--&nbsp;
                                                        <asp:Button ID="Btn_No" runat="server" CssClass="btn btn-sm btn-danger" Text="No" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_No_Click" />--%>
                                                    </div>
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

