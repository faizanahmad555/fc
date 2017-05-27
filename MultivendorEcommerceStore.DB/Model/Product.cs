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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductNotifications = new HashSet<ProductNotification>();
            this.WishLists = new HashSet<WishList>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public System.Guid ProductID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public Nullable<System.Guid> SupplierID { get; set; }
        public Nullable<System.Guid> CategoryID { get; set; }
        public Nullable<System.Guid> SubCategoryID { get; set; }
        public Nullable<System.Guid> SubCategoryItemID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string UnitSize { get; set; }
        public Nullable<int> UnitPrice { get; set; }
        public Nullable<bool> FeatureProduct { get; set; }
        public Nullable<decimal> MSRP { get; set; }
        public string AvailableSize { get; set; }
        public string AvailableColor { get; set; }
        public Nullable<int> SizeID { get; set; }
        public Nullable<int> ColorID { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<float> UnitWeight { get; set; }
        public Nullable<short> UnitInStock { get; set; }
        public Nullable<short> UnitOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public Nullable<bool> ProductAvailable { get; set; }
        public Nullable<bool> DiscountAvailable { get; set; }
        public Nullable<bool> CurrentOrder { get; set; }
        public string ProductPicture { get; set; }
        public Nullable<int> Ranking { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductNotification> ProductNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WishList> WishLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
