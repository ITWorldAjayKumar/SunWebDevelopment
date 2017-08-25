using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_LipidProfileReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_LipidProfileReports> GetLipidProfileReports(DC_LipidProfileReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_LipidProfileReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.LPR_TestReportID.HasValue)
                        search = from x in search where x.LPR_TestReportID == _objSearch.LPR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_LipidProfileReports
                                  {
                                      LPR_TestReportID = rs.LPR_TestReportID,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TChol = rs.TChol,
                                      Triglycerides = rs.Triglycerides,
                                      HDLChol = rs.HDLChol,
                                      LDLChol = rs.LDLChol,
                                      TCholHDL = rs.TCholHDL,
                                      LDLHDLRatio = rs.LDLHDLRatio,
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
        public DC_Message AddUpdateLipidProfileReports(DC_LipidProfileReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.LPR_TestReportID != null && _objSave.LPR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_LipidProfileReports
                                           where x.LPR_TestReportID != _objSave.LPR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_LipidProfileReports.Find(_objSave.LPR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.TChol = _objSave.TChol;
                            report.Triglycerides = _objSave.Triglycerides;
                            report.HDLChol = _objSave.HDLChol;
                            report.LDLChol = _objSave.LDLChol;
                            report.TCholHDL = _objSave.TCholHDL;
                            report.LDLHDLRatio = _objSave.LDLHDLRatio;
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_LipidProfileReports _objnew = new tbl_LipidProfileReports();
                            _objnew.LPR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.TChol = _objSave.TChol;
                            _objnew.Triglycerides = _objSave.Triglycerides;
                            _objnew.HDLChol = _objSave.HDLChol;
                            _objnew.LDLChol = _objSave.LDLChol;
                            _objnew.TCholHDL = _objSave.TCholHDL;
                            _objnew.LDLHDLRatio = _objSave.LDLHDLRatio;
                            _objnew.IsActive = _objSave.IsActive;
                            _objnew.TestDate = _objSave.TestDate;

                            context.tbl_LipidProfileReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_LipidProfileReports _objnew = new tbl_LipidProfileReports();
                        _objnew.LPR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.TChol = _objSave.TChol;
                        _objnew.Triglycerides = _objSave.Triglycerides;
                        _objnew.HDLChol = _objSave.HDLChol;
                        _objnew.LDLChol = _objSave.LDLChol;
                        _objnew.TCholHDL = _objSave.TCholHDL;
                        _objnew.LDLHDLRatio = _objSave.LDLHDLRatio;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.TestDate = _objSave.TestDate;

                        context.tbl_LipidProfileReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Lipid Profile has been" + ReadOnlyMessage.strFailed;
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
