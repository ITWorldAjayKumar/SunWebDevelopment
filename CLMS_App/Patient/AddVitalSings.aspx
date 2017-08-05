<%@ Page Title="Manage Patient" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVitalSings.aspx.cs" Inherits="CLMS_App.Patient.AddVitalSings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="page-wrapper">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header">Manage Vital Sign
                    </h3>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-wheelchair"></i><a href="Default.aspx">Patients</a>
                        </li>
                        <li class="active">
                            <i class="fa fa-table"></i>Manage Vital Sign Patient
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Patient Search</div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="form-group row">
                                <label class="col-md-4">Name</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="txtPatientNameSearch" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-4">Test Date</label>
                                <div class="col-md-8">
                                    <div class='input-group date' id='datetimepicker1'>
                                        <input type='text' class="form-control" id="txtDateTest" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                 <%--   <input type="text" placeholder="click to show datepicker" id="example1">--%>
                                    <%--  <asp:TextBox runat="server" placeholder="Age" CssClass="form-control" ID="txtAgeSearch" ClientIDMode="Static"></asp:TextBox>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group row">
                                <label class="col-md-4">Mobile</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" placeholder="Mobile No" CssClass="form-control" ID="txtMobilSearch" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Button runat="server" Text="Search" ID="btnSearchPatient" OnClick="btnSearchPatient_Click" CssClass="btn btn-primary btn-md" />
                                <asp:Button runat="server" Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-default btn-md" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Search Result</div>
                    <div class="panel-body">
                        <div class="col-md-12"></div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <link href="../css/bootstrap-datepicker.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({ format: 'DD-MM-YYYY' });
        });
    </script>
</asp:Content>

