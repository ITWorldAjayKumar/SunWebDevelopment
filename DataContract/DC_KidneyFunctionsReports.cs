using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_KidneyFunctionsReports
    {
        [DataMember]
        public Guid KFR_TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }
        [DataMember]
        public string SCreatinine { get; set; }
        [DataMember]
        public string UrineACR { get; set; }
        [DataMember]
        public string Urea { get; set; }
        [DataMember]
        public string Bun { get; set; }
        [DataMember]
        public string SUricAcid { get; set; }
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
    public class DC_KidneyFunctionsReports_Search
    {
        [DataMember]
        public Guid? KFR_TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
