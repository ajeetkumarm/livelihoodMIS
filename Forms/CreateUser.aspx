<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="Forms_CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        /* VALIDATION */
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Create User</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Master</li>
                <li class="breadcrumb-item active">Create User</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Create User</h5>
                        <hr />
                        <div class="row">
                            <!-- General Form Elements -->
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">User Category</label>
                                <asp:DropDownList ID="ddlUserCategory" runat="server" class="form-select"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">State</label>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Block</label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Village</label>
                                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Partner</label><span style="color: red;">*</span>
                                <asp:DropDownList ID="ddlPartner" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlPartner_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Project</label><span style="color: red;">*</span>
                                <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                             <div class="col-md-6 mb-3">
                                <label class="col-form-label">Location</label><span style="color: red;">*</span>
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Email Id</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Mobile No</label>
                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                            <!-- End General Form Elements -->

                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">User Details</h5>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card radius-10 mb-2 p-2">
                                    <div class="table-responsive">
                                        <table id="example1" class="table table-striped table-bordered nowrap">
                                            <asp:Repeater ID="rpt_UserDetails" runat="server">
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
                                                                <asp:Button ID="Btn_Edit" runat="server" CssClass="btn btn-sm btn-warning" Text="Edit" CommandArgument='<%#Eval("UserCode")%>' OnClick="Btn_Edit_Click" />
                                                                &nbsp;
                                                                <asp:Button ID="Btn_InActive" runat="server" CssClass="btn btn-sm btn-danger" Text="InActive" CommandArgument='<%#Eval("UserCode")%>'
                                                                    OnClick="Btn_InActive_Click" OnClientClick="if ( !confirm('Are you sure you want to InActive ? ')) return false;" />
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
            <asp:AsyncPostBackTrigger ControlID="rpt_UserDetails" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

