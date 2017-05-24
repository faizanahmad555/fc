using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.BL;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MultivendorEcommerceStore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

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


        // SHOW: All Categories of Display Order 1
        public PartialViewResult _ShowCategories()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categorylist = categoryBL.CategoryList();
            return PartialView("_ShowCategories", categorylist);
        }


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



        // SHOW: All Products According to Categories
        public ActionResult Products(Guid PId)
        {
            ProductBL productBL = new ProductBL();
            return View(productBL.ProductLists(PId));
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


        // SHOW: All Products of Supplier
        [HttpGet]
        public ActionResult SupplierProducts(Guid SupplierID, int? page)
        {
            var product = new ProductBL().GetProductsOfSupplier(SupplierID);
            var pager = new Pager(product.Count(), page);

            var model = new SupplierProductShopViewModel()
            {
                Products = product.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(model);
        }


        // ADD: Products to WishList(For Customers)
        [HttpPost]
        public ActionResult AddtoWishList(Guid productId)
        {
            WishListBL wishListBL = new WishListBL();
            wishListBL.AddProductstoWishList(CurrentCustomerID, productId);
            return RedirectToAction("Index");
        }


        // GET: WishList of Products(For Customers)
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public ActionResult WishList()
        {
            WishListBL wishListBL = new WishListBL();
            return View(wishListBL.GetWishListByCustomerID(CurrentCustomerID));
        }

    }
}