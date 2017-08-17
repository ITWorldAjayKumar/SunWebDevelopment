<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVitalSignDE.ascx.cs" Inherits="CLMS_App.UserControls.ucVitalSignDE" %>

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        debugger;
        $("#txtTestDate").datepicker();
        var url = window.location;
        $('ul.nav a[href="' + url + '"]').parent().addClass('active');
        $('ul.nav a').filter(function () {
            return this.href == url;
        }).parent().addClass('active');
    });
</script>
<style>
    ul li {
        list-style: none;
    }

    .fullwidth {
        width: 100%;
    }
</style>
<nav class="navbar navbar-inverse" role="navigation">
    <div>
        <ul class="nav navbar-nav">
            <li><a href="Report_VitalSignDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Vital Sign</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Diabetes</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Kidney</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Liver</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Lipid</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Thyroid</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Blood Count</a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Electrolytes </a></li>
            <li><a href="Report_DiabetesDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Bone Profile</a></li>
            <li><a href="Report_UrineDE.aspx?PatientID=<%= Request.QueryString["PatientID"] %>">Urine</a></li>
        </ul>
    </div>
</nav>
<div class="col-md-12">
    <asp:FormView runat="server" ID="frmvwAddUpdateVitalSign" CssClass="fullwidth" DataKeyNames="ID" OnItemCommand="frmvwAddUpdateVitalSign_ItemCommand" DefaultMode="Insert">
        <InsertItemTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">Add Update Vital Sign</div>
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
                                <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="AddPatient" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
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
                            <asp:Button runat="server" Text="Update" ID="btnUpdatePatient" CommandName="UpdatePatient" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                            <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                        </div>
                    </div>
                </div>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</div>

