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
    
    public partial class mRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mRole()
        {
            this.tMenuByRoles = new HashSet<tMenuByRole>();
        }
    
        public int intRoleID { get; set; }
        public string txtRoleName { get; set; }
        public string txtCreateBy { get; set; }
        public Nullable<System.DateTime> dtCreateDate { get; set; }
        public string txtUpdateBy { get; set; }
        public Nullable<System.DateTime> dtUpdateDate { get; set; }
        public Nullable<bool> bitSuperuser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tMenuByRole> tMenuByRoles { get; set; }
    }
}
