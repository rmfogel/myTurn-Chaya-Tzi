//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bl.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cancelation
    {
        public int id { get; set; }
        public Nullable<int> appointmentId { get; set; }
    
        public virtual Appointment Appointment { get; set; }
    }
}
