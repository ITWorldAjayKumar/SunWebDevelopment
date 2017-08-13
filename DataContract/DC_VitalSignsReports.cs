using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_VitalSignsReports
    {
        [DataMember]
        public Guid VSR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string SBP { get; set; }
        [DataMember]
        public string DBP { get; set; }
        [DataMember]
        public string Weight { get; set; }
        [DataMember]
        public string Pulse { get; set; }
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
    public class DC_VitalSignsReports_Search
    {
        [DataMember]
        public Guid? VSR_TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
