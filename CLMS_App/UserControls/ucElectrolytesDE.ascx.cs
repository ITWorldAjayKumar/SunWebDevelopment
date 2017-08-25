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
    public partial class ucElectrolytesDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_ElectrolytesReports _objDL = new DL_ElectrolytesReports();
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
                    var result = _objDL.GetElectrolytesReports(new DC_ElectrolytesReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwElectrolytesRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwElectrolytesRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwElectrolytesRptDetails.PageIndex = intPageIndex;
                    grdvwElectrolytesRptDetails.PageSize = intPageSize;
                    grdvwElectrolytesRptDetails.DataBind();
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
                frmvwAddUpdateElectrolytes.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateElectrolytes.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdvwElectrolytesRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();

        }

        protected void grdvwElectrolytesRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateElectrolytes.ChangeMode(FormViewMode.Edit);
                Guid ER_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetElectrolytesReports(new DC_ElectrolytesReports_Search() { ER_TestReportID = ER_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateElectrolytes.DataSource = result;
                    frmvwAddUpdateElectrolytes.DataBind();

                    TextBox txtTestDate = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtTestDate");
                    TextBox txtSodium = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtSodium");
                    TextBox txtPotassium = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtPotassium");
                    TextBox txtChloride = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtChloride");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtSodium.Text = result[0].Sodium;
                    txtChloride.Text = result[0].Potassium;
                    txtPotassium.Text = result[0].Chloride;
                }

            }

        }

        protected void frmvwAddUpdateElectrolytes_ItemCommand(object sender, FormViewCommandEventArgs e)
        {

            TextBox txtTestDate = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtTestDate");
            TextBox txtSodium = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtSodium");
            TextBox txtPotassium = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtPotassium");
            TextBox txtChloride = (TextBox)frmvwAddUpdateElectrolytes.FindControl("txtChloride");

            if (e.CommandName == "AddElectrolyte")
            {
                DC_Message _msg = new DC_Message();
                DC_ElectrolytesReports _objAdd = new DC_ElectrolytesReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.Sodium = txtSodium.Text;
                _objAdd.Potassium = txtPotassium.Text;
                _objAdd.Chloride = txtChloride.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateElectrolytesReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateElectrolytes.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateElectrolyte")
            {
                DC_Message _msg = new DC_Message();
                DC_ElectrolytesReports _objAdd = new DC_ElectrolytesReports();
                _objAdd.ER_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateElectrolytes.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.Sodium = txtSodium.Text;
                _objAdd.Potassium = txtPotassium.Text;
                _objAdd.Chloride = txtChloride.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateElectrolytesReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateElectrolytes.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
        }
    }
}