using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class SupplierProductShopViewModel
    {
        public Guid? ProductID { get; set; }

        public Guid? SupplierID { get; set; }

        public DisplayProductViewModel Product { get; set; }

        public SupplierBusinessInfoListViewModel SupplierBusinessInfo { get; set; }

        public Pager Pager { get; set; }
    }

    public class SupplierBusinessInfoandProductsViewModel
    {
        public IEnumerable<SupplierProductShopViewModel> Supplier { get; set; }
        public Pager Pager { get; set; }
    }






























    //public Pager Pager { get; set; }

    //public IEnumerable<SupplierProductShopViewModel> Products { get; set; }




    //public Guid? SupplierID { get; set; }


    //[Display(Name = "First Name")]
    //public string CompanyName { get; set; }


    //[Display(Name = "Company Logo")]
    //public string Logo { get; set; }


    //[Display(Name = "Business Email")]
    //[EmailAddress]
    //public string BusinessEmail { get; set; }


    //[Display(Name = "Business Address")]
    //public string Address { get; set; }


    //[Display(Name = "Mobile")]
    //public string Phone { get; set; }


    //[Display(Name = "Business Experience")]
    //public string BusinessExperience { get; set; }


    //[Display(Name = "Products Type")]
    //public string ProductsType { get; set; }





    //public Guid ProductID { get; set; }

    //[Display(Name = "Category")]
    //public string CategoryName { get; set; }

    //[Display(Name = "Sub Category")]
    //public string SubCategoryName { get; set; }

    //[Display(Name = "Sub-Category Item")]
    //public string SubCategoryItemName { get; set; }


    //[Display(Name = "Product Name")]
    //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
    //[StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
    //public string ProductName { get; set; }


    //[Display(Name = "Supplier Name")]
    //public string SupplierName { get; set; }


    //[Display(Name = "Product Description")]
    //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
    //public string ProductDescription { get; set; }

    //[Display(Name = "Product Image")]
    //public string ProductImage1 { get; set; }

    //[Display(Name = "Price")]
    //public int? Price { get; set; }

    //[Display(Name = "Quantity")]
    //public int? Quantity { get; set; }

    //[Display(Name = "Size")]
    //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
    //public string Size { get; set; }

    //[Display(Name = "Status")]
    //public string Status { get; set; }

    //[Display(Name = "IsActive")]
    //public string Active { get; set; }

    //[Display(Name = "Feature")]
    //public bool? FeatureProduct { get; set; }

    //[Display(Name = "Added on")]
    //public DateTime? CreatedOn { get; set; }
}

