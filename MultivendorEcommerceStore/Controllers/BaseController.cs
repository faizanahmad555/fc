using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultivendorEcommerceStore.Utility;
using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;

namespace MultivendorEcommerceStore.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            CurrentUserID = System.Web.HttpContext.Current.User.Identity.GetCurrentUserID();

            CurrentSupplierID = System.Web.HttpContext.Current.User.Identity.GetSupplierCurrentID();

            CurrentCustomerID = System.Web.HttpContext.Current.User.Identity.GetCustomerCurrentID();


            var userProfileBL = new UserProfileBL();

            var userData = new UserProfileViewModel();

            // GET: Current User Profile
            userData = userProfileBL.GetProfileByUserIdentity(CurrentUserID);

            ViewBag.LayoutModel = userData;

        }

        public string CurrentUserID { get; set; }

        public Guid CurrentSupplierID { get; set; }
        
        public Guid CurrentCustomerID { get; set; }



    }
}