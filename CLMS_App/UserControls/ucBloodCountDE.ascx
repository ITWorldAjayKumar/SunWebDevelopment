<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBloodCountDE.ascx.cs" Inherits="CLMS_App.UserControls.ucBloodCountDE" %>
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
            <div id="divmsg" runat="server"></div>
            <asp:FormView runat="server" ID="frmvwAddUpdateBloodCount" CssClass="fullwidth" DataKeyNames="BCR_TestReportID" OnItemCommand="frmvwAddUpdateBloodCount_ItemCommand" DefaultMode="Insert">
                <InsertItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Add Update Blood Count</div>
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
                                        <label class="col-md-4">CBC</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="CBC" CssClass="form-control" ID="txtCBC" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">WBC</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="WBC" CssClass="form-control" ID="txtWBC" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">PLATELET</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="PLATELET" ID="txtPLATELET" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">MCV</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="MCV" ID="txtMCV" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Neutrophils</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Neutrophils" ID="txtNeutrophils" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </div>

                                    </div>

                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-md-4">Lymphocytes</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Lymphocytes" ID="txtLymphocytes" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Eosinophil</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Eosinophil" ID="txtEosinophil" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Monocytes</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Monocytes" ID="txtMonocytes" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">Basophils</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Basophils" ID="txtBasophils" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-4">ESR</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="ESR" ID="txtESR" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group row pull-right">
                                        <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="AddBloodCount" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
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
                                    <label class="col-md-4">CBC</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="CBC" CssClass="form-control" ID="txtCBC" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">WBC</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="WBC" CssClass="form-control" ID="txtWBC" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">PLATELET</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="PLATELET" ID="txtPLATELET" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">MCV</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="MCV" ID="txtMCV" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Neutrophils</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Neutrophils" ID="txtNeutrophils" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label class="col-md-4">Lymphocytes</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Lymphocytes" ID="txtLymphocytes" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Eosinophil</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Eosinophil" ID="txtEosinophil" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Monocytes</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Monocytes" ID="txtMonocytes" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">Basophils</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="Basophils" ID="txtBasophils" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label class="col-md-4">ESR</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" placeholder="ESR" ID="txtESR" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Button runat="server" Text="Update" ID="btnUpdatePatient" CommandName="UpdateBloodCount" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
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
                    <asp:GridView ID="grdvwBloodCountRptDetails" AutoGenerateColumns="false" AllowCustomPaging="true" DataKeyNames="BCR_TestReportID"
                        OnPageIndexChanging="grdvwBloodCountRptDetails_PageIndexChanging" OnRowCommand="grdvwBloodCountRptDetails_RowCommand"
                        CssClass="table table-striped table-bordered table-hover"
                        runat="server"
                        AllowPaging="true">
                        <Columns>
                            <asp:BoundField DataField="TestDate" HeaderText="Test Date" DataFormatString="{0:MMM-dd-yyyy}" />
                            <asp:BoundField DataField="CBC" HeaderText="CBC" />
                            <asp:BoundField DataField="WBC" HeaderText="WBC" />
                            <asp:BoundField DataField="PLATELET" HeaderText="PLATELET" />
                            <asp:BoundField DataField="MCV" HeaderText="MCV" />
                            <asp:BoundField DataField="Neutrophils" HeaderText="Neutrophils" />
                            <asp:BoundField DataField="Lymphocytes" HeaderText="Lymphocytes" />
                            <asp:BoundField DataField="Eosinophil" HeaderText="Eosinophil" />
                            <asp:BoundField DataField="Monocytes" HeaderText="Monocytes" />
                            <asp:BoundField DataField="Basophils" HeaderText="Basophils" />
                            <asp:BoundField DataField="ESR" HeaderText="ESR" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-default" CommandName="select"
                                        CommandArgument='<%#Bind("BCR_TestReportID") %>'><span aria-hidden="true" class="glyphicon glyphicon-edit"></span></asp:LinkButton>
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
