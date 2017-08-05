using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_FileUploadDetails
    {
        [DataMember]
        public Guid FileUploadID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public Guid TestReportID { get; set; }
        [DataMember]
        public DateTime? TestDate { get; set; }
        [DataMember]
        public string TestType { get; set; }
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public string FileDispalyName { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
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
    public class DC_FileUploadDetails_Search
    {
        [DataMember]
        public Guid? FileUploadID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public Guid? TestReportID { get; set; }
        [DataMember]
        public DateTime? TestDate { get; set; }
        [DataMember]
        public string TestType { get; set; }
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public string FileDispalyName { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string EditedBy { get; set; }
        [DataMember]
        public DateTime? EditedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
