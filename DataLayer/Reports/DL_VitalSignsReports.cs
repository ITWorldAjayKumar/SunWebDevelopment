using DataContract;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Reports
{
    public class DL_VitalSignsReports : IDisposable
    {
        public void Dispose()
        { }
        public List<DC_VitalSignsReports> GetVitalSingsReports(DC_VitalSignsReports_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from x in context.tbl_VitalSignsReports select x;

                    if (_objSearch.PatientID.HasValue)
                        search = from x in search where x.PatientID == _objSearch.PatientID.Value select x;
                    if (_objSearch.VSR_TestReportID.HasValue)
                        search = from x in search where x.VSR_TestReportID == _objSearch.VSR_TestReportID.Value select x;

                    int total;
                    total = search.Count();

                    _objSearch.PageSize = _objSearch.PageSize == 0 ? 10 : _objSearch.PageSize;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = (from rs in search
                                  orderby rs.TestDate
                                  select new DC_VitalSignsReports
                                  {
                                      VSR_TestReportID = rs.VSR_TestReportID,
                                      Weight = Convert.ToString(rs.Weight),
                                      DBP = rs.DBP,
                                      PatientID = rs.PatientID,
                                      Pulse = rs.Pulse,
                                      SBP = rs.SBP,
                                      TestDate = rs.TestDate,
                                      CreatedBy = rs.CreatedBy,
                                      CreatedDate = rs.CreatedDate,
                                      EditedBy = rs.EditedBy,
                                      EditedDate = rs.EditedDate,
                                      IsActive = rs.IsActive ?? false,
                                      TotalRecord = total
                                  });
                    return result.OrderBy(p => p.CreatedDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdateVitalSingsReports(DC_VitalSignsReports _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities()) {

                    if(_objSave.VSR_TestReportID != null && _objSave.VSR_TestReportID != Guid.Empty)
                    {
                        var isDuplicate = (from x in context.tbl_VitalSignsReports
                                           where x.VSR_TestReportID != _objSave.VSR_TestReportID
                                           && x.PatientID == x.PatientID && x.TestDate == _objSave.TestDate
                                           select x).Count() == 0 ? false : true;

                        if (isDuplicate)
                        {
                            _msg.StatusMessage = "Report " + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var report = context.tbl_VitalSignsReports.Find(_objSave.VSR_TestReportID);
                        
                        if(report != null)
                        {
                         //   report.SBP
                        }



                    }

                }
            }
            catch (Exception ex) { }
            return _msg;
        }
    }
}
