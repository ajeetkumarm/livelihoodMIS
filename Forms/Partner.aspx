<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="Partner.aspx.cs" Inherits="Forms_Partner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Partner Master</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Masters</li>
                <li class="breadcrumb-item active">Partner</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Partner Master</h5>
                <hr />
                <div class="row">
                    <div class="mb-3 row m-1">
                        <label class="col-sm-3 col-form-label">Partner</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtPartner" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                        &nbsp;
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btn_Cancel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Partner Details</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_PartnerDetails" runat="server">
                                        <HeaderTemplate>
                                            <thead class="table-light">
                                                <tr>
                                                    <th>S.No</th>
                                                    <th>Partner Id </th>
                                                    <th>Partner</th>
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
                                                    <%# Eval("PartnerId") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PartnerName") %>
                                                </td>
                                                <td>
                                                    <div class="d-flex order-actions">
                                                        <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("PartnerId")%>' OnClick="Btn_Edit_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("PartnerId")%>'
                                                            OnClick="Btn_Delete_Click" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" />
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

