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
    
    public partial class FAQ_Category_Condition_Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAQ_Category_Condition_Device()
        {
            this.FAQs = new HashSet<FAQ>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid ConditionId { get; set; }
        public string DeviceCode { get; set; }
        public string ImageUrl { get; set; }
        public string DeviceName { get; set; }
        public bool IsActive { get; set; }
        public short SequenceNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAQ> FAQs { get; set; }
        public virtual FAQ_Category_Condition FAQ_Category_Condition { get; set; }
    }
}
