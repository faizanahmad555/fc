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
    
    public partial class SubCategoryItem
    {
        public System.Guid SubCategoryItemID { get; set; }
        public Nullable<System.Guid> SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Link { get; set; }
    
        public virtual SubCategory SubCategory { get; set; }
    }
}
