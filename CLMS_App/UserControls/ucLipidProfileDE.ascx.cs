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
    public partial class ucLipidProfileDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_LipidProfileReports _objDL = new DL_LipidProfileReports();
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
                    var result = _objDL.GetLipidProfileReports(new DC_LipidProfileReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwLipidProfileRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwLipidProfileRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwLipidProfileRptDetails.PageIndex = intPageIndex;
                    grdvwLipidProfileRptDetails.PageSize = intPageSize;
                    grdvwLipidProfileRptDetails.DataBind();
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
                frmvwAddUpdateLipidProfile.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateLipidProfile.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateLipidProfile_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            #region Controls
            TextBox txtTestDate = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTestDate");
            TextBox txtTChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTChol");
            TextBox txtTriglycerides = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTriglycerides");
            TextBox txtHDLChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtHDLChol");
            TextBox txtLDLChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtLDLChol");
            TextBox txtTCholHDL = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTCholHDL");
            TextBox txtLDLHDLRatio = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtLDLHDLRatio");


            #endregion
            if (e.CommandName == "AddLipidProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_LipidProfileReports _objAdd = new DC_LipidProfileReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.TChol = txtTChol.Text;
                _objAdd.Triglycerides = txtTriglycerides.Text;
                _objAdd.HDLChol = txtHDLChol.Text;
                _objAdd.LDLChol = txtLDLChol.Text;
                _objAdd.TCholHDL = txtTCholHDL.Text;
                _objAdd.LDLHDLRatio = txtLDLHDLRatio.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateLipidProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateLipidProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateLipidProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_LipidProfileReports _objAdd = new DC_LipidProfileReports();
                _objAdd.LPR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateLipidProfile.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.TChol = txtTChol.Text;
                _objAdd.Triglycerides = txtTriglycerides.Text;
                _objAdd.HDLChol = txtHDLChol.Text;
                _objAdd.LDLChol = txtLDLChol.Text;
                _objAdd.TCholHDL = txtTCholHDL.Text;
                _objAdd.LDLHDLRatio = txtLDLHDLRatio.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateLipidProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateLipidProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }

        }



        protected void grdvwLipidProfileRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwLipidProfileRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateLipidProfile.ChangeMode(FormViewMode.Edit);
                Guid LPR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetLipidProfileReports(new DC_LipidProfileReports_Search() {  LPR_TestReportID= LPR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateLipidProfile.DataSource = result;
                    frmvwAddUpdateLipidProfile.DataBind();

                    #region Controls
                    TextBox txtTestDate = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTestDate");
                    TextBox txtTChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTChol");
                    TextBox txtTriglycerides = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTriglycerides");
                    TextBox txtHDLChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtHDLChol");
                    TextBox txtLDLChol = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtLDLChol");
                    TextBox txtTCholHDL = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtTCholHDL");
                    TextBox txtLDLHDLRatio = (TextBox)frmvwAddUpdateLipidProfile.FindControl("txtLDLHDLRatio");
                    #endregion



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtTChol.Text = result[0].TChol;
                    txtTriglycerides.Text = result[0].Triglycerides;
                    txtHDLChol.Text = Convert.ToString(result[0].HDLChol);
                    txtLDLChol.Text = result[0].LDLChol;
                    txtTCholHDL.Text = result[0].TCholHDL;
                    txtLDLHDLRatio.Text = result[0].LDLHDLRatio;


                }

            }

        }

    }
}