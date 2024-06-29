<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="States.aspx.cs" Inherits="Forms_States" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src=" https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap.min.js"></script>   
    <script src="https://cdn.datatables.net/buttons/2.3.6/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.6/js/buttons.html5.min.js"></script>--%>
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap.min.css" rel="stylesheet" />  
    <link href="https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.3.6/css/buttons.dataTables.min.css" rel="stylesheet" />--%>
    <%--<script>
        $(document).ready(function () {
            $('#example').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    //'copyHtml5',
                    'excelHtml5',
                    'pdfHtml5'
                ]
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:HiddenField ID="hdfStateId" runat="server" />--%>

    <div class="pagetitle">
        <h1>State Master</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Masters</li>
                <li class="breadcrumb-item active">States</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">State Master</h5>
                        <hr class="m-0" />
                        <div class="row">
                            <div class="col-md-6 mb-2">
                                <label class="col-form-label">State Name</label>
                                <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                <%--<div class="col-sm-10">
                            <asp:TextBox ID="txtBeneficiaryCode" runat="server" class="form-control"></asp:TextBox>
                        </div>--%>
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
                        <h5 class="card-title">State Details</h5>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card radius-10 mb-2 p-2">

                                    <div class="table-responsive">
                                        <table id="example" class="table table-striped table-bordered nowrap">
                                            <asp:Repeater ID="rpt_StateDetails" runat="server">
                                                <HeaderTemplate>
                                                    <thead class="table-light">
                                                        <tr>
                                                            <th>S.No</th>
                                                            <th>State Id </th>
                                                            <th>State Name</th>
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
                                                            <%# Eval("StateId") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("StateName") %>
                                                        </td>
                                                        <td>
                                                            <div class="d-flex order-actions">
                                                                <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("StateId")%>' OnClick="Btn_Edit_Click" />
                                                                &nbsp;
                                                            <asp:Button ID="Btn_Delete" runat="server" CssClass="btn btn-sm btn-danger" Text="Delete" CommandArgument='<%#Eval("StateId")%>' OnClick="Btn_Delete_Click" 
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

