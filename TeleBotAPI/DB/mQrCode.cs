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
    
    public partial class mQrCode
    {
        public int intQrId { get; set; }
        public string txtCode { get; set; }
        public Nullable<System.DateTime> dtDate { get; set; }
        public string mOutletId { get; set; }
        public string txtOutletName { get; set; }
        public Nullable<int> bitActive { get; set; }
        public Nullable<System.DateTime> dtInserted { get; set; }
        public string txtInsertedBy { get; set; }
        public Nullable<System.DateTime> dtUpdated { get; set; }
        public string txtUpdatedBy { get; set; }
    }
}