using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_BloodCountReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_BloodCountReports> GetBloodCountReports(DC_BloodCountReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_BloodCountReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.BCR_TestReportID.HasValue)
                        search = from x in search where x.BCR_TestReportID == _objSearch.BCR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_BloodCountReports
                                  {
                                      BCR_TestReportID = rs.BCR_TestReportID,
                                      PatientID = rs.PatientID,
                                      TestDate = rs.TestDate,
                                      CBC = rs.CBC,
                                      WBC = rs.WBC,
                                      PLATELET = rs.PLATELET,
                                      MCV = rs.MCV,
                                      Neutrophils = rs.Neutrophils,
                                      Lymphocytes = rs.Lymphocytes,
                                      Eosinophil =rs.Eosinophil,
                                      Monocytes = rs.Monocytes,
                                      Basophils = rs.Basophils,
                                      ESR = rs.ESR,
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
        public DC_Message AddUpdateBloodCountReports(DC_BloodCountReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if (_objSave.BCR_TestReportID != null && _objSave.BCR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_BloodCountReports
                                           where x.BCR_TestReportID != _objSave.BCR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_BloodCountReports.Find(_objSave.BCR_TestReportID);

                        if (report != null)
                        {
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            report.EditedBy = _objSave.EditedBy;
                            report.EditedDate = _objSave.EditedDate;
                            report.CBC = _objSave.CBC;
                            report.WBC = _objSave.WBC;
                            report.PLATELET = _objSave.PLATELET;
                            report.MCV = _objSave.MCV;
                            report.Neutrophils = _objSave.Neutrophils;
                            report.Lymphocytes = _objSave.Lymphocytes;
                            report.Eosinophil = _objSave.Eosinophil;
                            report.Monocytes = _objSave.Monocytes;
                            report.Basophils = _objSave.Basophils;
                            report.ESR = _objSave.ESR;
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
                            tbl_BloodCountReports _objnew = new tbl_BloodCountReports();
                            _objnew.BCR_TestReportID = Guid.NewGuid();
                            _objnew.PatientID = _objSave.PatientID;
                            report.TestDate = _objSave.TestDate;
                            report.IsActive = _objSave.IsActive;
                            _objnew.CreatedBy = _objSave.CreatedBy;
                            _objnew.CreatedDate = _objSave.CreatedDate;
                            report.CBC = _objSave.CBC;
                            report.WBC = _objSave.WBC;
                            report.PLATELET = _objSave.PLATELET;
                            report.MCV = _objSave.MCV;
                            report.Neutrophils = _objSave.Neutrophils;
                            report.Lymphocytes = _objSave.Lymphocytes;
                            report.Eosinophil = _objSave.Eosinophil;
                            report.Monocytes = _objSave.Monocytes;
                            report.Basophils = _objSave.Basophils;
                            report.ESR = _objSave.ESR;

                            context.tbl_BloodCountReports.Add(_objnew);
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
                        tbl_BloodCountReports _objnew = new tbl_BloodCountReports();
                        _objnew.BCR_TestReportID = Guid.NewGuid();
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.TestDate = _objSave.TestDate;
                        _objnew.IsActive = _objSave.IsActive;
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = _objSave.CreatedDate;
                        _objnew.CBC = _objSave.CBC;
                        _objnew.WBC = _objSave.WBC;
                        _objnew.PLATELET = _objSave.PLATELET;
                        _objnew.MCV = _objSave.MCV;
                        _objnew.Neutrophils = _objSave.Neutrophils;
                        _objnew.Lymphocytes = _objSave.Lymphocytes;
                        _objnew.Eosinophil = _objSave.Eosinophil;
                        _objnew.Monocytes = _objSave.Monocytes;
                        _objnew.Basophils = _objSave.Basophils;
                        _objnew.ESR = _objSave.ESR;

                        context.tbl_BloodCountReports.Add(_objnew);
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
