﻿var app = angular.module('reportEnterpriesSetupTrainingApp',[]);
app.controller('reportEnterpriesSetupTrainingController', function ($scope, $http) {

    clearDataTableState();
    function clearDataTableState() {
        var state = JSON.parse(localStorage.getItem('DataTables_reportEnterpriesSetupTable_' + window.location.pathname));
        if (state) {
            state.start = 0;
            localStorage.setItem('DataTables_reportEnterpriesSetupTable_' + window.location.pathname, JSON.stringify(state));
        }
    }
    var dataTable = $('#reportEnterpriesSetupTable').DataTable({
        serverSide: true,
        processing: true,
        paging: true,
        
        ajax: function (data, callback, settings) {
           
            $http({
                method: 'POST',
                url: '/WebServices/Report.asmx/GetEnterpriesTrainingDetails',
                dataType: 'json',
                method: 'POST',
                data: "{'draw':" + data.draw + ",'pageNumber':" + data.start + ",'pageSize':" + data.length + ",'search':'" + data.search.value +"' }",
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
        columns: [
            { data: 'RowNum' },
            { data: 'BeneficiaryCode' },
            { data: 'StateName' },
            { data: 'DistrictName' },
            { data: 'BlockName' },
            { data: 'VillageName' },
            { data: 'ProjectName' },
            { data: 'UserName' },
            { data: 'WomenName' },
            { data: 'StartBusiness' },
            { data: 'BusinessReasons' },
            { data: 'Business' },
            { data: 'BusinessWhen' },
            { data: 'StatusBusiness' },
            { data: 'VillagePopulation' },
            { data: 'BusinessIdea' },
            { data: 'BusinessType' },
            { data: 'ProcureBusiness' },
            { data: 'CurrentBusiness' },
            { data: 'RegularFinancialBusiness' },
            { data: 'HowRegularFinancial' },
            { data: 'SettingBusinessType' },
            { data: 'MonthlyRent' },
            { data: 'ExpandBusiness' },
            { data: 'PotentialCustomers' },
            { data: 'BusinessDistance' },
            { data: 'ExpectedFootfall' },
            { data: 'HowFarBussiness' },
            { data: 'SupportBusiness' },
            { data: 'SupportType' },
            { data: 'NotProvidedSupport' },
            { data: 'PaidWorker' },
            { data: 'DigitalInclusion' },
            { data: 'DigitalInclusionDate' },
            { data: 'OwnSmartPhone' },
            { data: 'UseSmartPhone' },
            { data: 'SupplyChain' },
            { data: 'CreatedDisplay' }
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
        },
        dom: 'Bfrtip', // Add this line to show the buttons
        buttons: [
            {
                text: 'Export to Excel',
                action: function () {
                    var newWindow = window.open('/Forms/RptEnrollmentExport.aspx?ExportType=3', '_blank');
                    newWindow.onload = function () {
                        setTimeout(function () {
                            newWindow.close();
                        }, 300); // Adjust the timeout as needed
                    };
                }
            }
        ]
        //buttons: [
        //    {
        //        extend: 'excelHtml5',
        //        text: 'Export to Excel',
        //        exportOptions: {
        //            columns: ':visible' // export all visible columns
        //        },
        //        customize: function (xlsx) {
        //            var sheet = xlsx.xl.worksheets['Report_Enrollment_List.xml'];
        //            $('row c[r^="C"]', sheet).attr('s', '2'); // styling example
        //        },
        //        action: function (e, dt, button, config) {
        //            var oldStart = dt.settings()[0]._iDisplayStart;
        //            dt.one('preXhr', function (e, s, data) {
        //                data.start = 0;
        //                data.length = 2147483647; // 2^31 - 1, a large number to load all data
        //                dt.one('preDraw', function (e, settings) {
        //                    if (button[0].className.includes('buttons-excel')) {
        //                        $.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, button, config);
        //                    }
        //                    settings._iDisplayStart = oldStart;
        //                    data.start = oldStart;
        //                    return false;
        //                });
        //            });
        //            dt.ajax.reload();
        //        }
        //    }
        //]
    });
});