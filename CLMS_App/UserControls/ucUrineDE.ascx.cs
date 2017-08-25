using CLMS_App.App_Code;
using DataContract;
using DataContracts;
using DataLayer.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLMS_App.UserControls
{
    public partial class ucUrineDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_UrineReports _objDL = new DL_UrineReports();
        public static int intPageSize = 3;
        public static int intPageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFormView();
                BindGridDetails();
            }
        }

        public Guid GetPatientID()
        {
            string strPtId = Convert.ToString(Request.QueryString["PatientID"]);
            _patientId = !string.IsNullOrWhiteSpace(strPtId) ? Guid.Parse(strPtId) : Guid.Empty;
            return _patientId;
        }

        private void BindGridDetails()
        {
            try
            {
                if (GetPatientID() != Guid.Empty)
                {
                    var result = _objDL.GetUrineReports(new DC_UrineReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwUrinProfileDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwUrinProfileDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwUrinProfileDetails.PageIndex = intPageIndex;
                    grdvwUrinProfileDetails.PageSize = intPageSize;
                    grdvwUrinProfileDetails.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindFormView()
        {
            try
            {
                List<DC_UrineReports> _lstDC_VitalSignsReports = new List<DC_UrineReports>();
                DC_UrineReports _objvsr = new DC_UrineReports();
                _lstDC_VitalSignsReports.Add(_objvsr);
                grdvwUrinProfileDetails.DataSource = _lstDC_VitalSignsReports;
                grdvwUrinProfileDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

   


      

        protected void frmvwAddUpdateUrineDEVitalSign_ItemCommand(object sender, FormViewCommandEventArgs e)
        {

            TextBox txtTestDate = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtTestDate");
            TextBox txtAlbumin = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtAlbumin");
            TextBox txtCreatine = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtCreatine");
            TextBox txtACR = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtACR");
            //TextBox txtDBP = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtDBP");

            if (e.CommandName == "AddUrinProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_UrineReports _objAdd = new DC_UrineReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.Albumin = Convert.ToString(txtAlbumin.Text);
                _objAdd.Creatine = txtCreatine.Text;
                _objAdd.ACR = txtACR.Text;
                //  _objAdd.DBP = txtDBP.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateUrineReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateUrineDEVitalSign.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateUrinProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_UrineReports _objAdd = new DC_UrineReports();
                _objAdd.UR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateUrineDEVitalSign.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.Albumin = Convert.ToString(txtAlbumin.Text);
                _objAdd.Creatine = txtCreatine.Text;
                _objAdd.ACR = txtACR.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateUrineReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateUrineDEVitalSign.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
        }

        protected void grdvwUrinProfileDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwUrinProfileDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateUrineDEVitalSign.ChangeMode(FormViewMode.Edit);
                Guid UR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetUrineReports(new DC_UrineReports_Search() { UR_TestReportID = UR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateUrineDEVitalSign.DataSource = result;
                    frmvwAddUpdateUrineDEVitalSign.DataBind();

                   
                    TextBox txtTestDate = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtTestDate");
                    TextBox txtAlbumin = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtAlbumin");
                    TextBox txtCreatine = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtCreatine");
                    TextBox txtACR = (TextBox)frmvwAddUpdateUrineDEVitalSign.FindControl("txtACR");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtAlbumin.Text = result[0].Albumin;
                    txtCreatine.Text = result[0].Creatine;
                    txtACR.Text = result[0].ACR;

                }

            }
        }
    }
}