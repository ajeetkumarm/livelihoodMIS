var app = angular.module('businessProgressApp', ['ngFileUpload']);
app.controller('businessProgressController', function ($scope, $http, Upload) {
   // $scope.tab1Content = "This is the content of Tab 1.";
   // $scope.tab2Content = "This is the content of Tab 2.";
   // $scope.tab3Content = "This is the content of Tab 3.";
    $scope.currentTab = 1;
    $scope.EnrollmentId = 0;
    $scope.loadTabContent = function (tabNumber) {
        $scope.currentTab = tabNumber;
    };

    $scope.nextTab = function () {
        var nextTab = $scope.currentTab + 1;
        if (nextTab > 5) nextTab = 1;
        $scope.loadTab(nextTab);
    };

    $scope.prevTab = function () {
        var prevTab = $scope.currentTab - 1;
        if (prevTab < 1) prevTab = 5;
        $scope.loadTab(prevTab);
    };

    $scope.loadTab = function (tabNumber) {
        $("#tabs").tabs("option", "active", tabNumber - 1);
        $scope.loadTabContent(tabNumber);
    };

    // Load default tab content

    $scope.loading = false;
    $scope.BusinessProgressModel = {};
    $scope.LoadDetail = function (enrollMentId) {
        $scope.EnrollmentId = enrollMentId;
        console.log($scope.EnrollmentId);
        $scope.loadTabContent(1);
        $scope.GetBusinessProgressDetail();
    };
    $scope.GetBusinessProgressDetail = function () {

        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/GetBusinessProgressDetail',
            dataType: 'json',
            method: 'POST',
            data: {},
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            $scope.BusinessProgressModel = response.data.d;
            $scope.loading = false;
        }, function (response) {
            $scope.loading = false;
        });

    };

    $scope.Step1Validation = function () {

        
    };

    $scope.SaveBusinessProgress = function () {

        $scope.loading = true;
        var businessProgressModel = JSON.stringify($scope.BusinessProgressModel).replace(new RegExp(/\//g), '\\\/');
        console.log(businessProgressModel);
        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/SaveBusinessProgress',
            dataType: 'json',
            method: 'POST',
            data: "{'model':" + businessProgressModel + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            console.log(response.data.d);
            $scope.loading = false;
        }, function (response) {
            $scope.loading = false;
        });
    };

    $scope.calculateIncome = function () {

        $scope.BusinessProgressModel.CashSellAmount = $scope.BusinessProgressModel.IncomeSellCash ? +$scope.BusinessProgressModel.CashSellAmount : "";
        $scope.BusinessProgressModel.CreditSellAmount = $scope.BusinessProgressModel.IncomeCreditSell ? +$scope.BusinessProgressModel.CreditSellAmount : "";
        $scope.BusinessProgressModel.TotalIncome = $scope.BusinessProgressModel.IncomeSellCash ? +$scope.BusinessProgressModel.CashSellAmount : 0;
        $scope.BusinessProgressModel.TotalIncome += $scope.BusinessProgressModel.IncomeCreditSell ? +$scope.BusinessProgressModel.CreditSellAmount : 0;
    };

    $scope.calculateMonthlyProfitLoss = function () {
        var monhtlyProfitLoss = 0;
        $scope.BusinessProgressModel.CashExpenditure = $scope.BusinessProgressModel.CheckCashExpenditure ? +$scope.BusinessProgressModel.CashExpenditure : "";
        $scope.BusinessProgressModel.CreditExpenditure = $scope.BusinessProgressModel.CheckCreditExpenditure ? +$scope.BusinessProgressModel.CreditExpenditure : "";
        monhtlyProfitLoss = $scope.BusinessProgressModel.CheckCashExpenditure ? +$scope.BusinessProgressModel.CashExpenditure : 0;
        monhtlyProfitLoss += $scope.BusinessProgressModel.CheckCreditExpenditure ? +$scope.BusinessProgressModel.CreditExpenditure : 0;

        $scope.BusinessProgressModel.TotalExpenditure = (+$scope.BusinessProgressModel.CashExpenditure) + (+$scope.BusinessProgressModel.CreditExpenditure);

        // monhtlyProfitLoss += +$scope.BusinessProgressModel.LastMonthCredit;
        monhtlyProfitLoss += +$scope.BusinessProgressModel.CreditSettlement;
        var totalInvestment = + $scope.BusinessProgressModel.Investment;
        $scope.BusinessProgressModel.MonthlyProfitLoss = $scope.BusinessProgressModel.TotalIncome - (monhtlyProfitLoss + totalInvestment);
    };

    $scope.UploadFile = function (files, parentIndex, childIndex) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/WebServices/BusinessProgress.asmx/UploadFile',
                data: {
                    files: $scope.SelectedFiles
                }

            }).then(function (response) {
                // console.log(response.data);
                if (response.data) {

                    $scope.BusinessProgressModel.DigitalCategories[parentIndex].ServiceLines[childIndex].UplodedFileName = response.data.FileName;
                    $scope.BusinessProgressModel.DigitalCategories[parentIndex].ServiceLines[childIndex].DisplayView = true;
                }
                else {
                    // ShowNotification(response.data.message, 1);
                }


            }, function (response) {
                if (response.status > 0) {
                    var errorMsg = response.status + ': ' + response.data;
                    // ShowNotification(errorMsg, 1);
                }
            }
            );
        }
    };
});