﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="VillageOld.aspx.cs" Inherits="Forms_VillageOld" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Villages Master</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">State Name</label>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">District Name</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Block Name</label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Village Name</label>
                                <asp:TextBox ID="txtVillageName" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
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
                        <h5 class="card-title">Village Details</h5>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card radius-10 mb-2 p-2">
                                    <div class="table-responsive">
                                        <table id="example" class="table table-striped table-bordered nowrap">
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
                                                            <asp:Label ID="lblSrNo" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
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
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

