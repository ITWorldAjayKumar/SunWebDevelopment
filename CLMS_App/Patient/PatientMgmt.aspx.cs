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
    public partial class PatientMgmt : System.Web.UI.Page
    {
        DL_PatientDetails _objDL = new DL_PatientDetails();
        public static int intPageSize = 3;
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
                    TextBox txtAltMobileNo = (TextBox)frmvwAddUpdatePatient.FindControl("txtAltMobileNo");
                    
                    RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
                  //  HtmlTextArea txtAddress = (HtmlTextArea)frmvwAddUpdatePatient.FindControl("txtAddress")
                    TextBox txtAddress = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress");
                    TextBox txtAddress2 = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress2");
                    TextBox txtAddress3 = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress3");
                    TextBox txtPincode = (TextBox)frmvwAddUpdatePatient.FindControl("txtPincode");
                    TextBox txtEmailAdd = (TextBox)frmvwAddUpdatePatient.FindControl("txtEmailAdd");

                    txtPatientName.Text = result[0].Name;
                    txtAge.Text = Convert.ToString(result[0].Age);
                    txtOccupation.Text = result[0].Occupation;
                    txtMobileNo.Text = result[0].Mobile;
                    txtAltMobileNo.Text = result[0].AlternetMobNo;
                    rdbtnlstGender.SelectedValue = result[0].Gender;
                    txtAddress.Text = result[0].Address;
                    txtAddress2.Text = result[0].Address_2;
                    txtAddress3.Text = result[0].Address_3;
                    txtPincode.Text = result[0].PinCode;
                    txtEmailAdd.Text = result[0].Email_ID;

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
            TextBox txtAltMobileNo = (TextBox)frmvwAddUpdatePatient.FindControl("txtAltMobileNo");

            
            RadioButtonList rdbtnlstGender = (RadioButtonList)frmvwAddUpdatePatient.FindControl("rdbtnlstGender");
            TextBox txtAddress = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress");
            TextBox txtAddress2 = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress2");
            TextBox txtAddress3 = (TextBox)frmvwAddUpdatePatient.FindControl("txtAddress3");
            TextBox txtEmailAdd = (TextBox)frmvwAddUpdatePatient.FindControl("txtEmailAdd");
            TextBox txtPincode = (TextBox)frmvwAddUpdatePatient.FindControl("txtPincode");


            if (e.CommandName == "AddPatient")
            {
                DC_Message _msg = new DC_Message();
                DC_PatientDetails _objAdd = new DC_PatientDetails();
                _objAdd.Name = txtPatientName.Text;
                _objAdd.Age = Convert.ToInt32(txtAge.Text);
                _objAdd.Occupation = txtOccupation.Text;
                _objAdd.Mobile = txtMobileNo.Text;
                _objAdd.AlternetMobNo = txtAltMobileNo.Text;
                _objAdd.Address = txtAddress.Text;
                _objAdd.Address_2 = txtAddress2.Text;
                _objAdd.Address_3 = txtAddress3.Text;
                _objAdd.Email_ID = txtEmailAdd.Text;
                _objAdd.PinCode = txtPincode.Text;
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
                _objAdd.AlternetMobNo = txtAltMobileNo.Text;
                // _objAdd.Address = "Goregoan";
                _objAdd.Address = txtAddress.Text ;
                _objAdd.Address_2 = txtAddress2.Text;
                _objAdd.Address_3 = txtAddress3.Text;
                _objAdd.Email_ID = txtEmailAdd.Text;
                _objAdd.PinCode = txtPincode.Text;
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

     }
}