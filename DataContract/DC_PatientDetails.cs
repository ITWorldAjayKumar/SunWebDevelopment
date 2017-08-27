using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class DC_PatientDetails
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string AlternetMobNo { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Occupation { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Address_1 { get; set; }
        [DataMember]
        public string Address_2 { get; set; }
        [DataMember]
        public string Address_3 { get; set; }
        [DataMember]
        public string Email_ID { get; set; }
        [DataMember]
        public string PinCode { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime? EditedDate { get; set; }
        [DataMember]
        public string EditedBy { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int? TotalRecord { get; set; }

    }

    [DataContract]
    public class DC_PaitentDetails_Search
    {
        [DataMember]
        public Guid? ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
