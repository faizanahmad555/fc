using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddSupplierBusinessInfoVM
    {
        public Guid SupplierID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Company Name")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Business Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address.")]
        public string BusinessEmail { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Complete Address")]
        public string Address { get; set; }


        //[Required(ErrorMessage = "This field is required.")]
        //public string Country { get; set; }



        //[Required(ErrorMessage = "This field is required.")]
        //public string State { get; set; }


        //[Required(ErrorMessage = "This field is required.")]
        //public string City { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Business Experience")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string BusinessExperience { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Products Type")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string ProductsType { get; set; }
    }
}
