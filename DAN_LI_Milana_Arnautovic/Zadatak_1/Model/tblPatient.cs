//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPatient
    {
        public int PatientID { get; set; }
        public string FullName { get; set; }
        public string JMBG { get; set; }
        public string MedicalRecord { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public Nullable<int> SickLeaveID { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual tblSickLeave tblSickLeave { get; set; }
    }
}
