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
        DL_ThyroidProfileReports _objDL = new DL_ThyroidProfileReports();
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
                    var result = _objDL.GetThyroidProfileReports(new DC_ThyroidProfileReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwThyroidProfileDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwThyroidProfileDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwThyroidProfileDetails.PageIndex = intPageIndex;
                    grdvwThyroidProfileDetails.PageSize = intPageSize;
                    grdvwThyroidProfileDetails.DataBind();
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
                List<DC_ThyroidProfileReports> _lstDC_VitalSignsReports = new List<DC_ThyroidProfileReports>();
                DC_ThyroidProfileReports _objvsr = new DC_ThyroidProfileReports();
                _lstDC_VitalSignsReports.Add(_objvsr);
                frmvwAddUpdateThyroidProfile.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateThyroidProfile.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateThyroidProfile_ItemCommand(object sender, FormViewCommandEventArgs e)
        {

            TextBox txtTestDate = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtTestDate");
            TextBox txtFreeT3 = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtFreeT3");
            TextBox txtFreeT4 = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtFreeT4");
            TextBox txtTSH = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtTSH");

            if (e.CommandName == "AddThyroidProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_ThyroidProfileReports _objAdd = new DC_ThyroidProfileReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.FreeT3  = txtFreeT3.Text;
                _objAdd.FreeT4 = txtFreeT4.Text;
                _objAdd.TSH = txtTSH.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateThyroidProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateThyroidProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateThyroidProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_ThyroidProfileReports _objAdd = new DC_ThyroidProfileReports();
                _objAdd.TPR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateThyroidProfile.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.FreeT3 = txtFreeT3.Text;
                _objAdd.FreeT4 = txtFreeT4.Text;
                _objAdd.TSH = txtTSH.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateThyroidProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateThyroidProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
        }

        protected void grdvwThyroidProfileDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwThyroidProfileDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateThyroidProfile.ChangeMode(FormViewMode.Edit);
                Guid TPR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetThyroidProfileReports(new DC_ThyroidProfileReports_Search() { TPR_TestReportID = TPR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateThyroidProfile.DataSource = result;
                    frmvwAddUpdateThyroidProfile.DataBind();

                    TextBox txtTestDate = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtTestDate");
                    TextBox txtFreeT3 = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtFreeT3");
                    TextBox txtFreeT4 = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtFreeT4");
                    TextBox txtTSH = (TextBox)frmvwAddUpdateThyroidProfile.FindControl("txtTSH");
                    
                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtFreeT3.Text =result[0].FreeT3;
                    txtFreeT4.Text = result[0].FreeT4;
                    txtTSH.Text = result[0].TSH;
                }

            }

        }
    }
}