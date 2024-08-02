<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptTraining.aspx.cs" Inherits="Forms_RptTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>

    <script src="/assets/js/angular/ReportTraining.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>EDP Training Report</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Reports</li>
                <li class="breadcrumb-item active">EDP Training Report</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body" ng-app="reportTrainingApp" ng-controller="reportTrainingController">
                <h5 class="card-title">EDP Training Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="reportTrainingTable" class="table table-striped table-bordered nowrap">
                                    <thead class="table-light">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Beneficiary Code</th>
                                            <th>State</th>
                                            <th>District</th>
                                            <th>Block</th>
                                            <th>Village</th>
                                            <th>Project</th>
                                            <th>UserName (FE)</th>
                                            <th>Women Name</th>
                                            <th>Is Life Skills Training</th>
                                            <th>RCSC Date</th>
                                            <th>WRPC Date</th>
                                            <th>HNC Date</th>
                                            <th>FLC Date</th>
                                            <th>EDTS Date</th>
                                            <th>LEAP Date</th>
                                            <th>ESIS Date</th>
                                            <th>BMTC Date</th>
                                            <th>MMTC Date</th>
                                            <th>EDPT CDate</th>
                                            <th>Submited On</th>
                                        </tr>
                                    </thead>
                                </table>


                                <%--<asp:Repeater ID="rpt_Training" runat="server">
                                    <HeaderTemplate>

                                        <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSrNo" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
                                            </td>
                                            <td>
                                                <%# Eval("BeneficiaryCode") %>
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
                                                <%# Eval("ProjectName") %>
                                            </td>
                                            <td>
                                                <%# Eval("UserName") %>
                                            </td>
                                            <td>
                                                <%# Eval("WomenName") %>
                                            </td>
                                            <td>
                                                <%# Eval("IsLifeSkillsTraining") %>
                                            </td>
                                            <td>
                                                <%# Eval("RCSCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("WRPCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("HNCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("FLCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("EDTSDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("LEAPDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("ESISDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("BMTCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("MMTCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("EDPTCDate","{0:dd/MM/yyyy}") %>
                                            </td>
                                            <td>
                                                <%# Eval("CreatedOn","{0:dd/MM/yyyy}") %>
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                    </FooterTemplate>
                                </asp:Repeater>--%>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

