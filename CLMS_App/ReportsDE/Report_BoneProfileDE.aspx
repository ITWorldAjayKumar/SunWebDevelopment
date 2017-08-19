<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report_BoneProfileDE.aspx.cs" Inherits="CLMS_App.ReportsDE.Report_BoneProfileDE" %>

<%@ Register Src="~/UserControls/ucBoneProfileDE.ascx" TagPrefix="uc1" TagName="ucBoneProfileDE" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucBoneProfileDE runat="server" id="ucBoneProfileDE" />
</asp:Content>
