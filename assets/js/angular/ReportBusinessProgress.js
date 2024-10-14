var app = angular.module('reportBusinessProgressApp', []);
app.controller('reportBusinessProgressController', function ($scope, $http,$window) {
    var UserCategory = parseInt($window.UserCategory, 10);
    clearDataTableState();
    function clearDataTableState() {
        var state = JSON.parse(localStorage.getItem('DataTables_reportBusinessProgressTable_' + window.location.pathname));
        if (state) {
            state.start = 0;
            localStorage.setItem('DataTables_reportBusinessProgressTable_' + window.location.pathname, JSON.stringify(state));
        }
    }

    var columns = [{ data: 'RowNum' },
    { data: 'BeneficiaryCode' },
    { data: 'StateName' },
    { data: 'DistrictName' },
    { data: 'BlockName' },
    { data: 'VillageName' },
    { data: 'ProjectName' }];


    if (UserCategory !== 9) {

        columns = columns.concat({ data: 'UserName' });
        columns = columns.concat({ data: 'WomenName' });
    }

    columns = columns.concat({ data: 'StartingBusinessDate' },
        { data: 'Year' },
        { data: 'Month' },
        { data: 'NoNewCustomer' },
        { data: 'NoRepeatedCustomer' },
        { data: 'ServicesOfferedType' },
        { data: 'ServicesProvidedDetails' },
        { data: 'GovCustomerServices' },
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
        { data: 'CreatedDisplay' });

    var dataTable = $('#reportBusinessProgressTable').DataTable({
        serverSide: true,
        processing: true,
        paging: true,

        ajax: function (data, callback, settings) {

            $http({
                method: 'POST',
                url: '/WebServices/Report.asmx/GetRptBusinessProgressDetails',
                dataType: 'json',
                method: 'POST',
                data: "{'draw':" + data.draw + ",'pageNumber':" + data.start + ",'pageSize':" + data.length + ",'search':'" + data.search.value + "' }",
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                console.log(response.data.d);

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
        columns: columns,
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
        },
        dom: 'Bfrtip', // Add this line to show the buttons
        buttons: [
            {
                text: 'Export to Excel',
                action: function () {
                    var newWindow = window.open('/Forms/RptEnrollmentExport.aspx?ExportType=4', '_blank');
                    newWindow.onload = function () {
                        //setTimeout(function () {
                        //    newWindow.close();
                        //}, 300); // Adjust the timeout as needed
                    };
                }
            }
        ]
    });
});