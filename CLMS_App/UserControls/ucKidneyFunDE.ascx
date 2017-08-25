﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKidneyFunDE.ascx.cs" Inherits="CLMS_App.UserControls.ucKidneyFunDE" %>
<link href="../Content/jquery-ui.css" rel="stylesheet" />
<script src="../js/Jquery/jquery-1.12.4.js"></script>
<script src="../js/Jquery/jquery-ui.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        debugger;
        $("#txtTestDate").datepicker({ dateFormat: 'M-dd-yy' });
        var url = window.location;
        $('ul.nav a[href="' + url + '"]').parent().addClass('active');
        $('ul.nav a').filter(function () {
            return this.href == url;
        }).parent().addClass('active');
    });
    function pageLoad() {
        $("#txtTestDate").datepicker({ dateFormat: 'M-dd-yy' });
    }
</script>
<style>
    ul li {
        list-style: none;
    }

    .fullwidth {
        width: 100%;
    }
</style>
<asp:ScriptManager runat="server"></asp:ScriptManager>
<nav class="navbar navbar-inverse" role="navigation">
    <div>
        <ul class="nav navbar-nav">
            <li><a href="Report_VitalSignDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Vital Sign</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Diabetes</a></li>
            <li><a href="Report_KidneyFunDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Kidney</a></li>
            <li><a href="Report_LiverFunDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Liver</a></li>
            <li><a href="Report_LipidProfileDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Lipid</a></li>
            <li><a href="Report_ThyroidProfileDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Thyroid</a></li>
            <li><a href="Report_BloodCountDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Blood Count</a></li>
            <li><a href="Report_ElectrolytesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Electrolytes </a></li>
            <li><a href="Report_BoneProfileDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Bone Profile</a></li>
            <li><a href="Report_UrineDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Urine</a></li>
        </ul>
    </div>
</nav>
<div class="col-md-12">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divmsg" runat="server" ></div>
            <asp:FormView runat="server" ID="frmvwAddUpdateVitalSign" CssClass="fullwidth" DataKeyNames="VSR_TestReportID" OnItemCommand="frmvwAddUpdateVitalSign_ItemCommand" DefaultMode="Insert">
                <InsertItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Add Update Kidney Function</div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">Test Date</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Test Date" CssClass="form-control" ID="txtTestDate" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Pulse</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Pulse" CssClass="form-control" ID="txtPulse" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Weight</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Weight" CssClass="form-control" ID="txtWeight" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">S BP</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="S BP" ID="txtSBP" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">D SP</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="D BP" ID="txtDBP" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group row pull-right">
                                        <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="AddVitalSign" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                        <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Add Update Vital Sign</div>
                        <div class="panel-body">

                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label class="col-md-4">Test Date</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Test Date" CssClass="form-control" ID="txtTestDate" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Pulse</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Pulse" CssClass="form-control" ID="txtPulse" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Weight</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Weight" CssClass="form-control" ID="txtWeight" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label class="col-md-4">S BP</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="S BP" ID="txtSBP" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">D SP</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="D BP" ID="txtDBP" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Button runat="server" Text="Update" ID="btnUpdatePatient" CommandName="UpdateVitalSign" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                    <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                                </div>
                            </div>
                        </div>
                    </div>
                </EditItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div class="col-md-12">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-sm-6">
                            <strong>Patient Vital Sign Report Details</strong>
                        </div>

                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="grdvwVitalSignRptDetails" AutoGenerateColumns="false" AllowCustomPaging="true" DataKeyNames="VSR_TestReportID" OnPageIndexChanging="grdvwVitalSignRptDetails_PageIndexChanging" OnRowCommand="grdvwVitalSignRptDetails_RowCommand"
                        CssClass="table table-striped table-bordered table-hover"
                        runat="server"
                        AllowPaging="true">
                        <Columns>
                            <asp:BoundField DataField="TestDate" HeaderText="Test Date" DataFormatString="{0:MMM-dd-yyyy}"/>
                            <asp:BoundField DataField="SBP" HeaderText="SBP" />
                            <asp:BoundField DataField="DBP" HeaderText="DBP" />
                            <asp:BoundField DataField="Weight" HeaderText="Weight" />
                            <asp:BoundField DataField="Pulse" HeaderText="Pulse" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-default" CommandName="select"
                                        CommandArgument='<%#Bind("VSR_TestReportID") %>'><span aria-hidden="true" class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>