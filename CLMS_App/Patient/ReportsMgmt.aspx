<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsMgmt.aspx.cs" Inherits="CLMS_App.Patient.ReportsMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../js/HighCharts/highcharts.js"></script>
    <script src="../js/HighCharts/exporting.js"></script>
    <link href="../css/PanelCollapseToggal.css" rel="stylesheet" />
    <script src="../js/PanelCollapseToggal.js"></script>
    <style>
        #container {
            min-width: 310px;
            max-width: 800px;
            height: 400px;
            margin: 0 auto;
        }
    </style>
    <div class="panel-group" id="accordionBloodCount" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="BloodCount">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionBloodCount" href="#collapseOneBloodCount" aria-expanded="true" aria-controls="collapseOneBloodCount">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Blood Count Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneBloodCount" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerBloodCount"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionBoneProfile" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOneBoneProfile">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionBoneProfile" href="#collapseOneBoneProfile" aria-expanded="true" aria-controls="collapseOneBoneProfile">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Bone Profile Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneBoneProfile" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerBoneProfile"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionDiabetes" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOneDiabetes">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionDiabetes" href="#collapseOneDiabetes" aria-expanded="true" aria-controls="collapseOneDiabetes">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Diabetes Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneDiabetes" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerDiabetes"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionElectrolytes" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="Electrolytes">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionElectrolytes" href="#collapseOneElectrolytes" aria-expanded="true" aria-controls="collapseOneElectrolytes">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Electrolytes Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneElectrolytes" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerElectrolytes"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionKidneyFunction" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOneKidneyFunction">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionKidneyFunction" href="#collapseOneKidneyFunction" aria-expanded="true" aria-controls="collapseOneKidneyFunction">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Kidney Function Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneKidneyFunction" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerKidneyFunction"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionLipidProfile" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOneLipidProfile">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionLipidProfile" href="#collapseOneLipidProfile" aria-expanded="true" aria-controls="collapseOneLipidProfile">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Lipid Profile Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneLipidProfile" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerLipidProfile"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionLiverFunction" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="LiverFunction">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionLiverFunction" href="#collapseOneLiverFunction" aria-expanded="true" aria-controls="collapseOneLiverFunction">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Liver Function Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneLiverFunction" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerLiverFunction"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionThyroidProfile" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="ThyroidProfile">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionThyroidProfile" href="#collapseOneThyroidProfile" aria-expanded="true" aria-controls="collapseOneThyroidProfile">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Thyroid Profile Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneThyroidProfile" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerThyroidProfile"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionUrine" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="Urine">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionUrine" href="#collapseOneUrine" aria-expanded="true" aria-controls="collapseOneUrine">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Urine Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneUrine" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerUrine"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-group" id="accordionVitalSign" role="tablist" aria-multiselectable="true">

        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="VitalSign">
                <h4 class="panel-title">
                    <a role="button" data-toggle="collapse" data-parent="#accordionVitalSign" href="#collapseOneVitalSign" aria-expanded="true" aria-controls="collapseOneVitalSign">
                        <i class="more-less glyphicon glyphicon-plus"></i>
                        Vital Sign Report
                    </a>
                </h4>
            </div>
            <div id="collapseOneVitalSign" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <div id="containerVitalSign"></div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {

            //Ajax Call to PageMethods
            function DrawBloodCount() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetBloodCount",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessBloodCount,
                    error: function (response) {
                        alert(response.d);
                    }
                });

            }
            function DrawBoneProfile() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetBoneProfile",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessBoneProfile,
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }
            function DrawDiabetes() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetDiabetes",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessDiabetes,
                    error: function (response) {
                        alert(response.d);
                    }
                });


            }
            function DrawElectrolytes() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetElectrolytes",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessElectrolytes,
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }
            function DrawKidneyFunction() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetKidneyFunction",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessKidneyFunction,
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }
            function DrawLipidProfile() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetLipidProfile",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessLipidProfile,
                    error: function (response) {
                        alert(response.d);
                    }
                });

            }
            function DrawLiverFunction() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetLiverFun",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessLiverFunction,
                    error: function (response) {
                        alert(response.d);
                    }
                });

            }
            function DrawThyroidProfile() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetThyroidProfile",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessThyroidProfile,
                    error: function (response) {
                        alert(response.d);
                    }
                });


            }
            function DrawUrine() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetUnineReport",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessUrine,
                    error: function (response) {
                        alert(response.d);
                    }
                });

            }
            function DrawVitalSign() {
                debugger;
                var value = $(location).attr('search').toString().split('=')[1];
                var obj = {
                    'PatientID': value,
                    'PageNo': '0',
                    'PageSize': '20'
                };
                $.ajax({
                    type: "POST",
                    url: "ReportsMgmt.aspx/GetVitalSign",
                    //data: JSON.stringify({ '_patientID': 'ADC54555-2E38-47FC-A37A-7D5DE133D6F2' }),
                    data: JSON.stringify({ '_patientID': value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessVitalSign,
                    error: function (response) {
                        alert(response.d);
                    }
                });

            }

            //Call AllFunction to call Ajax 
            DrawBloodCount();
            DrawBoneProfile();
            DrawDiabetes();
            DrawElectrolytes();
            DrawKidneyFunction(); DrawLipidProfile(); DrawLiverFunction();
            DrawThyroidProfile(); DrawUrine();
            DrawVitalSign();

        });

        function DrawLineBloodCount(resultData) {
            debugger;
            var dataArrayCBC = []; var dataArrayWBC = []; var dataArrayPLATELET = [];
            var dataArrayNeutrophils = []; var dataArrayLymphocytes = []; var dataArrayEosinophil = [];
            var dataArrayMonocytes = []; var dataArrayBasophils = []; var dataArrayESR = [];

            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayCBC.push(parseInt(resultData[i].CBC));
                dataArrayWBC.push(parseInt(resultData[i].WBC));
                dataArrayPLATELET.push(parseInt(resultData[i].PLATELET));
                dataArrayNeutrophils.push(parseInt(resultData[i].Neutrophils));
                dataArrayLymphocytes.push(parseInt(resultData[i].Lymphocytes));
                dataArrayEosinophil.push(parseInt(resultData[i].Eosinophil));
                dataArrayMonocytes.push(parseInt(resultData[i].Monocytes));
                dataArrayBasophils.push(parseInt(resultData[i].Basophils));
                dataArrayESR.push(parseInt(resultData[i].ESR));
                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }
            debugger;
            Highcharts.chart('containerBloodCount', {

                title: {
                    //text: resultData[0].PatientName + "- BloodCount Report"
                    text: "BloodCount Report"

                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'CBC',
                    data: dataArrayCBC
                },
                {
                    name: 'WBC',
                    data: dataArrayWBC
                },
                {
                    name: 'PLATELET',
                    data: dataArrayPLATELET
                },
                {
                    name: 'Neutrophils',
                    data: dataArrayNeutrophils
                },
                {
                    name: 'Lymphocytes',
                    data: dataArrayLymphocytes
                },
                {
                    name: 'Eosinophil',
                    data: dataArrayEosinophil
                },
                {
                    name: 'Monocytes',
                    data: dataArrayMonocytes
                },
                {
                    name: 'Basophils',
                    data: dataArrayBasophils
                },
                {
                    name: 'ESR',
                    data: dataArrayESR
                }]
            });
        }
        function DrawLineBoneProfile(resultData) {
            var dataArrayVitaminD = [];
            var dataArrayParathyroidHormone = [];
            var dataArrayCalcium = [];
            var dataArrayMagnesium = [];
            var dataArrayNeutrophils = [];


            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayVitaminD.push(parseInt(resultData[i].VitaminD));
                dataArrayParathyroidHormone.push(parseInt(resultData[i].ParathyroidHormone));
                dataArrayCalcium.push(parseInt(resultData[i].Calcium));
                dataArrayMagnesium.push(parseInt(resultData[i].Magnesium));
                dataArrayNeutrophils.push(parseInt(resultData[i].Neutrophils));


                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerBoneProfile', {

                title: {
                    text: "BoneProfile Report"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'VitaminD',
                    data: dataArrayVitaminD
                },
                {
                    name: 'ParathyroidHormone',
                    data: dataArrayParathyroidHormone
                },
                {
                    name: 'Calcium',
                    data: dataArrayCalcium
                },
                {
                    name: 'Magnesium',
                    data: dataArrayMagnesium
                },
                {
                    name: 'Neutrophils',
                    data: dataArrayNeutrophils
                }]
            });
        }
        function DrawLineDiabetes(resultData) {
            var dataArrayFBS = [];
            var dataArrayPPBS = [];
            var dataArrayHBAIC = [];

            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayFBS.push(parseInt(resultData[i].FBS));
                dataArrayPPBS.push(parseInt(resultData[i].PPBS));
                dataArrayHBAIC.push(parseInt(resultData[i].HBAIC));
                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }
            debugger;
            Highcharts.chart('containerDiabetes', {

                title: {
                    text: resultData[0].PatientName + "- Diabetes Report - Diabetes"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },



                series: [{
                    name: 'FBS',
                    data: dataArrayFBS
                },
                {
                    name: 'PPBS',
                    data: dataArrayPPBS
                },
                {
                    name: 'HBAIC',
                    data: dataArrayHBAIC
                }]
            });
        }
        function DrawLineElectrolytes(resultData) {

            var dataArraySodium = [];
            var dataArrayPotassium = [];
            var dataArrayChloride = [];

            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArraySodium.push(parseInt(resultData[i].Sodium));
                dataArrayPotassium.push(parseInt(resultData[i].Potassium));
                dataArrayChloride.push(parseInt(resultData[i].Chloride));
                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerElectrolytes', {

                title: {
                    text: " Electrolytes Report"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'Sodium',
                    data: dataArraySodium
                },
                {
                    name: 'Potassium',
                    data: dataArrayPotassium
                },
                {
                    name: 'Chloride',
                    data: dataArrayChloride
                }]
            });
        }
        function DrawLineKidneyFunction(resultData) {
            var dataArraySCreatinine = [];
            var dataArrayUrineACR = [];
            var dataArrayUrea = [];
            var dataArrayBun = [];
            var dataArraySUricAcid = [];


            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArraySCreatinine.push(parseInt(resultData[i].SCreatinine));
                dataArrayUrineACR.push(parseInt(resultData[i].UrineACR));
                dataArrayUrea.push(parseInt(resultData[i].Urea));
                dataArrayBun.push(parseInt(resultData[i].Bun));
                dataArraySUricAcid.push(parseInt(resultData[i].SUricAcid));

                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerKidneyFunction', {

                title: {
                    text: resultData[0].PatientName + "- Vital Sign Report - Vital Sign"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },



                series: [{
                    name: 'SCreatinine',
                    data: dataArraySCreatinine
                },
                {
                    name: 'UrineACR',
                    data: dataArrayUrineACR
                },
                {
                    name: 'Urea',
                    data: dataArrayUrea
                },
                {
                    name: 'SUricAcid',
                    data: dataArraySUricAcid
                }]
            });
        }
        function DrawLineLipidProfile(resultData) {

            var dataArrayTChol = [];
            var dataArrayTriglycerides = [];
            var dataArrayHDLChol = [];
            var dataArrayLDLChol = [];
            var dataArrayTCholHDL = [];
            var dataArrayLDLHDLRatio = [];


            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayTChol.push(parseInt(resultData[i].TChol));
                dataArrayTriglycerides.push(parseInt(resultData[i].Triglycerides));
                dataArrayHDLChol.push(parseInt(resultData[i].HDLChol));
                dataArrayLDLChol.push(parseInt(resultData[i].LDLChol));
                dataArrayTCholHDL.push(parseInt(resultData[i].TCholHDL));
                dataArrayLDLHDLRatio.push(parseInt(resultData[i].LDLHDLRatio));

                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerLipidProfile', {

                title: {
                    text: resultData[0].PatientName + "- Lipid Profile Report"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },



                series: [{
                    name: 'TChol',
                    data: dataArrayTChol
                },
                {
                    name: 'Triglycerides',
                    data: dataArrayTriglycerides
                },
                {
                    name: 'HDLChol',
                    data: dataArrayHDLChol
                },
                {
                    name: 'LDLChol',
                    data: dataArrayLDLChol
                },
                {
                    name: 'TCholHDL',
                    data: dataArrayTCholHDL
                },
                {
                    name: 'LDLHDLRatio',
                    data: dataArrayLDLHDLRatio
                }]
            });
        }
        function DrawLineLiverFunction(resultData) {

            var dataArraySBilirubin = [];
            var dataArraySGOT = [];
            var dataArraySGPT = [];
            var dataArrayGGT = [];
            var dataArraySAlkPhosphate = [];
            var dataArraySProtein = [];
            var dataArrayAlbumin = [];
            var dataArrayGlobulin = [];
            var dataArrayAGRatio = [];


            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArraySBilirubin.push(parseInt(resultData[i].SBilirubin));
                dataArraySGOT.push(parseInt(resultData[i].SGOT));
                dataArraySGPT.push(parseInt(resultData[i].SGPT));
                dataArrayGGT.push(parseInt(resultData[i].GGT));
                dataArraySAlkPhosphate.push(parseInt(resultData[i].SAlkPhosphate));
                dataArraySProtein.push(parseInt(resultData[i].SProtein));
                dataArrayAlbumin.push(parseInt(resultData[i].Albumin));
                dataArrayGlobulin.push(parseInt(resultData[i].Globulin));
                dataArrayAGRatio.push(parseInt(resultData[i].AGRatio));

                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerLiverFunction', {

                title: {
                    text: resultData[0].PatientName + "- Liver Function Report"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                series: [{
                    name: 'SBilirubin',
                    data: dataArraySBilirubin
                },
                {
                    name: 'SGOT',
                    data: dataArraySGOT
                },
                {
                    name: 'SGPT',
                    data: dataArraySGPT
                },
                {
                    name: 'GGT',
                    data: dataArrayGGT
                },
                {
                    name: 'SAlkPhosphate',
                    data: dataArraySAlkPhosphate
                },
                {
                    name: 'SProtein',
                    data: dataArraySProtein
                },
                {
                    name: 'Albumin',
                    data: dataArrayAlbumin
                },
                {
                    name: 'Globulin',
                    data: dataArrayGlobulin
                },
                {
                    name: 'AGRatio',
                    data: dataArrayAGRatio
                }]
            });
        }
        function DrawLineThyroidProfile(resultData) {
            var dataArrayFreeT3 = [];
            var dataArrayFreeT4 = [];
            var dataArrayTSH = [];

            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayFreeT3.push(parseInt(resultData[i].FreeT3));
                dataArrayFreeT4.push(parseInt(resultData[i].FreeT4));
                dataArrayTSH.push(parseInt(resultData[i].TSH));
                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerThyroidProfile', {

                title: {
                    text: resultData[0].PatientName + "- TSH Report "
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },



                series: [{
                    name: 'FreeT3',
                    data: dataArrayFreeT3
                },
                {
                    name: 'FreeT4',
                    data: dataArrayFreeT4
                },
                {
                    name: 'TSH',
                    data: dataArrayTSH
                }]
            });
        }
        function DrawLineUrine(resultData) {

            var dataArrayAlbumin = [];
            var dataArrayCreatine = [];
            var dataArrayACR = [];



            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArrayAlbumin.push(parseInt(resultData[i].Albumin));
                dataArrayCreatine.push(parseInt(resultData[i].Creatine));
                dataArrayACR.push(parseInt(resultData[i].ACR));


                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerUrine', {

                title: {
                    text: resultData[0].PatientName + "- Urine Report "
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },



                series: [{
                    name: 'Albumin',
                    data: dataArrayAlbumin
                },
                {
                    name: 'Creatine',
                    data: dataArrayCreatine
                },
                {
                    name: 'ACR',
                    data: dataArrayACR
                }]
            });
        }
        function DrawLineVitalSign(resultData) {

            var dataArraySBP = [];
            var dataArrayDBP = [];
            var dataArrayWeight = [];
            var dataArrayPulse = [];

            var dataArrayXaxis = [];

            for (var i = 0; i < resultData.length; i++) {
                dataArraySBP.push(parseInt(resultData[i].SBP));
                dataArrayDBP.push(parseInt(resultData[i].DBP));
                dataArrayWeight.push(parseInt(resultData[i].Weight));
                dataArrayPulse.push(parseInt(resultData[i].Pulse));
                dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
            }

            Highcharts.chart('containerVitalSign', {

                title: {
                    text: resultData[0].PatientName + "- Vital Sign Report - Vital Sign"
                },

                subtitle: {
                    text: 'Source: By IT World '
                },
                xAxis: {
                    categories: dataArrayXaxis
                },
                yAxis: {
                    title: {
                        text: 'Measurement'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'SBP',
                    data: dataArraySBP
                },
                {
                    name: 'DBP',
                    data: dataArrayDBP
                },
                {
                    name: 'Weight',
                    data: dataArrayWeight
                },
                {
                    name: 'Pulse',
                    data: dataArrayPulse
                }]
            });
        }


        function OnSuccessBloodCount(response) {
            debugger;
            var result = response.d;
            DrawLineBloodCount(result);
        }
        function OnSuccessBoneProfile(response) {
            var result = response.d;
            DrawLineBoneProfile(result);
        }
        function OnSuccessDiabetes(response) {
            var result = response.d;
            DrawLineDiabetes(result)
        }
        function OnSuccessElectrolytes(response) {
            var result = response.d;
            DrawLineElectrolytes(result);
        }
        function OnSuccessKidneyFunction(response) {
            var result = response.d;
            DrawLineKidneyFunction(result)
        }
        function OnSuccessLipidProfile(response) {
            var result = response.d;
            DrawLineLipidProfile(result);
        }
        function OnSuccessLiverFunction(response) {
            var result = response.d;
            DrawLineLiverFunction(result);
        }
        function OnSuccessThyroidProfile(response) {
            var result = response.d;
            DrawLineThyroidProfile(result)
        }
        function OnSuccessUrine(response) {
            var result = response.d;
            DrawLineUrine(result);
        }
        function OnSuccessVitalSign(response) {
            var result = response.d;
            DrawLineVitalSign(result);
        }

    </script>
</asp:Content>

