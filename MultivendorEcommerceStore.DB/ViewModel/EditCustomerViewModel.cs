using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class EditCustomerViewModel
    {
        public string AspNetUserID { get; set; }
        public Guid CustomerID { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "First name is Required")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Profile Photo is Required")]
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }


        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Address { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\03-?)|0)?[0-9]{10}$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }

    }
}
