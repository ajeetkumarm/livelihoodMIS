<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="BusinessProgressCustomer.aspx.cs" Inherits="Forms_BusinessProgressCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <style>
        input[type="checkbox"] {
            margin-left: 0.75rem;
        }

        .ui-tabs .ui-tabs-nav li.ui-tabs-active a {
            background-color: #4154f1; /* Change this to your desired color */
            color: white; /* Text color */
        }

        .text-danger {
            color: red;
        }
    </style>
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
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>
    <script src="/assets/js/angular/ng-file-upload.js"></script>
    <script src="/assets/js/angular/businessProgressCustomer.js"></script>

    <script>
        // app.value("enrollmentId", <%= EnrollmentId %>);
        $(document).ready(function () {
            $("#tabs").tabs({
                activate: function (event, ui) {
                    var newIndex = ui.newTab.index();
                    angular.element(document.getElementById('divTab')).scope().loadTabContent(newIndex + 1);
                }
            });
        });


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Business Progress</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Business Progress</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->

    <section class="section">
        <div class="card">
            <div id="divTab" class="card-body" style="" ng-app="businessProgressApp" ng-controller="businessProgressController" ng-init="LoadDetail(<%= EnrollmentId %>, <%= UserCategory %>);">
                <div id="tabs">
                    <ul>
                        <li><a href="#tab1" ng-click="loadTabContent(1)">Reporting Period</a></li>
                        <li><a href="#tab2" ng-click="loadTabContent(2)">Customer Related</a></li>
                        <li><a href="#tab3" ng-click="loadTabContent(3)">Services Related</a></li>
                        <li><a href="#tab4" ng-click="loadTabContent(4)">Income Statement</a></li>
                        <li><a href="#tab5" ng-click="loadTabContent(5)">Others</a></li>
                    </ul>
                    <div id="tab1">
                        <div class="mb-3 row m-1" visible="false">
                            <label class="col-sm-3 col-form-label">Date of Starting of Business <span class="text-danger">*</span></label>
                            <div class="col-sm-3">
                                <input id="txtBusinessStartingDate" name="txtBusinessStartingDate" ng-model="BusinessProgressModel.StartingBusinessDate"
                                     ng-disabled="StartingBusinessDateEnable"
                                    class="form-control" type="date" />
                                <span class="text-danger" ng-show="IsSubmittedTab1 && !BusinessProgressModel.StartingBusinessDate">Required.</span>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Months <span class="text-danger">*</span></label>
                            <div class="col-sm-3">
                                <select id="ddlMonths" name="ddlMonths" ng-model="BusinessProgressModel.Month" class="form-select">
                                    <option value="">--Select--</option>
                                    <option value="Jan">Jan</option>
                                    <option value="Feb">Feb</option>
                                    <option value="March">March</option>
                                    <option value="April">April</option>
                                    <option value="May">May</option>
                                    <option value="June">June</option>
                                    <option value="July">July</option>
                                    <option value="Aug">Aug</option>
                                    <option value="Sep">Sep</option>
                                    <option value="Oct">Oct</option>
                                    <option value="Nov">Nov</option>
                                    <option value="Dec">Dec</option>
                                </select>
                                <span class="text-danger" ng-show="IsSubmittedTab1 && !BusinessProgressModel.Month">Required.</span>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Year <span class="text-danger">*</span></label>
                            <div class="col-sm-3">
                                <select id="ddlYear" name="ddlYear" ng-model="BusinessProgressModel.Year" class="form-select">
                                    <option value="">--Select--</option>
                                    <option value="2022">2022</option>
                                    <option value="2023">2023</option>
                                    <option value="2024">2024</option>
                                    <option value="2025">2025</option>
                                </select>
                                <span class="text-danger" ng-show="IsSubmittedTab1 && !BusinessProgressModel.Year">Required.</span>
                            </div>
                        </div>
                        <div class="mb-3 row m-1" ng-show="DisplayMonthYearDataExist">
                             <label class="col-sm-12 col-form-label text-danger">You alreay entered data for Month({{BusinessProgressModel.Month}}) & Year({{BusinessProgressModel.Year}}).</label>
                        </div>
                        <div class="tab-buttons">
                            <button type="button" ng-click="prevTab()" class="btn btn-secondary">Previous</button>
                            <button type="button" ng-click="nextTab()" class="btn btn-primary">Next</button>
                        </div>
                    </div>
                    <div id="tab2">
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">No. of New customer <span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <input id="txtNewCustomer" name="txtNewCustomer" type="text" class="form-control" maxlength="9" ng-model="BusinessProgressModel.NoNewCustomer" onkeypress="return isNumberKey(event)" />
                                <span class="text-danger" ng-show="IsSubmittedTab2 && !BusinessProgressModel.NoNewCustomer">Required.</span>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">No. of Repeated Customer <span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <input id="txtRepeatedCustomer" name="txtRepeatedCustomer" type="text" class="form-control" maxlength="9" ng-model="BusinessProgressModel.NoRepeatedCustomer" onkeypress="return isNumberKey(event)" />
                                <span class="text-danger" ng-show="IsSubmittedTab2 && !BusinessProgressModel.NoRepeatedCustomer">Required.</span>
                            </div>
                        </div>
                        <div class="tab-buttons">
                            <button type="button" ng-click="prevTab()" class="btn btn-secondary">Previous</button>
                            <button type="button" ng-click="nextTab()" class="btn btn-primary">Next</button>
                        </div>
                    </div>
                    <div id="tab3">
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Type of services offered <span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <select id="ddlServicesOfferedType" name="ddlServicesOfferedType" ng-model="BusinessProgressModel.ServicesOfferedType" class="form-select">
                                    <option value="">--Select--</option>
                                    <option value="Digital">Digital</option>
                                    <option value="Non-Digital">Non-Digital</option>
                                    <option value="Both">Both</option>
                                </select>
                                <span class="text-danger" ng-show="IsSubmittedTab3 && !BusinessProgressModel.ServicesOfferedType">Required.</span>

                            </div>
                        </div>
                        <div id="div_DigiCat" class="mb-3 row m-1" ng-show="BusinessProgressModel.ServicesOfferedType=='Digital' || BusinessProgressModel.ServicesOfferedType=='Both'">
                            <label class="col-sm-12 col-form-label">Digital Category</label>
                            <div class="col-sm-12">
                                <div class="row">
                                    <div class="col-sm-6" ng-repeat="_category in BusinessProgressModel.DigitalCategories" ng-init="parentIndex = $index">
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" id="chkCategory{{_category.CategoryId}}" ng-model="_category.IsSelected" />
                                            <label class="form-check-label" for="chkCategory{{_category.CategoryId}}">
                                                <strong>{{_category.Category}}</strong>
                                            </label>
                                        </div>
                                        <div ng-show="_category.IsSelected" style="border: 1px solid #ccc; margin-left: 25px;" class="row p-1" ng-repeat="_surviceLine in _category.ServiceLines">
                                            <div class="col-md-12 mb-1">
                                                <div class="row">
                                                    <div class="col-md-6">{{_surviceLine.ServiceLine}}</div>
                                                    <div class="col-md-6">
                                                        <a href="{{_surviceLine}}" target="_blank" ng-repeat="_surviceLine in _surviceLine.ServiceURLs">
                                                            <img src="/assets/img/link-solid.svg" style="color: blue;" />
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 pb-1">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <input type="text" class="form-control" ng-model="_surviceLine.CustomersNo" onkeypress="return isNumberKey(event)" />
                                                    </div>

                                                    <div class="col-md-9">
                                                        <input class="form-control form-control-sm" type="file" id="serviceFileUpload" ngf-select="UploadFile($files,parentIndex,$index)" />

                                                        <a ng-show="_surviceLine.DisplayView" href="/UploadedFile/BusinessProgress/{{_surviceLine.UplodedFileName}}" target="_blank"><i class="fa fa-eyes"></i>View</a>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3 row m-1" ng-show="BusinessProgressModel.ServicesOfferedType=='Non-Digital' || BusinessProgressModel.ServicesOfferedType=='Both'">
                            <label class="col-sm-3 col-form-label">Kindly provide details of services provided</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtServicesDetails" class="form-control" ng-model="BusinessProgressModel.ServicesProvidedDetails" maxlength="150" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">If related to government to customer services mention the number</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtGovCustServices" class="form-control" ng-model="BusinessProgressModel.GovCustomerServices" onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="tab-buttons">
                            <button type="button" ng-click="prevTab()" class="btn btn-secondary">Previous</button>
                            <button type="button" ng-click="nextTab()" class="btn btn-primary">Next</button>
                        </div>
                    </div>
                    <div id="tab4">
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Income from Sell</label>
                            <div class="col-sm-6">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkIncomeSellCash" ng-model="BusinessProgressModel.IncomeSellCash" ng-change="calculateIncome()" />
                                    <label class="form-check-label" for="chkIncomeSellCash">
                                        Cash Sell
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkIncomeCreditSell" ng-model="BusinessProgressModel.IncomeCreditSell" ng-change="calculateIncome()" />
                                    <label class="form-check-label" for="chkIncomeCreditSell">
                                        Credit Sell
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Cash Sell Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtCashSellAmount" class="form-control" ng-model="BusinessProgressModel.CashSellAmount"
                                    ng-disabled="!BusinessProgressModel.IncomeSellCash"
                                    ng-change="calculateIncome()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Sell Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtCreditSellAmount" class="form-control" ng-model="BusinessProgressModel.CreditSellAmount"
                                    ng-disabled="!BusinessProgressModel.IncomeCreditSell"
                                    ng-change="calculateIncome()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Total Income</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtTotalIncome" class="form-control" ng-model="BusinessProgressModel.TotalIncome" disabled="disabled" onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Investment</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtInvestment" class="form-control" ng-model="BusinessProgressModel.Investment" onkeypress="return isNumberKey(event)" maxlength="9"
                                    ng-change="calculateMonthlyProfitLoss()" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Expenditure from Purchase</label>
                            <div class="col-sm-6">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkCashExpenditure" ng-model="BusinessProgressModel.CheckCashExpenditure" ng-change="calculateMonthlyProfitLoss()" />
                                    <label class="form-check-label" for="chkCashExpenditure">
                                        Cash Expenditure
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkCreditExpenditure" ng-model="BusinessProgressModel.CheckCreditExpenditure" ng-change="calculateMonthlyProfitLoss()" />
                                    <label class="form-check-label" for="chkCreditExpenditure">
                                        Credit Expenditure
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Cash Expenditure Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtCashExpenditureAmount" class="form-control" ng-model="BusinessProgressModel.CashExpenditure"
                                    ng-disabled="!BusinessProgressModel.CheckCashExpenditure"
                                    ng-change="calculateMonthlyProfitLoss()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Expenditure Amount(Rs.)</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtCreditExpenditureAmount" class="form-control" ng-model="BusinessProgressModel.CreditExpenditure"
                                    ng-disabled="!BusinessProgressModel.CheckCreditExpenditure"
                                    ng-change="calculateMonthlyProfitLoss()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Total Expenditure</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtTotalExpenditure" class="form-control" ng-model="BusinessProgressModel.TotalExpenditure" disabled="disabled" onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Last Month Credit</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtLastMonthCredit" class="form-control" ng-model="BusinessProgressModel.LastMonthCredit"
                                    ng-change="calculateMonthlyProfitLoss()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Credit Settlement</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtCreditSettlement" class="form-control" ng-model="BusinessProgressModel.CreditSettlement"
                                    ng-change="calculateMonthlyProfitLoss()"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Net Monthly Profit/Loss</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtMonthlyProfitLoss" class="form-control"
                                    ng-class="{'text-danger': BusinessProgressModel.MonthlyProfitLoss < 0, 'text-success': BusinessProgressModel.MonthlyProfitLoss > 0}"
                                    ng-model="BusinessProgressModel.MonthlyProfitLoss"
                                    disabled="disabled" onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>

                        <div class="tab-buttons">
                            <button type="button" ng-click="prevTab()" class="btn btn-secondary">Previous</button>
                            <button type="button" ng-click="nextTab()" class="btn btn-primary">Next</button>
                        </div>
                    </div>
                    <div id="tab5">
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">How payment are received</label>
                            <div class="col-sm-6">


                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkPaymentModeDigital" ng-model="BusinessProgressModel.PaymentModeDigital" ng-change="OTherPaymentReceived()" />
                                    <label class="form-check-label" for="chkPaymentModeDigital">
                                        Digital
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="chkPaymentModeNoneDigital" ng-model="BusinessProgressModel.PaymentModeNoneDigital" ng-change="OTherPaymentReceived()" />
                                    <label class="form-check-label" for="chkPaymentModeNoneDigital">
                                        Non-Digital
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3 row m-1">
                            <label class="col-sm-3 col-form-label">Please specify % of payment received for each mode</label>
                            <div class="col-sm-6">
                                <input type="text" id="txtPaymentRecivedMode" class="form-control" ng-model="BusinessProgressModel.PaymentRecivedMode"
                                    ng-disabled="(BusinessProgressModel.PaymentModeDigital && !BusinessProgressModel.PaymentModeNoneDigital) || (!BusinessProgressModel.PaymentModeDigital && BusinessProgressModel.PaymentModeNoneDigital)"
                                    onkeypress="return isNumberKey(event)" maxlength="9" />
                            </div>
                        </div>
                        <div class="tab-buttons">
                            <button type="button" ng-click="prevTab()" class="btn btn-secondary">Previous</button>
                            <button type="button" ng-click="SaveBusinessProgress()" class="btn btn-primary">Save</button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>

