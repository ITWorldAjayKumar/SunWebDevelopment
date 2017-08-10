using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_BloodCountReports
    {
        [DataMember]
        public Guid BCR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string CBC { get; set; }
        [DataMember]
        public string WBC { get; set; }
        [DataMember]
        public string PLATELET { get; set; }
        [DataMember]
        public string MCV { get; set; }
        [DataMember]
        public string Neutrophils { get; set; }
        [DataMember]
        public string Lymphocytes { get; set; }
        [DataMember]
        public string Eosinophil { get; set; }
        [DataMember]
        public string Monocytes { get; set; }
        [DataMember]
        public string Basophils { get; set; }
        [DataMember]
        public string ESR { get; set; }
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
