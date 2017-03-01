using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class SupplierProfileViewModel
    {
        public string UserID { get; set; }

        public Guid SupplierID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Profile Photo")]
        public string ProfilePhoto { get; set; }

        [Display(Name = "PhoneNo")]
        public string PhoneNo { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }
    }
}
