using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class CategoryListViewModel
    {
        public Guid? CategoryID { get; set; }

        public Guid? SubCategoryID { get; set; }
        public Guid? SubCategoryItemID { get; set; }


        [Display(Name = "Category Picture")]
        public string CategoryPicture { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }


        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }


        [Display(Name = "Sub Category Item")]
        public string SubCategoryItem { get; set; }
    }
}
