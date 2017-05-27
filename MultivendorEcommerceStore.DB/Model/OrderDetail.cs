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
    
    public partial class OrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDetail()
        {
            this.ReturnRequests = new HashSet<ReturnRequest>();
        }
    
        public System.Guid OrderDetailID { get; set; }
        public Nullable<System.Guid> OrderID { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public Nullable<int> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnRequest> ReturnRequests { get; set; }
        public virtual Order Order { get; set; }
    }
}
