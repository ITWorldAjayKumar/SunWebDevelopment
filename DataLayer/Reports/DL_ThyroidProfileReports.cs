using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_ThyroidProfileReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_ThyroidProfileReports> GetThyroidProfileReports(DC_ThyroidProfileReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_ThyroidProfileReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.TPR_TestReportID.HasValue)
                        search = from x in search where x.TPR_TestReportID == _objSearch.TPR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_ThyroidProfileReports
                                  {
                                      TPR_TestReportID = rs.TPR_TestReportID,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TotalRecord = total,
                                      FreeT3 = rs.FreeT3,
                                      FreeT4 = rs.FreeT4,
                                      TSH = rs.TSH
                                  });
                    return result.OrderByDescending(p => p.TestDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateThyroidProfileReports(DC_ThyroidProfileReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.TPR_TestReportID != null && _objSave.TPR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_ThyroidProfileReports
                                           where x.TPR_TestReportID != _objSave.TPR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_ThyroidProfileReports.Find(_objSave.TPR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.FreeT3 = _objSave.FreeT3;
                            report.FreeT4 = _objSave.FreeT4;
                            report.TSH = _objSave.TSH;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_ThyroidProfileReports _objnew = new tbl_ThyroidProfileReports();
                            _objnew.TPR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.FreeT3 = _objSave.FreeT3;
                            _objnew.FreeT4 = _objSave.FreeT4;
                            _objnew.TSH = _objSave.TSH;
                            _objnew.IsActive = _objSave.IsActive;
                            _objnew.TestDate = _objSave.TestDate;

                            context.tbl_ThyroidProfileReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_ThyroidProfileReports _objnew = new tbl_ThyroidProfileReports();
                        _objnew.TPR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.FreeT3 = _objSave.FreeT3;
                        _objnew.FreeT4 = _objSave.FreeT4;
                        _objnew.TSH = _objSave.TSH;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.TestDate = _objSave.TestDate;

                        context.tbl_ThyroidProfileReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Thyroid Profile Reports has been" + ReadOnlyMessage.strFailed;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return _msg;
        }
    }
}
