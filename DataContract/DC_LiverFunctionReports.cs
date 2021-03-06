﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_LiverFunctionReports
    {
        [DataMember]
        public Guid LFR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string SBilirubin { get; set; }
        [DataMember]
        public string SGOT { get; set; }
        [DataMember]
        public string SGPT { get; set; }
        [DataMember]
        public string GGT { get; set; }
        [DataMember]
        public string SAlkPhosphate { get; set; }
        [DataMember]
        public string SProtein { get; set; }
        [DataMember]
        public string Albumin { get; set; }
        [DataMember]
        public string Globulin { get; set; }
        [DataMember]
        public string AGRatio { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string EditedBy { get; set; }
        [DataMember]
        public DateTime? EditedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int? TotalRecord { get; set; }
    }
    [DataContract]
    public class DC_LiverFunctionReports_Search
    {
        [DataMember]
        public Guid? LFR_TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
