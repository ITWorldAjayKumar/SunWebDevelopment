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
    
    public partial class tbl_LipidProfileReports
    {
        public System.Guid LPR_TestReportID { get; set; }
        public System.Guid PatientID { get; set; }
        public System.DateTime TestDate { get; set; }
        public string TChol { get; set; }
        public string Triglycerides { get; set; }
        public string HDLChol { get; set; }
        public string LDLChol { get; set; }
        public string TCholHDL { get; set; }
        public string LDLHDLRatio { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
