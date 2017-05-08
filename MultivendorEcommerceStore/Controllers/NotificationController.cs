using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult ProductDetail(Guid productID)
        {
            if (productID != null)
            {
                var notificationBL = new NotificationBL();
                var model = notificationBL.GetProductDetail(productID);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }



        [HttpPost]
        public JsonResult GetNotifications()
        {
            var bl = new NotificationBL();
            var temp = bl.GetUnSeenNotification();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public void ChangeIsSeenState(SeenNotifications model)
        {
            var bl = new NotificationBL();
            bl.ChangeIsSeenState(model);
        }




    }
}