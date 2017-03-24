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


        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Display(Name = "Product Discription")]
        public string ProductDiscription { get; set; }


        [Display(Name = "Product Image")]
        public HttpPostedFileBase ProductImage1 { get; set; }


        [Display(Name = "Product Image")]
        public string ProductImagePath { get; set; }


        [Display(Name = "Price")]
        public int? UnitPrice { get; set; }


        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }


        [Display(Name = "Size")]
        public string Size { get; set; }


    }
}
