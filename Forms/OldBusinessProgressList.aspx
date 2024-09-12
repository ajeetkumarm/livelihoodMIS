<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="OldBusinessProgressList.aspx.cs" Inherits="Forms_OldBusinessProgressList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Business Progress List</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Business Progress List</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Business Progress</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_BusinessProgress" runat="server">
                                        <HeaderTemplate>
                                            <thead class="table-light">
                                                <tr>
                                                    <th>S.No</th>
                                                    <th>Indicatior</th>
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
                                                    <a href="javascript:void(0)" tile="View product detail" data-bs-toggle="modal"
                                                        data-bs-target="#viewStatus" class="text-primary">Update Status
                                                    </a>
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
                                                        <asp:Button ID="Btn_AddBusinessProgress" runat="server" CssClass="btn btn-sm btn-success" Text="Add Business Progress" CommandArgument='<%#Eval("EnrollmentId")%>' OnClick="Btn_AddBusinessProgress_Click" />
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


    <div id="viewStatus" class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true"
        style="display: none;">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="myModalLabel">Update Business Status</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body py-0">
                    <div class="table-responsive table-card">
                        <table class="table table-sm table-nowrap mb-0" summary="Order Product Details List">
                            <tbody>
                                <tr>
                                    <th style="width: 30%;" class="text-left">Business Status</th>
                                    <td style="width: 1%;">:</td>
                                    <td class="no-word-wrap">
                                        <select id="ddlBusinessStatus" class="form-select-sm">
                                            <option value="0">Select</option>
                                            <option value="1">Active</option>
                                            <option value="2">Hold</option>
                                            <option value="3">Closed</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>

