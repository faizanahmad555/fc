//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultivendorEcommerceStore.DB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tracking
    {
        public System.Guid TrackingID { get; set; }
        public Nullable<System.Guid> ShipperID { get; set; }
        public string TrackingNumber { get; set; }
    }
}
