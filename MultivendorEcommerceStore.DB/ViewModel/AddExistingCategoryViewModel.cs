using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddExistingCategoryViewModel
    {
        [Display(Name = "Category")]
        public Guid CategoryID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Sub Category")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Category Picture")]
        public HttpPostedFileBase Picture { get; set; }

    }
}
