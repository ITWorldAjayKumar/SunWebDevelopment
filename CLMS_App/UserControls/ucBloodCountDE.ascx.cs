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
    public partial class ucBloodCountDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_BloodCountReports _objDL = new DL_BloodCountReports();
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
                    var result = _objDL.GetBloodCountReports(new DC_BloodCountReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwBloodCountRptDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwBloodCountRptDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwBloodCountRptDetails.PageIndex = intPageIndex;
                    grdvwBloodCountRptDetails.PageSize = intPageSize;
                    grdvwBloodCountRptDetails.DataBind();
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
                List<DC_BloodCountReports> _lstDC_BloodCountReports = new List<DC_BloodCountReports>();
                DC_BloodCountReports _objvsr = new DC_BloodCountReports();
                _lstDC_BloodCountReports.Add(_objvsr);
                frmvwAddUpdateBloodCount.DataSource = _lstDC_BloodCountReports;
                frmvwAddUpdateBloodCount.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

                 

        

        protected void frmvwAddUpdateBloodCount_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtTestDate = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtTestDate");
            TextBox txtCBC = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtCBC");
            TextBox txtWBC = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtWBC");
            TextBox txtPLATELET = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtPLATELET");
            TextBox txtMCV = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtMCV");
            TextBox txtNeutrophils = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtNeutrophils");
            TextBox txtLymphocytes = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtLymphocytes");
            TextBox txtEosinophil = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtEosinophil");
            TextBox txtMonocytes = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtMonocytes");
            TextBox txtBasophils = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtBasophils");
            TextBox txtESR = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtESR");

            if (e.CommandName == "AddBloodCount")
            {
                DC_Message _msg = new DC_Message();
                DC_BloodCountReports _objAdd = new DC_BloodCountReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.CBC = txtCBC.Text;
                _objAdd.WBC = txtWBC.Text;
                _objAdd.PLATELET = txtPLATELET.Text;
                _objAdd.MCV = txtMCV.Text;
                _objAdd.Neutrophils = txtNeutrophils.Text;
                _objAdd.Lymphocytes = txtLymphocytes.Text;
                _objAdd.Eosinophil = txtEosinophil.Text;
                _objAdd.Monocytes = txtMonocytes.Text;
                _objAdd.Basophils = txtBasophils.Text;
                _objAdd.ESR = txtESR.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateBloodCountReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateBloodCount.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateBloodCount")
            {
                DC_Message _msg = new DC_Message();
                DC_BloodCountReports _objAdd = new DC_BloodCountReports();
                _objAdd.BCR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateBloodCount.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.CBC = txtCBC.Text;
                _objAdd.WBC = txtWBC.Text;
                _objAdd.PLATELET = txtPLATELET.Text;
                _objAdd.MCV = txtMCV.Text;
                _objAdd.Neutrophils = txtNeutrophils.Text;
                _objAdd.Lymphocytes = txtLymphocytes.Text;
                _objAdd.Eosinophil = txtEosinophil.Text;
                _objAdd.Monocytes = txtMonocytes.Text;
                _objAdd.Basophils = txtBasophils.Text;
                _objAdd.ESR = txtESR.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateBloodCountReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateBloodCount.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
        }

        protected void grdvwBloodCountRptDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwBloodCountRptDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateBloodCount.ChangeMode(FormViewMode.Edit);
                Guid BCR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetBloodCountReports(new DC_BloodCountReports_Search() { BCR_TestReportID = BCR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateBloodCount.DataSource = result;
                    frmvwAddUpdateBloodCount.DataBind();
                    TextBox txtTestDate = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtTestDate");
                    TextBox txtCBC = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtCBC");
                    TextBox txtWBC = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtWBC");
                    TextBox txtPLATELET = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtPLATELET");
                    TextBox txtMCV = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtMCV");
                    TextBox txtNeutrophils = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtNeutrophils");
                    TextBox txtLymphocytes = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtLymphocytes");
                    TextBox txtEosinophil = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtEosinophil");
                    TextBox txtMonocytes = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtMonocytes");
                    TextBox txtBasophils = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtBasophils");
                    TextBox txtESR = (TextBox)frmvwAddUpdateBloodCount.FindControl("txtESR");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtCBC.Text = result[0].CBC;
                    txtWBC.Text = result[0].WBC;
                    txtPLATELET.Text = result[0].PLATELET;
                    txtMCV.Text = result[0].MCV;
                    txtNeutrophils.Text = result[0].Neutrophils;
                    txtLymphocytes.Text = result[0].Lymphocytes;
                    txtEosinophil.Text = result[0].Eosinophil;
                    txtMonocytes.Text = result[0].Monocytes;
                    txtBasophils.Text = result[0].Basophils;
                    txtESR.Text = result[0].ESR;
                   
                }

            }

        }
    }
}