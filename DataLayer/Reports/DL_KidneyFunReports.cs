using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_KidneyFunReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_KidneyFunctionsReports> GetKidneyFunctionsReports(DC_KidneyFunctionsReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_KidneyFunctionsReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.KFR_TestReportID.HasValue)
                        search = from x in search where x.KFR_TestReportID == _objSearch.KFR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_KidneyFunctionsReports
                                  {
                                      KFR_TestReportID = rs.KFR_TestReportID,
                                      SCreatinine = rs.SCreatinine,
                                      UrineACR = rs.UrineACR,
                                      Urea = rs.Urea,
                                      Bun = rs.Bun,
                                      SUricAcid = rs.SUricAcid,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TotalRecord = total
                                  });
                    return result.OrderByDescending(p => p.TestDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateKidneyFunctionsReports(DC_KidneyFunctionsReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.KFR_TestReportID != null && _objSave.KFR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_KidneyFunctionsReports
                                           where x.KFR_TestReportID != _objSave.KFR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_KidneyFunctionsReports.Find(_objSave.KFR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.KFR_TestReportID = _objSave.KFR_TestReportID;
                            report.SCreatinine = _objSave.SCreatinine;
                            report.UrineACR = _objSave.UrineACR;
                            report.Urea = _objSave.Urea;
                            report.Bun = _objSave.Bun;
                            report.SUricAcid = _objSave.SUricAcid;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_KidneyFunctionsReports _objnew = new tbl_KidneyFunctionsReports();
                            _objnew.KFR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.TestDate = _objSave.TestDate;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.KFR_TestReportID = _objSave.KFR_TestReportID;
                            _objnew.SCreatinine = _objSave.SCreatinine;
                            _objnew.UrineACR = _objSave.UrineACR;
                            _objnew.Urea = _objSave.Urea;
                            _objnew.Bun = _objSave.Bun;
                            _objnew.SUricAcid = _objSave.SUricAcid;

                            context.tbl_KidneyFunctionsReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_KidneyFunctionsReports _objnew = new tbl_KidneyFunctionsReports();
                        _objnew.KFR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.TestDate = _objSave.TestDate;
                        _objnew.KFR_TestReportID = _objSave.KFR_TestReportID;
                        _objnew.SCreatinine = _objSave.SCreatinine;
                        _objnew.UrineACR = _objSave.UrineACR;
                        _objnew.Urea = _objSave.Urea;
                        _objnew.Bun = _objSave.Bun;
                        _objnew.SUricAcid = _objSave.SUricAcid;

                        context.tbl_KidneyFunctionsReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Kidney Function Report has been" + ReadOnlyMessage.strFailed;
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
