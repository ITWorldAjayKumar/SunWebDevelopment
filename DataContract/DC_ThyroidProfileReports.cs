using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_ThyroidProfileReports
    {
        [DataMember]
        public Guid TPR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string FreeT3 { get; set; }
        [DataMember]
        public string FreeT4 { get; set; }
        [DataMember]
        public string TSH { get; set; }
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
    }
    [DataContract]
    public class DC_ThyroidProfileReports_Search
    {
        [DataMember]
        public Guid? TPR_TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
