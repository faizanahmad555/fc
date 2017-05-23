using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class CustomerRegisterViewModel
    {
        public string AspNetUserID { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "First name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(30, ErrorMessage = "Minimum 6 and Maximum 30 characters and Mixture of Upper and Lowercase", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is Required")]
        [Display(Name = "Confirm Password")]
        [StringLength(30, ErrorMessage = "Minimum 6 and Maximum 30 characters and Mixture of Upper and Lowercase", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Profile Photo is Required")]
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }
        

        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\03-?)|0)?[0-9]{10}$", ErrorMessage = "Not a valid Mobile Number")]
        public string Mobile { get; set; }


        //[Required(ErrorMessage = "Country is Required")]
        [Display(Name = "Country")]
        public int? Country { get; set; }

        [Required(ErrorMessage = "State is Required")]
        [Display(Name = "State")]
        public int? State { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [Display(Name = "City")]
        public int? City { get; set; }



    }

    public class CustomerLoginViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }

    public class CustomerLoginRegisterViewModel
    {
        public CustomerLoginViewModels CustomerLoginVM { get; set; }
        public CustomerRegisterViewModel CustomerRegisterVM { get; set; }
    }
}
