<%@ Page Title="Vital Sign" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VitalMgmt.aspx.cs" Inherits="CLMS_App.Patient.VitalMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .fullwidth{
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        function ShowAddUpdateVitalSign() {
            $('#AddUpdateUserVitalSign').modal('show');
        }
        function CloseAddUpdateVitalSign() {
            $('#AddUpdateUserVitalSign').modal('hide');
        }
        function pageLoad() {
            $("#txtdatepicker").datepicker();
            var flag = $('#MainContent_hdnFlag');
            if (typeof flag != 'undefined') {
                if (flag.val() == "true") {
                    CloseAddUpdateVitalSign();
                    $('#MainContent_hdnFlag').val("false");
                }
            }
        }
    </script>
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header">Vital Sign List
                    </h3>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-wheelchair"></i><a href="PatientMgmt.aspx">Patients</a>
                        </li>
                        <li class="active">
                            <i class="fa fa-table"></i>Vital Sign
                        </li>
                    </ol>
                </div>
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div id="divmsg" runat="server" style="display: none;"></div>
                        <asp:HiddenField runat="server" ID="hdnFlag" Value="" />
                        <div class="panel panel-default">
                            <div class="panel-heading">Patient Details</div>
                            <div class="panel-body">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">Name</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientName" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Age</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientAge" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Address</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientAddress" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">Mobile</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientMobile" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Gender</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientGender" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Occupation</label>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblVitalPatientOccupation" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.row -->
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <strong>Vital Sign List</strong>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-default" ID="lnkbtnNewVitalSign" Text="Add Vital Sign" OnClientClick="ShowAddUpdateVitalSign();" OnClick="lnkbtnNewVitalSign_Click"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="grdvwVitals" AutoGenerateColumns="false" AllowCustomPaging="true" OnPageIndexChanging="grdvwVitals_PageIndexChanging" OnRowCommand="grdvwVitals_RowCommand"
                                    CssClass="table table-striped table-bordered table-hover" DataKeyNames="TestReportID,PatientID"
                                    runat="server"
                                    AllowPaging="true">
                                    <Columns>
                                        <asp:BoundField DataField="BP" HeaderText="BP" />
                                        <asp:BoundField DataField="Weight" HeaderText="Weight" />
                                        <asp:BoundField DataField="Temperature" HeaderText="Temperature" />
                                        <asp:BoundField DataField="Pluse" HeaderText="Pluse" />
                                        <asp:BoundField DataField="TestDate" DataFormatString="{0:MMMM d, yyyy}" HeaderText="Test Date" />

                                        <%--    <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />--%>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-default" OnClientClick="ShowAddUpdateVitalSign();" CommandName="select"
                                                    CommandArgument='<%#Bind("TestReportID") %>'><span aria-hidden="true" class="glyphicon glyphicon-edit"></span>&nbspEdit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkaddVitalSign" runat="server" CssClass="btn btn-default" PostBackUrl='<%# String.Format("~/Patient/AddReports.aspx?TestReportID={0}",Eval("TestReportID")) %>'><span aria-hidden="true" class="glyphicon glyphicon-cloud-upload
"></span>&nbspAdd Reports</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <div id="AddUpdateUserVitalSign" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-md">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add Update Vital Sign</h4>
                        </div>
                        <div class="modal-body">
                            <%--<div class="col-md-12">--%>
                                <asp:FormView runat="server" ID="frmVitalSign" CssClass="fullwidth" DataKeyNames="TestReportID" OnItemCommand="frmVitalSign_ItemCommand" DefaultMode="Insert">
                                    <InsertItemTemplate>
                                        <div class="panel-body">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4">Test Date</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Test Date" CssClass="form-control" ID="txtdatepicker" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <asp:HiddenField ID="hdnPatientID" runat="server" />
                                                    <label class="col-md-4">Blood Pressure(mmHg)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Blood Pressure" CssClass="form-control" ID="txtBP" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4">Weight(Kg)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Weight" CssClass="form-control" ID="txtWeight" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4">Pulse(Heart Beats/min)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Pulse" ID="txtPluse" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4">Temperature(*F)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Temperature" CssClass="form-control" ID="txtTemperature" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="AddVitalSign" ValidationGroup="AddVitalSign" CssClass="btn btn-primary btn-md" />
                                                    <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                                                </div>
                                            </div>
                                        </div>
                                    </InsertItemTemplate>
                                    <EditItemTemplate>
                                        <div class="panel-body">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4">Test Date</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Blood Pressure" CssClass="form-control" ID="txtdatepicker" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4">Blood Pressure(mmHg)</label>

                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Blood Pressure" CssClass="form-control" ID="txtBP" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4">Weight(Kg)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Weight" CssClass="form-control" ID="txtWeight" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4">Pulse(Heart Beats/min)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Pulse" ID="txtPluse" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4">Temperature(*F)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox runat="server" placeholder="Temperature" CssClass="form-control" ID="txtTemperature" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="EditVitalSign" ValidationGroup="AddVitalSign" CssClass="btn btn-primary btn-md" />
                                                    <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                                                </div>
                                            </div>
                                            <%--<div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-4">Pulse</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Pulse" ID="txtPluse" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>

                                        </div>--%>
                                        </div>
                                    </EditItemTemplate>
                                </asp:FormView>
                            <%--</div>--%>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
