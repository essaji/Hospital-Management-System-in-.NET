//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public employee()
        {
            this.doctors = new HashSet<doctor>();
            this.nurses = new HashSet<nurse>();
        }
    
        public long eid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<int> salary { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public Nullable<long> uid { get; set; }
    
        public virtual ICollection<doctor> doctors { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<nurse> nurses { get; set; }
    }
}
