<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsMgmt.aspx.cs" Inherits="CLMS_App.Patient.ReportsMgmt" %>

<%@ Register Src="~/UserControls/ucVitalSignReport.ascx" TagPrefix="uc1" TagName="ucVitalSignReport" %>
<%@ Register Src="~/UserControls/ucUrineReports.ascx" TagPrefix="uc2" TagName="ucUrineReports" %>
<%@ Register Src="~/UserControls/ucThyroidProfileReports.ascx" TagPrefix="uc3" TagName="ucThyroidProfileReports" %>
<%@ Register Src="~/UserControls/ucLiverFunctionReports.ascx" TagPrefix="uc4" TagName="ucLiverFunctionReports" %>
<%@ Register Src="~/UserControls/ucLipidProfileReports.ascx" TagPrefix="uc5" TagName="ucLipidProfileReports" %>
<%@ Register Src="~/UserControls/ucKidneyFunctionsReports.ascx" TagPrefix="uc6" TagName="ucKidneyFunctionsReports" %>
<%@ Register Src="~/UserControls/ucElectrolytesReports.ascx" TagPrefix="uc7" TagName="ucElectrolytesReports" %>
<%@ Register Src="~/UserControls/ucDiabetesReports.ascx" TagPrefix="uc8" TagName="ucDiabetesReports" %>
<%@ Register Src="~/UserControls/ucBoneProfileReports.ascx" TagPrefix="uc9" TagName="ucBoneProfileReports" %>
<%@ Register Src="~/UserControls/ucBloodCountReports.ascx" TagPrefix="uc10" TagName="ucBloodCountReports" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../js/HighCharts/highcharts.js"></script>
    <script src="../js/HighCharts/exporting.js"></script>
    <style>
        .chart {
            height: 200px;
        }

        .spacer {
            height: 20px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <div class="row">
        <uc1:ucVitalSignReport runat="server" ID="ucVitalSignReport1" />
    </div>
    <div class="spacer"></div>
    <div class="row">
        <uc2:ucUrineReports runat="server" ID="ucUrineReports1" />
    </div>
    <%--<uc3:ucThyroidProfileReports runat="server" ID="ucThyroidProfileReports1" />
    <uc4:ucLiverFunctionReports runat="server" ID="ucLiverFunctionReports1" />
    <uc5:ucLipidProfileReports runat="server" ID="ucLipidProfileReports1" />
    <uc6:ucKidneyFunctionsReports runat="server" ID="ucKidneyFunctionsReports1" />
    <uc7:ucElectrolytesReports runat="server" ID="ucElectrolytesReports1" />
    <uc8:ucDiabetesReports runat="server" ID="ucDiabetesReports1" />
    <uc9:ucBoneProfileReports runat="server" ID="ucBoneProfileReports1" />
    <uc10:ucBloodCountReports runat="server" ID="ucBloodCountReports1" />--%>
</asp:Content>

