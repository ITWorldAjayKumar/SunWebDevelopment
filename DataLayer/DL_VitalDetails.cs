using System;
using System.Linq;
using DataContracts;
using System.Collections.Generic;
using DataContract;
using DataLayer;

namespace DataLayer
{
    public class DL_VitalDetails : IDisposable
    {
        public static string strClassFor = "Patient ";
        public void Dispose()
        { }
        #region 
       
        public List<DC_PatientDetails> GetPatientDetails(DC_PaitentDetails_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from a in context.tbl_PatientDetails select a;
                    if (_objSearch.ID.HasValue)
                    {
                        if (_objSearch.ID.Value != Guid.Empty)
                        {
                            Guid _PatientID = Guid.Parse(Convert.ToString(_objSearch.ID));
                            search = from a in search where a.ID == _PatientID select a;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(_objSearch.Name))
                    {
                        search = from a in search where a.Name.Contains(_objSearch.Name) select a;
                    }
                    if (!string.IsNullOrWhiteSpace(_objSearch.MobileNo))
                    {
                        search = from a in search where a.Mobile == _objSearch.MobileNo select a;
                    }
                    int total;

                    total = search.Count();

                    if (_objSearch.PageSize == 0)
                        _objSearch.PageSize = 10;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = from a in search
                                 orderby a.Name
                                 select new DC_PatientDetails
                                 {
                                     ID = a.ID,
                                     Name = a.Name,
                                     Mobile = a.Mobile,
                                     Age = a.Age,
                                     Occupation = a.Occupation,
                                     Address = a.Address,
                                     Gender = a.Gender,
                                     CreatedBy = a.CreatedBy,
                                     CreatedDate = a.CreatedDate,
                                     EditedBy = a.EditedBy,
                                     EditedDate = a.EditedDate,
                                     IsActive = a.IsActive,
                                     TotalRecord = total
                                 };
                    return result.OrderBy(p => p.Name).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DC_Message AddUpdatePatientDetails(DC_PatientDetails _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    if (_objSave.ID != null && _objSave.ID != Guid.Empty) //Edit
                    {
                        var isduplicate = (from p in context.tbl_PatientDetails
                                           where p.ID != _objSave.ID && p.Name == _objSave.Name && p.Mobile == _objSave.Mobile
                                           select p).Count() == 0 ? false : true;

                        if (isduplicate)
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }
                        var patient = context.tbl_PatientDetails.Find(_objSave.ID);
                        if (patient != null)
                        {
                            patient.Name = _objSave.Name;
                            patient.Mobile = _objSave.Mobile;
                            patient.Age = _objSave.Age;
                            patient.Address = _objSave.Address;
                            patient.Occupation = _objSave.Occupation;
                            patient.Gender = _objSave.Gender;
                            patient.EditedBy = _objSave.EditedBy;
                            patient.EditedDate = DateTime.Now;
                            patient.IsActive = _objSave.IsActive;
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
                        var isduplicate = (from p in context.tbl_PatientDetails
                                           where p.Name == _objSave.Name && p.Mobile == _objSave.Mobile
                                           select p).Count() == 0 ? false : true;

                        if (isduplicate)
                        {
                            _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAlreadyExist;
                            _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                            return _msg;
                        }

                        tbl_PatientDetails _objP = new tbl_PatientDetails
                        {
                            ID = Guid.NewGuid(),
                            Name = _objSave.Name,
                            Mobile = _objSave.Mobile,
                            Age = _objSave.Age,
                            Occupation = _objSave.Occupation,
                            Address = _objSave.Address,
                            Gender = _objSave.Gender,
                            CreatedBy = _objSave.CreatedBy,
                            CreatedDate = DateTime.Now,
                            IsActive = _objSave.IsActive,
                        };
                        context.tbl_PatientDetails.Add(_objP);
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
        public DC_Message AddUpdateVitalSignDetails(DC_VitalSingsDetails _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    if (_objSave.TestReportID != null && _objSave.TestReportID != Guid.Empty) //Edit
                    {
                        var isExist = (from p in context.tbl_VitalSingsDetails
                                       where p.TestReportID != _objSave.TestReportID
                                       select p).Count() == 0 ? false : true;



                    }
                    else //Add
                    {

                        tbl_VitalSingsDetails _objP = new tbl_VitalSingsDetails
                        {
                            TestReportID = Guid.NewGuid(),
                            PatientID = _objSave.PatientID,
                            BP = _objSave.BP,
                            Weight = Convert.ToDecimal(_objSave.Weight),
                            Temperature = Convert.ToDecimal(_objSave.Temperature),
                            Pluse = _objSave.Pluse,
                            CreatedBy = _objSave.CreatedBy,
                            CreatedDate = DateTime.Now,
                            IsActive = _objSave.IsActive,
                        };
                        context.tbl_VitalSingsDetails.Add(_objP);
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
