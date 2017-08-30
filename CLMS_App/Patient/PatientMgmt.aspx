<%@ Page Title="Patient List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMgmt.aspx.cs" Inherits="CLMS_App.Patient.PatientMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .fullwidth {
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        function ShowAddUpdatePatient() {
            $('#AddUpdatePatient').modal('show');
        }
        function CloseAddUpdatePatient() {
            $('#AddUpdatePatient').modal('hide');
        }
        function ShowAddUpdateVitalSign() {
            $('#AddUpdateUserVitalSign').modal('show');
        }
        function CloseAddUpdateVitalSign() {
            $('#AddUpdateUserVitalSign').modal('hide');
        }
        function pageLoad() {
            debugger;
            var flag = $('#MainContent_hdnFlag');
            if (typeof flag != 'undefined') {
                if (flag.val() == "true") {
                    CloseAddUpdatePatient();
                    $('#MainContent_hdnFlag').val("false");
                }
            }
        }
    </script>
    <style type="text/css">
       

    
    </style>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header">Patient List
                    </h3>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-wheelchair"></i><a href="PatientMgmt.aspx">Patients</a>
                        </li>
                        <li class="active">
                            <i class="fa fa-table"></i>Patients
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
                                        <label class="col-md-4">Age</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" placeholder="Age" CssClass="form-control" ID="txtAgeSearch" ClientIDMode="Static"></asp:TextBox>
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
                                    <div class="form-group pull-right col-md-5 row">
                                        <asp:Button runat="server" Text="Search" ID="btnSearchPatient" OnClick="btnSearchPatient_Click" CssClass="btn btn-primary btn-md" />
                                        <asp:Button runat="server" Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-default btn-md" />
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
                                        <strong>Patient List</strong>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-default" ID="lnkbtnNewPatient" Text="Add Patient" OnClientClick="ShowAddUpdatePatient();"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="grdvwPatients" AutoGenerateColumns="false" AllowCustomPaging="true" DataKeyNames="ID" OnPageIndexChanging="grdvwPatients_PageIndexChanging" OnRowCommand="grdvwPatients_RowCommand"
                                    CssClass="table table-striped table-bordered table-hover"
                                    runat="server"
                                    AllowPaging="true">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-default" OnClientClick="ShowAddUpdatePatient();" CommandName="select"
                                                    CommandArgument='<%#Bind("ID") %>'><span aria-hidden="true" class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Report">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkaddVitalSign" runat="server" CssClass="btn btn-default" CommandName="Report"
                                                    PostBackUrl='<%# String.Format("~/Patient/AddReports.aspx?PatientID={0}",Eval("id")) %>'>
                                               <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>&nbspAdd/Edit </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vital Sign">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkaddVitalSign" runat="server" CssClass="btn btn-default" CommandName="select"
                                                    PostBackUrl='<%# String.Format("~/Patient/VitalMgmt.aspx?PatientID={0}",Eval("id")) %>'>
                                               <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>&nbspAdd/Edit </asp:LinkButton>
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
        </div>
    </div>

    <div id="AddUpdatePatient" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add Update Patient</h4>
                        </div>
                        <div class="modal-body">
                            <asp:FormView runat="server" ID="frmvwAddUpdatePatient" CssClass="fullwidth" DataKeyNames="ID" OnItemCommand="frmvwAddUpdatePatient_ItemCommand" DefaultMode="Insert">
                                <InsertItemTemplate>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-md-4">Name</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="txtPatientName" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Age</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Age" CssClass="form-control" ID="txtAge" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Occupation</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Occupation" CssClass="form-control" ID="txtOccupation" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="form-group row">
                                                <label class="col-md-4">E-Mail</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Email Address" CssClass="form-control" ID="txtEmailAdd" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                              <div class="form-group row">
                                                <label class="col-md-4">Pin Code</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Pincode" CssClass="form-control" ID="txtPincode" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-md-4">Mobile No</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Mobile Number" ID="txtMobileNo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>
                                                <div class="form-group row">
                                                <label class="col-md-4">Alt Mobile No</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Alternate Mobile Number" ID="txtAltMobileNo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-4">Gender</label>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdbtnlstGender">
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>

                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Address 1</label>
                                                <div class="col-md-8">
                                                      <asp:TextBox runat="server" placeholder="Enter Address 1" ID="txtAddress" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                   <label class="col-md-4">Address 2</label>
                                             <div class="col-md-8">
                                                 <asp:TextBox runat="server" placeholder="Enter Address 2" ID="txtAddress2" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                              </div>
                                                <label class="col-md-4">Address 3</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Address 3" ID="txtAddress3" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                  </div>

                                            </div>
                                            
                                            <div class="form-group row">
                                                <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="AddPatient" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                                <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />
                                            </div>
                                        </div>
                                    </div>
                                </InsertItemTemplate>
                                 <EditItemTemplate>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-md-4">Name</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="txtPatientName" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Age</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Age" CssClass="form-control" ID="txtAge" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Occupation</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Occupation" CssClass="form-control" ID="txtOccupation" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="form-group row">
                                                <label class="col-md-4">E-Mail</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Email Address" CssClass="form-control" ID="txtEmailAdd" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                              <div class="form-group row">
                                                <label class="col-md-4">Pin Code</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Pincode" CssClass="form-control" ID="txtPincode" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-md-4">Mobile No</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Mobile Number" ID="txtMobileNo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>
                                                <div class="form-group row">
                                                <label class="col-md-4">Alt Mobile No</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Alternate Mobile Number" ID="txtAltMobileNo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-4">Gender</label>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdbtnlstGender">
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>

                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Address 1</label>
                                                <div class="col-md-8">
                                                      <asp:TextBox runat="server" placeholder="Enter Address 1" ID="txtAddress" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                   <label class="col-md-4">Address 2</label>
                                             <div class="col-md-8">
                                                 <asp:TextBox runat="server" placeholder="Enter Address 2" ID="txtAddress2" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                              </div>
                                                <label class="col-md-4">Address 3</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Enter Address 3" ID="txtAddress3" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                  </div>

                                            </div>
                                            
                                            <div class="form-group row">
                                                <asp:Button runat="server" Text="Save1" ID="btnSavePatient" CommandName="EditPatient" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                                <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />
                                            </div>
                                        </div>
                                    </div>
                                </EditItemTemplate>
                              <%--  <EditItemTemplate>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-4">Name</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="txtPatientName" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Age</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Age" CssClass="form-control" ID="txtAge" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Occupation</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Occupation" CssClass="form-control" ID="txtOccupation" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-4">Mobile No</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" placeholder="Mobile Number" ID="txtMobileNo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Gender</label>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdbtnlstGender">
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>

                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-md-4">Address</label>
                                                <div class="col-md-8">
                                                    <textarea runat="server" id="txtAddress" style="margin: 0px; width: 281px; height: 66px;" placeholder="Enter Address"></textarea>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <asp:Button runat="server" Text="Save" ID="btnSavePatient" CommandName="EditPatient" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                                <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-default btn-md" />

                                            </div>
                                        </div>
                                    </div>
                                </EditItemTemplate>--%>
                            </asp:FormView>
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
