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
        public Guid CategoryID { get; set; }
        public Guid SubCategoryID { get; set; }

        [Required]
        [Display(Name = "Sub Category Item")]
        public string SubCategoryItem { get; set; }
    }
}
