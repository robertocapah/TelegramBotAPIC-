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
    
    public partial class tMenuByRole
    {
        public int intMenuOptionID { get; set; }
        public Nullable<int> intRoleId { get; set; }
        public Nullable<int> intMenuId { get; set; }
        public Nullable<int> bitActive { get; set; }
    
        public virtual mMenuAndroid mMenuAndroid { get; set; }
        public virtual mRole mRole { get; set; }
    }
}