<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReports.aspx.cs" Inherits="CLMS_App.Patient.AddReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/jquery-ui.css" rel="stylesheet" />
    <script src="../js/Jquery/jquery-1.12.4.js"></script>
    <script src="../js/Jquery/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#txtTestDate").datepicker({ dateFormat: 'M-dd-yy' });
        });
    </script>
    <div id="page-wrapper">
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3 class="page-header">Report List
                            </h3>
                            <ol class="breadcrumb">
                                <li>
                                    <i class="fa fa-wheelchair"></i><a href="PatientMgmt.aspx">Patients</a>
                                </li>
                                <li>
                                    <i class="fa fa-bar-chart"></i><a href="VitalMgmt.aspx">Vital Sign</a>
                                </li>
                                <li class="active">
                                    <i class="fa fa-book fa-fw"></i>Reports Upload/View
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">Upload Reports</div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div id="divmsg" runat="server" style="display: none;"></div>
                                <asp:HiddenField runat="server" ID="hdnFlag" Value="" />

                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-md-4">Test Date</label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" placeholder="Test Date" CssClass="form-control" ID="txtTestDate" ClientIDMode="Static"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-md-4">Test Name</label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" placeholder="Test Name" CssClass="form-control" ID="txtTestName" ClientIDMode="Static"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">File to Upload</label>
                                        <div class="col-md-8">
                                            <asp:FileUpload ID="FileUploadControl" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6"></div>
                                <div class="col-md-6 btn-group pull-right">
                                    <asp:Button runat="server" CssClass="btn btn-primary" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />

                                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnReset" Text="Reset" OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </div>


                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">List Of Reports</div>
                        <div class="panel-body">
                            <asp:ListView runat="server" ID="lstUploadFile"
                                DataKeyNames="TestReportID">
                                <%--OnItemCommand="lstUploadFile_ItemCommand" OnItemDataBound="lstUploadFile_ItemDataBound"--%>
                                <ItemTemplate>
                                    <div class="col-md-4 well">
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <a href='<%# String.Format("/Patient/ReportUploaded/{0}",Eval("FileName")) %>' target="_blank">
                                                    <img src="../Images/Icon_Report.png" /><br />
                                                </a>
                                            </div>
                                            <div class="col-md-10">
                                                <span><%# Eval("TestName")%></span><br />
                                                <span><%# Convert.ToDateTime(Eval("TestDate")).ToString("dd/MMM/yyyy")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="UploadButton" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dialog" style="display: none"></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
