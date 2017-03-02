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

            SupplierProfileBL supplierProfileBL = new SupplierProfileBL();
            EditSupplierViewModel viewModel = supplierProfileBL.EditSupplierProfile(UserID, SupplierID);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditSupplier(EditSupplierViewModel viewModel)
        {
            SupplierProfileBL supplierProfileBL = new SupplierProfileBL();
            supplierProfileBL.AddEditedSupplierProfile(viewModel);
            return RedirectToAction("SupplierList");
        }



        // DELETE: Supplier (Need Changes)
        [HttpGet]
        public ActionResult DeleteSupplier(Guid id)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.DeleteSupplier(id);
            return RedirectToAction("Index");
        }



        //ADD: Category
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel model)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.AddCategory(model);
            return View("AddCategory");
        }

        public ActionResult CategoryList()
        {
            AdminBL adminBL = new AdminBL();
            return View(adminBL.CategoryList());
        }


        public JsonResult StatesByCountryID(int id)
        {
            AdminBL bl = new AdminBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var states = bl.GetStatesByCountryID(id).Select(s => new
            {
                Text = s.Name,
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
                Text = s.Name,
                Id = s.CityID
            }).ToList();
            var city = new SelectList(cities, "Id", "Text");
            return Json(new { city }, JsonRequestBehavior.AllowGet);
        }

    }
}