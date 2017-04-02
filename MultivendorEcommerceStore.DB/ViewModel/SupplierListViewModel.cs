using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class SupplierListViewModel
    {
        public string AspNetUserID { get; set; }

        public Guid SupplierID { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "Profile Photo")]
        public string ProfilePhoto { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address.")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter characters only")]
        public string MobileNumber { get; set; }

        [Display(Name = "Complete Address")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 5)]
        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

        //public string SupplierConfirmation { get; set; }
    }
}
