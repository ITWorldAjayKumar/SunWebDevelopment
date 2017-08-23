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
    public partial class ucKidneyFunDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_KidneyFunReports _objDL = new DL_KidneyFunReports();
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
                    var result = _objDL.GetKidneyFunctionsReports(new DC_KidneyFunctionsReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwKidneyFunctionRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwKidneyFunctionRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwKidneyFunctionRptDetails.PageIndex = intPageIndex;
                    grdvwKidneyFunctionRptDetails.PageSize = intPageSize;
                    grdvwKidneyFunctionRptDetails.DataBind();
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
                List<DC_KidneyFunctionsReports> _lstDC_KidneyFunctionsReports = new List<DC_KidneyFunctionsReports>();
                DC_KidneyFunctionsReports _objvsr = new DC_KidneyFunctionsReports();
                _lstDC_KidneyFunctionsReports.Add(_objvsr);
                frmvwAddUpdateKidneyFunction.DataSource = _lstDC_KidneyFunctionsReports;
                frmvwAddUpdateKidneyFunction.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void frmvwAddUpdateKidneyFunction_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtTestDate = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtTestDate");
            TextBox txtSCreatinine = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtSCreatinine");
            TextBox txtUrineACR = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtUrineACR");
            TextBox txtUrea = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtUrea");
            TextBox txtBUN = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtBUN");
            TextBox txtSUricAcid = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtSUricAcid");


            if (e.CommandName == "AddKidneyFunction")
            {
                DC_Message _msg = new DC_Message();
                DC_KidneyFunctionsReports _objAdd = new DC_KidneyFunctionsReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.KFR_TestReportID = Guid.NewGuid();
                _objAdd.PatientID = GetPatientID();
                _objAdd.SCreatinine = txtSCreatinine.Text;
                _objAdd.UrineACR = txtUrineACR.Text;
                _objAdd.Urea = txtUrea.Text;
                _objAdd.Bun = txtBUN.Text;
                _objAdd.SUricAcid = txtSUricAcid.Text;

                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;

                _msg = _objDL.AddUpdateKidneyFunctionsReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateKidneyFunction.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateKidneyFunction")
            {
                DC_Message _msg = new DC_Message();
                DC_KidneyFunctionsReports _objAdd = new DC_KidneyFunctionsReports();
                _objAdd.KFR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateKidneyFunction.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.SCreatinine = txtSCreatinine.Text;
                _objAdd.UrineACR = txtUrineACR.Text;
                _objAdd.Urea = txtUrea.Text;
                _objAdd.Bun = txtBUN.Text;
                _objAdd.SUricAcid = txtSUricAcid.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateKidneyFunctionsReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateKidneyFunction.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
        }

        protected void grdvwKidneyFunctionRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwKidneyFunctionRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateKidneyFunction.ChangeMode(FormViewMode.Edit);
                Guid KFR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetKidneyFunctionsReports(new DC_KidneyFunctionsReports_Search() { KFR_TestReportID = KFR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateKidneyFunction.DataSource = result;
                    frmvwAddUpdateKidneyFunction.DataBind();

                    TextBox txtTestDate = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtTestDate");
                    TextBox txtSCreatinine = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtSCreatinine");
                    TextBox txtUrineACR = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtUrineACR");
                    TextBox txtUrea = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtUrea");
                    TextBox txtBUN = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtBUN");
                    TextBox txtSUricAcid = (TextBox)frmvwAddUpdateKidneyFunction.FindControl("txtSUricAcid");




                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtSCreatinine.Text = result[0].SCreatinine;
                    txtUrineACR.Text = result[0].UrineACR;
                    txtUrea.Text = result[0].Urea;
                    txtBUN.Text = result[0].Bun;
                    txtSUricAcid.Text = result[0].SUricAcid;

                }

            }
        }
    }
}