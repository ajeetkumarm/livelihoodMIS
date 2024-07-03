var app = angular.module('enterpriesSetupApp',[]);
app.controller('enterpriesSetupController', function ($scope, $http) {

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
                "data": "EnrollmentId",
                "render": function (data) {

                    return `<div><a href="EnterpriseStartUpgrate.aspx?EnrolId=${data}" class="btn btn-sm btn-success" title="Update" >
                                    Update
                                    </a>
                             </div>`
                }, 
            },
            
        ],
        lengthMenu: [
            [25, 50, 100, -1],
            [25, 50, 100, 'All'],
        ],
        "bStateSave": true,
        "fnStateSave": function (oSettings, oData) {
            localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
        },
        "fnStateLoad": function (oSettings) {
            return JSON.parse(localStorage.getItem('DataTables_' + window.location.pathname));
        }
    });
});