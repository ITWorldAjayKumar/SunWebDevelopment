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
    public partial class ucDiabetesDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_DiabetesReports _objDL = new DL_DiabetesReports();
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
                    var result = _objDL.GetDiabetesReports(new DC_DiabetesReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwDiabetesRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwDiabetesRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwDiabetesRptDetails.PageIndex = intPageIndex;
                    grdvwDiabetesRptDetails.PageSize = intPageSize;
                    grdvwDiabetesRptDetails.DataBind();
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
                frmvwAddUpdateDiabetes.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateDiabetes.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateDiabetes_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtTestDate = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtTestDate");
            TextBox txtFBS = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtFBS");
            TextBox txtPPBS = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtPPBS");
            TextBox txtHBAIC = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtHBAIC");

            if (e.CommandName == "AddDiabetes")
            {
                DC_Message _msg = new DC_Message();
                DC_DiabetesReports _objAdd = new DC_DiabetesReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.FBS = txtFBS.Text;
                _objAdd.PPBS = txtPPBS.Text;
                _objAdd.HBAIC = txtHBAIC.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateDiabetesReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateDiabetes.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateDiabetes")
            {
                DC_Message _msg = new DC_Message();
                DC_DiabetesReports _objAdd = new DC_DiabetesReports();
                _objAdd.DIR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateDiabetes.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.FBS = txtFBS.Text;
                _objAdd.PPBS = txtPPBS.Text;
                _objAdd.HBAIC = txtHBAIC.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateDiabetesReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateDiabetes.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }

        }


        protected void grdvwDiabetesRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwDiabetesRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateDiabetes.ChangeMode(FormViewMode.Edit);
                Guid DIR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetDiabetesReports(new DC_DiabetesReports_Search() { DIR_TestReportID = DIR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateDiabetes.DataSource = result;
                    frmvwAddUpdateDiabetes.DataBind();

                    TextBox txtTestDate = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtTestDate");
                    TextBox txtFBS = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtFBS");
                    TextBox txtPPBS = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtPPBS");
                    TextBox txtHBAIC = (TextBox)frmvwAddUpdateDiabetes.FindControl("txtHBAIC");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtFBS.Text = Convert.ToString(result[0].FBS);
                    txtPPBS.Text = result[0].PPBS;
                    txtHBAIC.Text = result[0].HBAIC;
                }

            }

        }


    }
}