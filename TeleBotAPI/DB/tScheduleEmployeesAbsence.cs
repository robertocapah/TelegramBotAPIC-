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
    
    public partial class tScheduleEmployeesAbsence
    {
        public int id { get; set; }
        public string txtNIK { get; set; }
        public string txtEmpName { get; set; }
        public Nullable<System.DateTime> dtDate { get; set; }
        public string workGroup { get; set; }
        public string fixWorkSchedule { get; set; }
        public Nullable<int> shiftId { get; set; }
        public string shiftCode { get; set; }
        public string shiftName { get; set; }
        public Nullable<System.DateTime> shiftIn { get; set; }
        public Nullable<System.DateTime> shiftOut { get; set; }
        public Nullable<System.DateTime> dtInserted { get; set; }
        public Nullable<System.DateTime> dtUpdated { get; set; }
    }
}
