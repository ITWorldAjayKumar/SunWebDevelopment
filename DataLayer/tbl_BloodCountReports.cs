//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_BloodCountReports
    {
        public System.Guid BCR_TestReportID { get; set; }
        public System.Guid PatientID { get; set; }
        public System.DateTime TestDate { get; set; }
        public string CBC { get; set; }
        public string WBC { get; set; }
        public string PLATELET { get; set; }
        public string MCV { get; set; }
        public string Neutrophils { get; set; }
        public string Lymphocytes { get; set; }
        public string Eosinophil { get; set; }
        public string Monocytes { get; set; }
        public string Basophils { get; set; }
        public string ESR { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
