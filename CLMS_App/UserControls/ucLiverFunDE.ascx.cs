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
    public partial class ucLiverFunDE : System.Web.UI.UserControl
    {
        #region Variables
        public static Guid _patientId = Guid.Empty;
        DL_LiverFunReports _objDL = new DL_LiverFunReports();

        public static int intPageSize = 3;
        public static int intPageIndex = 0;
        #endregion
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
                    var result = _objDL.GetLiverFunReports(new DC_LiverFunctionReports_Search() { PatientID = _patientId, PageNo = intPageIndex, PageSize = intPageSize });
                    grdvwLiverFunctionDetails.DataSource = result;
                    if (result != null && result.Count > 0)
                        grdvwLiverFunctionDetails.VirtualItemCount = result[0].TotalRecord ?? 0;

                    grdvwLiverFunctionDetails.PageIndex = intPageIndex;
                    grdvwLiverFunctionDetails.PageSize = intPageSize;
                    grdvwLiverFunctionDetails.DataBind();
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
                List<DC_LiverFunctionReports> _lstDC_VitalSignsReports = new List<DC_LiverFunctionReports>();
                DC_LiverFunctionReports _objvsr = new DC_LiverFunctionReports();
                _lstDC_VitalSignsReports.Add(_objvsr);
                grdvwLiverFunctionDetails.DataSource = _lstDC_VitalSignsReports;
                grdvwLiverFunctionDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void frmvwAddUpdateLiverFunction_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            #region Controls 
            TextBox txtTestDate = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtTestDate");
            TextBox txtSBilirubin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSBilirubin");
            TextBox txtSGOT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSGOT");
            TextBox txtSGPT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSGPT");
            TextBox txtGGT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtGGT");
            TextBox txtSAlkPhosphate = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSAlkPhosphate");
            TextBox txtSProtein = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSProtein");
            TextBox txtAlbumin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtAlbumin");
            TextBox txtGlobulin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtGlobulin");
            TextBox txtAGRatio = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtAGRatio");
            #endregion

            if (e.CommandName == "AddLiverFunction")
            {
                DC_Message _msg = new DC_Message();
                DC_LiverFunctionReports _objAdd = new DC_LiverFunctionReports();
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.PatientID = GetPatientID();
                _objAdd.SBilirubin = txtSBilirubin.Text;
                _objAdd.SGOT = txtSGOT.Text;
                _objAdd.SGPT = txtSGPT.Text;
                _objAdd.GGT = txtGGT.Text;
                _objAdd.SAlkPhosphate = txtSAlkPhosphate.Text;
                _objAdd.SProtein = txtSProtein.Text;
                _objAdd.Albumin = txtAlbumin.Text;
                _objAdd.Globulin = txtGlobulin.Text;
                _objAdd.AGRatio = txtAGRatio.Text;
                _objAdd.CreatedBy = "Ajay";
                _objAdd.CreatedDate = DateTime.Today;
                _msg = _objDL.AddUpdateLiverFunReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateLiverFunction.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }
            if (e.CommandName == "UpdateLiverFunction")
            {
                DC_Message _msg = new DC_Message();
                DC_LiverFunctionReports _objAdd = new DC_LiverFunctionReports();
                _objAdd.LFR_TestReportID = Guid.Parse(Convert.ToString(frmvwAddUpdateLiverFunction.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtTestDate.Text);
                _objAdd.SBilirubin = txtSBilirubin.Text;
                _objAdd.SGOT = txtSGOT.Text;
                _objAdd.SGPT = txtSGPT.Text;
                _objAdd.GGT = txtGGT.Text;
                _objAdd.SAlkPhosphate = txtSAlkPhosphate.Text;
                _objAdd.SProtein = txtSProtein.Text;
                _objAdd.Albumin = txtAlbumin.Text;
                _objAdd.Globulin = txtGlobulin.Text;
                _objAdd.AGRatio = txtAGRatio.Text;
                _objAdd.EditedBy = "Ajay";
                _objAdd.EditedDate = DateTime.Today;
                _msg = _objDL.AddUpdateLiverFunReports(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    frmvwAddUpdateLiverFunction.ChangeMode(FormViewMode.Insert);
                    BindGridDetails();
                }
            }

        }

        protected void grdvwLiverFunctionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridDetails();
        }

        protected void grdvwLiverFunctionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdateLiverFunction.ChangeMode(FormViewMode.Edit);
                Guid LFR_TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetLiverFunReports(new DC_LiverFunctionReports_Search() { LFR_TestReportID = LFR_TestReportID, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdateLiverFunction.DataSource = result;
                    frmvwAddUpdateLiverFunction.DataBind();

                    #region Controls 
                    TextBox txtTestDate = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtTestDate");
                    TextBox txtSBilirubin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSBilirubin");
                    TextBox txtSGOT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSGOT");
                    TextBox txtSGPT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSGPT");
                    TextBox txtGGT = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtGGT");
                    TextBox txtSAlkPhosphate = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSAlkPhosphate");
                    TextBox txtSProtein = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtSProtein");
                    TextBox txtAlbumin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtAlbumin");
                    TextBox txtGlobulin = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtGlobulin");
                    TextBox txtAGRatio = (TextBox)frmvwAddUpdateLiverFunction.FindControl("txtAGRatio");
                    #endregion



                    txtTestDate.Text = result[0].TestDate.ToString("MMM-dd-yyyy");
                    txtSBilirubin.Text = Convert.ToString(result[0].SBilirubin);
                    txtSGOT.Text = Convert.ToString(result[0].SGOT);
                    txtSGPT.Text = Convert.ToString(result[0].SGPT);
                    txtGGT.Text = Convert.ToString(result[0].GGT);
                    txtSAlkPhosphate.Text = Convert.ToString(result[0].SAlkPhosphate);
                    txtSProtein.Text = Convert.ToString(result[0].SProtein);
                    txtAlbumin.Text = Convert.ToString(result[0].Albumin);
                    txtGlobulin.Text = Convert.ToString(result[0].Globulin);
                    txtAGRatio.Text = Convert.ToString(result[0].AGRatio);

                }

            }

        }

    }
}