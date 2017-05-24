using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class SupplierBusinessInfoListViewModel
    {
        public Guid? SupplierID { get; set; }


        [Display(Name = "First Name")]
        public string CompanyName { get; set; }


        [Display(Name = "Company Logo")]
        public string Logo { get; set; }


        [Display(Name = "Business Email")]
        [EmailAddress]
        public string BusinessEmail { get; set; }


        [Display(Name = "Business Address")]
        public string Address { get; set; }


        [Display(Name = "Mobile")]
        public string Phone { get; set; }


        [Display(Name = "Business Experience")]
        public string BusinessExperience { get; set; }


        [Display(Name = "Products Type")]
        public string ProductsType { get; set; }

    }
}
