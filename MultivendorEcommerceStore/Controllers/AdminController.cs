using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
    }
}