<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="ProjectLocation.aspx.cs" Inherits="Forms_ProjectLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pagetitle">
        <h1>Project Location Master</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Masters</li>
                <li class="breadcrumb-item active">Project Location</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Project Location Master</h5>
                <hr />
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label class="col-form-label">Project Location</label>
                        <asp:TextBox ID="txtProjectLocation" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
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
                <h5 class="card-title">Project Location Details</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_ProjectLocationDetails" runat="server">
                                        <HeaderTemplate>
                                            <thead class="table-light">
                                                <tr>
                                                    <th>S.No</th>
                                                    <th>Project Location Id </th>
                                                    <th>Project Location</th>
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
                                                    <%# Eval("ProjectId") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ProjectName") %>
                                                </td>
                                                <td>
                                                    <div class="d-flex order-actions">
                                                        <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("ProjectId")%>' OnClick="Btn_Edit_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("ProjectId")%>'
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

