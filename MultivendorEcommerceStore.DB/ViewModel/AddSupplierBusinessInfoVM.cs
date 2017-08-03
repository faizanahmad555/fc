using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddSupplierBusinessInfoVM
    {
        public Guid SupplierID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Company Name")]
        [StringLength(30, ErrorMessage = "No more than 30 characters.", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string CompanyName { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Company Logo")]
        public HttpPostedFileBase Logo { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Business Email")]
        [EmailAddress]
        public string BusinessEmail { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Business Address")]
        [StringLength(200, ErrorMessage = "No more than 200 characters.", MinimumLength = 5)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string Address { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\03-?)|0)?[0-9]{11}$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Enter Business Experience Years")]
        [Display(Name = "Business Experience")]
        [StringLength(2, ErrorMessage = "No more than 2 digits.", MinimumLength = 1)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a positive number")]
        public string BusinessExperience { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Products Type")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string ProductsType { get; set; }


    }
}
