<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="EnterpriesTraining.aspx.cs" Inherits="Forms_EnterpriesTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="radio"] {
            margin-left: 0.75rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="pagetitle">
        <h1>Enterpries Training Form</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Enterpries Training</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <section class="section">
                <div class="card">
                    <div class="card-body">
                        <%--<h5 class="card-title">Life Skills Training</h5>
                        <hr />--%>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label class="col-form-label">Shown interest to start business</label>
                                <asp:RadioButtonList ID="rblStartBusiness" runat="server" RepeatDirection="Horizontal" CssClass="pe-4"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblStartBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                           <%-- <div id="div_StartedImprovedBusiness" class="col-md-6 mb-3" runat="server" visible="false">
                                <label class="col-form-label">Started / improved business</label>
                                <asp:RadioButtonList ID="rblStartedImprovedBusiness" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblStartedImprovedBusiness_SelectedIndexChanged">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>--%>
                            <asp:Panel ID="pnl_Lst" runat="server" Visible="false">
                                <div class="col-md-6 mb-3">
                                    <label class="col-form-label">if, Yes</label>
                                    <asp:RadioButtonList ID="rblStartedImprovedDetails" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Started Business">Started Business</asp:ListItem>
                                        <asp:ListItem Value="Improved Business">Improved Business</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label class="col-form-label">Type of business</label>
                                    <asp:DropDownList ID="ddlBusinessType" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBusinessType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Grocery">Grocery</asp:ListItem>
                                        <asp:ListItem Value="Cosmetic & Stationery">Cosmetic & Stationery</asp:ListItem>
                                        <asp:ListItem Value="Tailoring">Tailoring</asp:ListItem>
                                        <asp:ListItem Value="Garment">Garment</asp:ListItem>
                                        <asp:ListItem Value="Beauty Parlor">Beauty Parlor</asp:ListItem>
                                        <asp:ListItem Value="Dairy">Dairy</asp:ListItem>
                                        <asp:ListItem Value="Bakery/Food">Bakery/Food</asp:ListItem>
                                        <asp:ListItem Value="Vegetable Selling">Vegetable Selling</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="div_Other" runat="server" visible="false" class="col-md-6 mb-3">
                                    <label class="col-form-label">Other</label>
                                    <asp:TextBox ID="txtOther" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label class="col-form-label">Advanced support for business</label>
                                    <asp:RadioButtonList ID="rblAdvSupportBusiness" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        <asp:ListItem Value="No">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </asp:Panel>
                            <div id="div_Ressons" runat="server" class="col-md-6 mb-3" visible="false">
                                <label class="col-form-label">Please Specify Reasons</label>
                                <asp:DropDownList ID="ddlNoReasons" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Not Interested">Not Interested</asp:ListItem>
                                    <asp:ListItem Value="Time Availability">Time Availability</asp:ListItem>
                                    <asp:ListItem Value="Household Chores">Household Chores</asp:ListItem>
                                    <asp:ListItem Value="May be Migrating Soon">May be Migrating Soon</asp:ListItem>
                                    <asp:ListItem Value="Family is Not Allowing">Family is Not Allowing</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>


                        </div>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Btn_Submit_Click" />
                                    &nbsp;
                                    <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="Btn_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>

