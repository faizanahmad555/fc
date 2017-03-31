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
        public Guid CategoryID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }

        [Display(Name = "Category Picture")]
        public HttpPostedFileBase Picture { get; set; }

    }
}
