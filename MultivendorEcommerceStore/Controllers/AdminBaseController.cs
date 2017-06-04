using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class AdminBaseController : Controller
    {
        // GET: AdminBase
        public AdminBaseController()
        {
            var adminBL = new AdminBL();

            var data = new AdminLayoutViewModel();

            //data.UserCount = adminBL.GetAllUserCount();
            //data.SupplierCount = adminBL.GetSupplierCount();
            //data.CustomerCount = adminBL.GetCustomerCount();
            //data.ProductCount = adminBL.GetProductCount();
            //data.OrderCount = adminBL.GetOrderCount();
            ViewBag.LayoutData = data;
        }
    }
}