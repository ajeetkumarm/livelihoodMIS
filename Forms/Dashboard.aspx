<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <div class="pagetitle">
            <h1>Dashboard</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                    <li class="breadcrumb-item active">Dashboard</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section dashboard">
            <div class="card">
                <div class="card-body">
                    <div class="row g-3 align-items-center">
                        <div class="col-auto">
                            <label class="col-form-label">Project</label>
                        </div>
                        <div class="col-auto">
                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-auto">
                            <label class="col-form-label">From Date</label>
                        </div>
                        <div class="col-auto">
                            <input type="date" class="form-control" id="txtFromDate" runat="server" name="fromDate" />
                        </div>
                        <div class="col-auto">
                            <label class="col-form-label">To Date</label>
                        </div>
                        <div class="col-auto">
                            <input type="date" class="form-control" id="txtToDate" runat="server" name="toDate" />
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>


                        <%--<div class="col-auto">
                            <label class="col-form-label">Partner</label>
                        </div>
                        <div class="col-auto">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-auto">
                            <label class="col-form-label">Location</label>
                        </div>
                        <div class="col-auto">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                        </div>--%>
                    </div>

                </div>

            </div>
            <div class="row">
                <!-- Sales Card -->
                <div class="col-xxl-4 col-md-6">
                    <div class="card bg-danger bg-opacity-25 info-card sales-card">
                        <div class="card-body">
                            <h5 class="card-title">Enrollment <span>| No. of Users</span></h5>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-people"></i></div>
                                <div class="ps-3">
                                    <h6>
                                        <asp:Label ID="lblTotalEnrollment" runat="server"></asp:Label>
                                    </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Sales Card -->

                <!-- Revenue Card -->
                <div class="col-xxl-4 col-md-6">
                    <div class="card bg-primary bg-opacity-25 info-card revenue-card">
                        <div class="card-body">
                            <h5 class="card-title">EDP Training <span>| No. of Users</span></h5>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-people"></i></div>
                                <div class="ps-3">
                                    <h6>
                                        <asp:Label ID="lblTotalEDPTraining" runat="server"></asp:Label>
                                    </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Revenue Card -->

                <!-- Customers Card -->
                <div class="col-xxl-4 col-xl-12">
                    <div class="card  bg-warning bg-opacity-25 info-card customers-card">
                        <div class="card-body">
                            <h5 class="card-title">Enterprises Setup <span>| No. of Users</span></h5>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-people"></i></div>
                                <div class="ps-3">
                                    <h6>
                                        <asp:Label ID="lblTotalEnterprisesSetup" runat="server"></asp:Label>
                                    </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Customers Card -->

                <!-- Business Card -->
                <div class="col-xxl-4 col-xl-12">
                    <div class="card  bg-success bg-opacity-50 info-card business-card">
                        <div class="card-body">
                            <h5 class="card-title">Business Progress <span>| No. of Users</span></h5>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-people"></i></div>
                                <div class="ps-3">
                                    <h6>
                                        <asp:Label ID="lblTotalBusinessProgress" runat="server"></asp:Label>
                                    </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Customers Card -->

            </div>
        </section>
    </div>
</asp:Content>

