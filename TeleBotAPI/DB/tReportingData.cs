//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeleBotAPI.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tReportingData
    {
        public int intReportId { get; set; }
        public Nullable<int> intLeaveId { get; set; }
        public string txtNIK { get; set; }
        public string txtEmployeeName { get; set; }
        public Nullable<System.DateTime> dtAbsenceDate { get; set; }
        public Nullable<System.DateTime> dtDateIn { get; set; }
        public Nullable<System.DateTime> dtTimeIn { get; set; }
        public Nullable<System.DateTime> dtDateOut { get; set; }
        public Nullable<System.DateTime> dtTimeOut { get; set; }
        public string txtShiftCode { get; set; }
        public string txtAtdIn { get; set; }
        public string txtAtdOut { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> dtInserted { get; set; }
        public Nullable<System.DateTime> dtUpdated { get; set; }
    }
}