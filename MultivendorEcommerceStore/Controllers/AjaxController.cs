using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class AjaxController : BaseController
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }


        // GET: States By CountryID
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

        // GET: Cities By StateID
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


        #region WishList
        // ADD: Products to WishList(For Customers)
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public Guid AddtoWishList(Guid productId)
        {
            var wishListBL = new WishListBL();
            wishListBL.AddProductstoWishList(CurrentCustomerID, productId);
            return User.Identity.GetCustomerCurrentID();
        }


        [HttpPost]
        public Guid DeleteItemFromWishList(Guid wishListID)
        {
            new WishListRepository().Delete(wishListID);
            return User.Identity.GetCustomerCurrentID();
        }

        #endregion

    }
}