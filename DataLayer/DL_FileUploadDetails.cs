using System;
using System.Linq;
using DataContracts;
using System.Collections.Generic;
using DataContract;
using DataLayer;

namespace DataLayer
{
    public class DL_FileUploadDetails : IDisposable
    {
        public static string strClassFor = "Test Report ";
        public void Dispose()
        { }
        #region 
        public List<DC_FileUploadDetails> GetTestFileDetails(DC_FileUploadDetails_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from a in context.tbl_FileUploadDetails select a;
                    if (_objSearch.FileUploadID.HasValue)
                    {
                        if (_objSearch.FileUploadID.Value != Guid.Empty)
                        {
                            Guid _FileUploadID = Guid.Parse(Convert.ToString(_objSearch.FileUploadID));
                            search = from a in search where a.FileUploadID == _FileUploadID select a;
                        }
                    }
                    if (_objSearch.PatientID.HasValue)
                    {
                        if (_objSearch.PatientID.Value != Guid.Empty)
                        {
                            Guid _PatientID = Guid.Parse(Convert.ToString(_objSearch.PatientID));
                            search = from a in search where a.PatientID == _PatientID select a;
                        }
                    }
                    if (_objSearch.TestReportID.HasValue)
                    {
                        if (_objSearch.TestReportID.Value != Guid.Empty)
                        {
                            Guid _TestReportID = Guid.Parse(Convert.ToString(_objSearch.TestReportID));
                            search = from a in search where a.TestReportID == _TestReportID select a;
                        }
                    }
                    //if (!string.IsNullOrWhiteSpace(_objSearch.FileName))
                    //{
                    //    search = from a in search where a.Name.Contains(_objSearch.Name) select a;
                    //}
                    //if (!string.IsNullOrWhiteSpace(_objSearch.MobileNo))
                    //{
                    //    search = from a in search where a.Mobile == _objSearch.MobileNo select a;
                    //}

                    int total;

                    total = search.Count();

                    if (_objSearch.PageSize == 0)
                        _objSearch.PageSize = 10;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = from a in search
                                 orderby a.TestDate
                                 select new DC_FileUploadDetails
                                 {
                                     TestReportID = a.TestReportID.HasValue ? a.TestReportID.Value : Guid.Empty,
                                     TestName = a.TestName,
                                     TestType = a.TestType,
                                     FileDispalyName = a.FileDispalyName,
                                     FileName = a.FileName,
                                     PatientID = a.PatientID.HasValue ? a.PatientID.Value : Guid.Empty,
                                     FilePath = a.FilePath,
                                     TestDate = a.TestDate,
                                     CreatedBy = a.CreatedBy,
                                     CreatedDate = a.CreatedDate,
                                     EditedBy = a.EditedBy,
                                     EditedDate = a.EditedDate,
                                     IsActive = a.IsActive.HasValue ? a.IsActive.Value : false,
                                     TotalRecord = total
                                 };
                    return result.OrderBy(p => p.TestDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateFileDetails(DC_FileUploadDetails _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    if (_objSave.FileUploadID != null && _objSave.FileUploadID != Guid.Empty) //Edit
                    {
                        var isduplicate = (from p in context.tbl_FileUploadDetails
                                           where p.FileUploadID != _objSave.FileUploadID && p.PatientID == _objSave.PatientID && p.TestReportID == _objSave.TestReportID
                                           select p).Count() == 0 ? false : true;

                        if (isduplicate)
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var FileUpload = context.tbl_FileUploadDetails.Find(_objSave.TestReportID);
                        if (FileUpload != null)
                        {
                            FileUpload.TestName = _objSave.TestName;
                            FileUpload.TestDate = _objSave.TestDate;
                            FileUpload.TestType = _objSave.TestType;
                            FileUpload.FilePath = _objSave.FilePath;
                            FileUpload.FileDispalyName = _objSave.FileDispalyName;
                            FileUpload.EditedBy = _objSave.EditedBy;
                            FileUpload.EditedDate = DateTime.Now;
                            FileUpload.IsActive = _objSave.IsActive;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = strClassFor + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = strClassFor + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {

                        }

                    }
                    else //Add
                    {
                        var isduplicate = (from p in context.tbl_FileUploadDetails
                                           where p.FileUploadID != _objSave.FileUploadID && p.PatientID == _objSave.PatientID && p.TestReportID == _objSave.TestReportID
                                           select p).Count() == 0 ? false : true;

                        if (isduplicate)
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }

                        var patientID = (from x in context.tbl_VitalSingsDetails where x.TestReportID == _objSave.TestReportID select x.PatientID).FirstOrDefault();

                        tbl_FileUploadDetails _objP = new tbl_FileUploadDetails
                        {
                            FileUploadID = Guid.NewGuid(),
                            PatientID = _objSave.PatientID,
                            TestReportID = _objSave.TestReportID,
                            FileDispalyName = _objSave.FileDispalyName,
                            FilePath = _objSave.FilePath,
                            FileName = _objSave.FileName,
                            TestName = _objSave.TestName,
                            TestDate = _objSave.TestDate,
                            TestType = _objSave.TestType,
                            CreatedBy = _objSave.CreatedBy,
                            CreatedDate = DateTime.Now,
                            IsActive = _objSave.IsActive,
                        };
                        context.tbl_FileUploadDetails.Add(_objP);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strFailed;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                        }
                    }
                }

            }
            catch (Exception)
            {
                _msg.StatusMessage = ReadOnlyMessage.strFailed;
                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
            }
            return _msg;
        }
        #endregion

    }
}
