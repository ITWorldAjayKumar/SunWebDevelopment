using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_LiverFunReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_LiverFunctionReports> GetLiverFunReports(DC_LiverFunctionReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_LiverFunctionReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.LFR_TestReportID.HasValue)
                        search = from x in search where x.LFR_TestReportID == _objSearch.LFR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_LiverFunctionReports
                                  {
                                      LFR_TestReportID = rs.LFR_TestReportID,
                                      TestDate = rs.TestDate,
                                      PatientID = rs.PatientID,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      SBilirubin = rs.SBilirubin,
                                      SGOT = rs.SGOT,
                                      SGPT = rs.SGPT,
                                      GGT = rs.GGT,
                                      SAlkPhosphate = rs.SAlkPhosphate,
                                      SProtein = rs.SProtein,
                                      Albumin = rs.Albumin,
                                      Globulin = rs.Globulin,
                                      AGRatio = rs.AGRatio,
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
        public DC_Message AddUpdateLiverFunReports(DC_LiverFunctionReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.LFR_TestReportID != null && _objSave.LFR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_LiverFunctionReports
                                           where x.LFR_TestReportID != _objSave.LFR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_LiverFunctionReports.Find(_objSave.LFR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.SBilirubin = _objSave.SBilirubin;
                            report.SGOT = _objSave.SGOT;
                            report.SGPT = _objSave.SGPT;
                            report.GGT = _objSave.GGT;
                            report.SAlkPhosphate = _objSave.SAlkPhosphate;
                            report.SProtein = _objSave.SProtein;
                            report.Albumin = _objSave.Albumin;
                            report.Globulin = _objSave.Globulin;
                            report.AGRatio = _objSave.AGRatio;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_LiverFunctionReports _objnew = new tbl_LiverFunctionReports();
                            _objnew.LFR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.IsActive = _objSave.IsActive;
                            _objnew.TestDate = _objSave.TestDate;
                            _objnew.SBilirubin = _objSave.SBilirubin;
                            _objnew.SGOT = _objSave.SGOT;
                            _objnew.SGPT = _objSave.SGPT;
                            _objnew.GGT = _objSave.GGT;
                            _objnew.SAlkPhosphate = _objSave.SAlkPhosphate;
                            _objnew.SProtein = _objSave.SProtein;
                            _objnew.Albumin = _objSave.Albumin;
                            _objnew.Globulin = _objSave.Globulin;
                            _objnew.AGRatio = _objSave.AGRatio;
                            context.tbl_LiverFunctionReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_LiverFunctionReports _objnew = new tbl_LiverFunctionReports();
                        _objnew.LFR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.TestDate = _objSave.TestDate;
                        _objnew.SBilirubin = _objSave.SBilirubin;
                        _objnew.SGOT = _objSave.SGOT;
                        _objnew.SGPT = _objSave.SGPT;
                        _objnew.GGT = _objSave.GGT;
                        _objnew.SAlkPhosphate = _objSave.SAlkPhosphate;
                        _objnew.SProtein = _objSave.SProtein;
                        _objnew.Albumin = _objSave.Albumin;
                        _objnew.Globulin = _objSave.Globulin;
                        _objnew.AGRatio = _objSave.AGRatio;

                        context.tbl_LiverFunctionReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Liver Function has been" + ReadOnlyMessage.strFailed;
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
