using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_UrineReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_UrineReports> GetUrineReports(DC_UrineReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_UrineReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.UR_TestReportID.HasValue)
                        search = from x in search where x.UR_TestReportID == _objSearch.UR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_UrineReports
                                  {
                                      UR_TestReportID = rs.UR_TestReportID,
                                      PatientID = rs.PatientID,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TotalRecord = total,
                                      Albumin = rs.Albumin,
                                      Creatine = rs.Creatine,
                                      ACR = rs.ACR
                                  });
                    return result.OrderByDescending(p => p.TestDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateUrineReports(DC_UrineReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.UR_TestReportID != null && _objSave.UR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_UrineReports
                                           where x.UR_TestReportID != _objSave.UR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_UrineReports.Find(_objSave.UR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.Albumin = _objSave.Albumin;
                            report.Creatine = _objSave.Creatine;
                            report.ACR = _objSave.ACR;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_UrineReports _objnew = new tbl_UrineReports();
                            _objnew.UR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.Albumin = _objSave.Albumin;
                            _objnew.Creatine = _objSave.Creatine;
                            _objnew.ACR = _objSave.ACR;
                            _objnew.IsActive = _objSave.IsActive;
                            _objnew.TestDate = _objSave.TestDate;

                            context.tbl_UrineReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_UrineReports _objnew = new tbl_UrineReports();
                        _objnew.UR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.Albumin = _objSave.Albumin;
                        _objnew.Creatine = _objSave.Creatine;
                        _objnew.ACR = _objSave.ACR;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.TestDate = _objSave.TestDate;

                        context.tbl_UrineReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Vital Sign has been" + ReadOnlyMessage.strFailed;
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
