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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.OrderHistories = new HashSet<OrderHistory>();
        }
    
        public System.Guid OrderID { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }
        public Nullable<int> TransactionNumber { get; set; }
        public Nullable<System.Guid> ShipperID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ShippingAddress { get; set; }
        public string PayPalReference { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
