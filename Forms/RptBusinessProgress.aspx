<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="RptBusinessProgress.aspx.cs" Inherits="Forms_RptBusinessProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Business Progress Report</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Reports</li>
                <li class="breadcrumb-item active">Business Progress Report</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Business Progress Report</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <asp:Repeater ID="rpt_BusinessProgress" runat="server">
                                        <HeaderTemplate>
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
                                                    <th>StartingBusinessDate</th>
                                                    <th>Year</th>
                                                    <th>Month</th>
                                                    <th>NoNewCustomer</th>
                                                    <th>NoRepeatedCustomer</th>
                                                    <th>ServicesOfferedType</th>
                                                    <th>ServicesProvidedDetails</th>
                                                    <th>GovCustomerServices</th>
                                                    <th>G2CServices</th>
                                                    <th>IncomefromSell</th>
                                                    <th>CashSellAmount</th>
                                                    <th>CreditSellAmount</th>
                                                    <th>TotalIncome</th>
                                                    <th>Investment</th>
                                                    <th>ExpenditurefromPurchase</th>
                                                    <th>CashExpenditure</th>
                                                    <th>CreditExpenditure</th>
                                                    <th>TotalExpenditure</th>
                                                    <th>LastMonthCredit</th>
                                                    <th>CreditSettlement</th>
                                                    <th>MonthlyProfitLoss</th>
                                                    <th>PaymentReceived</th>
                                                    <th>PaymentReceivedMode</th>
                                                    <th>Submited On</th>
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
                                                    <%# Eval("StartingBusinessDate") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Year") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Month") %>
                                                </td>
                                                <td>
                                                    <%# Eval("NoNewCustomer") %>
                                                </td>
                                                <td>
                                                    <%# Eval("NoRepeatedCustomer") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ServicesOfferedType") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ServicesProvidedDetails") %>
                                                </td>
                                                <td>
                                                    <%# Eval("GovCustomerServices") %>
                                                </td>
                                                <td>
                                                    <%# Eval("G2CServices") %>
                                                </td>
                                                <td>
                                                    <%# Eval("IncomefromSell") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CashSellAmount") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CreditSellAmount") %>
                                                </td>
                                                <td>
                                                    <%# Eval("TotalIncome") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Investment") %>
                                                </td>
                                                <td>
                                                    <%# Eval("ExpenditurefromPurchase") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CashExpenditure") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CreditExpenditure") %>
                                                </td>
                                                <td>
                                                    <%# Eval("TotalExpenditure") %>
                                                </td>
                                                <td>
                                                    <%# Eval("LastMonthCredit") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CreditSettlement") %>
                                                </td>
                                                <td>
                                                    <%# Eval("MonthlyProfitLoss") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PaymentReceived") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PaymentReceivedMode") %>
                                                </td>
                                                <td>
                                                    <%# Eval("CreatedOn","{0:yyyy/MM/dd}") %>
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

