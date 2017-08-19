<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_DiabetesDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_DiabetesDE" %>

<%@ Register Src="~/UserControls/ucDiabetesDE.ascx" TagPrefix="uc1" TagName="ucDiabetesDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucDiabetesDE runat="server" id="ucDiabetesDE" />
</asp:Content>
