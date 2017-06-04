using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class DisplayProductViewModel
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



        public string UserID { get; set; }

        //public Guid? SupplierID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        //[Display(Name = "Email")]
        //public string Email { get; set; }


        //[Display(Name = "Gender")]
        //public string Gender { get; set; }

        //[Display(Name = "DOB")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? DOB { get; set; }

        [Display(Name = "Profile Photo")]
        public string ProfilePhoto { get; set; }

        //[Display(Name = "PhoneNo")]
        //public string PhoneNo { get; set; }

        //[Display(Name = "Address")]
        //public string Address { get; set; }

        //[Display(Name = "Country")]
        //public string Country { get; set; }

        //[Display(Name = "State")]
        //public string State { get; set; }

        //[Display(Name = "City")]
        //public string City { get; set; }


        public string ProductsType { get; set; }
        public string BusinessExperience { get; set; }
        public string CompanyName { get; set; }





        //public Guid ProductID { get; set; }

        //[Display(Name = "Category")]
        //public string CategoryName { get; set; }

        //[Display(Name = "Sub Category")]
        //public string SubCategoryName { get; set; }

        //[Display(Name = "Sub-Category Item")]
        //public string SubCategoryItemName { get; set; }


        //[Display(Name = "Product Name")]
        //public string ProductName { get; set; }


        //[Display(Name = "Supplier Name")]
        //public string SupplierName { get; set; }


        //[Display(Name = "Product Description")]
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

        //[Display(Name = "Status")]
        //public string Active { get; set; }

        //[Display(Name = "Added on")]
        //public DateTime? CreatedOn { get; set; }


    }
}
