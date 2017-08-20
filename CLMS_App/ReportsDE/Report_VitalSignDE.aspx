<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_VitalSignDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_VitalSignDE" %>

<%@ Register Src="~/UserControls/ucVitalSignDE.ascx" TagPrefix="uc1" TagName="ucVitalSignDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVitalSignDE runat="server" ID="ucVitalSignDE" />
</asp:Content>
