using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class EditSupplierViewModel
    {
        public string AspNetUserID { get; set; }

        public Guid SupplierID { get; set; }


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


       
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfilePhotoPath { get; set; }




        [Display(Name = "Email")]
        public string Email { get; set; }


        //Improve
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
        [Display(Name = "Gender")]
        public string Gender { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Country")]
        public int CountryID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "State")]
        public int StateID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "City")]
        public int CityID { get; set; }
        


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "CNIC")]
        [RegularExpression(@"^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "Entered CNIC format is not valid.")]
        public string CNIC { get; set; }

    }
}
