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

        public ActionResult Login()
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

        public ActionResult Products()
        {
            ProductBL productBL = new ProductBL();
            return View(productBL.ProductList());
        }


        public PartialViewResult _ShowCategories()
        {
            CategoryBL categoryBL = new CategoryBL();
            var categorylist = categoryBL.CategoryList();
            return PartialView("_ShowCategories", categorylist);
        }

    }
}