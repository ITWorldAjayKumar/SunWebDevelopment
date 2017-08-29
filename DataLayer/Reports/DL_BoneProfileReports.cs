using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_BoneProfileReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_BoneProfileReports> GetBoneProfileReports(DC_BoneProfileReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_BoneProfileReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.BPR_TestReportID.HasValue)
                        search = from x in search where x.BPR_TestReportID == _objSearch.BPR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_BoneProfileReports
                                  {
                                      BPR_TestReportID = rs.BPR_TestReportID,
                                      VitaminD = rs.VitaminD,
                                      ParathyroidHormone = rs.ParathyroidHormone,
                                      PatientID = rs.PatientID,
                                      Calcium = rs.Calcium,
                                      Magnesium = rs.Magnesium,
                                      Neutrophils = rs.Neutrophils,
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
        public DC_Message AddUpdateBoneProfileReports(DC_BoneProfileReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.BPR_TestReportID != null && _objSave.BPR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_BoneProfileReports
                                           where x.BPR_TestReportID != _objSave.BPR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_BoneProfileReports.Find(_objSave.BPR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.VitaminD = _objSave.VitaminD;
                            report.ParathyroidHormone = _objSave.ParathyroidHormone;
                            report.Calcium = _objSave.Calcium;
                            report.Magnesium = _objSave.Magnesium;
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
                            tbl_BoneProfileReports _objnew = new tbl_BoneProfileReports();
                            _objnew.BPR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            report.TestDate = _objSave.TestDate;
                            report.VitaminD = _objSave.VitaminD;
                            report.ParathyroidHormone = _objSave.ParathyroidHormone;
                            report.Calcium = _objSave.Calcium;
                            report.Magnesium = _objSave.Magnesium;
                            report.IsActive = _objSave.IsActive;
                            report.CreatedBy = _objSave.CreatedBy;
                            report.CreatedDate = _objSave.CreatedDate;

                            context.tbl_BoneProfileReports.Add(_objnew);
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

                        tbl_BoneProfileReports _objnew = new tbl_BoneProfileReports();
                        _objnew.BPR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.TestDate = _objSave.TestDate;
                        _objnew.VitaminD = _objSave.VitaminD;
                        _objnew.ParathyroidHormone = _objSave.ParathyroidHormone;
                        _objnew.Calcium = _objSave.Calcium;
                        _objnew.Magnesium = _objSave.Magnesium;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        context.tbl_BoneProfileReports.Add(_objnew);
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
        public void Test() { }
    }
}
