using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class DC_VitalSingsDetails
    {
        [DataMember]
        public Guid TestReportID { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }

        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public string BP { get; set; }
        [DataMember]
        public decimal? Weight { get; set; }
        [DataMember]
        public decimal? Temperature { get; set; }
        [DataMember]
        public string Pluse { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public string EditedBy { get; set; }
        [DataMember]
        public DateTime? EditedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public int? TotalRecord { get; set; }
    }

    [DataContract]
    public class DC_VitalSingsDetails_History
    {
        [DataMember]
        public Guid TestReport_HistoryID { get; set; }
        [DataMember]
        public Guid TestReportID { get; set; }
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public string BP { get; set; }
        [DataMember]
        public string Weight { get; set; }
        [DataMember]
        public string Temperature { get; set; }
        [DataMember]
        public string Pluse { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public string EditedBy { get; set; }
        [DataMember]
        public DateTime? EditedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
    [DataContract]
    public class DC_VitalDetails_Search
    {
        [DataMember]
        public Guid? TestReportID { get; set; }
        [DataMember]
        public Guid? PatientID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
        [DataMember]
        public DateTime? TestDate { get; set; }
    }
}
