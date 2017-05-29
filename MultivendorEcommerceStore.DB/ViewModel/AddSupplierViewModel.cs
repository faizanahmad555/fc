using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddSupplierViewModel
    {
        public string AspNetUserID { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Password")]
        [StringLength(30, ErrorMessage = "Minimum 6 and Maximum 30 characters and Mixture of Upper and Lowercase", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Confirm Password")]
        [StringLength(30, ErrorMessage = "Minimum 6 and Maximum 30 characters and Mixture of Upper and Lowercase", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Gender")]
        public string Gender { get; set;}



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\03-?)|0)?[0-9]{10}$", ErrorMessage = "Not a valid Phone number")]
        public string MobileNumber { get; set; }


        //Improve
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Complete Address")]
        [StringLength(200, ErrorMessage = "No less than 10 & No more than 200 characters", MinimumLength = 10)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string Address { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int Country { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int State { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int City { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "CNIC")]
        [RegularExpression(@"^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "Entered CNIC format is not valid.")]
        public string CNIC { get; set; }


        //public string SupplierConfirmation { get; set; }
    }
}
