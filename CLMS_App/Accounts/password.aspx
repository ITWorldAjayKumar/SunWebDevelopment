<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Accounts.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="CLMS_App.Accounts.password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-signin .form-control {
	  position: relative;
	  font-size: 16px;
	  height: auto;
	  padding: 10px;
	  margin-bottom: 10px;
	  -webkit-box-sizing: border-box;
	     -moz-box-sizing: border-box;
	          box-sizing: border-box;
	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="margin-top: 60px;">
            <div class="col-md-4 col-md-offset-4 form-signin">
                <fieldset>
                    <h2>Request password reset</h2>
                    <hr class="colorgraph" />
                    <input class="form-control" placeholder="Enter your E-mail" name="email" type="text" />
                    <p>
                        <input class="btn btn-lg btn-success btn-block" type="submit" value="Request password reset" />
                    </p>
                    <p class="text-center">Remembered your password? <a href="login.aspx">Login here</a></p>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
