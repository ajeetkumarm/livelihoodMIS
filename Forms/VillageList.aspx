<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="VillageList.aspx.cs" Inherits="Forms_VillageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Villages Master</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Masters</li>
                <li class="breadcrumb-item active">Villages</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <div class="card">
        <div class="card-body">


            <div class="row">
                <div class="col-md-6">
                    <h5 class="card-title">Village Details
                       
                    </h5>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoComplete="off" placeholder="Search"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="Btn_Search" runat="server" Text="Search" CssClass="btn btn-primary " OnClick="Btn_Search_Click" />
                    <a href="Village.aspx" class="btn btn-primary" >Add New</a>
                    <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-primary" OnClick="Btn_Export_Click" />
                </div>
               
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card radius-10 mb-2 p-2">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered nowrap">


                                <asp:Repeater ID="rpt_VillageDetails" runat="server">
                                    <HeaderTemplate>
                                        <thead class="table-light">
                                            <tr>
                                                <th>S.No</th>
                                                <th>State Name </th>
                                                <th>District Name</th>
                                                <th>Block Name</th>
                                                <th>Village Name</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("RowNum") %>
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
                                                <div class="d-flex order-actions">
                                                    <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("VillageId")%>' OnClick="Btn_Edit_Click" />
                                                    &nbsp;
                                            <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("VillageId")%>' OnClick="Btn_Delete_Click"
                                                OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" />
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="6" align="right">
                                        <div id="paging">
                                            <asp:Literal runat="server" ID="litPager"></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

