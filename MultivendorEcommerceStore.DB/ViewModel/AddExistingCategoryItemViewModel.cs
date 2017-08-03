using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddExistingCategoryItemViewModel
    {
        [Display(Name = "Category")]
        public Guid CategoryID { get; set; }

        [Display(Name = "Sub Category")]
        public Guid SubCategoryID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Sub Category Item")]
        [StringLength(20, ErrorMessage = "No less than 1 & No more than 20 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string SubCategoryItem { get; set; }
    }
}
