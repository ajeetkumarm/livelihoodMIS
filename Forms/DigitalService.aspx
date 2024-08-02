<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="DigitalService.aspx.cs" Inherits="Forms_DigitalService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        /* VALIDATION */
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please Enter Only Numeric Value:");
                return false;
            }
            return true;
        }

        function onlyAlpha(e) {
            var k = e.charCode;
            if (k == 0) {
                e.returnValue = true;
                return true;
            }
            else if ((k < 65 || k > 90) && (k < 97 || k > 122) && (k < 32 || k >= 33)) {
                e.returnValue = false;
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Service Line Master</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Masters</li>
                <li class="breadcrumb-item active">Service Line</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Service Line Master</h5>
                <hr />
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label class="col-form-label">Digital Service</label>
                        <asp:DropDownList ID="ddlDigitalService" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label class="col-form-label">Service Line</label>
                        <asp:TextBox ID="txtServiceLine" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label class="col-form-label">Digital Service URL</label>
                        <asp:TextBox ID="txtServiceURL" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label class="col-form-label">Display Order</label>
                        <asp:TextBox ID="txtDisplayOrder" runat="server" CssClass="form-control" AutoComplete="off" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                <h5 class="card-title">Digital Service Details</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_DigitalServiceDetails" runat="server">
                                        <HeaderTemplate>
                                            <thead class="table-light">
                                                <tr>
                                                    <th>S.No</th>
                                                    <th>Service Line Id </th>
                                                    <th>Digital Service</th>
                                                    <th>Service Line</th>
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
                                                    <%# Eval("ServiceId") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Category") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ServiceLine") %>
                                                </td>
                                                <td>
                                                    <div class="d-flex order-actions">
                                                        <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("ServiceId")%>' OnClick="Btn_Edit_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("ServiceId")%>'
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

