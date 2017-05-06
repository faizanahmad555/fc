﻿using System;
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
        [StringLength(30, ErrorMessage = "No less than 1 & No more than 30 characters", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter characters only")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Description")]
        [StringLength(500, ErrorMessage = "No less than 20 & No more than 500 characters", MinimumLength = 20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter characters only")]
        public string ProductDescription { get; set; }




        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Long Description")]
        [StringLength(1000, ErrorMessage = "No more than 1000 characters.", MinimumLength = 30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter characters only")]
        public string ProductLongDescription { get; set; }



        //Improve
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Product Image")]
        public HttpPostedFileBase ProductImage1 { get; set; }


        //Improve
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Price")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Price must be positive Numbers only.")]
        [Range(typeof(int), "0", "50000", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int Price { get; set; }



        [Required(ErrorMessage = "This feild is required")]
        [Display(Name = "Quantity")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Quantity must be positive numbers only.")]
        [Range(typeof(int), "0", "100000", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Size")]
        [DataType(DataType.Text, ErrorMessage = "Please enter characters only")]
        public string Size { get; set; }

       
        [Display(Name = "Apply For Feature?")]
        public bool FeatureProduct { get; set; }

       
    }
}
