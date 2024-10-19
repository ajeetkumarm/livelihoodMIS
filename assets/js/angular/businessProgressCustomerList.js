var app = angular.module('businessProgressCustomerListApp', []);
app.controller('businessProgressCustomerListController', function ($scope, $http, enrollmentId) {

    $scope.categoryCountList = [];
    clearDataTableState();
    function clearDataTableState() {
        var state = JSON.parse(localStorage.getItem('DataTables_enterpriesSetupDataTable_' + window.location.pathname));
        if (state) {
            state.start = 0;
            localStorage.setItem('DataTables_enterpriesSetupDataTable_' + window.location.pathname, JSON.stringify(state));
        }
    }
    var dataTable = $('#enterpriesSetupDataTable').DataTable({
        serverSide: true,
        processing: true,
        paging: true,
        ajax: function (data, callback, settings) {
            
            $http({
                method: 'POST',
                url: '/WebServices/BusinessProgress.asmx/GetBusinessProgressCustomerList',
                dataType: 'json',
                method: 'POST',
                data: "{'enrollmentId':" + enrollmentId + ",'draw':" + data.draw + ",'pageNumber':" + data.start + ",'pageSize':" + data.length + ",'search':'" + data.search.value + "' }",
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                // console.log(response.data.d);

                callback({
                    draw: response.data.d.draw,
                    recordsTotal: response.data.d.recordsTotal,
                    recordsFiltered: response.data.d.recordsTotal,
                    data: response.data.d.data
                });

                $scope.loading = false;
            }, function (response) {
                $scope.loading = false;
            });
        },
        columns: [
            { data: 'RowNum' },
            {
                "data": "BeneficiaryCode",
                "render": function (data, type, row) {
                    return `<div><a href="BusinessProgressCustomer.aspx?EnrolId=${row["EnrollmentId"]}&editId=${row["BusinessProgressId"]}" title="Edit" data-toggle="tooltip">${data}</a></div>`
                }
            },
            { data: 'StateName' },
            { data: 'DistrictName' },
            { data: 'BlockName' },
            { data: 'VillageName' },
            { data: 'ProjectName' },
            { data: 'UserName' },
            { data: 'WomenName' },
            { data: 'StartingBusinessDate' },
            { data: 'Year' },
            { data: 'Month' },
            { data: 'NoNewCustomer' },
            { data: 'NoRepeatedCustomer' },
            { data: 'ServicesOfferedType' },
            { data: 'ServicesProvidedDetails' },
            { data: 'TotalVillagesCovered' },
            { data: 'G2CServices' },
            { data: 'IncomefromSell' },
            { data: 'CashSellAmount' },
            { data: 'CreditSellAmount' },
            { data: 'TotalIncome' },
            { data: 'Investment' },
            { data: 'ExpenditurefromPurchase' },
            { data: 'CashExpenditure' },
            { data: 'CreditExpenditure' },
            { data: 'TotalExpenditure' },
            { data: 'LastMonthCredit' },
            { data: 'CreditSettlement' },
            { data: 'MonthlyProfitLoss' },
            { data: 'PaymentReceived' },
            { data: 'PaymentReceivedMode' },
            { data: 'CreatedOnText' },
            

        ],
        lengthMenu: [
            [25, 50, 100, -1],
            [25, 50, 100, 'All'],
        ],
        language: {
            searchPlaceholder: "Search by Women Name",
            info: "Showing _START_ to _END_ of _TOTAL_ records.",
            lengthMenu: "Show _MENU_ records.",
            infoEmpty: "Showing 0 to 0 of 0 records",
            "emptyTable": "No Record Found!",
        },
        "bStateSave": true,
        "fnStateSave": function (oSettings, oData) {
            localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
        },
        "fnStateLoad": function (oSettings) {
            return JSON.parse(localStorage.getItem('DataTables_' + window.location.pathname));
        }
    });

    // binda data into categoryCountList from service
    $scope.LoadCategoryCount = function (enrollMentId) {
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/GetBusinessProgressServiceLineCount',
            dataType: 'json',
            method: 'POST',
            data: "{'enrollmentId':" + enrollMentId + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            console.log(response.data.d);
            $scope.categoryCountList = response.data.d;

            

            $scope.loading = false;
        }, function (response) {
            $scope.loading = false;
        });
    };
});