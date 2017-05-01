using Microsoft.AspNet.Identity;
using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class SupplierController : BaseController
    {
        // GET: Supplier
        [Authorize(Roles = "Supplier")]
        public ActionResult Index()
        {
            return View();
        }


        // GET : Supplier Profile
        [Authorize(Roles = "Supplier")]
        [HttpGet]
        public ActionResult SupplierProfile()
        {
            //string UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();

            UserProfileBL userProfileBL = new UserProfileBL();
            return View(userProfileBL.GetProfileByUserIdentity(CurrentUserID));
        }

        
        // ADD: Product
        [Authorize(Roles = "Supplier")]
        [HttpGet]
        public ActionResult AddProduct()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categories = categoryBL.GetCategories().Select(c => new
            {
                Text = c.CategoryName,
                Value = c.CategoryID
            }).ToList();
            ViewBag.CategoryDropDown = new SelectList(categories, "Value", "Text");
            return View();
        }


        [Authorize(Roles = "Supplier")]
        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel model)
        {
            ProductBL productBL = new ProductBL();
            productBL.AddProduct(model, CurrentSupplierID);
            return RedirectToAction("AddProduct");
        }


        // SHOW: Current Supplier Products
        [Authorize(Roles = "Supplier")]
        [HttpGet]
        public ActionResult ProductList()
        {
            ProductBL productBL = new ProductBL();
            return View(productBL.GetProductsBySupplierID(CurrentSupplierID));
        }


        // EDIT: Existing Products
        [Authorize(Roles = "Supplier")]
        [HttpGet]
        public ActionResult EditProduct(Guid SupplierID, Guid ProductID)
        {
            ProductBL productBL = new ProductBL();
            EditProductViewModel viewModel = productBL.EditSupplierProduct(SupplierID, ProductID);
            return View(viewModel);
        }

        [Authorize(Roles = "Supplier")]
        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel viewModel)
        {
            ProductBL productBL = new ProductBL();
            productBL.AddEditedSupplierProduct(viewModel);
            return RedirectToAction("ProductList");
        }


        public bool DeleteProductConfirm(Guid ProductID)
        {
            ProductBL productBL = new ProductBL();
            productBL.DeleteProduct(ProductID);
            return true;
        }


    }
}