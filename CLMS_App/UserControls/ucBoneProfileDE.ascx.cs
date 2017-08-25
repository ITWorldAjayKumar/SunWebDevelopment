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
    public partial class ucBoneProfileDE : System.Web.UI.UserControl
    {
        public static Guid _patientId = Guid.Empty;
        DL_BoneProfileReports _objDL = new DL_BoneProfileReports();
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
                    var result = _objDL.GetBoneProfileReports(new DC_BoneProfileReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwBoneProfileDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwBoneProfileDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwBoneProfileDetails.PageSize = intPageSize;
                    grdvwBoneProfileDetails.PageIndex = intPageIndex;
                    grdvwBoneProfileDetails.DataBind();
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
                frmvwAddUpdateBoneProfile.DataSource = _lstDC_VitalSignsReports;
                frmvwAddUpdateBoneProfile.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateBoneProfile_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtTestDate = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtTestDate");
            TextBox txtVitaminD = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtVitaminD");
            TextBox txtParathyroidHormone = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtParathyroidHormone");
            TextBox txtCalcium = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtCalcium");
            TextBox txtMagnesium = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtMagnesium");
            TextBox txtNeutrophils = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtNeutrophils");


            if (e.CommandName == "AddBoneProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_BoneProfileReports _objAdd = new DC_BoneProfileReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.VitaminD = txtVitaminD.Text;
                _objAdd.ParathyroidHormone = txtParathyroidHormone.Text;
                _objAdd.Calcium = txtCalcium.Text;
                _objAdd.Magnesium = txtMagnesium.Text;
                _objAdd.Neutrophils = txtNeutrophils.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateBoneProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateBoneProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateBoneProfile")
            {
                DC_Message _msg = new DC_Message();
                DC_BoneProfileReports _objAdd = new DC_BoneProfileReports();
                _objAdd.BPR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateBoneProfile.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.VitaminD = txtVitaminD.Text;
                _objAdd.ParathyroidHormone = txtParathyroidHormone.Text;
                _objAdd.Calcium = txtCalcium.Text;
                _objAdd.Magnesium = txtMagnesium.Text;
                _objAdd.Neutrophils = txtNeutrophils.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateBoneProfileReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateBoneProfile.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }

        }





        protected void grdvwBoneProfileDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwBoneProfileDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateBoneProfile.ChangeMode(FormViewMode.Edit);
                Guid BPR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetBoneProfileReports(new DC_BoneProfileReports_Search() { BPR_TestReportID = BPR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateBoneProfile.DataSource = result;
                    frmvwAddUpdateBoneProfile.DataBind();
                    TextBox txtTestDate = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtTestDate");
                    TextBox txtVitaminD = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtVitaminD");
                    TextBox txtParathyroidHormone = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtParathyroidHormone");
                    TextBox txtCalcium = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtCalcium");
                    TextBox txtMagnesium = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtMagnesium");
                    TextBox txtNeutrophils = (TextBox)frmvwAddUpdateBoneProfile.FindControl("txtNeutrophils");



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtVitaminD.Text = result[0].VitaminD;
                    txtParathyroidHormone.Text = result[0].ParathyroidHormone;
                    txtCalcium.Text = result[0].Calcium;
                    txtMagnesium.Text = result[0].Magnesium;
                    txtNeutrophils.Text = result[0].Neutrophils;

                }

            }
        }

    }
}