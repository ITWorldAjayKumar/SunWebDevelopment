<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_UrineDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_UrineDE" %>

<%@ Register Src="~/UserControls/ucUrineDE.ascx" TagPrefix="uc1" TagName="ucUrineDE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucUrineDE runat="server" id="ucUrineDE" />
</asp:Content>
