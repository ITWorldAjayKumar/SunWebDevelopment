<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_ElectrolytesDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_ElectrolytesDE" %>

<%@ Register Src="~/UserControls/ucElectrolytesDE.ascx" TagPrefix="uc1" TagName="ucElectrolytesDE" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucElectrolytesDE runat="server" id="ucElectrolytesDE" />
</asp:Content>

