using System;
using System.Web.UI;
using AjaxControlToolkit;
using DataLayer;
using DataContracts;
using CLMS_App.App_Code;

namespace CLMS_App.Patient
{
    public partial class AddReports : System.Web.UI.Page
    {
        DL_FileUploadDetails _objDL = new DL_FileUploadDetails();
        public static int intPageSize = 5;
        public static int intPageIndex = 0;
        public static Guid TestReportID = Guid.Empty;
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
                TestReportID = Guid.Parse(Request.QueryString["TestReportID"]);
                //Get Da
                DL_FileUploadDetails _objDlFile = new DL_FileUploadDetails();
                var result = _objDlFile.GetTestFileDetails(new DataContract.DC_FileUploadDetails_Search() { TestReportID = TestReportID });
                if (result != null && result.Count > 0)
                {
                    lstUploadFile.DataSource = result;
                    lstUploadFile.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void fileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {


        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadControl.HasFile)
                {
                    DC_Message _msg = new DC_Message();
                    string fileDisplayname = System.IO.Path.GetFileName(FileUploadControl.FileName);
                    string filename = fileDisplayname + DateTime.Now.Ticks.ToString();
                    string filepath = Server.MapPath("ReportUploaded/") + filename;
                    TestReportID = Guid.Parse(Request.QueryString["TestReportID"]);
                    FileUploadControl.SaveAs(filepath);


                    _msg = _objDL.AddUpdateFileDetails(new DataContract.DC_FileUploadDetails()
                    {
                        FileDispalyName = fileDisplayname,
                        FileName = filename,
                        FilePath = filepath,
                        TestReportID = TestReportID,
                        CreatedBy = "System",
                        CreatedDate = DateTime.Now,
                        TestDate = DateTime.Now,
                    });
                    if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                    {
                        BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                        hdnFlag.Value = "true";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}