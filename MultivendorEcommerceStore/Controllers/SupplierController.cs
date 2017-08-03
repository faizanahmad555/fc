using Microsoft.AspNet.Identity;
using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultivendorEcommerceStore.Utility;

namespace MultivendorEcommerceStore.Controllers
{
    public class SupplierController : BaseController
    {
        // GET: Supplier
        [Authorize(Roles = "Supplier")]
        public ActionResult Index()
        {
            var model = new SupplierDashboardStatisticsVM();
            var supplierBL = new SupplierDashboardBL();
            var supplierID = User.Identity.GetSupplierCurrentID();

            model.SupplierProductsCount = supplierBL.GetAllProductsCount(supplierID);
            model.SupplierOrdersCount = supplierBL.GetAllOrdersCount(supplierID);

            model.SupplierProductsChart = supplierBL.GetProductsForChartForSuppliers(supplierID);
            model.SupplierOrdersChart = supplierBL.GetOrdersChartForSuppliers(supplierID);

            return View(model);
        }

        #region Supplier Profile

        // GET : Supplier Profile
        [Authorize(Roles = "Supplier")]
        [HttpGet]
        public ActionResult SupplierProfile()
        {
            UserProfileBL userProfileBL = new UserProfileBL();
            return View(userProfileBL.GetProfileByUserIdentity(User.Identity.GetCurrentUserID()));
        }


        // GET : Supplier Profile(For Admin Side)
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult SupplierProfiles(string userId)
        {
            UserProfileBL userProfileBL = new UserProfileBL();
            return View(userProfileBL.GetSupplierProfileByUserIdentity(userId));
        }

        #endregion


        #region Manage Products

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
            try
            {
                var productBL = new ProductBL();
                var model = new ProductReporViewModel();
                var supplierID = User.Identity.GetSupplierCurrentID();
                model.Products = productBL.GetProductsBySupplierID(supplierID).OrderByDescending(s => s.CreatedOn);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        //SHOW: Products According to Date Range
        [HttpPost]
        public ActionResult ProductList(ProductReporViewModel viewmodel)
        {
            try
            {
                var productBL = new ProductBL();
                var model = new ProductReporViewModel();
                var supplierID = User.Identity.GetSupplierCurrentID();
                var products = productBL.GetProductsByRange(supplierID, viewmodel.From, viewmodel.To).OrderByDescending(s => s.CreatedOn);
                model.Products = null;
                model.Products = products;
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
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

        #endregion


        #region Manage Orders


        [Authorize(Roles = "Supplier")]
        public ActionResult DisplayOrder()
        {
            try
            {
                var orderBL = new OrderBL();
                var supplierID = User.Identity.GetSupplierCurrentID();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetOrdersBySupplierID(supplierID).OrderByDescending(s => s.CreatedOn);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        //GET: Orders According to Date Range
        [HttpPost]
        public ActionResult DisplayOrder(OrderReportViewModel viewModel)
        {
            try
            {
                var orderBL = new OrderBL();
                var supplierID = User.Identity.GetSupplierCurrentID();
                var model = new OrderReportViewModel();
                model.Orders = orderBL.GetOrdersByRange(supplierID, viewModel.From, viewModel.To).OrderByDescending(s => s.CreatedOn);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }



        //Display Order detail by orderID
        [Authorize(Roles = "Supplier")]
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
                return RedirectToAction("DisplayOrder", "Supplier");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }

        #endregion


    }
}