<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Forms_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!--plugins-->
    <%--<link href="assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
    <link href="assets/plugins/select2/css/select2.min.css" rel="stylesheet" />
    <link href="assets/plugins/select2/css/select2-bootstrap4.css" rel="stylesheet" />
    <link href="assets/plugins/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" />
    <link href="assets/plugins/metismenu/css/metisMenu.min.css" rel="stylesheet" />
    <link href="assets/plugins/highcharts/css/highcharts.css" rel="stylesheet" />--%>

    <link href="../assets/vendor/datatable/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <%--<link href="assets/plugins/datatable/css/dataTables.bootstrap5.min.css" rel="stylesheet" />--%>
    <%--<link href="assets/plugins/Drag-And-Drop/dist/imageuploadify.min.css" rel="stylesheet" />--%>
    
    <!-- Bootstrap CSS -->
    <%--<link href="assets/css/bootstrap.min.css" rel="stylesheet">--%>
    <link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

   <%-- <link href="assets/css/bootstrap-extended.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&amp;display=swap" rel="stylesheet">
    <link href="assets/css/app.css" rel="stylesheet">
    <link href="assets/css/icons.css" rel="stylesheet">
    <!-- Theme Style CSS -->
    <link rel="stylesheet" href="assets/css/dark-theme.css" />
    <link rel="stylesheet" href="assets/css/semi-dark.css" />
    <link rel="stylesheet" href="assets/css/header-colors.css" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-wrapper">
            <div class="page-content">

                <div class="row">
                    <div class="col">
                        <div class="card radius-10 mb-4">
                            <div class="card-header">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h5 class="my-0">Task Details</h5>
                                    </div>
                                    <div class="ms-auto"><a href="javscript:;" class="btn btn-primary btn-sm radius-30" data-bs-toggle="modal" data-bs-target="#addTaskModal"><i class="bx bx-task"></i>Add Task</a> </div>
                                </div>
                            </div>
                            <div class="card-body p-2">
                                <div class="table-responsive">
                                    <table id="example2" class="table table-striped table-bordered table-sm align-middle mb-0">
                                        <thead class="table-light small">
                                            <tr>
                                                <th>Task ID</th>
                                                <th>Issue, Action or Decision</th>
                                                <th>Priority</th>
                                                <th>Date of Decision / Initiation</th>
                                                <th>Deadline</th>
                                                <th>Task Coordinator</th>
                                                <th>Action Taken / Status </th>
                                                <th>Officer Responsible</th>
                                                <th>Additional Comments</th>
                                                <th>New Status</th>
                                                <th>Status</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>44</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>High</td>
                                                <td>22/11/2021</td>
                                                <td>10/12/2021*</td>
                                                <td>Shri Nagendra Nath Sinha</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="icon-badge position-relative bg-success me-lg-3" title="Completed"><i class="bx bx-check align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span></div>
                                                </td>
                                                <td><span class="badge bg-light-success text-success w-100">Completed</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>43</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>High</td>
                                                <td>22/11/2021</td>
                                                <td>10/12/2021*</td>
                                                <td>Shri Sunil Kumar</td>
                                                <td>&nbsp;</td>
                                                <td>Dr Bijaya Kumar Behera</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-info me-lg-3" title="Work in Progress"><i class="bx bx-street-view align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-info text-info w-100">Work in Progress</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>42</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>Top</td>
                                                <td>23/11/2021</td>
                                                <td>10/12/2021*</td>
                                                <td>Shri Ajay Tirkey</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-primary me-lg-3" title="On Time"><i class="bx bxs-time align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-primary text-primary w-100">On Time</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>41</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>Top</td>
                                                <td>22/11/2021</td>
                                                <td>30/11/2021*</td>
                                                <td>Shri Ajay Tirkey</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-warning me-lg-3" title="Slight Delay"><i class="bx bxs-time-five align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-warning text-warning w-100">Slight Delay</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>40</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>Top</td>
                                                <td>22/11/2021</td>
                                                <td>29/11/2021*</td>
                                                <td>Smt Alka Upadhyaya</td>
                                                <td>&nbsp;</td>
                                                <td>Dr Bijaya Kumar Behera</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-danger me-lg-3" title="Significant Delay"><i class="bx bxs-timer align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-danger text-danger w-100">Significant Delay</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>39</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>Top</td>
                                                <td>22/11/2021</td>
                                                <td>23/11/2021*</td>
                                                <td>Shri Mitter Sain</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-success me-lg-3" title="Completed"><i class="bx bx-check align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-success text-success w-100">Completed</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>38</td>
                                                <td>Electronic sensor for automated switching</td>
                                                <td>Top</td>
                                                <td>22/11/2021</td>
                                                <td>23/11/2021*</td>
                                                <td>Ms Rekha Yadav</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <div class="col">
                                                        <div class="icon-badge position-relative bg-info me-lg-3" title="Work in Progress"><i class="bx bx-street-view align-middle font-20 text-white"></i><span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary fw-normal">22 <span class="visually-hidden">unread messages</span></span> </div>
                                                    </div>
                                                </td>
                                                <td><span class="badge bg-light-info text-info w-100">Work in Progress</span></td>
                                                <td>
                                                    <div class="d-flex order-actions"><a href="javascript:;" class="text-danger bg-light-danger border-0"><i class="bx bxs-trash"></i></a><a href="javascript:;" class="ms-4 text-primary bg-light-primary border-0"><i class="bx bxs-edit"></i></a></div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="card-footer">
                                <ul class="nav d-flex justify-content-evenly lh-1">
                                    <li class="nav-item d-flex align-items-center">
                                        <div class="me-2 icon-badge bg-success" title="Completed"><i class="bx bx-check align-middle font-20 text-white"></i></div>
                                        <div class="ms-auto">
                                            <strong>Completed</strong><br>
                                            <small>Task Completed</small>
                                        </div>
                                    </li>
                                    <li class="nav-item d-flex align-items-center">
                                        <div class="me-2 icon-badge bg-info" title="Work in Progress"><i class="bx bx-street-view align-middle font-20 text-white"></i></div>
                                        <div class="ms-auto">
                                            <strong>Work in Progress</strong>
                                            <br>
                                            <small>Deadline future date</small>
                                        </div>
                                    </li>
                                    <li class="nav-item d-flex align-items-center">
                                        <div class="me-2 icon-badge bg-primary" title="On Time"><i class="bx bxs-time align-middle font-20 text-white"></i></div>
                                        <div class="ms-auto">
                                            <strong>On Time</strong>
                                            <br>
                                            <small>Delay within 0-7 days</small>
                                        </div>
                                    </li>
                                    <li class="nav-item d-flex align-items-center">
                                        <div class="me-2 icon-badge bg-warning" title="Slight Delay"><i class="bx bxs-time-five align-middle font-20 text-white"></i></div>
                                        <div class="ms-auto">
                                            <strong>Slight Delay</strong>
                                            <br>
                                            <small>Delay within 8-30 days</small>
                                        </div>
                                    </li>
                                    <li class="nav-item d-flex align-items-center">
                                        <div class="me-2 icon-badge bg-danger" title="Significant Delay"><i class="bx bxs-timer align-middle font-20 text-white"></i></div>
                                        <div class="ms-auto">
                                            <strong>Significant Delay</strong>
                                            <br>
                                            <small>Delay Beyond 30 days</small>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>












    <!-- Bootstrap JS -->
    <%--<script src="assets/js/bootstrap.bundle.min.js"></script>--%>
    <!--plugins-->
    <%--<script src="assets/js/jquery.min.js"></script>--%>
    <script src="../assets/js/jquery.min.js"></script>

    <%--<script src="assets/plugins/simplebar/js/simplebar.min.js"></script>
    <script src="assets/plugins/metismenu/js/metisMenu.min.js"></script>
    <script src="assets/plugins/perfect-scrollbar/js/perfect-scrollbar.js"></script>
    <script src="assets/plugins/Drag-And-Drop/dist/imageuploadify.min.js"></script>--%>
    <!-- highcharts js -->
    <%--<script src="assets/plugins/highcharts/js/highcharts.js"></script>
    <script src="assets/plugins/highcharts/js/highcharts-more.js"></script>
    <script src="assets/plugins/highcharts/js/variable-pie.js"></script>
    <script src="assets/plugins/highcharts/js/solid-gauge.js"></script>
    <script src="assets/plugins/highcharts/js/highcharts-3d.js"></script>
    <script src="assets/plugins/highcharts/js/cylinder.js"></script>
    <script src="assets/plugins/highcharts/js/funnel3d.js"></script>
    <script src="assets/plugins/highcharts/js/exporting.js"></script>
    <script src="assets/plugins/highcharts/js/export-data.js"></script>
    <script src="assets/plugins/highcharts/js/accessibility.js"></script>--%>
    <!--<script src="assets/js/index4.js"></script> -->
    <script src="../assets/vendor/datatable/js/jquery.dataTables.min.js"></script>
    <script src="../assets/vendor/datatable/js/dataTables.bootstrap5.min.js"></script>
    <%--<script src="assets/plugins/datatable/js/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/datatable/js/dataTables.bootstrap5.min.js"></script>--%>
    <!--select2-->
    <%--<script src="assets/plugins/select2/js/select2.min.js"></script>--%>
    <script>
        $(document).ready(function () {
            $('#image-uploadify').imageuploadify();
            //multiple-select
            $('.multiple-select').select2({
                dropdownParent: $('#addTaskModal'),
                theme: 'bootstrap4',
                width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
                placeholder: $(this).data('placeholder'),
                allowClear: Boolean($(this).data('allow-clear')),
            });
        })
        $(document).ready(function () {
            var table = $('#example2').DataTable({
                lengthChange: false,
                buttons: ['copy',
					{
					    extend: 'excel', autoFilter: true, sheetName: 'Exported data', title: 'Data export',
					    messageTop: 'Excel created by MRD Admin Dashboard, GOI.'
					},

					{
					    extend: 'pdf', orientation: 'landscape', pageSize: 'A4', title: 'Data export',
					    messageTop: 'PDF created by MRD Admin Dashboard, GOI.', download: 'open',
					    customize: function (doc) { doc.pageMargins = [10, 10, 10, 10]; doc.defaultStyle.fontSize = 7; doc.styles.tableHeader.fontSize = 7; },

					    /*customize: function (doc) {
                           doc.content.splice(0,1);
                           var now = new Date();
                           var jsDate = now.getDate()+'-'+(now.getMonth()+1)+'-'+now.getFullYear();
                           
                           doc.pageMargins = [0,5,0,10];
                           doc.defaultStyle.fontSize = 7;
                           doc.styles.tableHeader.fontSize = 7;
   
                           doc['footer']=(function(page, pages) {
                               return {
                                   columns: [{
                                           alignment: 'left',
                                           text: ['Created on: ', { text: jsDate.toString() }]
                                       }, {
                                           alignment: 'right',
                                           text: ['page ', { text: page.toString() },	' of ',	{ text: pages.toString() }]
                                       }
                                   ],
                                   margin: 0
                               }
                           });
                               var objLayout = {};
                               objLayout['hLineWidth'] = function(i) { return .25; };
                               objLayout['vLineWidth'] = function(i) { return .25; };
                               objLayout['hLineColor'] = function(i) { return '#aaa'; };
                               objLayout['vLineColor'] = function(i) { return '#aaa'; };
                               objLayout['paddingLeft'] = function(i) { return 2; };
                               objLayout['paddingRight'] = function(i) { return 2; };
                               doc.content[0].layout = objLayout;
                               }*/
					},
						{
						    extend: 'print', messageTop: 'The information in this table is copyright to MoRD Dashboard.', customize: function (win) {
						        $(win.document.body).css('font-size', '8pt');
						        $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
						    }
						}
                ],
            });

            table.buttons().container()
				.appendTo('#example2_wrapper .col-md-6:eq(0)');
        });
    </script>
    <!--app JS-->
    <script src="assets/js/app.js"></script>
</body>
</html>
