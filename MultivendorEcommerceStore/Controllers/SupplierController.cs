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
    [Authorize(Roles = "Supplier")]
    public class SupplierController : Controller
    {

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }


        // GET : Supplier Profile
        [HttpGet]
        public ActionResult SupplierProfile()
        {
            string UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();

            SupplierProfileBL BL = new SupplierProfileBL();
            var profile = BL.GetProfileByUserIdentity(UserID);
            return View(profile);
        }


        // ADD: Product
        [HttpGet]
        public ActionResult AddProduct()
        {
            SupplierBL supplierBL = new SupplierBL();
            var categories = supplierBL.GetCategories().Select(c => new
            {
                Text = c.CategoryName,
                Value = c.CategoryID
            }).ToList();
            ViewBag.CategoryDropDown = new SelectList(categories, "Value", "Text");
            //ViewBag.SupplierID = supplierBL.GetSupplierByID(Id);
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel model)
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            SupplierBL supplierBL = new SupplierBL();
            supplierBL.AddProduct(model, UserId);
            return RedirectToAction("AddProduct");
        }


        // SHOW: All Products
        [HttpGet]
        public ActionResult ProductList()
        {
            SupplierBL supplierBL = new SupplierBL();
            return View(supplierBL.ProductList());
        }

        // EDIT: Existing Products
        [HttpGet]
        public ActionResult EditProduct(Guid SupplierID, Guid ProductID)
        {

            SupplierBL supplierBL = new SupplierBL();
            EditProductViewModel viewModel = supplierBL.EditSupplierProduct(SupplierID, ProductID);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel viewModel)
        {
            SupplierBL supplierBL = new SupplierBL();
            supplierBL.AddEditedSupplierProduct(viewModel);
            return RedirectToAction("ProductList");
        }


        public JsonResult SubCategoriesByCategoryID(Guid ID)
        {
            SupplierBL supplierBL = new SupplierBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var subCategory = supplierBL.GetSubCategoriesByCategoryID(ID).Select(c => new
            {
                Text = c.SubCategoryName,
                Value = c.SubCategoryID
            }).ToList();
            var subcategory = new SelectList(subCategory, "Value", "Text");
            return Json(new { subcategory }, JsonRequestBehavior.AllowGet);
        }

    }
}