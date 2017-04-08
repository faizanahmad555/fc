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
        public List<CategoryEntity> listCategoryEntity = new List<CategoryEntity>();
    }


    public class CategoryEntity
    {
        public Guid? CategoryID { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Picture")]
        public string CategoryPicture { get; set; }

        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }

        public List<SubCategoryEntity> listSubCategoryEntity = new List<SubCategoryEntity>();
    }


    public class SubCategoryEntity
    {
        public Guid? SubCategoryID { get; set; }

        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }

        public List<SubCategoryItemEntity> listSubCategoryItemEntity = new List<SubCategoryItemEntity>();
    }

    public class SubCategoryItemEntity
    {
        public Guid? SubCategoryItemID { get; set; }

        [Display(Name = "Sub Category Item")]
        public string SubCategoryItemName { get; set; }
    }

}
