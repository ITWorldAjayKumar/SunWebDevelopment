using DataContract;
using DataLayer;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<DC_VitalSingsDetails> GetVitalSign(string _patientID)
        {

            DL_PatientDetails _objDL = new DL_PatientDetails();
            List<DC_VitalSingsDetails> data = _objDL.GetVitalDetails(new DC_VitalDetails_Search() { PatientID = Guid.Parse(_patientID), PageNo = 0, PageSize = 20 });
            return data;

        }
    }
}