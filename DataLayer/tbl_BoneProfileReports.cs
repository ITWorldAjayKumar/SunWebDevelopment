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
    
    public partial class tbl_BoneProfileReports
    {
        public System.Guid BPR_TestReportID { get; set; }
        public System.Guid PatientID { get; set; }
        public System.DateTime TestDate { get; set; }
        public string VitaminD { get; set; }
        public string ParathyroidHormone { get; set; }
        public string Calcium { get; set; }
        public string Magnesium { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Neutrophils { get; set; }
    }
}
