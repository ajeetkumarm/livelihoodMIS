<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Livelihood.master" AutoEventWireup="true" CodeFile="BusinessProgressList.aspx.cs" Inherits="Forms_BusinessProgressList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="/assets/js/angular/angular.min.js"></script>
    <script src="/assets/js/angular/BusinessProgressList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagetitle">
        <h1>Business Progress List</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item">Forms</li>
                <li class="breadcrumb-item active">Business Progress List</li>
            </ol>
        </nav>
    </div>
    <section class="section">
        <div class="card">
            <div class="card-body" ng-app="businessProgressApp" ng-controller="businessProgressController">
                <h5 class="card-title">Business Progress</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card radius-10 mb-2 p-2">
                            <div class="table-responsive">
                                <table id="BusinessProgressTable" class="table table-striped table-bordered nowrap">
                                    <thead class="table-light">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Update Status</th>
                                            <th>Beneficiary Code</th>
                                            <th>Women Name</th>
                                            <th>Phone No</th>
                                            <th>State</th>
                                            <th>District</th>
                                            <th>Block</th>
                                            <th>Village</th>
                                            <th>Registration Date</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="viewStatus" class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true"
                    style="display: none;">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="myModalLabel">Update Business Status</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body py-0">
                                <div class="table-responsive table-card">
                                    <table class="table table-sm table-nowrap mb-0" summary="Order Product Details List">
                                        <tbody>
                                            <tr>
                                                <th style="width: 32%;" class="text-left">Business Status <span class="text-danger">*</span></th>
                                                <td style="width: 1%;">:</td>
                                                <td class="no-word-wrap">
                                                    <select id="ddlBusinessStatus" ng-model="BusinessProgressStatus.BusinessStatus" ng-change="onStatusChange()" class="form-select">
                                                        <option value="0">Select</option>
                                                        <option value="1">Active</option>
                                                        <option value="2">Hold</option>
                                                        <option value="3">Closed</option>
                                                    </select>
                                                    <span ng-show="BusinessProgressStatus.BusinessStatusError" class="text-danger">Required</span>
                                                </td>
                                            </tr>
                                            <tr ng-show="BusinessProgressStatus.BusinessStatus!=0">
                                                <th style="width: 32%;" class="text-left">
                                                    <span id="lblDate">{{
                                                         BusinessProgressStatus.BusinessStatus==2 ? 'Hold Date' : BusinessProgressStatus.BusinessStatus==1 ? 'Active Date' : 
                                                         BusinessProgressStatus.BusinessStatus==3 ? 'Closed Date' : ''
                                                        }}
                                                    </span> <span class="text-danger">*</span>
                                                </th>
                                                <td style="width: 1%;">:</td>
                                                <td class="no-word-wrap">
                                                    <input type="text" id="txtDate" ng-disabled="true" class="form-control" ng-model="BusinessProgressStatus.BusinessStatusDate" />
                                                </td>
                                            </tr>
                                            <tr ng-show="BusinessProgressStatus.BusinessStatus==2">
                                                <th style="width: 32%;" class="text-left">
                                                    <span>Hold Reason</span> <span class="text-danger">*</span>
                                                </th>
                                                <td style="width: 1%;">:</td>
                                                <td class="no-word-wrap">
                                                    <div ng-repeat="reason in HoldReason">
                                                        <label>
                                                            <input type="checkbox" ng-model="reason.IsSelected" ng-value="reason.ReasonValue" />
                                                            {{reason.ReasonText}}
                                       
                                                        </label>
                                                    </div>
                                                    <span ng-show="BusinessProgressStatus.HoldReasonError" class="text-danger">Please select reason</span>
                                                </td>
                                            </tr>
                                            <tr ng-show="BusinessProgressStatus.BusinessStatus==3">
                                                <th style="width: 32%;" class="text-left">
                                                    <span>Closed Reason</span> <span class="text-danger">*</span>
                                                </th>
                                                <td style="width: 1%;">:</td>
                                                <td class="no-word-wrap">
                                                    <div ng-repeat="reason in ClosedReason">
                                                        <label>
                                                            <input type="checkbox" ng-model="reason.IsSelected" ng-value="reason.ReasonValue" />
                                                            {{reason.ReasonText}}
                                       
                                                        </label>
                                                    </div>
                                                    <span ng-show="BusinessProgressStatus.ClosedReasonError" class="text-danger">Please select reason</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <button type="button" class="btn btn-primary" ng-click="UpdateBusinessStatus()">Update</button>
                                                    <button type="button" class="btn btn-secondary" ng-click="CloseBusinessStatusForm()" data-bs-dismiss="modal">Close</button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
            </div>
        </div>
    </section>






</asp:Content>

