using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class CustomerListViewModel
    {
        public string AspNetUserID { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile #")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter characters only")]
        public string Phone { get; set; }

        [Display(Name = "Added on")]
        public DateTime? CreatedOn { get; set; }


    }
}
