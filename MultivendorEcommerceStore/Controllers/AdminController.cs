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
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(AddSupplierViewModel SupplierViewModel) //, HttpPostedFileBase ProfilePhoto)
        {
            if (SupplierViewModel != null)
            {
                AdminBL supplierBL = new AdminBL();
                supplierBL.AddSupplier(SupplierViewModel);
                return View("Index");
            }
            return View();
        }

        // Show All Suppliers
        [HttpGet]
        public ActionResult SupplierList()
        {
            AdminBL adminBL = new AdminBL();
            return View(adminBL.SupplierList());
        }

        // Delete Supplier
        [HttpGet]
        public ActionResult DeleteSupplier(Guid id)
        {
            AdminBL adminBL = new AdminBL();
            adminBL.DeleteSupplier(id);
            return RedirectToAction("Index");
        }

    }
}