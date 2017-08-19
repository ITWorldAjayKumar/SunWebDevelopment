<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_KidneyFunDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_KidneyFunDE" %>

<%@ Register Src="~/UserControls/ucKidneyFunDE.ascx" TagPrefix="uc1" TagName="ucKidneyFunDE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucKidneyFunDE runat="server" id="ucKidneyFunDE" />
</asp:Content>
