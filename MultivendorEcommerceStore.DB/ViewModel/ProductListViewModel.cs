using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class ProductListViewModel
    {
        public Guid? SupplierID { get; set; }
        public Guid ProductID { get; set; }

        public Guid SubCategoryID { get; set; }
        public Guid SubCategoryItemID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }

        [Display(Name = "Sub-Category Item")]
        public string SubCategoryItemName { get; set; }


        [Display(Name = "Product Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string ProductName { get; set; }


        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }


        [Display(Name = "Product Description")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage1 { get; set; }

        [Display(Name = "Price")]
        public int? Price { get; set; }

        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        [Display(Name = "Size")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string Size { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "IsActive")]
        public string Active { get; set; }

        [Display(Name = "Feature")]
        public bool? FeatureProduct { get; set; }

        [Display(Name = "Added on")]
        public DateTime? CreatedOn { get; set; }


        public Pager Pager { get; set; }
        public IEnumerable<ProductListViewModel> Products { get; set; }

   
        public List<SupplierBusinessInfoListViewModel> SupplierBusinessInformationList = new List<SupplierBusinessInfoListViewModel>();
    }


}
