using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class EditProductViewModel
    {
        public Guid ProductID { get; set; }

        public Guid SupplierID { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Name")]
        [StringLength(30, ErrorMessage = "No less than 1 & No more than 30 characters", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Description")]
        [StringLength(500, ErrorMessage = "No less than 20 & No more than 500 characters", MinimumLength = 20)]
        [RegularExpression("[a-zA-Z #,-]+", ErrorMessage = "Please enter characters only")]
        public string ProductDiscription { get; set; }

        
        [Display(Name = "Product Image")]
        public HttpPostedFileBase ProductImage1 { get; set; }


        [Display(Name = "Product Image")]
        public string ProductImagePath { get; set; }


  
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Price")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a natural number")]
        [Range(typeof(int), "0", "50000", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int? UnitPrice { get; set; }



        [Required(ErrorMessage = "This feild is required")]
        [Display(Name = "Quantity")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a natural number")]
        [Range(typeof(int), "0", "100000", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int? Quantity { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Size")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string Size { get; set; }


    }
}
