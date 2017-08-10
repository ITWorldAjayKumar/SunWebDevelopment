using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_BoneProfileReports
    {
        [DataMember]
        public Guid BPR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string VitaminD { get; set; }
        [DataMember]
        public string ParathyroidHormone { get; set; }
        [DataMember]
        public string Calcium { get; set; }
        [DataMember]
        public string Magnesium { get; set; }
        [DataMember]
        public string Neutrophils { get; set; }
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
}
