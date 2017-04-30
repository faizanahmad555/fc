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


        public PartialViewResult _FASHIONCategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_FASHIONCategoryProducts", categoryList);
        }


        public PartialViewResult _SPORTSCategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_SPORTSCategoryProducts", categoryList);
        }


        public PartialViewResult _ELECTRONICSCategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_ELECTRONICSCategoryProducts", categoryList);
        }


        public PartialViewResult _DIGITALCategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_DIGITALCategoryProducts", categoryList);
        }


        public PartialViewResult _FURNITURECategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_FURNITURECategoryProducts", categoryList);
        }


        public PartialViewResult _JEWELRYCategoryProducts()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categoryList = categoryBL.CategoryList();
            return PartialView("_JEWELRYCategoryProducts", categoryList);
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