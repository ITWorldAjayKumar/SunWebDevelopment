using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_LipidProfileReports
    {
        [DataMember]
        public Guid LPR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string TChol { get; set; }
        [DataMember]
        public string Triglycerides { get; set; }
        [DataMember]
        public string HDLChol { get; set; }
        [DataMember]
        public string LDLChol { get; set; }
        [DataMember]
        public string TCholHDL { get; set; }
        [DataMember]
        public string LDLHDLRatio { get; set; }
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
    public class DC_LipidProfileReports_Search
    {
        [DataMember]
        public Guid? LPR_TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
