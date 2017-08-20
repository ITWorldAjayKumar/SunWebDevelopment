<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_LiverFunDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_LiverFunDE" %>

<%@ Register Src="~/UserControls/ucLiverFunDE.ascx" TagPrefix="uc1" TagName="ucLiverFunDE" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucLiverFunDE runat="server" id="ucLiverFunDE" />
</asp:Content>
