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

        //Create Category
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(AddCategoryViewModel CategoryViewModel, HttpPostedFileBase LogoPath)
        {
            String status = _categoryBL.CreateCategory(CategoryViewModel, LogoPath);
            ViewBag.StatusMessage = status;
            return View();
        }

        //public ActionResult ShowCategory()
        //{
        //    ICategoryRepository
        //}

    }
}