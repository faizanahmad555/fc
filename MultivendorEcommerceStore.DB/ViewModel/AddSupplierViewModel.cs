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

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "Password is required.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Confirm Password")]
        [StringLength(50, ErrorMessage = "Password and Confirm Password do not match.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter characters only")]
        public string MobileNumber { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Complete Address")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 5)]
        public string Address { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int Country { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        public int State { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int City { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

        //public string SupplierConfirmation { get; set; }
    }
}
