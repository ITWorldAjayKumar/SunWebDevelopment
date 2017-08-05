<%@ Page Title="Add Patient" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="CLMS_App.Patient.AddPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script src="../js/ServiceAPI.js"></script>--%>

    <script type="text/javascript">
        //function APIServiceCall(_obj, url, callType) {
        //    debugger;
        //    var finalURL = 'http://localhost:59475/Api/' + url;
           
        //}
        function AddPatient() {
            var _obj = {
                "Name": $('#txtPatientName').val(),
                "Mobile": $('#txtMobileNo').val(),
                "Age": $('#txtAge').val(),
                "Occupation": $('#txtOccupation').val(),
                "Address": $('#txtAddress').val(),
                "Gender": $("#<%=rdbtnlstGender.ClientID%>").find(":checked").val(),
                "CreatedBy": "ajay",
                "IsActive": true
            };
            $.ajax({
                url: 'http://localhost:59475/Api/AddUpdatePatientDetails',
                type: 'POST',
                cache: false,
                dataType: 'json',
                data: JSON.stringify(_obj),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    return data;
                },
                error: function (xhr, textStatus, errorThrown) {
                    return "Error Occured. Please contact system admin";
                }
            });
            //var data = APIServiceCall(_obj, 'AddUpdatePatientDetails', 'POST');
            //if (typeof data != 'undefined' && data != null) {
            //    alert(data.Message);
            //}



        }
        function ClearControls() {
            $('#txtPatientName').val('');
            $('#txtAge').val('');
            $('#txtOccupation').val('');
            $('#txtMobileNo').val('');
            $('#txtAddress').val('');
        }

    </script>
    <div id="page-wrapper">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header">Add Patient
                        </h3>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-wheelchair"></i><a href="Default.aspx">Patients</a>
                        </li>
                        <li class="active">
                            <i class="fa fa-table"></i>Add Patient
                            </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Add Patient Detail</div>
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
                                    <textarea runat="server" id="txtAddress" placeholder="Enter Address"></textarea>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Button runat="server" Text="Save" ID="btnSavePatient" OnClientClick="AddPatient();" ValidationGroup="AddPatient" CssClass="btn btn-primary btn-md" />
                                <asp:Button runat="server" Text="Reset" ID="btnReset" OnClientClick="ClearControls();" CssClass="btn btn-default btn-md" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
