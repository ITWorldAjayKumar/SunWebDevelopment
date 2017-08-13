<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDiabetesReports.ascx.cs" Inherits="CLMS_App.UserControls.ucDiabetesReports" %>
<%--<script src="../js/jquery.js"></script>
<script src="../js/HighCharts/highcharts.js"></script>
<script src="../js/HighCharts/exporting.js"></script>--%>
<style>
    #line-chart {
        height: 400px;
    }

    #container {
        min-width: 310px;
        max-width: 800px;
        height: 400px;
        margin: 0 auto;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {


        function DrawLineChart() {
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
                success: OnSuccess,
                error: function (response) {
                    alert(response.d);
                }
            });

        }
        DrawLineChart();
    });
    function DrawLine(resultData) {
        //var _data = "{name : 'BP',";
        //_data = _data + "data: [";
        var dataArrayBP = [];
        var dataArrayWeight = [];

        var dataArrayPluse = [];

        var dataArrayTemperature = [];

        var dataArrayXaxis = [];

        for (var i = 0; i < resultData.length; i++) {
            dataArrayBP.push(parseInt(resultData[i].BP));
            dataArrayWeight.push(parseInt(resultData[i].Weight));
            dataArrayPluse.push(parseInt(resultData[i].Pluse));
            dataArrayTemperature.push(parseInt(resultData[i].Temperature));
            dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
        }

        for (var i = 0; i < resultData.length; i++) {
            dataArrayBP.push(parseInt(resultData[i].BP));
            dataArrayWeight.push(parseInt(resultData[i].Weight));
            dataArrayPluse.push(parseInt(resultData[i].Pluse));
            dataArrayTemperature.push(parseInt(resultData[i].Temperature));
            dataArrayXaxis.push(new Date(parseInt(resultData[i].TestDate.split('(')[1].split(')')[0])).toDateString());
        }


        Highcharts.chart('container', {

            title: {
                text: resultData[0].PatientName + "- Vital Sign Report"
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

            //plotOptions: {
            //    series: {
            //        pointStart: 2010
            //    }
            //},

            series: [{
                name: 'BP',
                data: dataArrayBP
            },
            {
                name: 'Weight',
                data: dataArrayWeight
            },
            {
                name: 'Pluse',
                data: dataArrayPluse
            },
            {
                name: 'Temperature',
                data: dataArrayTemperature
            }]


            //finalresultdata // [{ name: 'BP', data: [98, 99, 100, 97] }, { name: 'Weight', data: [52, 50, 49, 53] }, { name: 'Pluse', data: [70, 72, 69, 75] }, { name: 'Temperature', data: [97.7, 100, 80, 85] }]
            //            [{ name: 'BP', data: [98, 99, 100, 97] }, { name: 'Weight', data: [52, 50, 49, 53] }, { name: 'Pluse', data: [70, 72, 69, 75] }, { name: 'Temperature', data: [97.7, 100, 80, 85] }]
            //[{ name: 'BP', data: [98, 99, 100, 97] }, { name: 'Weight', data: [52, 50, 49, 53] }, { name: 'Pluse', data: [70, 72, 69, 75] }, { name: 'Temperature', data: [97.7, 100, 80, 85] }]
            //["{name : 'BP',data: [98,99,100,97 ]}", "{name : 'Weight',data: [52,50,49,53 ]}", "{name : 'Pluse',data: [70,72,69,75 ]}", "{name : 'Temperature',data: [97.7,100,80,85 ]} "]
        });
    }
    function OnSuccess(response) {
        var result = response.d;
        DrawLine(result);
    }
</script>
<div id="container"></div>
