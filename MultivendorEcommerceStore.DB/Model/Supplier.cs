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
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Products = new HashSet<Product>();
            this.SupplierBusinessInformations = new HashSet<SupplierBusinessInformation>();
        }
    
        public System.Guid SupplierID { get; set; }
        public string AspNetUserID { get; set; }
        public string SupplierFirstName { get; set; }
        public string SupplierLastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string DiscountType { get; set; }
        public string DiscountRate { get; set; }
        public string TypeGoods { get; set; }
        public Nullable<bool> DiscountAvailable { get; set; }
        public Nullable<bool> CurrentOrder { get; set; }
        public string SizeURL { get; set; }
        public string ProfilePhoto { get; set; }
        public Nullable<int> Ranking { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string CNIC { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CityMaster CityMaster { get; set; }
        public virtual CountryMaster CountryMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierBusinessInformation> SupplierBusinessInformations { get; set; }
    }
}
