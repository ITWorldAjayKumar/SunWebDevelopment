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
    public partial class ucThyroidProfileDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_VitalSignsReports _objDL = new DL_VitalSignsReports();
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
                    var result = _objDL.GetVitalSingsReports(new DC_VitalSignsReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwVitalSignRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwVitalSignRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwVitalSignRptDetails.PageIndex = intPageIndex;
                    grdvwVitalSignRptDetails.PageSize = intPageSize;
                    grdvwVitalSignRptDetails.DataBind();
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
                List<DC_VitalSignsReports> _lstDC_VitalSignsReports = new List<DC_VitalSignsReports>();
                DC_VitalSignsReports _objvsr = new DC_VitalSignsReports();
                _lstDC_VitalSignsReports.Add(_objvsr);
                frmvwAddUpdateVitalSign.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateVitalSign.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateVitalSign_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtTestDate = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtTestDate");
            TextBox txtPulse = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtPulse");
            TextBox txtWeight = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtWeight");
            TextBox txtSBP = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtSBP");
            TextBox txtDBP = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtDBP");

            if (e.CommandName == "AddVitalSign")
            {
                DC_Message _msg = new DC_Message();
                DC_VitalSignsReports _objAdd = new DC_VitalSignsReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.Pulse = Convert.ToString(txtPulse.Text);
                _objAdd.Weight = txtWeight.Text;
                _objAdd.SBP = txtSBP.Text;
                _objAdd.DBP = txtDBP.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateVitalSingsReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateVitalSign.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateVitalSign")
            {
                DC_Message _msg = new DC_Message();
                DC_VitalSignsReports _objAdd = new DC_VitalSignsReports();
                _objAdd.VSR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateVitalSign.DataKey.Value));
                _objAdd.Pulse = Convert.ToString(txtPulse.Text);
                _objAdd.Weight = txtWeight.Text;
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.SBP = txtSBP.Text;
                _objAdd.DBP = txtDBP.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateVitalSingsReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateVitalSign.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }

        }



        protected void grdvwVitalSignRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwVitalSignRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateVitalSign.ChangeMode(FormViewMode.Edit);
                Guid VSR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetVitalSingsReports(new DC_VitalSignsReports_Search() { VSR_TestReportID = VSR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateVitalSign.DataSource = result;
                    frmvwAddUpdateVitalSign.DataBind();

                    TextBox txtTestDate = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtTestDate");
                    TextBox txtPulse = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtPulse");
                    TextBox txtWeight = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtWeight");
                    TextBox txtSBP = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtSBP");
                    TextBox txtDBP = (TextBox)frmvwAddUpdateVitalSign.FindControl("txtDBP");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtPulse.Text = Convert.ToString(result[0].Pulse);
                    txtWeight.Text = result[0].Weight;
                    txtSBP.Text = result[0].SBP;
                    txtDBP.Text = result[0].DBP;
                }

            }

        }
    }
}