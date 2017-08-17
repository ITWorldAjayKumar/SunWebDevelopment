<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_UrineDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_UrineDE" %>

<%@ Register Src="~/UserControls/ucUrineReportsDE.ascx" TagPrefix="uc1" TagName="ucUrineReportsDE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucUrineReportsDE runat="server" id="ucUrineReportsDE" />
</asp:Content>
