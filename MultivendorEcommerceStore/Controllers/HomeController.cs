using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.BL;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using MultivendorEcommerceStore.Utility;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search(string search)
        {
            MultivendorEcommerceStoreEntities _db = new MultivendorEcommerceStoreEntities();

            var searchProduct = _db.Products.Where(x => x.ProductName.StartsWith(search) || x.ProductDescription.StartsWith(search) || x.Category.CategoryName.StartsWith(search)).ToList();
            return View(searchProduct);

            //_db.Products.Where(x => x.ProductName.StartsWith(search) || x.ProductDescription.StartsWith(search) || x.Category.CategoryName.StartsWith(search)).ToList()
        }

        #region Company Info

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(AddContactUsViewModel model)
        {
            ContactUsBL contactBL = new ContactUsBL();
            contactBL.AddContactMessage(model);
            return RedirectToAction("Index");
        }

        public ActionResult DeliveryInformation()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult TermsConditions()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }

        #endregion

        // SHOW: All Categories of Display Order 1
        public PartialViewResult _ShowCategories()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categorylist = categoryBL.CategoryList();
            return PartialView("_ShowCategories", categorylist);
        }



        #region Feature Products Section

        public PartialViewResult _FASHIONFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_FASHIONFeatureProducts", productList);
        }


        public PartialViewResult _SPORTSFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_SPORTSFeatureProducts", productList);
        }


        public PartialViewResult _ELECTRONICSFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_ELECTRONICSFeatureProducts", productList);
        }


        public PartialViewResult _DIGITALFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_DIGITALFeatureProducts", productList);
        }


        public PartialViewResult _FURNITUREFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_FURNITUREFeatureProducts", productList);
        }


        public PartialViewResult _JEWELRYFeatureProducts()
        {
            ProductBL productBL = new ProductBL();
            var productList = productBL.FeatureProductList();
            return PartialView("_JEWELRYFeatureProducts", productList);
        }

        #endregion


        #region Display Products According to Categories

        // SHOW: All Products According to Sub Categories
        public ActionResult Products(Guid PId, int? page)
        {
            var products = new ProductBL().ProductLists(PId);
            var pager = new Pager(products.Count(), page);
            var model = new ProductByCategoryViewModel()
            {
                Pager = pager,
                ProductsList = products.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize)
            };
            return View(model);
        }


        // SHOW: All Products According to Sub Category Items
        public ActionResult ProductSs(Guid PId, int? page)
        {
            var products = new ProductBL().ProductLists(PId);
            var pager = new Pager(products.Count(), page);
            var model = new ProductByCategoryViewModel()
            {
                Pager = pager,
                ProductsList = products.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize)
            };
            return View(model);
        }


        // SHOW: All Products Detail According to Product
        public ActionResult ProductDetail(Guid ProductID)
        {
            if (ProductID != null)
            {
                ProductBL productBL = new ProductBL();
                return View(productBL.GetProductDetails(ProductID));
            }
            else
            {
                return View("Index", "Home");
            }
        }


        // SHOW: All Products of Supplier(For Front End Side)
        [HttpGet]
        public ActionResult SupplierProducts(Guid SupplierID, int? page)
        {
            var product = new ProductBL().GetProductBySupplier(SupplierID);
            var pager = new Pager(product.Count(), page);

            var model = new SupplierBusinessInfoandProductsViewModel()
            {
                Supplier = product.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(model);
        }


        #endregion


        #region GetWishList

        // GET: WishList of Products(For Customers)
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public ActionResult WishList(int? page)
        {
            var wishList = new WishListBL().GetWishListByCustomerID(User.Identity.GetCustomerCurrentID());
            var pager = new Pager(wishList.Count(), page);
            var model = new WishListViewModel()
            {
                WishList = wishList.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
            };
            return View(model);
        }

        #endregion


        #region Get Customer Order

        [Authorize(Roles = "Customer")]
        // SHOW: Customer All Orders
        public ActionResult MyOrder()
        {
            var customerBL = new CustomerBL();
            var model = new CustomerDetailViewModel();

            model.CustomerOrders = customerBL.GetMyOrder(User.Identity.GetCustomerCurrentID());
            //model.WishList = homeBL.GetMyWishList(User.Identity.GetCustomerCurrentID());

            return View(model);
        }


        [Authorize(Roles = "Customer")]
        public ActionResult MyOrdersDetails(Guid orderID)
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
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PageNotFound", "Error", new { message = ex.Message });
            }
        }


        #endregion

    }
}