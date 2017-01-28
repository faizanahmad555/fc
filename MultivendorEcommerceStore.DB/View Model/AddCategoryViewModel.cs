using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "No more than 50 characters", MinimumLength = 1)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Category Logo")]
        public string LogoPath { get; set; }
        public int Type { get; set; }


    }
}
