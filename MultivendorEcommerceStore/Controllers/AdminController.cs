using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : AdminBaseController
    {
        // Dashboard
        public ActionResult Index()
        {
            var BL = new AdminDashboardBL();
            return View(BL.DashboardStats());
        }

        #region Manage Supplier

        // ADD: Supplier
        [HttpGet]
        public ActionResult AddSupplier()
        {
            AdminBL adminBL = new AdminBL();
            var countries = adminBL.GetCountries().Select(c => new
            {
                Text = c.Name,
                Value = c.CountryID
            }).ToList();
            ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
            return View();
        }
        

        // ADD: Supplier Business Information
        [HttpGet]
        public ActionResult AddBusinessInfo(string userID)
        {
            if (userID != null)
            {
                AdminBL adminBL = new AdminBL();
                ViewBag.SupplierID = adminBL.GetSupplierByUserID(userID);
                return View();
            }
            return RedirectToAction("AddSupplier", "Admin");
        }

        [HttpPost]
        public ActionResult AddBusinessInfo(AddSupplierBusinessInfoVM model)
        {
            if (model != null)
            {
                AdminBL adminBL = new AdminBL();
                adminBL.AddBusinessInfo(model);
                return View("Index");
            }
            return View();
        }



        // SHOW: All Suppliers
        [HttpGet]
        public ActionResult SupplierList()
        {
            AdminBL adminBL = new AdminBL();
            return View(adminBL.SupplierList());
        }


        // EDIT: Existing Suppliers
        [HttpGet]
        public ActionResult EditSupplier(string UserID, Guid SupplierID)
        {
            if (UserID != null && SupplierID != null)
            {
                AdminBL adminBL = new AdminBL();
                SupplierProfileBL supplierProfileBL = new SupplierProfileBL();
                var countries = adminBL.GetCountries().Select(c => new
                {
                    Text = c.Name,
                    Value = c.CountryID
                }).ToList();
                ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
                EditSupplierViewModel viewModel = supplierProfileBL.EditSupplierProfile(UserID, SupplierID);
                return View(viewModel);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        [HttpPost]
        public ActionResult EditSupplier(EditSupplierViewModel viewModel)
        {
            SupplierProfileBL supplierProfileBL = new SupplierProfileBL();
            supplierProfileBL.AddEditedSupplierProfile(viewModel);
            return RedirectToAction("SupplierList");
        }


        // DELETE: All Suppliers
        public bool DeleteSupplier(string UserID)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.DeleteSupplier(UserID);
            return true;
        }

        #endregion


        #region Manage Category

        //ADD: Category
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel model)
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryBL.AddCategory(model);
            return View("AddCategory");
        }


        //ADD: To Existing Category
        [HttpGet]
        public ActionResult AddExistingCategory()
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

        [HttpPost]
        public ActionResult AddExistingCategory(AddExistingCategoryViewModel model)
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryBL.AddExistingCategory(model);
            return RedirectToAction("AddExistingCategory");
        }


        //ADD: To Existing SubCategory
        [HttpGet]
        public ActionResult AddExistingCategoryItem()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categories = categoryBL.GetCategoriess().Select(c => new
            {
                Text = c.CategoryName,
                Value = c.CategoryID
            }).ToList();
            ViewBag.CategoryDropDown = new SelectList(categories, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult AddExistingCategoryItem(AddExistingCategoryItemViewModel model)
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryBL.AddExistingCategoryItems(model);
            return RedirectToAction("AddExistingCategoryItem");
        }


        // SHOW: All Categories
        public ActionResult CategoryLists()
        {
            CategoryBL categoryBL = new CategoryBL();
            return View(categoryBL.CategoryLists());
        }

        // SHOW: All Categories
        public ActionResult CategoryList()
        {
            CategoryBL categoryBL = new CategoryBL();
            return View(categoryBL.CategoryList());
        }


        #endregion


        #region Manage Products

        // SHOW: Products of All Suppliers
        public ActionResult ProductList()
        {
            ProductBL productBL = new ProductBL();
            return View(productBL.ProductList());
        }

        
        // EDIT: Existing Products of All Suppliers
        [HttpGet]
        public ActionResult EditProduct(Guid SupplierID, Guid ProductID)
        {
            ProductBL productBL = new ProductBL();
            EditProductViewModel viewModel = productBL.EditSupplierProduct(SupplierID, ProductID);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel viewModel)
        {
            ProductBL productBL = new ProductBL();
            productBL.AddEditedSupplierProduct(viewModel);
            return RedirectToAction("ProductList");
        }


        // DELETE: Products of All Suppliers
        [HttpGet]
        public PartialViewResult _DeleteProduct(Guid? ProductID)
        {

            /*var deleteItem = db.Items.Find(id);*/  // I'm using 'Items' as a generic term for whatever item you have

            return PartialView("Delete", ProductID);
        }

        #endregion


        #region Manage Customer

        // SHOW: All Customers
        [HttpGet]
        public ActionResult CustomerList()
        {
            CustomerBL customerBL = new CustomerBL();
            return View(customerBL.CustomerList());
        }


        // DELETE: Customers
        public bool DeleteCustomer(string UserID)
        {
            CustomerBL customerBL = new CustomerBL();
            customerBL.DeleteCustomer(UserID);
            return true;
        }
       
        #endregion


        #region ContactMessage
        // SHOW: All Contact Messages
        [HttpGet]
        public ActionResult ContactMessagesList()
        {
            var contactBL = new ContactUsBL();
            return View(contactBL.ContactMessageList());
        }


        // EDIT: Existing Contact Message
        [HttpGet]
        public ActionResult EditContactMessage(Guid ContactID)
        {
            var contactBL = new ContactUsBL();
            EditContactUsViewModel viewModel = contactBL.EditContactMessage(ContactID);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditContactMessage(EditContactUsViewModel viewModel)
        {
            var contactBL = new ContactUsBL();
            contactBL.AddEditedContactMessage(viewModel);
            return RedirectToAction("ContactMessagesList");
        }


        // DELETE: Prompt Before Delete ContactMessage
        public bool DeleteContactMessageConfirm(Guid ContactID)
        {
            ContactUsBL contactBL = new ContactUsBL();
            contactBL.DeleteContactMessage(ContactID);
            return true;
        }

        #endregion

        
    }
}