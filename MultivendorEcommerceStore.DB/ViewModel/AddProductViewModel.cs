using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddProductViewModel
    {
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid SubCategoryID { get; set; }
        public Guid SubCategoryItemID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Description")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Product Image")]
        public HttpPostedFileBase ProductImage1 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Price")]
        // [DataType(DataType.Currency)]
        public int Price { get; set; }


        [Required(ErrorMessage = "This feild is required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Size")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string Size { get; set; }


        [Display(Name = "Apply For Feature?")]
        public bool FeatureProduct { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Quantity Per Unit")]
        //public string QuantityPerUnit { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Unit Size")]
        //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        //[StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        //public string UnitSize { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Available Size")]
        //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        //[StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        //public string AvailableSize { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Available Color")]
        //[DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        //[StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        //public string AvailableColor { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //public string Discount { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //public string Note { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Product Available")]
        //public string ProductAvailable { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Discount Available")]
        //public string DiscountAvailable { get; set; }


    }
}
