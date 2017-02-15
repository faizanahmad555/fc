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
    public class AdminController : Controller
    {
        // Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // Admin Login
        public ActionResult Login()
        {
            return View();
        }


        // Add Supplier
        [HttpGet]
        public ActionResult AddSupplier()
        {
            AdminBL adminBL = new AdminBL();
            var countries = adminBL.GetCountries().Select(c => new
            {
                Text = c.CountryName,
                Value = c.CountryID
            }).ToList();
            ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
            return View();
        }
       

        // Show All Suppliers
        [HttpGet]
        public ActionResult SupplierList()
        {
            AdminBL adminBL = new AdminBL();
            return View(adminBL.SupplierList());
        }

        // Delete Supplier (Need Changes)
        [HttpGet]
        public ActionResult DeleteSupplier(Guid id)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.DeleteSupplier(id);
            return RedirectToAction("Index");
        }



        //Add Category
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel model) //, HttpPostedFileBase Picture)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.AddCategory(model); //, Picture);
            return View("AddCategory");
        }


        public JsonResult StatesByCountryID(int id)
        {
            AdminBL bl = new AdminBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var states = bl.GetStatesByCountryID(id).Select(s => new
            {
                Text = s.StateName,
                Id = s.StateID
            }).ToList();
            var state = new SelectList(states, "Id", "Text");
            return Json(new { state }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CitesByStateID(int id)
        {
            AdminBL bl = new AdminBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var cities = bl.GetCitiesByStateID(id).Select(s => new
            {
                Text = s.CityName,
                Id = s.CityID
            }).ToList();
            var city = new SelectList(cities, "Id", "Text");
            return Json(new { city }, JsonRequestBehavior.AllowGet);
        }

    }
}