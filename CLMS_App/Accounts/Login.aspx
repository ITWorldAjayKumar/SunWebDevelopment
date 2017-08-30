<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Accounts.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CLMS_App.Accounts.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-signin input[type="text"] {
            margin-bottom: -1px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        .form-signin input[type="password"] {
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
        <div class="row" style="margin-top: 60px;">
            <div class="col-md-4 col-md-offset-4 form-signin">
                <fieldset>
                    <h3 class="sign-up-title" style="color: dimgray; text-align: center">Welcome back! Please sign in</h3>

                    <hr class="colorgraph" />
                    <div class="warning">
                        <asp:ValidationSummary ID="vsLogin" runat="server" ValidationGroup="vLogin" DisplayMode="BulletList" CssClass="alert alert-danger" />
                    </div>
                    <%--<input class="form-control email-title" placeholder="E-mail" name="email" type="text" />--%>
                    <%--<input class="form-control" placeholder="Password" name="password" type="password" value="" />--%>
                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control email-title" placeholder="User ID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtUserID" runat="server" ControlToValidate="txtUserID" Text="*" ValidationGroup="vLogin" Display="None" ErrorMessage="Enter user id to Login"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPswd" runat="server" TextMode="Password" CssClass="form-control email-title" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPswd" runat="server" ControlToValidate="txtPswd" Text="*" ValidationGroup="vLogin" Display="None" ErrorMessage="Enter password to Login"></asp:RequiredFieldValidator>
                    <a class="pull-right" href="password.aspx">Forgot password?</a>
                    <div class="checkbox" style="width: 140px;">
                        <label>
                            <input name="remember" type="checkbox" value="Remember Me" />
                            Remember Me</label>
                    </div>
                    <%--<input class="btn btn-lg btn-success btn-block" type="submit" value="Login" />--%>
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-lg btn-success btn-block" ValidationGroup="vLogin" Text="Login" OnClick="btnLogin_Click" />
                    <p class="text-center" style="margin-top: 10px;">OR</p>
                    <p class="text-center"><a href="register.aspx">Register for an account?</a></p>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
