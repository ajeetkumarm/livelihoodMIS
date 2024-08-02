var app = angular.module('businessProgressApp', ['ngFileUpload']);
app.controller('businessProgressController', function ($scope, $http, Upload) {
    $scope.currentTab = 1;
    $scope.EnrollmentId;
    $scope.UserCategory;
    $scope.IsSubmittedTab1 = false;
    $scope.IsSubmittedTab2 = false;
    $scope.IsSubmittedTab3 = false;
    $scope.StartingBusinessDateEnable = false;
    $scope.DisplayMonthYearDataExist = false;
    $scope.loadTabContent = function (tabNumber) {
        $scope.currentTab = tabNumber;
    };

    $scope.nextTab = function () {


        //var isFormValid = $scope.Validation();
        ////console.log(isFormValid);
        //if (isFormValid == false) {
        //    return;
        //}

        //var nextTab = $scope.currentTab + 1;
        //if (nextTab > 5) nextTab = 1;
        //$scope.loadTab(nextTab);

        $scope.Validation().then(function (isValid) {
            if (isValid== false) {
                return
            } else {
                var nextTab = $scope.currentTab + 1;
                if (nextTab > 5) nextTab = 1;
                $scope.loadTab(nextTab);
            }
        });
    };

    $scope.prevTab = function () {
        var prevTab = $scope.currentTab - 1;
        if (prevTab < 1) prevTab = 5;
        $scope.loadTab(prevTab);
    };
    $scope.Validation = function () {
        return new Promise(function (resolve) {
            var isValid = true;

            if ($scope.currentTab == 1) {
                $scope.IsSubmittedTab1 = true;

                if (!$scope.BusinessProgressModel.StartingBusinessDate) {
                    isValid = false;
                }
                if (!$scope.BusinessProgressModel.Month) {
                    isValid = false;
                }
                if (!$scope.BusinessProgressModel.Year) {
                    isValid = false;
                }

                if (isValid) {
                    $scope.CheckBusinessProgressCustomerDataExist().then(function (exists) {
                        if (exists) {
                            isValid = false;
                        }
                        resolve(isValid);
                    });
                } else {
                    resolve(isValid);
                }
            } else if ($scope.currentTab == 2) {
                $scope.IsSubmittedTab2 = true;
                if (!$scope.BusinessProgressModel.NoNewCustomer) {
                    isValid = false;
                }
                if (!$scope.BusinessProgressModel.NoRepeatedCustomer) {
                    isValid = false;
                }
                resolve(isValid);
            } else if ($scope.currentTab == 3) {
                $scope.IsSubmittedTab3 = true;
                if (!$scope.BusinessProgressModel.ServicesOfferedType) {
                    isValid = false;
                }
                resolve(isValid);
            } else if ($scope.currentTab == 4) {
                if ($scope.BusinessProgressModel.PaymentRecivedMode == "") {
                    resolve(false);
                } else {
                    resolve(true);
                }
            } else {
                resolve(true);
            }
        });
    };
    //$scope.Validation = function () {

    //    var isValid = true;
    //    if ($scope.currentTab == 1) {

    //        $scope.IsSubmittedTab1 = true;
    //        if (!$scope.BusinessProgressModel.StartingBusinessDate) {
    //            isValid = false;
    //        }
    //        if (!$scope.BusinessProgressModel.Month) {
    //            isValid = false;
    //        }
    //        if (!$scope.BusinessProgressModel.Year) {
    //            isValid = false;
    //        }

    //        if (isValid) {
    //            return $scope.CheckBusinessProgressCustomerDataExist().then(function (exists) {
    //                if (exists) {
    //                    isValid = false;
    //                }
    //                return isValid;
    //            });
    //        } else {
    //            return Promise.resolve(isValid);
    //        }
    //    }
    //    if ($scope.currentTab == 2) {
    //        $scope.IsSubmittedTab2 = true;
    //        if (!$scope.BusinessProgressModel.NoNewCustomer) {
    //            isValid = false;
    //        }
    //        if (!$scope.BusinessProgressModel.NoRepeatedCustomer) {
    //            isValid = false;
    //        }
    //        return isValid;
    //    }
    //    if ($scope.currentTab == 3) {
    //        $scope.IsSubmittedTab3 = true;

    //        if (!$scope.BusinessProgressModel.ServicesOfferedType) {
    //            isValid = false;
    //        }
    //        return isValid;
    //    }
    //    if ($scope.currentTab == 4) {
    //        if ($scope.BusinessProgressModel.PaymentRecivedMode == "") {
    //            return false;
    //        }
    //    }
    //};

    $scope.loadTab = function (tabNumber) {
        $("#tabs").tabs("option", "active", tabNumber - 1);
        $scope.loadTabContent(tabNumber);
    };

    // Load default tab content

    $scope.loading = false;
    $scope.BusinessProgressModel = {};
    $scope.LoadDetail = function (enrollMentId, userCategory) {
        $scope.EnrollmentId = enrollMentId;
        $scope.UserCategory = userCategory;
        // console.log($scope.EnrollmentId);
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
            data: "{'enrollmentId':" + $scope.EnrollmentId + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            $scope.BusinessProgressModel = response.data.d;

            if (response.data.d.StartingBusinessDate) {

                var dateString = response.data.d.StartingBusinessDate;
                var parts = dateString.split('-');
                var year = parseInt(parts[2], 10);
                var month = parseInt(parts[1], 10) - 1; // Months are 0-based
                var day = parseInt(parts[0], 10);

                $scope.BusinessProgressModel.StartingBusinessDate = new Date(year, month, day);
            }
            if ($scope.UserCategory == 8) {
                $scope.StartingBusinessDateEnable = $scope.BusinessProgressModel.StartingBusinessDate ? true : false;
            }

            $scope.loading = false;
        }, function (response) {
            $scope.loading = false;
        });

    };

    //$scope.CheckBusinessProgressCustomerDataExist = function () {
    //    $scope.loading = true;
    //    $http({
    //        method: 'POST',
    //        url: '/WebServices/BusinessProgress.asmx/CheckBusinessProgressCustomerDataExist',
    //        dataType: 'json',
    //        method: 'POST',
    //        data: "{'businessProgressId':" + 0 + ",'enrollmentId':" + $scope.EnrollmentId + ",'year':" + $scope.BusinessProgressModel.Year + ",'month':'" + $scope.BusinessProgressModel.Month + "'}",
    //        headers: { 'Content-Type': 'application/json' }
    //    }).then(function (response) {

    //        console.log(response.data.d);
    //        $scope.DisplayMonthYearDataExist = response.data.d;
    //        $scope.loading = false;
    //        return $scope.DisplayMonthYearDataExist;
    //    }, function (response) {
    //        $scope.loading = false;
    //        return false;
    //    });

    //};
    $scope.CheckBusinessProgressCustomerDataExist = function () {
        $scope.loading = true;
        return $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/CheckBusinessProgressCustomerDataExist',
            dataType: 'json',
            data: JSON.stringify({
                businessProgressId: 0,
                enrollmentId: $scope.EnrollmentId,
                year: $scope.BusinessProgressModel.Year,
                month: $scope.BusinessProgressModel.Month
            }),
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            console.log(response.data.d);
            $scope.DisplayMonthYearDataExist = response.data.d;
            $scope.loading = false;
            return response.data.d;
        }, function (response) {
            $scope.loading = false;
            return false;
        });
    };
    $scope.SaveBusinessProgress = function () {

        $scope.loading = true;
        $scope.BusinessProgressModel.EnrollMentId = $scope.EnrollmentId;

        if ($scope.BusinessProgressModel.StartingBusinessDate) {

            $scope.BusinessProgressModel.StartingBusinessDate = new Date($scope.BusinessProgressModel.StartingBusinessDate);
        }

        var businessProgressModel = JSON.stringify($scope.BusinessProgressModel).replace(new RegExp(/\//g), '\\\/');
        // console.log(businessProgressModel);
        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/SaveBusinessProgress',
            dataType: 'json',
            method: 'POST',
            data: "{'model':" + businessProgressModel + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            //console.log(response.data.d);
            var res = response.data.d;
            if (res.success) {
                alert(res.message);
                if ($scope.UserCategory == 8) {
                    window.location.href = "/Forms/BusinessProgressCustomerList.aspx";
                }
                else {
                    window.location.href = "/Forms/BusinessProgressCustomerList.aspx?EnrolId=" + $scope.EnrollmentId;
                }
            }
            else {
                alert(res.message);
            }
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

    $scope.OTherPaymentReceived = function () {

        $scope.BusinessProgressModel.PaymentRecivedMode =
            ($scope.BusinessProgressModel.PaymentModeDigital && !$scope.BusinessProgressModel.PaymentModeNoneDigital)
                || (!$scope.BusinessProgressModel.PaymentModeDigital && $scope.BusinessProgressModel.PaymentModeNoneDigital)
                ? '100%' : '';
    }

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