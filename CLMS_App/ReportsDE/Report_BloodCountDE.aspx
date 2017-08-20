<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_BloodCountDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_BloodCountDE" %>

<%@ Register Src="~/UserControls/ucBloodCountDE.ascx" TagPrefix="uc1" TagName="ucBloodCountDE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucBloodCountDE runat="server" id="ucBloodCountDE" />
</asp:Content>
