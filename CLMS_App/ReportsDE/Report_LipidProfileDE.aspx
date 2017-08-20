<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_LipidProfileDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_LipidProfileDE" %>

<%@ Register Src="~/UserControls/ucLipidProfileDE.ascx" TagPrefix="uc1" TagName="ucLipidProfileDE" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucLipidProfileDE runat="server" id="ucLipidProfileDE" />
</asp:Content>
