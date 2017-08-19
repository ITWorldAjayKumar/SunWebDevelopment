<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_ThyroidProfileDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_ThyroidProfileDE" %>

<%@ Register Src="~/UserControls/ucThyroidProfileDE.ascx" TagPrefix="uc1" TagName="ucThyroidProfileDE" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucThyroidProfileDE runat="server" id="ucThyroidProfileDE" />
</asp:Content>

