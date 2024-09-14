var app = angular.module('businessProgressApp', []);
app.controller('businessProgressController', function ($scope, $http, $compile) {

    // get current date
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    $scope.SelectedEnrollmentId = 0;

    $scope.BusinessProgressStatus = {
        BusinessStatus: "0",
        BusinessStatusError: false,
        BusinessStatusDate: dd + '-' + mm + '-' + yyyy,
        HoldReason: [],
        HoldReasonError: false,
        ClosedReason: [],
        ClosedReasonError: false,
    };
    $scope.HoldReason = [
        { ReasonValue: 'Family Issues', ReasonText: 'Family Issues', IsSelected: false },
        { ReasonValue: 'Health Issues', ReasonText: 'Health Issues', IsSelected: false },
        { ReasonValue: 'Seasonal Business', ReasonText: 'Seasonal Business', IsSelected: false },
        { ReasonValue: 'Natural Calamity', ReasonText: 'Natural Calamity', IsSelected: false },
        { ReasonValue: 'Others', ReasonText: 'Others', IsSelected: false },
    ];
    $scope.ClosedReason = [
        { ReasonValue: 'Entrepreneur is no more', ReasonText: 'Entrepreneur is no more', IsSelected: false },
        { ReasonValue: 'Not interested', ReasonText: 'Not interested', IsSelected: false },
        { ReasonValue: 'Business not blooming', ReasonText: 'Business not blooming', IsSelected: false },
        { ReasonValue: 'Family issues', ReasonText: 'Family issues', IsSelected: false },
        { ReasonValue: 'Migrated', ReasonText: 'Migrated', IsSelected: false },
        { ReasonValue: 'Natural Calamity', ReasonText: 'Natural Calamity', IsSelected: false },
        { ReasonValue: 'Got a Job', ReasonText: 'Got a Job', IsSelected: false },
    ];
    $scope.CurrentStatus = 0;
    clearDataTableState();
    function clearDataTableState() {
        var state = JSON.parse(localStorage.getItem('DataTables_BusinessProgressTable_' + window.location.pathname));
        if (state) {
            state.start = 0;
            localStorage.setItem('DataTables_BusinessProgressTable_' + window.location.pathname, JSON.stringify(state));
        }
    }
    var dataTable = $('#BusinessProgressTable').DataTable({
        serverSide: true,
        processing: true,
        paging: true,

        ajax: function (data, callback, settings) {

            $http({
                method: 'POST',
                url: '/WebServices/BusinessProgress.asmx/GetBusinessProgressList',
                dataType: 'json',
                method: 'POST',
                data: "{'draw':" + data.draw + ",'pageNumber':" + data.start + ",'pageSize':" + data.length + ",'search':'" + data.search.value + "' }",
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
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
                data: 'EnrollmentId',
                class: 'no-word-wrap',
                render: function (data, type, row) {
                    var compiledHtml = $compile(`
                        <div>
                            <a href="javascript:void(0)" title="Click to change the status" data-bs-toggle="modal" data-bs-target="#viewStatus" ng-click="ViewStatus(${row.EnrollmentId});"
                               class="text-primary">
                               ${row.BusinessStatusDisplay}
                            </a>
                        </div>
                    `)($scope);
                    // Ensure Angular is aware of changes
                    $scope.$applyAsync();
                    return compiledHtml[0].outerHTML;
                },

                width: '15%'
            },
            { data: 'BeneficiaryCode' },
            { data: 'WomenName' },
            { data: 'PhoneNo' },
            { data: 'StateName' },
            { data: 'DistrictName' },
            { data: 'BlockName' },
            { data: 'VillageName' },
            { data: 'RegistrationDateDisplay' },
            {
                data: 'EnrollmentId',
                class: 'no-word-wrap',
                render: function (data, type, row) {
                    return $compile(`
                        <div class="text-center">
                            <a href="BusinessProgressCustomerList.aspx?EnrolId=${row.EnrollmentId}" title="Add Business Progress" 
                               class="btn btn-sm btn-success">
                               Add Business Progress
                            </a> 
                             <a href="javascript:void(0)" title="Click to change the status" style="${row.DisplayDelete}" ng-click="DeleteClick(${row.EnrollmentId});" class="btn btn-sm btn-danger m-1">
                                   Delete
                                </a>
                       </div>
                    `)($scope)[0].outerHTML;
                },
                width: '10%'
            }
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
        },
        dom: 'Bfrtip', // Add this line to show the buttons
        buttons: [
            {
                text: 'Export to Excel',
                action: function () {
                    var newWindow = window.open('/Forms/RptEnrollmentExport.aspx?ExportType=5', '_blank');
                    newWindow.onload = function () {
                        //setTimeout(function () {
                        //    newWindow.close();
                        //}, 300); // Adjust the timeout as needed
                    };
                }
            }
        ]
    });

    $scope.onStatusChange = function () {
        if ($scope.CurrentStatus != $scope.BusinessProgressStatus.BusinessStatus) {
            $scope.BusinessProgressStatus.BusinessStatusDate = dd + '-' + mm + '-' + yyyy;
        }
        else {
            $scope.BusinessProgressStatus.BusinessStatusDate = $scope.CurrentBusinessStatusDate;
        }
    }

    $scope.ViewStatus = function (Id) {
        // console.log(Id);
        $scope.SelectedEnrollmentId = Id;
        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/GetBusinessProgressStatus',
            dataType: 'json',
            method: 'POST',
            data: "{'enrollmentId':'" + Id + "'}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            //console.log(response.data.d);
            if (response.data.d) {
                let data = response.data.d;
                //console.log(data);
                $scope.CurrentStatus = data.BusinessStatus;
                $scope.CurrentBusinessStatusDate = data.BusinessStatusDate;
                $scope.BusinessProgressStatus.BusinessStatus = data.BusinessStatus.toString();
                $scope.BusinessProgressStatus.BusinessStatusDate = data.BusinessStatusDate.toString();
                if (data.BusinessStatusReason && data.BusinessStatus === 2) {
                    var holdReason = data.BusinessStatusReason.split(',');
                    $scope.HoldReason.forEach(function (item) {
                        item.IsSelected = holdReason.includes(item.ReasonValue);
                    });
                }
                if (data.BusinessStatusReason && data.BusinessStatus === 3) {
                    var closedReason = data.BusinessStatusReason.split(',');
                    $scope.ClosedReason.forEach(function (item) {
                        item.IsSelected = closedReason.includes(item.ReasonValue);
                    });
                }
            }
        }, function (response) {
            $scope.loading = false;
        });
    };
    $scope.UpdateBusinessStatus = function () {
        console.log($scope.BusinessProgressStatus);

        // validate BusinessProgressStatus
        $scope.BusinessProgressStatus.BusinessStatusError = false;
        $scope.BusinessProgressStatus.HoldReasonError = false;
        $scope.BusinessProgressStatus.ClosedReasonError = false;

        var isValidate = true;
        if ($scope.BusinessProgressStatus.BusinessStatus == "0") {
            $scope.BusinessProgressStatus.BusinessStatusError = true;
            isValidate = false
        }
        if ($scope.BusinessProgressStatus.BusinessStatus == "2") {
            var holdReason = $scope.HoldReason.filter(x => x.IsSelected == true);
            if (holdReason.length == 0) {
                $scope.BusinessProgressStatus.HoldReasonError = true;
                isValidate = false;

            }
        }
        if ($scope.BusinessProgressStatus.BusinessStatus == "3") {
            var closedReason = $scope.ClosedReason.filter(x => x.IsSelected == true);
            if (closedReason.length == 0) {
                $scope.BusinessProgressStatus.ClosedReasonError = true;
                isValidate = false;
            }
        }

        if (!isValidate) {
            return;
        }

        // Get Hold Reason with comma separated
        var holdReason = $scope.HoldReason.filter(x => x.IsSelected == true).map(x => x.ReasonValue).join(',');
        var closedReason = $scope.ClosedReason.filter(x => x.IsSelected == true).map(x => x.ReasonValue).join(',');

        var businessProgressStatus = {
            EnrollmentId: $scope.SelectedEnrollmentId,
            BusinessStatus: $scope.BusinessProgressStatus.BusinessStatus,
            BusinessStatusDate: $scope.BusinessProgressStatus.BusinessStatusDate,
            BusinessStatusReason: $scope.BusinessProgressStatus.BusinessStatus == 2 ? holdReason : $scope.BusinessProgressStatus.BusinessStatus == 3 ? closedReason : '',
        };

        console.log($scope.BusinessProgressStatus.BusinessStatus);
        console.log(businessProgressStatus);

        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/UpdateBusinessProgressStatus',
            dataType: 'json',
            method: 'POST',
            data: "{'businessProgressStatus':" + JSON.stringify(businessProgressStatus) + "}",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            if (response.data.d) {
                $scope.CloseBusinessStatusForm();
                $('#viewStatus').modal('hide');
                dataTable.ajax.reload();
                alert("Status Updated Successfully");
            }
        }, function (response) {
            $scope.loading = false;
        });
    };
    $scope.CloseBusinessStatusForm = function () {

        $scope.SelectedEnrollmentId = 0;
        $scope.BusinessProgressStatus.BusinessStatus = "0";
        $scope.HoldReason.forEach(function (item) {
            item.IsSelected = false;
        });
        $scope.ClosedReason.forEach(function (item) {
            item.IsSelected = false;
        });
    };
    $scope.DeleteClick = function (enrollmentId) {
        var r = confirm("Are you sure you want to delete this record?");
        if (r == false) {
            return;
        }

        $http({
            method: 'POST',
            url: '/WebServices/BusinessProgress.asmx/BusinessProgressMoveToEnterpriseSetup',
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