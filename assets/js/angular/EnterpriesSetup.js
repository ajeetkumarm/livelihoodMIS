var app = angular.module('enterpriesSetupApp',[]);
app.controller('enterpriesSetupController', function ($scope, $http, $compile) {

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
                url: '/WebServices/EnterpriesSetup.asmx/GetEnterpriesSetupList',
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
            { data: 'WomenName' },
            { data: 'PhoneNo' },
            { data: 'StateName' },
            { data: 'DistrictName' },
            { data: 'BlockName' },
            { data: 'VillageName' },
            { data: 'RegistrationDateText' },
            {
                data: 'EnrollmentId',
                class: 'no-word-wrap',
                render: function (data, type, row) {
                    var compiledHtml = $compile(`
                        <div class="text-center">
                            <a href="EnterpriseStartUpgrate.aspx?EnrolId=${data}" class="btn btn-sm btn-success" title="Update" >
                                    Update
                                    </a>
                            <a href="javascript:void(0)" title="Click to change the status" style="${row.DisplayDelete}" ng-click="DeleteClick(${row.EnrollmentId});" class="btn btn-sm btn-danger m-1">
                               Delete
                            </a>
                        </div>
                    `)($scope);
                    // Ensure Angular is aware of changes
                    $scope.$applyAsync();
                    return compiledHtml[0].outerHTML;
                },

                width: '10%'
            },
            
            
        ],
        "createdRow": function (row, data, index) {
            $compile(row)($scope);  //add this to compile the DOM
        },
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

    $scope.DeleteClick = function (enrollmentId) {
        var r = confirm("Are you sure you want to delete this record?");
        if (r == false) {
            return;
        }

        $http({
            method: 'POST',
            url: '/WebServices/EnterpriesSetup.asmx/EnterpriseSetupMoveToEDPTraining',
            dataType: 'json',
            method: 'POST',
            data: "{'enrollmentId':" + enrollmentId + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            if (response.data.d) {
                dataTable.ajax.reload();
                alert("Record has been deleted successfully.");
            }
        }, function (response) {
            $scope.loading = false;
        });
    };
});