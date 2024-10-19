var app = angular.module('reportTrainingApp',[]);
app.controller('reportTrainingController', function ($scope, $http) {

    clearDataTableState();
    function clearDataTableState() {
        var state = JSON.parse(localStorage.getItem('DataTables_reportTrainingTable_' + window.location.pathname));
        if (state) {
            state.start = 0;
            localStorage.setItem('DataTables_reportTrainingTable_' + window.location.pathname, JSON.stringify(state));
        }
    }
    var dataTable = $('#reportTrainingTable').DataTable({
        serverSide: true,
        processing: true,
        paging: true,
        
        ajax: function (data, callback, settings) {
           
            $http({
                method: 'POST',
                url: '/WebServices/Report.asmx/GetTrainingDetails',
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
            { data: 'IsLifeSkillsTraining' },
            { data: 'RCSCDate' },
            { data: 'WRPCDate' },
            { data: 'HNCDate' },
            { data: 'FLCDate' },
            { data: 'IsInductionTraining' },
            { data: 'InductionTrainingDay1' },
            { data: 'InductionTrainingDay2' },
            { data: 'IsDigitalSkillTraining' },
            { data: 'DigitalSkillTrainingDay1' },
            { data: 'DigitalSkillTrainingDay2' },
            { data: 'DigitalSkillTrainingDay3' },
            { data: 'EDTSDate' },
            { data: 'LEAPDate' },
            { data: 'ESISDate' },
            { data: 'BMTCDate' },
            { data: 'MMTCDate' },
            { data: 'EDPTCDate' },
            { data: 'EDPIntroDay1' },
            { data: 'BusinessPlanDay2' },
            { data: 'FinancialLiteracyDay3' },
            { data: 'FinancialTermsDay4' },
            { data: 'BusinessManagementDay5' },
            { data: 'CreatedDisplay' },
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
                    var newWindow = window.open('/Forms/RptEnrollmentExport.aspx?ExportType=2', '_blank');
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