using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_ElectrolytesReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_ElectrolytesReports> GetElectrolytesReports(DC_ElectrolytesReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_ElectrolytesReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.ER_TestReportID.HasValue)
                        search = from x in search where x.ER_TestReportID == _objSearch.ER_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_ElectrolytesReports
                                  {
                                      ER_TestReportID = rs.ER_TestReportID,
                                      PatientID = rs.PatientID,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TotalRecord = total,
                                      Sodium = rs.Sodium,
                                      Potassium = rs.Potassium,
                                      Chloride = rs.Chloride
                                  });
                    return result.OrderByDescending(p => p.TestDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateElectrolytesReports(DC_ElectrolytesReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.ER_TestReportID != null && _objSave.ER_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_ElectrolytesReports
                                           where x.ER_TestReportID != _objSave.ER_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_ElectrolytesReports.Find(_objSave.ER_TestReportID);

                        if (report != null)
                        {
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.Sodium = _objSave.Sodium;
                            report.Potassium = _objSave.Potassium;
                            report.Chloride = _objSave.Chloride;
                            report.IsActive = _objSave.IsActive;
                            report.TestDate = _objSave.TestDate;

                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strUpdatedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }
                        else
                        {
                            tbl_ElectrolytesReports _objnew = new tbl_ElectrolytesReports();
                            _objnew.ER_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            _objnew.Sodium = _objSave.Sodium;
                            _objnew.Potassium = _objSave.Potassium;
                            _objnew.Chloride = _objSave.Chloride;
                            _objnew.IsActive = _objSave.IsActive;
                            _objnew.TestDate = _objSave.TestDate;

                            context.tbl_ElectrolytesReports.Add(_objnew);
                            if (context.SaveChanges() == 1)
                            {
                                _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strAddedSuccessfully;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                            }
                            else
                            {
                                _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strFailed;
                                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
                            }
                        }

                    }
                    else
                    {
                        tbl_ElectrolytesReports _objnew = new tbl_ElectrolytesReports();
                        _objnew.ER_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.Sodium = _objSave.Sodium;
                        _objnew.Potassium = _objSave.Potassium;
                        _objnew.Chloride = _objSave.Chloride;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.TestDate = _objSave.TestDate;

                        context.tbl_ElectrolytesReports.Add(_objnew);
                        if (context.SaveChanges() == 1)
                        {
                            _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strAddedSuccessfully;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Success;
                        }
                        else
                        {
                            _msg.StatusMessage = "Electrolytes report has been" + ReadOnlyMessage.strFailed;
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
