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


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }



        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfilePhotoPath { get; set; }




        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }


        [Display(Name = "Complete Address")]
        public string Address { get; set; }


        public string Country { get; set; }



        public string State { get; set; }


        public string City { get; set; }


        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }


        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

    }
}
