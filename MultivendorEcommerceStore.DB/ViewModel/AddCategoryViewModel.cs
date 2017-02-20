using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddCategoryViewModel
    {

        [Required(ErrorMessage = "This filed is required")]
        [StringLength(50, ErrorMessage = "No more than 50 characters", MinimumLength = 1)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }


        [Display(Name = "Sub Category Item")]
        public string SubCategoryItem { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Category Picture")]
        public string Picture { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
