<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReports.aspx.cs" Inherits="CLMS_App.Patient.AddReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    <div id="page-wrapper">
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
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

                        <%--<div class="col-md-6"></div>--%>
                        <div class="col-md-6">
                            <div class="form-group row">
                                <label class="col-md-4">Test Date</label>
                                <div class="col-md-8">
                                    <input type="text" id="datepicker">
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6">
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="form-group row">
                            <div class="col-md-6">
                                <label class="col-md-4">Select File to Upload</label>
                                <div class="col-md-8">
                                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">List Of Reports</div>
                    <div class="panel-body">
                        <%--<asp:DataGrid runat="server" ID="lstUploadFile" DataKeyNames="TestReportID">
                            <Columns>
                                <asp:TemplateColumn>
                                    <ItemTemplate>
                                          <asp:Image runat="server" ImageUrl="~/Images/Icon_Report.png" Width ="16" /> 
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="TestName" HeaderText="Test Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TestDate" HeaderText="Test Date"></asp:BoundColumn>

                            </Columns>

                        </asp:DataGrid>--%>
                        <asp:ListView runat="server" ID="lstUploadFile"
                            DataKeyNames="TestReportID">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <img src="../Images/Icon_Report.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>
                                                <%# Eval("TestName")%>
                                            </span>
                                            <br />
                                            <span>
                                                <b>Test Date: </b><%# Eval("TestDate")%>
                                            </span>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
