<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="Training.aspx.cs" Inherits="Forms_Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="radio"] {
            margin-left: 0.75rem;
        }
    </style>

    <%--<script type="text/javascript">
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
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Training Form</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Training</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="section">
                <div class="card">
                    <div class="card-body">

                        <!-- General Form Elements -->
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Is Life skills training a part of the programme</label>
                            <div class="col-sm-6">
                                <asp:RadioButtonList ID="rblIsLifeSkills" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblIsLifeSkills_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="divLst" runat="server" class="row">

                            <span style="color: #0026ff; font-weight: bold;">* Life Skills Training Component</span>

                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Day 1: Resilience & communication skills completion date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtRCSCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Day 2: Women rights & protection completion date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtWRPCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Day 3: Health & nutrition completion date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtHNCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Day 4: Financial literacy completion date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtFLCDAte" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFLCDate" runat="server" ErrorMessage="Required." ControlToValidate="txtFLCDAte"
                                        ValidationGroup="Submit" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div id="divEdt" runat="server" class="row">
                            <span style="color: #0026ff; font-weight: bold;">* Enterprise Development Training Component</span>

                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Enterprise Development Training Starting Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtEDTSDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">LEAP Training Completion Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtLEAPDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">FEST Training 1: Enterprenuership Skills, Interpersonnel Skills and Time Mangement Training Completion Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtESISTDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Training 2: Business Management Training Completion Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtBMTCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">Training 3: Marketing Management Training Completion Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtMMTCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row m-1">
                                <label class="col-sm-3 col-form-label">EDP Training Completion Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtEDPTCDate" runat="server" class="form-control" type="date" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <div class="col-sm-10">
                                <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="Submit" OnClick="Btn_Submit_Click" />
                                &nbsp;
                                    <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                            </div>
                        </div>
                        <!-- End General Form Elements -->
                    </div>

                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

