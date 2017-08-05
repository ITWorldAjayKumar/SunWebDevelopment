using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContracts;
using DataLayer;
using CLMS_App.App_Code;
using System.Web.UI.HtmlControls;
using DataContract;


namespace CLMS_App.Patient
{
    public partial class VitalMgmt : System.Web.UI.Page
    {
        DL_PatientDetails _objDL = new DL_PatientDetails();
        public static int intPageSize = 5;
        public static int intPageIndex = 0;
        public static Guid Patient_ID = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Patient_ID = Guid.Parse(Request.QueryString["PatientID"]);
                BindPatientBasicDetails(Patient_ID);
                BindGridView(Patient_ID);
            }
        }

        private void BindPatientBasicDetails(Guid patient_ID)
        {
            try
            {
                DL_PatientDetails _dlPatient = new DL_PatientDetails();
                var result = _dlPatient.GetPatientDetails(new DC_PaitentDetails_Search() { ID = patient_ID, PageNo = 0, PageSize = 5 });
                if (result != null && result.Count > 0)
                {
                    lblVitalPatientName.Text = result[0].Name;
                    lblVitalPatientAge.Text = Convert.ToString(result[0].Age);
                    lblVitalPatientMobile.Text = Convert.ToString(result[0].Mobile);
                    lblVitalPatientAddress.Text = result[0].Address;
                    lblVitalPatientOccupation.Text = Convert.ToString(result[0].Occupation);
                    lblVitalPatientGender.Text = Convert.ToString(result[0].Gender);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindGridView(Guid patient_ID)
        {
            try
            {
                DC_VitalDetails_Search _objSearch = new DC_VitalDetails_Search();

                _objSearch.PageNo = intPageIndex;
                _objSearch.PageSize = intPageSize;
                //if (!String.IsNullOrWhiteSpace(txtPatientNameSearch.Text))
                //    _objSearch.Name = txtPatientNameSearch.Text;
                //if (!String.IsNullOrWhiteSpace(txtMobilSearch.Text))
                //    _objSearch.MobileNo = txtMobilSearch.Text;
                //if (!String.IsNullOrWhiteSpace(txtAgeSearch.Text))
                //    _objSearch.Name = txtAgeSearch.Text;
                _objSearch.PatientID = patient_ID;

                //   var result = _objDL.GetPatientDetails(_objSearch);
                var result = _objDL.GetVitalDetails(_objSearch);

                grdvwVitals.DataSource = result;
                grdvwVitals.PageSize = intPageSize;
                grdvwVitals.PageIndex = intPageIndex;
                if (result != null && result.Count > 0)
                {
                    grdvwVitals.VirtualItemCount = Convert.ToInt32(result[0].TotalRecord);
                }
                grdvwVitals.DataBind();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void grdvwVitals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            //BindGridView();

        }

        protected void grdvwVitals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmVitalSign.ChangeMode(FormViewMode.Edit);
                Guid TestReportID = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetVitalDetails(new DC_VitalDetails_Search { TestReportID = TestReportID, PageNo = 0, PageSize = 10 });
                if (result != null && result.Count > 0)
                {
                    frmVitalSign.DataSource = result;
                    frmVitalSign.DataBind();

                    TextBox txtdatepicker = (TextBox)frmVitalSign.FindControl("txtdatepicker");
                    //HtmlInputText txtTestDate = (HtmlInputText)frmVitalSign.FindControl("datepicker");

                    TextBox txtBP = (TextBox)frmVitalSign.FindControl("txtBP");
                    TextBox txtWeight = (TextBox)frmVitalSign.FindControl("txtWeight");
                    TextBox txtTemperature = (TextBox)frmVitalSign.FindControl("txtTemperature");
                    TextBox txtPluse = (TextBox)frmVitalSign.FindControl("txtPluse");

                    txtdatepicker.Text = Convert.ToString(result[0].TestDate);
                    txtBP.Text = Convert.ToString(result[0].BP);
                    txtWeight.Text = Convert.ToString(result[0].Weight);
                    txtTemperature.Text = Convert.ToString(result[0].Temperature);
                    txtPluse.Text = Convert.ToString(result[0].Pluse);
                }
            }

        }

        protected void btnSearchVital_Click(object sender, EventArgs e)
        {
            intPageIndex = 0;
            intPageSize = 2;
            //  BindGridView();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            //txtAgeSearch.Text = string.Empty;
            //txtMobilSearch.Text = string.Empty;
            //txtPatientNameSearch.Text = string.Empty;

        }


        protected void frmVitalSign_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            //HtmlInputText txtTestDate = (HtmlInputText)frmVitalSign.FindControl("datepicker");
            TextBox txtdatepicker = (TextBox)frmVitalSign.FindControl("txtdatepicker");

            TextBox txtBP = (TextBox)frmVitalSign.FindControl("txtBP");
            TextBox txtWeight = (TextBox)frmVitalSign.FindControl("txtWeight");
            TextBox txtTemperature = (TextBox)frmVitalSign.FindControl("txtTemperature");
            TextBox txtPluse = (TextBox)frmVitalSign.FindControl("txtPluse");
            HiddenField hdnPatientID = (HiddenField)frmVitalSign.FindControl("hdnPatientID");

            //RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
            //HtmlTextArea txtAddress = (HtmlTextArea)frmvwAddUpdatePatient.FindControl("txtAddress");

            if (e.CommandName == "AddVitalSign")
            {
                DC_Message _msg = new DC_Message();
                DC_VitalSingsDetails _objAdd = new DC_VitalSingsDetails();
                _objAdd.TestDate = Convert.ToDateTime(txtdatepicker.Text);
                _objAdd.PatientID = Guid.Parse(hdnPatientID.Value);//Guid.Parse(Convert.ToString(frmVitalSign.DataKey.Value));
                _objAdd.BP = txtBP.Text;
                _objAdd.Weight = Convert.ToDecimal(txtWeight.Text);
                _objAdd.Temperature = Convert.ToDecimal(txtTemperature.Text);
                _objAdd.Pluse = txtPluse.Text;
                _objAdd.CreatedBy = "Ajay";

                _msg = _objDL.AddUpdateVitalDetails(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    hdnFlag.Value = "true";
                    Patient_ID = Guid.Parse(Request.QueryString["PatientID"]);
                    BindGridView(Patient_ID);
                }
            }
            if (e.CommandName == "EditVitalSign")
            {
                DC_Message _msg = new DC_Message();
                DC_VitalSingsDetails _objAdd = new DC_VitalSingsDetails();
                _objAdd.PatientID = Guid.Parse(Convert.ToString(frmVitalSign.DataKey.Value));
                _objAdd.TestDate = Convert.ToDateTime(txtdatepicker.Text);
                _objAdd.BP = txtBP.Text;
                _objAdd.Weight = Convert.ToDecimal(txtWeight.Text);
                _objAdd.Temperature = Convert.ToDecimal(txtTemperature.Text);
                _objAdd.Pluse = txtPluse.Text;
                _objAdd.EditedBy = "Ajay";
                _msg = _objDL.AddUpdateVitalDetails(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    hdnFlag.Value = "true";
                }
            }
        }

        protected void lnkbtnNewVitalSign_Click(object sender, EventArgs e)
        {
            Patient_ID = Guid.Parse(Request.QueryString["PatientID"]);
            frmVitalSign.ChangeMode(FormViewMode.Insert);
            HiddenField hdnPatientID = (HiddenField)frmVitalSign.FindControl("hdnPatientID");
            if (hdnPatientID != null)
            {
                hdnPatientID.Value = Convert.ToString(Patient_ID);
            }
        }
    }
}