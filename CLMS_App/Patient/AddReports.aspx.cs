using System;
using System.Web.UI;
using AjaxControlToolkit;
using DataLayer;
using DataContracts;
using CLMS_App.App_Code;
using System.Web.UI.WebControls;

namespace CLMS_App.Patient
{
    public partial class AddReports : System.Web.UI.Page
    {
        DL_FileUploadDetails _objDL = new DL_FileUploadDetails();
        public static int intPageSize = 5;
        public static int intPageIndex = 0;
        public static Guid PatientID = Guid.Empty;
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
                PatientID = Guid.Parse(Request.QueryString["PatientID"]);
                //Get Da
                DL_FileUploadDetails _objDlFile = new DL_FileUploadDetails();
                var result = _objDlFile.GetTestFileDetails(new DataContract.DC_FileUploadDetails_Search() { PatientID = PatientID });
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

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadControl.HasFile)
                {
                    if (!FileUploadControl.PostedFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                        BootstrapAlert.BootstrapAlertMessage(divmsg, "Only PDF files are supported. Uploaded File Type: " + FileUploadControl.PostedFile.ContentType, BootstrapAlertType.Warning);
                    else if (!FileUploadControl.HasFile)
                        BootstrapAlert.BootstrapAlertMessage(divmsg, "You must select a valid file to upload.", BootstrapAlertType.Warning);

                    else if (FileUploadControl.FileContent.Length == 0)
                        BootstrapAlert.BootstrapAlertMessage(divmsg, "You must select a non empty file to upload.", BootstrapAlertType.Warning);
                    else
                    {
                        DC_Message _msg = new DC_Message();
                        // if(FileUploadControl.FileName.GetType() == "")
                        string fileDisplayname = System.IO.Path.GetFileName(FileUploadControl.FileName);
                        string FileNameWithOutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUploadControl.FileName);
                        string filename = FileNameWithOutExtension + DateTime.Now.Ticks.ToString() + ".pdf";
                        string filepath = Server.MapPath("ReportUploaded/") + filename;
                        PatientID = Guid.Parse(Request.QueryString["PatientID"]);
                        FileUploadControl.SaveAs(filepath);
                        _msg = _objDL.AddUpdateFileDetails(new DataContract.DC_FileUploadDetails()
                        {
                            FileDispalyName = fileDisplayname,
                            FileName = filename,
                            FilePath = filepath,
                            PatientID = PatientID,
                            TestReportID = Guid.NewGuid(),
                            TestName = txtTestName.Text,
                            CreatedBy = "System",
                            CreatedDate = DateTime.Now,
                            TestDate = Convert.ToDateTime(txtTestDate.Text),
                        });
                        if (_msg.StatusCode == ReadOnlyMessage.StatusCode.Success)
                        {
                            BootstrapAlert.BootstrapAlertMessage(divmsg, _msg.StatusMessage, BootstrapAlertType.Success);
                            hdnFlag.Value = "true";
                            ClearControls();
                            BindGridView();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void ClearControls()
        {
            try
            {
                txtTestDate.Text = string.Empty;
                txtTestName.Text = string.Empty;
                FileUploadControl.Attributes.Clear();   
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}