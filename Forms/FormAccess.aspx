<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="FormAccess.aspx.cs" Inherits="Forms_FormAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Form Access</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Master</li>
                <li class="breadcrumb-item active">Form Access</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Form Access Data Entry</h5>
                        <hr />
                        <!-- General Form Elements -->
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">User Category</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlUserCategory" runat="server" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlUserCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Project</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Users (Login User Id)</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Forms</label>
                            <div class="col-sm-6">
                                <asp:CheckBox ID="chkAll" Text="Select All Forms" runat="server" OnCheckedChanged="Check_UnCheckAll" AutoPostBack="true" />
                                <asp:CheckBoxList ID="chkForms" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="chkForms_SelectedIndexChanged">
                                    <asp:ListItem Value="1">1. Forms - Enrollment</asp:ListItem>
                                    <asp:ListItem Value="2">2. Forms - Enrollment List</asp:ListItem>
                                    <asp:ListItem Value="3">3. Forms - Training</asp:ListItem>
                                    <asp:ListItem Value="4">4. Forms - Enterprise Setup</asp:ListItem>
                                    <asp:ListItem Value="5">5. Forms - Business Progress</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Btn_Submit_Click" ValidationGroup="Submit" />
                                    &nbsp;
                                        <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Application Page Details</h5>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card radius-10 mb-2 p-2">
                                    <div class="table-responsive">
                                        <table id="example" class="table table-striped table-bordered nowrap">
                                            <asp:Repeater ID="rpt_PageDetails" runat="server">
                                                <HeaderTemplate>
                                                    <thead class="table-light">
                                                        <tr>
                                                            <th>S.No</th>
                                                            <th>UserCode</th>
                                                            <th>State</th>
                                                            <th>District</th>
                                                            <th>Block</th>
                                                            <th>Village</th>
                                                            <th>Partner</th>
                                                            <th>Project</th>
                                                            <th>Location</th>
                                                            <th>First Name</th>
                                                            <th>Last Name</th>
                                                            <th>Mobile No</th>
                                                            <th>Email</th>
                                                            <th>User Category</th>
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
                                                            <%# Eval("UserCode") %>
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
                                                            <%# Eval("PartnerName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ProjectName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("LocationName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("FirstName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("LastName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ContactNo") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Email") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Category") %>
                                                        </td>
                                                        <td>
                                                            <div class="d-flex order-actions">
                                                                <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("UserCode")%>' />
                                                                &nbsp;
                                                                <asp:Button ID="Btn_InActive" runat="server" CssClass="btn btn-sm btn-danger" Text="InActive" CommandArgument='<%#Eval("UserCode")%>'
                                                                    OnClientClick="if ( !confirm('Are you sure you want to InActive ? ')) return false;" />
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
                </div>--%>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" />
            <%--<asp:AsyncPostBackTrigger ControlID="rpt_PageDetails" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

