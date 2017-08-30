<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Accounts.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CLMS_App.Accounts.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style >
        .form-signin input[type="text"] {
	  margin-bottom: -1px;
	  border-bottom-left-radius: 0;
	  border-bottom-right-radius: 0;
	}

	.form-signin .middle {
	  margin-bottom: -1px;
	  border-top-left-radius: 0;
	  border-top-right-radius: 0;
	  border-bottom-left-radius: 0;
	  border-bottom-right-radius: 0;
	}

	.form-signin .bottom {
	  margin-bottom: 10px;
	  border-top-left-radius: 0;
	  border-top-right-radius: 0;
	}
	.form-signin .form-control {
	  position: relative;
	  font-size: 16px;
	  height: auto;
	  padding: 10px;
	  -webkit-box-sizing: border-box;
	     -moz-box-sizing: border-box;
	          box-sizing: border-box;
	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row form-signin" style="margin-top: 40px;">
            <div class="col-md-4 col-md-offset-4">
                <h3 style="color: dimgray; text-align: center">Register now to create and fork snippets</h3>
                <hr class="colorgraph" />
                <fieldset>
                    <input class="form-control" placeholder="Username" name="username" type="text" />
                    <input class="form-control middle" placeholder="E-mail" name="email" type="text" />
                    <input class="form-control middle" placeholder="Password" name="password" type="password" value="" />
                    <input class="form-control bottom" placeholder="Confirm Password" name="password_confirmation" type="password" value="" />
                    <input class="btn btn-lg btn-primary btn-block" type="submit" value="Register" />
                    <p class="text-center" style="margin-top: 10px;">OR</p>
                    <br />
                    <p class="text-center"><a href="login.aspx">Already have an account?</a></p>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
