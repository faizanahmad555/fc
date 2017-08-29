using MultivendorEcommerceStore.BL;
using MultivendorEcommerceStore.DB.ViewModel;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultivendorEcommerceStore.Utility;
using System.Net.Mail;
using System.Net;

namespace MultivendorEcommerceStore.Controllers
{
    public class CartController : Controller
    {

        #region Manage Cart

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

        #endregion


        #region Cash On Delivery Orders

        //public ActionResult Checkout()
        //{
        //    var cart = GetCartItems();
        //    if (cart.Any())
        //    {
        //        // Flat rate shipping
        //        int shipping = 0;

        //        // Flat rate tax 10%
        //        var taxRate = 0;

        //        var subtotal = cart.Sum(x => x.ProductDetail.Price * x.Quantity);
        //        var tax = Convert.ToInt32((subtotal + shipping) * taxRate);
        //        var total = subtotal + shipping + tax;
        //        // Create an Order object to store info about the shopping cart
        //        OrderBL orderDetailBL = new OrderBL();
        //        AddOrderViewModel orderObj = new AddOrderViewModel()
        //        {
        //            CustomerID = User.Identity.GetCustomerCurrentID(),

        //            Tax = tax,
        //            Total = total,
        //            Shipping = shipping,
        //            SubTotal = subtotal,
        //        };

        //        // Get PayPal API Context using configuration from web.config
        //        var apiContext = GetApiContext();

        //        // Create a new payment object
        //        var payment = new PayPal.Api.Payment
        //        {
        //            intent = "sale",
        //            payer = new Payer
        //            {
        //                payment_method = "paypal"
        //            },
        //            transactions = new List<Transaction>
        //            {
        //                new Transaction
        //                {
        //                    description = $"Transaction Description",
        //                    amount = new Amount
        //                    {
        //                        currency = "USD",
        //                        total = (orderObj.Total/100M).ToString(), // PayPal expects string amounts, eg. "20.00",
        //                        details = new Details()
        //                        {
        //                            subtotal = (orderObj.SubTotal/100M).ToString(),
        //                            shipping = (orderObj.Shipping/100M).ToString(),
        //                            tax = (orderObj.Tax/100M).ToString()
        //                        }
        //                    },
        //                    item_list = new ItemList()
        //                    {
        //                        items = cart.Select(x=> new Item()
        //                        {
        //                            description = x.ProductDetail.ProductName,
        //                            currency = "USD",
        //                            quantity = x.Quantity.ToString(),
        //                            price = (x.ProductDetail.Price/100M).ToString(),
        //                        }).ToList()

        //                    }
        //                }
        //            },
        //            redirect_urls = new RedirectUrls
        //            {
        //                return_url = Url.Action("Return", "Cart", null, Request.Url.Scheme),
        //                cancel_url = Url.Action("CheckoutCancel", "Cart", null, Request.Url.Scheme)
        //            }
        //        };

        //        // Send the payment to PayPal
        //        var createdPayment = payment.Create(apiContext);

        //        // Save a reference to the paypal payment
        //        orderObj.PayPalReference = createdPayment.id;

        //        // Find the Approval URL to send our user to
        //        var approvalUrl =
        //            createdPayment.links.FirstOrDefault(
        //                x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

        //        var orderID = orderDetailBL.AddOrderReturnID(orderObj);
        //        //Inserting data in OrderDetail Entity
        //        AddOrderDetailViewModel orderDetailVM = new AddOrderDetailViewModel();
        //        foreach (var item in cart)
        //        {
        //            orderDetailVM.OrderID = orderID;
        //            orderDetailVM.UnitPrice = (item.ProductDetail.Price) * item.Quantity;
        //            orderDetailVM.Quantity = item.Quantity;
        //            orderDetailVM.ProductID = item.ProductID;
        //            orderDetailBL.AddOrderDetail(orderDetailVM);
        //        }

        //        // Send the user to PayPal to approve the payment
        //        return Redirect(approvalUrl.href);






        //    }

        //    return RedirectToAction("CartIndex");



        //}




        #endregion



        #region PayPal Payment Handling

        [Authorize(Roles = "Customer")]
        public ActionResult PayPalCheckout()
        {
            var cart = GetCartItems();
            if (cart.Any())
            {
                // Flat rate shipping
                int shipping = 0;

                // Flat rate tax 10%
                var taxRate = 0;

                var subtotal = cart.Sum(x => x.ProductDetail.Price * x.Quantity);
                var tax = Convert.ToInt32((subtotal + shipping) * taxRate);
                var total = subtotal + shipping + tax;
                // Create an Order object to store info about the shopping cart
                OrderBL orderDetailBL = new OrderBL();
                AddOrderViewModel orderObj = new AddOrderViewModel()
                {
                    CustomerID = User.Identity.GetCustomerCurrentID(),

                    Tax = tax,
                    Total = total,
                    Shipping = shipping,
                    SubTotal = subtotal,
                };

                // Get PayPal API Context using configuration from web.config
                var apiContext = GetApiContext();

                // Create a new payment object
                var payment = new PayPal.Api.Payment
                {
                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"Transaction Description",
                            amount = new Amount
                            {
                                currency = "USD",
                                total = (orderObj.Total/100M).ToString(), // PayPal expects string amounts, eg. "20.00",
                                details = new Details()
                                {
                                    subtotal = (orderObj.SubTotal/100M).ToString(),
                                    shipping = (orderObj.Shipping/100M).ToString(),
                                    tax = (orderObj.Tax/100M).ToString()
                                }
                            },
                            item_list = new ItemList()
                            {
                                items = cart.Select(x=> new Item()
                                {
                                    description = x.ProductDetail.ProductName,
                                    currency = "USD",
                                    quantity = x.Quantity.ToString(),
                                    price = (x.ProductDetail.Price/100M).ToString(),
                                }).ToList()

                            }
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("Return", "Cart", null, Request.Url.Scheme),
                        cancel_url = Url.Action("CheckoutCancel", "Cart", null, Request.Url.Scheme)
                    }
                };

                // Send the payment to PayPal
                var createdPayment = payment.Create(apiContext);

                // Save a reference to the paypal payment
                orderObj.PayPalReference = createdPayment.id;

                // Find the Approval URL to send our user to
                var approvalUrl =
                    createdPayment.links.FirstOrDefault(
                        x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                var orderID = orderDetailBL.AddOrderReturnID(orderObj);
                //Inserting data in OrderDetail Entity
                AddOrderDetailViewModel orderDetailVM = new AddOrderDetailViewModel();
                foreach (var item in cart)
                {
                    orderDetailVM.OrderID = orderID;
                    orderDetailVM.UnitPrice = (item.ProductDetail.Price) * item.Quantity;
                    orderDetailVM.Quantity = item.Quantity;
                    orderDetailVM.ProductID = item.ProductID;
                    orderDetailBL.AddOrderDetail(orderDetailVM);
                }

                // Send the user to PayPal to approve the payment
                return Redirect(approvalUrl.href);






            }

            return RedirectToAction("CartIndex");
        }

        //public ActionResult Return(string payerId, string paymentId)
        //{
        //    // Fetch the existing order
        //    OrderBL orderDetailBL = new OrderBL();

        //    var order = orderDetailBL.GetOrderByPayPalReference(paymentId);
        //    var orderDetail = orderDetailBL.GetOrderDetailByOrderID(order.Id);

        //    var orderID = order.Id;

        //    //var orderNR = new OrderNotificationRepository();
        //    //var orderNE = new OrderNotification();
        //    //orderNE.OrderID = orderID;
        //    //orderNE.Description = "New Placed Order..";
        //    //orderNE.IsSeen = false;
        //    //orderNE.Timestamp = DateTime.Now;
        //    //orderNE.URL = "/Notification/OrderDetail?orderID=" + orderID;
        //    //orderNR.Insert(orderNE);
        //    // Get PayPal API Context using configuration from web.config
        //    var apiContext = GetApiContext();
        //    // Set the payer for the payment
        //    var paymentExecution = new PaymentExecution()
        //    {
        //        payer_id = payerId
        //    };

        //    // Identify the payment to execute
        //    var payment = new PayPal.Api.Payment()
        //    {
        //        id = paymentId
        //    };
        //    // Execute the Payment
        //    var executedPayment = payment.Execute(apiContext, paymentExecution);



        //    //For Email Sending
        //    //var message = new MailMessage();
        //    //message.From = new MailAddress("thefinecollectionstore@gmail.com", "Fine Collection");
        //    //message.To.Add(new MailAddress(order.CientI.Email));

        //    //message.Subject = "Your Order Details";
        //    //message.Body = "<h1>Dear, " + order.Customer.FirstName + "</h1><br><br> You Wil Recieve Your Order in next 2 - 3 Business days <br><br> Thanks <br><strong>Fine Collection</strong>";
        //    //message.IsBodyHtml = true;
        //    ////// For File Attachment..
        //    ////message.Attachments.Add(new Attachment(PathToSave));

        //    //SmtpClient SC = new SmtpClient();
        //    //SC.Credentials = new System.Net.NetworkCredential("thefinecollectionstore@gmail.com", "Pakistan@123");
        //    //SC.Host = "smtp.gmail.com";
        //    //SC.Port = 587;
        //    //SC.EnableSsl = true;
        //    //try
        //    //{
        //    //    SC.Send(message);
        //    //}
        //    //catch (Exception)
        //    //{


        //    //}



        //    //For message sending
        //    String username = "finecollection";
        //    String password = "Pakistan@123";
        //    String from = "03059337887";
        //    String to = order.Customer.Mobile;
        //    String messageBody = "Dear" + order.Customer.FirstName + "! You will receive your order in 2 - 3 business days. Thank You for shopping at Fine Collection";
        //    String URL = "http://Lifetimesms.com" +
        //    "/plain?" +
        //    "username=" + username +
        //    "&password=" + password +
        //    "&from=" + from +
        //    "&to=" + to +
        //    "&message=" + Uri.UnescapeDataString(messageBody);
        //    try
        //    {
        //        WebRequest req = WebRequest.Create(URL);
        //        WebResponse resp = req.GetResponse();


        //    }
        //    catch (Exception)
        //    {


        //    }




        //    //ClearCart();
        //    ClearCart();
        //    return RedirectToAction("Thankyou", "Cart");



        //}

        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult CartErrors(string message)
        {
            ViewBag.ErrorMessage = message;
            return View();
        }

        public ActionResult CheckoutCancel()
        {
            return View();
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }


        #endregion

    }
}