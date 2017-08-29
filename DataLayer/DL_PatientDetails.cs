using System;
using System.Linq;
using DataContracts;
using System.Collections.Generic;
using DataContract;
using DataLayer;

namespace DataLayer
{
    public class DL_PatientDetails : IDisposable
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
                                     AlternetMobNo = a.AlternetMobNo,
                                     Age = a.Age,
                                     Occupation = a.Occupation,
                                     Address = a.Address,
                                     Address_2 = a.Address_2,
                                     Address_3 = a.Address_3,
                                     Email_ID = a.Email_ID,
                                     PinCode = a.PinCode,
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
                            patient.AlternetMobNo = _objSave.AlternetMobNo;
                            patient.Age = _objSave.Age;
                            patient.Address = _objSave.Address;
                            patient.Address_2 = _objSave.Address_2;
                            patient.Address_3 = _objSave.Address_3;
                            patient.PinCode = _objSave.PinCode;
                            patient.Email_ID = _objSave.Email_ID;
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
                            AlternetMobNo = _objSave.AlternetMobNo,
                            Age = _objSave.Age,
                            Occupation = _objSave.Occupation,
                            Address = _objSave.Address,
                            Gender = _objSave.Gender,
                            PinCode = _objSave.PinCode,
                            Email_ID = _objSave.Email_ID,
                            Address_2 = _objSave.Address_2,
                            Address_3 = _objSave.Address_3,
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
    

        public List<DC_VitalSingsDetails> GetVitalDetails(DC_VitalDetails_Search _objSearch)
        {
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {
                    var search = from a in context.tbl_VitalSingsDetails select a;
                    if (_objSearch.TestReportID.HasValue)
                    {
                        search = from a in search where a.TestReportID == (_objSearch.TestReportID.HasValue ? _objSearch.TestReportID.Value : Guid.Empty) select a;

                    }
                    if (_objSearch.PatientID.HasValue && _objSearch.PatientID != Guid.Empty)
                    {
                        search = from a in search where a.PatientID == (_objSearch.PatientID.HasValue ? _objSearch.PatientID.Value : Guid.Empty) select a;
                    }

                    int total;

                    total = search.Count();

                    if (_objSearch.PageSize == 0)
                        _objSearch.PageSize = 10;

                    int skip = (_objSearch.PageNo ?? 0) * (_objSearch.PageSize ?? 0);

                    var canPage = skip < total;

                    var result = from a in search
                                 join p in context.tbl_PatientDetails on a.PatientID equals p.ID
                                 orderby a.CreatedDate
                                 select new DC_VitalSingsDetails
                                 {
                                     TestReportID = a.TestReportID,
                                     PatientName = p.Name,
                                     BP = a.BP,
                                     Pluse = a.Pluse,
                                     Temperature = a.Temperature,
                                     Weight = a.Weight,
                                     TestDate = a.TestDate,
                                     CreatedBy = a.CreatedBy,
                                     CreatedDate = a.CreatedDate,
                                     EditedBy = a.EditedBy,
                                     EditedDate = a.EditedDate
                                 };
                    return result.OrderBy(p => p.CreatedDate).Skip(skip).Take((_objSearch.PageSize ?? total)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DC_Message AddUpdateVitalDetails(DC_VitalSingsDetails _objSave)
        {
            DC_Message _msg = new DC_Message();
            try
            {
                using (CLMS_DBEntities context = new CLMS_DBEntities())
                {

                    if ((_objSave.PatientID != null && _objSave.PatientID != Guid.Empty) && (_objSave.TestReportID != null && _objSave.TestReportID != Guid.Empty)) //Edit
                    {
                        //var isduplicate = (from p in context.tbl_VitalSingsDetails
                        //                   where p.PatientID != _objSave.PatientID && p.TestReportID ==
                        //                   select p).Count() == 0 ? false : true;

                        //if (isduplicate)
                        //{
                        //    _msg.StatusMessage = strClassFor + ReadOnlyMessage.strAlreadyExist;
                        //    _msg.StatusCode = ReadOnlyMessage.StatusCode.Duplicate;
                        //    return _msg;
                        //}
                        var Vital = context.tbl_VitalSingsDetails.Where(p => p.PatientID == _objSave.PatientID && p.TestReportID == _objSave.TestReportID).FirstOrDefault();
                        if (Vital != null)
                        {
                            Vital.TestDate = _objSave.TestDate;
                            Vital.BP = _objSave.BP;
                            Vital.Pluse = _objSave.Pluse;
                            Vital.Weight = 232;
                            Vital.Temperature = Convert.ToDecimal(_objSave.Temperature);
                            Vital.EditedBy = _objSave.EditedBy;
                            Vital.EditedDate = DateTime.Now;
                            Vital.IsActive = _objSave.IsActive;
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

                        tbl_VitalSingsDetails _objnew = new tbl_VitalSingsDetails();
                        _objnew.TestReportID = Guid.NewGuid();
                        _objnew.TestDate = _objSave.TestDate;
                        _objnew.PatientID = _objSave.PatientID;
                        _objnew.BP = _objSave.BP;
                        _objnew.Pluse = _objSave.Pluse;
                        _objnew.Weight = 232;
                        _objnew.Temperature = Convert.ToDecimal(_objSave.Temperature);
                        _objnew.CreatedBy = _objSave.CreatedBy;
                        _objnew.CreatedDate = DateTime.Now;
                        _objnew.IsActive = _objSave.IsActive;
                        context.tbl_VitalSingsDetails.Add(_objnew);
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
            catch (Exception ex)
            {
                _msg.StatusMessage = ReadOnlyMessage.strFailed;
                _msg.StatusCode = ReadOnlyMessage.StatusCode.Failed;
            }
            return _msg;
        }

        #endregion

    }
}
