using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class DisplayContactUsViewModel
    {
        public Guid? ContactID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Added On")]
        public DateTime? CreatedOn { get; set; }
    }
}
