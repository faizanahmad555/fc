using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult CartIndex()
        {
            return View((List<CartViewModel>)Session["Cart"]);
        }


        [HttpPost]
        public JsonResult AddItemInCart(Guid productID, int quantity = 1)
        {
            CartBL cartBL = new CartBL();
            CartViewModel cartSessionVM = new CartViewModel();
            List<CartViewModel> list1 = new List<CartViewModel>();
            //add if session is empty
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
                //add next product if product already existed and just increment quantity.
                var list2 = (List<CartViewModel>)Session["Cart"];
                if (list2.Exists(s => s.ProductID == productID))
                {
                    list2.Where(s => s.ProductID == productID).Select(/*w => w.Quantity++*/w => w.Quantity = quantity + w.Quantity).ToList();
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
            var list2 = GetCartItems();
            var product = list2.Where(s => s.ProductID == productID).FirstOrDefault();
            list2.Remove(product);
            Session["Cart"] = list2 as List<CartViewModel>;

            return Json(Session["Cart"] as List<CartViewModel>, JsonRequestBehavior.AllowGet);
        }

        private List<CartViewModel> GetCartItems()
        {
            return (List<CartViewModel>)Session["Cart"];
        }

        public void ClearCart()
        {
            Session.Remove("Cart");
        }



    }
}