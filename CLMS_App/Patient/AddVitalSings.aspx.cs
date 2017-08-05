using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLMS_App.Patient
{
    public partial class AddVitalSings : System.Web.UI.Page
    {
        DL_PatientDetails _objDL = new DL_PatientDetails();
        public static int intPageSize = 2;
        public static int intPageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVitalDetails();
            }

        }

        private void BindVitalDetails()
        {
            try
            {
                //DC_PaitentDetails_Search _objSearch = new DC_PaitentDetails_Search();

                //_objSearch.PageNo = intPageIndex;
                //_objSearch.PageSize = intPageSize;
                //if (!String.IsNullOrWhiteSpace(txtPatientNameSearch.Text))
                //    _objSearch.Name = txtPatientNameSearch.Text;
                //if (!String.IsNullOrWhiteSpace(txtMobilSearch.Text))
                //    _objSearch.MobileNo = txtMobilSearch.Text;
                //if (!String.IsNullOrWhiteSpace(txtAgeSearch.Text))
                //    _objSearch.Name = txtAgeSearch.Text;

                //var result = _objDL.GetPatientDetails(_objSearch);
                //grdvwPatients.DataSource = result;
                //grdvwPatients.PageSize = intPageSize;
                //grdvwPatients.PageIndex = intPageIndex;
                //if (result != null && result.Count > 0)
                //{
                //    grdvwPatients.VirtualItemCount = Convert.ToInt32(result[0].TotalRecord);
                //}
                //grdvwPatients.DataBind();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchPatient_Click(object sender, EventArgs e)
        {

        }
    }
}