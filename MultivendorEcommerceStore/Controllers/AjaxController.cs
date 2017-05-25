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


        [HttpPost]
        public JsonResult AddItemInCart(Guid productID, int quantity = 1)
        {
            CartBL cartBL = new CartBL();
            CartViewModel cartSessionVM = new CartViewModel();
            List<CartViewModel> list1 = new List<CartViewModel>();
            if (Session["Cart"] == null)
            {
                cartSessionVM.ProductID = productID;
                cartSessionVM.Quantity = quantity;
                cartSessionVM.ProductDetail = cartBL.GetProductByID(productID);
                list1.Add(cartSessionVM);
                Session["Cart"] = list1 as List<CartViewModel>;
            }
            else
            {
                var list2 = (List<CartViewModel>)Session["Cart"];
                if (list2.Exists(s => s.ProductID == productID))
                {
                    list2.Where(s => s.ProductID == productID).Select(w => w.Quantity++).ToList();

                    Session["Cart"] = list2 as List<CartViewModel>;
                }
                else
                {
                    cartSessionVM.ProductID = productID;
                    cartSessionVM.Quantity = quantity;
                    cartSessionVM.ProductDetail = cartBL.GetProductByID(productID);
                    list2.Add(cartSessionVM);
                    Session["Cart"] = list2 as List<CartViewModel>;
                }
            }
            return Json(Session["Cart"] as List<CartViewModel>, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItemFromCart(Guid productID)
        {
            var list2 = (List<CartViewModel>)Session["Cart"];
            var product = list2.Where(s => s.ProductID == productID).FirstOrDefault();
            //list2.Select(s => s.Count--).ToList();
            list2.Remove(product);
            //if (list2.Any())
            //{
            //    Session["Cart"] = list2 as List<CartSessionViewModel>;
            //}
            //else
            //{
            //    Session["Cart"] = null;
            //}
            Session["Cart"] = list2 as List<CartViewModel>;

            return Json(Session["Cart"] as List<CartViewModel>, JsonRequestBehavior.AllowGet);
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
        public Guid AddtoWishList(Guid? productId)
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