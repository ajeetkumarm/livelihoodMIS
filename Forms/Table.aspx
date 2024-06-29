<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="Table.aspx.cs" Inherits="Forms_Table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <!--plugins-->
   

    <%--<link href="../assets/vendor/datatable/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
   
    <link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                    <table id="example1" class="table table-striped table-bordered table-sm align-middle mb-0">
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
                                            <br />
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



  
<%--    <script src="../assets/js/jquery.min.js"></script>

    <script src="../assets/vendor/datatable/js/jquery.dataTables.min.js"></script>
    <script src="../assets/vendor/datatable/js/dataTables.bootstrap5.min.js"></script>--%>
    
    
</asp:Content>

