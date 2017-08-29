using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;

namespace MultivendorAdmin.Controllers
{
    public class AdminController : Controller
    {

        // Dashboard
        public ActionResult Index()
        {
            var adminBL = new AdminDashboardBL();
            var model = new DashboardStatisticsVM();

            model.UsersCount = adminBL.GetAllUsersCount();
            model.SuppliersCount = adminBL.GetAllSuppliersCount();
            model.CustomersCount = adminBL.GetAllCustomersCount();
            model.ProductsCount = adminBL.GetAllProductsCount();
            model.OrdersCount = adminBL.GetAllOrdersCount();

            model.SuppliersChart = adminBL.GetAllSuppliersForChart();
            model.CustomersChart = adminBL.GetAllCustomersForChart();
            model.ProductsChart = adminBL.GetAllProductsForChart();
            model.OrdersChart = adminBL.GetAllOrdersForChart();

            return View(model);
        }


        #region Manage Supplier

        // ADD: Supplier
        [HttpGet]
        public ActionResult AddSupplier()
        {
            try
            {
                var adminBL = new AdminBL();
                var countries = adminBL.GetCountries().Select(c => new
                {
                    Text = c.Name,
                    Value = c.CountryID
                }).ToList();
                ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        // ADD: Supplier Business Information
        [HttpGet]
        public ActionResult AddBusinessInfo(string userID)
        {
            try
            {
                if (userID != null)
                {
                    var adminBL = new AdminBL();
                    ViewBag.SupplierID = adminBL.GetSupplierByUserID(userID);
                    return View();
                }
                return RedirectToAction("AddSupplier", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddBusinessInfo(AddSupplierBusinessInfoVM model)
        {
            try
            {
                if (model != null)
                {
                    var adminBL = new AdminBL();
                    adminBL.AddBusinessInfo(model);
                    return RedirectToAction("SupplierList", "Admin");
                }
                return RedirectToAction("AddSupplier", "Admin");
            }

            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        // SHOW: All Suppliers
        [HttpGet]
        public ActionResult SupplierList()
        {
            try
            {
                var adminBL = new AdminBL();
                return View(adminBL.SupplierList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        // EDIT: Existing Suppliers
        [HttpGet]
        public ActionResult EditSupplier(string UserID, Guid SupplierID)
        {
            try
            {
                if (UserID != null && SupplierID != null)
                {
                    var adminBL = new AdminBL();
                    var supplierProfileBL = new SupplierProfileBL();
                    var countries = adminBL.GetCountries().Select(c => new
                    {
                        Text = c.Name,
                        Value = c.CountryID
                    }).ToList();
                    ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
                    EditSupplierViewModel viewModel = supplierProfileBL.EditSupplierProfile(UserID, SupplierID);
                    return View(viewModel);
                }
                return RedirectToAction("SupplierList", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult EditSupplier(EditSupplierViewModel viewModel)
        {
            try
            {
                var supplierProfileBL = new SupplierProfileBL();
                supplierProfileBL.AddEditedSupplierProfile(viewModel);
                return RedirectToAction("SupplierList", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        // DELETE: All Suppliers
        public bool DeleteSupplier(string UserID)
        {
            var adminBL = new AdminBL();
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

        //SHOW: Products of All Suppliers
        [HttpGet]
        public ActionResult ProductList()
        {
            try
            {
                var model = new ProductReporViewModel();
                var productBL = new ProductBL();

                model.Products = productBL.ProductList();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult ProductList(ProductReporViewModel viewModel)
        {
            try
            {
                var model = new ProductReporViewModel();
                var productBL = new ProductBL();
                model.Products = productBL.GetProductsByRange(viewModel.From, viewModel.To);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
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
            return RedirectToAction("ProductList", "Admin");
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
            try
            {
                var model = new CustomersReportViewModel();
                var customerBL = new CustomerBL();
                model.Customers = customerBL.CustomerList();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult CustomerList(CustomersReportViewModel viewModel)
        {
            try
            {
                var customerBL = new CustomerBL();
                var customers = customerBL.GetCustomersByRange(viewModel.From, viewModel.To).OrderByDescending(s => s.CreatedOn);
                viewModel.Customers = null;
                viewModel.Customers = customers;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        // EDIT: Existing Customers
        [HttpGet]
        public ActionResult EditCustomer(string UserID, Guid CustomerID)
        {
            try
            {
                if (UserID != null && CustomerID != null)
                {
                    var adminBL = new AdminBL();
                    EditCustomerViewModel viewModel = adminBL.EditCustomerInfo(UserID, CustomerID);
                    return View(viewModel);
                }
                return RedirectToAction("CustomerList", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        // EDIT: Save Edited Customers Info
        [HttpPost]
        public ActionResult EditCustomer(EditCustomerViewModel viewModel)
        {
            try
            {
                var adminBL = new AdminBL();
                adminBL.SaveEditedCustomerInfo(viewModel);
                return RedirectToAction("CustomerList", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        // DELETE: Customers
        public bool DeleteCustomer(string UserID)
        {
            var customerBL = new CustomerBL();
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


        #region Manage Orders

        [HttpGet]
        public ActionResult OrderList()
        {
            try
            {
                var orderBL = new OrderBL();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetAllOrders();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult OrderList(OrderReportViewModel viewModel)
        {
            try
            {
                var orderBL = new OrderBL();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetAllOrdersByRange(viewModel.From, viewModel.To);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        public ActionResult OrderDetails(Guid orderID)
        {
            try
            {
                if (orderID != null)
                {
                    var orderBL = new OrderBL();
                    var model = new OrderViewModel();
                    model.Order = orderBL.GetOrderByID(orderID);
                    model.OrderDetail = orderBL.GetOrderDetailByOrderID(orderID);
                    return View(model);
                }
                return RedirectToAction("OrderList", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        #endregion


        #region Google Maps


        public ActionResult GoogleMaps()
        {
            return View();
        }

        #endregion



        #region Generate Reports

        [HttpGet]
        public ActionResult OrderReport()
        {
            try
            {
                var orderBL = new OrderBL();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetAllOrders();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult orderreportsss(OrderReportViewModel viewModel)
        {
            try
            {
                var orderBL = new OrderBL();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetAllOrdersByRange(viewModel.From, viewModel.To);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }



        #endregion



        public ActionResult DatetimePicker()
        {
            return View();
        }


    }
}