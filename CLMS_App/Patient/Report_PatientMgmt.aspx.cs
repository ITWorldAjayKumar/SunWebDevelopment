using DataContracts;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CLMS_App.App_Code;
using System.Web.UI.HtmlControls;
using DataContract;

namespace CLMS_App.Patient
{
    public partial class Report_PatientMgmt : System.Web.UI.Page
    {
        DL_PatientDetails _objDL = new DL_PatientDetails();
        public static int intPageSize = 5;
        public static int intPageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                DC_PaitentDetails_Search _objSearch = new DC_PaitentDetails_Search();

                _objSearch.PageNo = intPageIndex;
                _objSearch.PageSize = intPageSize;
                if (!String.IsNullOrWhiteSpace(txtPatientNameSearch.Text))
                    _objSearch.Name = txtPatientNameSearch.Text;
                if (!String.IsNullOrWhiteSpace(txtMobilSearch.Text))
                    _objSearch.MobileNo = txtMobilSearch.Text;
                if (!String.IsNullOrWhiteSpace(txtAgeSearch.Text))
                    _objSearch.Name = txtAgeSearch.Text;

                var result = _objDL.GetPatientDetails(_objSearch);
                grdvwPatients.DataSource = result;
                grdvwPatients.PageSize = intPageSize;
                grdvwPatients.PageIndex = intPageIndex;
                if (result != null && result.Count > 0)
                {
                    grdvwPatients.VirtualItemCount = Convert.ToInt32(result[0].TotalRecord);
                }
                grdvwPatients.DataBind();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void grdvwPatients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            intPageIndex = e.NewPageIndex;
            BindGridView();

        }

        protected void grdvwPatients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                divmsg.Style.Add("display", "none");
                frmvwAddUpdatePatient.ChangeMode(FormViewMode.Edit);
                Guid userId = Guid.Parse(e.CommandArgument.ToString());

                var result = _objDL.GetPatientDetails(new DC_PaitentDetails_Search() { ID = userId, PageNo = 0, PageSize = 1 });
                if (result != null && result.Count > 0)
                {
                    frmvwAddUpdatePatient.DataSource = result;
                    frmvwAddUpdatePatient.DataBind();

                    TextBox txtPatientName = (TextBox)frmvwAddUpdatePatient.FindControl("txtPatientName");
                    TextBox txtAge = (TextBox)frmvwAddUpdatePatient.FindControl("txtAge");
                    TextBox txtOccupation = (TextBox)frmvwAddUpdatePatient.FindControl("txtOccupation");
                    TextBox txtMobileNo = (TextBox)frmvwAddUpdatePatient.FindControl("txtMobileNo");
                    RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
                    HtmlTextArea txtAddress = (HtmlTextArea)frmvwAddUpdatePatient.FindControl("txtAddress");

                    txtPatientName.Text = result[0].Name;
                    txtAge.Text = Convert.ToString(result[0].Age);
                    txtOccupation.Text = result[0].Occupation;
                    txtMobileNo.Text = result[0].Mobile;
                    rdbtnlstGender.SelectedValue = result[0].Gender;
                    txtAddress.Value = result[0].Address;

                }
            }

        }

        protected void btnSearchPatient_Click(object sender, EventArgs e)
        {
            intPageIndex = 0;
            intPageSize = 2;
            BindGridView();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            txtAgeSearch.Text = string.Empty;
            txtMobilSearch.Text = string.Empty;
            txtPatientNameSearch.Text = string.Empty;

        }

        protected void frmvwAddUpdatePatient_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtPatientName = (TextBox)frmvwAddUpdatePatient.FindControl("txtPatientName");
            TextBox txtAge = (TextBox)frmvwAddUpdatePatient.FindControl("txtAge");
            TextBox txtOccupation = (TextBox)frmvwAddUpdatePatient.FindControl("txtOccupation");
            TextBox txtMobileNo = (TextBox)frmvwAddUpdatePatient.FindControl("txtMobileNo");
            RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
            HtmlTextArea txtAddress = (HtmlTextArea)frmvwAddUpdatePatient.FindControl("txtAddress");

            if (e.CommandName == "AddPatient")
            {
                DC_Message _msg = new DC_Message();
                DC_PatientDetails _objAdd = new DC_PatientDetails();
                _objAdd.Name = txtPatientName.Text;
                _objAdd.Age = Convert.ToInt32(txtAge.Text);
                _objAdd.Occupation = txtOccupation.Text;
                _objAdd.Mobile = txtMobileNo.Text;
                _objAdd.Address = txtAddress.Value;
                _objAdd.Gender = rdbtnlstGender.SelectedItem.Text;
                _objAdd.CreatedBy = "Ajay";
                _msg = _objDL.AddUpdatePatientDetails(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    hdnFlag.Value = "true";
                }
            }
            if (e.CommandName == "EditPatient")
            {
                DC_Message _msg = new DC_Message();
                DC_PatientDetails _objAdd = new DC_PatientDetails();
                _objAdd.ID = Guid.Parse(Convert.ToString(frmvwAddUpdatePatient.DataKey.Value));
                _objAdd.Name = txtPatientName.Text;
                _objAdd.Age = Convert.ToInt32(txtAge.Text);
                _objAdd.Occupation = txtOccupation.Text;
                _objAdd.Mobile = txtMobileNo.Text;
                _objAdd.Address = "Goregoan";
                _objAdd.Gender = rdbtnlstGender.SelectedItem.Text;
                _objAdd.EditedBy = "Ajay";
                _msg = _objDL.AddUpdatePatientDetails(_objAdd);
                if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                {
                    BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                    hdnFlag.Value = "true";
                }
            }

        }

        //protected void frmVitalSign_ItemCommand(object sender, FormViewCommandEventArgs e)
        //{
        //    TextBox txtBP = (TextBox)frmVitalSign.FindControl("txtBP");
        //    TextBox txtWeight = (TextBox)frmVitalSign.FindControl("txtWeight");
        //    TextBox txtTemperature = (TextBox)frmVitalSign.FindControl("txtTemperature");
        //    TextBox txtPluse = (TextBox)frmVitalSign.FindControl("txtPluse");
        //    //RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
        //    //HtmlTextArea txtAddress = (HtmlTextArea)frmvwAddUpdatePatient.FindControl("txtAddress");

        //    if (e.CommandName == "AddVitalSign")
        //    {
        //        DC_Message _msg = new DC_Message();
        //        DC_VitalSingsDetails _objAdd = new DC_VitalSingsDetails();
        //        _objAdd.PatientID = Guid.Parse(Convert.ToString(frmVitalSign.DataKey.Value));
        //        _objAdd.BP = txtBP.Text;
        //        _objAdd.Weight = Convert.ToDecimal(txtWeight.Text);
        //        _objAdd.Temperature = Convert.ToDecimal(txtTemperature.Text);
        //        _objAdd.Pluse = txtPluse.Text;
        //        _objAdd.CreatedBy = "Ajay";
        //       // _msg = _objDL.AddUpdateVitalSignDetails(_objAdd);
        //        if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
        //        {
        //            BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
        //            hdnFlag.Value = "true";
        //        }
        //    }
        //    if (e.CommandName == "EditVitalSign")
        //    {
        //        DC_Message _msg = new DC_Message();
        //        DC_VitalSingsDetails _objAdd = new DC_VitalSingsDetails();
        //        _objAdd.PatientID = Guid.Parse(Convert.ToString(frmvwAddUpdatePatient.DataKey.Value));
        //        _objAdd.BP = txtBP.Text;
        //        _objAdd.Weight = Convert.ToDecimal(txtWeight.Text);
        //        _objAdd.Temperature = Convert.ToDecimal(txtTemperature.Text);
        //        _objAdd.Pluse = txtPluse.Text;
        //        _objAdd.EditedBy = "Ajay";
        //       // _msg = _objDL.AddUpdateVitalSignDetails(_objAdd);
        //        if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
        //        {
        //            BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
        //            hdnFlag.Value = "true";
        //        }
        //    }
        //}
    }
}