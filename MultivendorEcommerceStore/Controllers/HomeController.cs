using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.BL;
using System;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private CategoryBL _categoryBL = new CategoryBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DailyDealProducts()
        {
            return View();
        }

        public ActionResult Products(Guid PId)
        {
            ProductBL productBL = new ProductBL();
            return View(productBL.ProductLists(PId));
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



        public ActionResult ProductDetail(Guid ProductID)
        {
            if (ProductID != null)
            {
                ProductBL productBL = new ProductBL();
                return View(productBL.GetProductDetails(ProductID));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}