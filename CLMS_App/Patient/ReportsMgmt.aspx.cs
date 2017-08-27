using DataContract;
using DataLayer;
using DataLayer.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLMS_App.Patient
{
    public partial class ReportsMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region BloodCount Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_BloodCountReports> GetBloodCount(string _patientID)
        {

            DL_BloodCountReports _objDL = new DL_BloodCountReports();
            List<DC_BloodCountReports> data = _objDL.GetBloodCountReports(new DC_BloodCountReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Bone Profile Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_BoneProfileReports> GetBoneProfile(string _patientID)
        {

            DL_BoneProfileReports _objDL = new DL_BoneProfileReports();
            List<DC_BoneProfileReports> data = _objDL.GetBoneProfileReports(new DC_BoneProfileReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Diabetes Report
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_DiabetesReports> GetDiabetes(string _patientID)
        {

            DL_DiabetesReports _objDL = new DL_DiabetesReports();
            List<DC_DiabetesReports> data = _objDL.GetDiabetesReports(new DC_DiabetesReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Electrolytes Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_ElectrolytesReports> GetElectrolytes(string _patientID)
        {

            DL_ElectrolytesReports _objDL = new DL_ElectrolytesReports();
            List<DC_ElectrolytesReports> data = _objDL.GetElectrolytesReports(new DC_ElectrolytesReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Kidney Functions Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_KidneyFunctionsReports> GetKidneyFunction(string _patientID)
        {

            DL_KidneyFunReports _objDL = new DL_KidneyFunReports();
            List<DC_KidneyFunctionsReports> data = _objDL.GetKidneyFunctionsReports(new DC_KidneyFunctionsReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Lipid Profile Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_LipidProfileReports> GetLipidProfile(string _patientID)
        {

            DL_LipidProfileReports _objDL = new DL_LipidProfileReports();
            List<DC_LipidProfileReports> data = _objDL.GetLipidProfileReports(new DC_LipidProfileReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Liver Function Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_LiverFunctionReports> GetLiverFun(string _patientID)
        {

            DL_LiverFunReports _objDL = new DL_LiverFunReports();
            List<DC_LiverFunctionReports> data = _objDL.GetLiverFunReports(new DC_LiverFunctionReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region Thyroid Profile Reports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_ThyroidProfileReports> GetThyroidProfile(string _patientID)
        {

            DL_ThyroidProfileReports _objDL = new DL_ThyroidProfileReports();
            List<DC_ThyroidProfileReports> data = _objDL.GetThyroidProfileReports(new DC_ThyroidProfileReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region UnineReport
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_UrineReports> GetUnineReport(string _patientID)
        {

            DL_UrineReports _objDL = new DL_UrineReports();
            List<DC_UrineReports> data = _objDL.GetUrineReports(new DC_UrineReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
        #region VitalSignsReports
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_VitalSignsReports> GetVitalSign(string _patientID)
        {

            DL_VitalSignsReports _objDL = new DL_VitalSignsReports();
            List<DC_VitalSignsReports> data = _objDL.GetVitalSingsReports(new DC_VitalSignsReports_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
        #endregion
    }
}