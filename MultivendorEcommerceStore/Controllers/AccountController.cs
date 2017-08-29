using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MultivendorEcommerceStore.Models;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.BL;
using System.Data.SqlClient;
using System.Web.Hosting;
using System.IO;
using System.Configuration;

namespace MultivendorEcommerceStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public static string EConfUser { get; set; }
        public static string connection = GetConnectionString("DefaultConnection");
        public static string command = null;
        public static string parameterName = null;
        public static string methodName = null;
        string codeType = null;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }






        #region CustomerLogin & Register

        // GET: /Account/CustomerLogin
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            AdminBL adminBL = new AdminBL();
            var countries = adminBL.GetCountries().Select(c => new
            {
                Text = c.Name,
                Value = c.CountryID
            }).ToList();
            ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
            return View();
        }


        // POST: /Account/CustomerLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(CustomerLoginRegisterViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.CustomerLoginVM.Email, model.CustomerLoginVM.Password, model.CustomerLoginVM.RememberMe, shouldLockout: false);
            var user = await UserManager.FindAsync(model.CustomerLoginVM.Email, model.CustomerLoginVM.Password);
            switch (result)
            {
                case SignInStatus.Success:

                    if (UserManager.IsInRole(user.Id, "Customer"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.CustomerLoginVM.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }




        // POST: /Account/CustomerRegister
        [HttpPost/*, ActionName("Login")*/]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CustomerRegister(CustomerLoginRegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.CustomerRegisterVM.EmailAddress, Email = model.CustomerRegisterVM.EmailAddress };
            var result = await UserManager.CreateAsync(user, model.CustomerRegisterVM.Password);

            if (result.Succeeded)
            {
                CustomerBL customerBL = new CustomerBL();
                UserManager.AddToRole(user.Id, "Customer");
                model.CustomerRegisterVM.AspNetUserID = user.Id;
                customerBL.CustomerRegister(model);
                await SignInManager.SignInAsync(user, isPersistent: true, rememberBrowser: true);
                return RedirectToAction("Index", "Home");
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //return RedirectToAction("Index", "Home");
            }
            AddErrors(result);

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Login", "Home");
        }


        #endregion


        #region AdminLogin

        // GET: /Account/AdminLogin
        [AllowAnonymous]
        public ActionResult AdminLogin(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // POST: /Account/AdminLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdminLogin(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            var user = await UserManager.FindAsync(model.Email, model.Password);
            switch (result)
            {
                case SignInStatus.Success:
                    if (model.Email == "finecollectionstore@gmail.com")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        #endregion



        #region SuppierLogin & AddSupplier

        // GET: /Account/SupplierLogin
        [AllowAnonymous]
        public ActionResult SupplierLogin(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // POST: /Account/SupplierLogin(Only When Email is Confirmed)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SupplierLogin(SupplierLoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var custEmailConf = EmailConfirmation(model.Email);
            var custUserName = FindUserName(model.Email);
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            var user = await UserManager.FindAsync(model.Email, model.Password);
            if (custEmailConf == false && custUserName != null && result.ToString() == "Success")
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                EConfUser = model.Email;
                return RedirectToAction("EmailConfirmationFailed", "Account");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                if (ModelState.IsValid)
                {
                    switch (result)
                    {
                        case SignInStatus.Success:
                            if (UserManager.IsInRole(user.Id, "Supplier"))
                            {
                                return RedirectToAction("Index", "Supplier");
                            }
                            //UpdateLastLoginDate(model.LoginUsername);
                            return RedirectToLocal(returnUrl);
                        case SignInStatus.LockedOut:
                            return View("Lockout");
                        case SignInStatus.RequiresVerification:
                            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                        case SignInStatus.Failure:
                        default:
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return View(model);
                    }
                }
                // If we got this far, something failed, redisplay form
                return View("SupplierLogin", "Account");
            }
        }


        // POST: Add Supplier and Send Confirmation Email
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSupplier(AddSupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var custEmail = FindEmail(model.Email);
                var custUserName = FindUserName(model.Email);
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                if (custEmail == null && custUserName == null)
                {
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        AdminBL adminBL = new AdminBL();
                        UserManager.AddToRole(user.Id, "Supplier");
                        model.AspNetUserID = user.Id;
                        adminBL.AddSupplier(model);

                        //// Send an email with this link
                        codeType = "EmailConfirmation";
                        await SendEmail("ConfirmEmail", "Account", user, model.Email, "WelcomeEmail", "Confirm your account");
                        return RedirectToAction("AddBusinessInfo", "Admin", new { userID = user.Id });

                        //return RedirectToAction("ConfirmationEmailSent", "Account");
                    }
                    AddErrors(result);
                }
                else
                {
                    if (custEmail != null)
                    {
                        ModelState.AddModelError("", "Email is already registered.");
                    }
                    if (custUserName != null)
                    {
                        ModelState.AddModelError("", "Username " + model.Email.ToLower() + " is already taken.");
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // POST: /Account/SupplierLogin(Without Confirming Email)
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SupplierLogin(SupplierLoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // This doesn't count login failures towards account lockout
        //    // To enable password failures to trigger account lockout, change to shouldLockout: true
        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    var user = await UserManager.FindAsync(model.Email, model.Password);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:

        //            if (UserManager.IsInRole(user.Id, "Supplier"))
        //            {
        //                return RedirectToAction("Index", "Supplier");
        //            }
        //            return RedirectToLocal(returnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //            return View(model);
        //    }
        //}


        //// Add Supplier Without Confirmating Email
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AddSupplier(AddSupplierViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            AdminBL adminBL = new AdminBL();
        //            UserManager.AddToRole(user.Id, "Supplier");
        //            model.AspNetUserID = user.Id;
        //            adminBL.AddSupplier(model);
        //            return RedirectToAction("AddBusinessInfo", "Admin", new { userID = user.Id });
        //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //            //return RedirectToAction("Index", "Home");
        //        }
        //        AddErrors(result);
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return RedirectToAction("AddSupplier", "Admin");
        //}



        #endregion



        #region Send Confirmation Email


        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, DateTime date, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("ConfirmationLinkExpired", "Account");
            }
            var emailConf = EmailConfirmationById(userId);
            if (emailConf == true)
            {
                return RedirectToAction("ConfirmationLinkUsed", "Account");
            }
            if (date != null)
            {
                if (date.AddMinutes(10) < DateTime.Now)
                {
                    return RedirectToAction("ConfirmationLinkExpired", "Account");
                }
                else
                {
                    var result = await UserManager.ConfirmEmailAsync(userId, code);
                    return View(result.Succeeded ? "ConfirmEmail" : "Error");
                }
            }
            else
            {
                return View("Error");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendConfirmationMail()
        {
            string res = null;
            string connection = GetConnectionString("DefaultConnection");
            using (SqlConnection myConnection = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand("SELECT Email AS Email FROM AspNetUsers WHERE UserName = @UserName", myConnection))
            {
                cmd.Parameters.AddWithValue("@UserName", EConfUser);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        if (reader.Read())
                        {
                            // To avoid unexpected bugs access columns by name.
                            res = reader["Email"].ToString();
                            var user = await UserManager.FindByEmailAsync(res);
                            //UpdateEmailLinkDate(EConfUser);
                            codeType = "EmailConfirmation";
                            await SendEmail("ConfirmEmail", "Account", user, res, "WelcomeEmail", "Confirm your account");
                        }
                        myConnection.Close();
                    }
                }
            }
            return RedirectToAction("ConfirmationEmailSent", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult EmailConfirmationFailed()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmationEmailSent()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmationLinkExpired()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmationLinkUsed()
        {
            return View();
        }


        public async Task SendEmail(string actionName, string controllerName, ApplicationUser user, string email, string emailTemplate, string emailSubject)
        {
            string code = null;
            if (codeType == "EmailConfirmation")
            {
                code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            }
            else if (codeType == "ResetPassword")
            {
                code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            }
            var callbackUrl = Url.Action(actionName, controllerName, new { userId = user.Id, date = DateTime.Now, code = code }, protocol: Request.Url.Scheme);
            var message = await EMailTemplate(emailTemplate);
            message = message.Replace("@ViewBag.Name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.UserName));
            message = message.Replace("@ViewBag.Link", callbackUrl);
            await MessageServices.SendEmailAsync(email, emailSubject, message);
        }


        #endregion


        //GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        #region Forgot Password

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null /*|| !(await UserManager.IsEmailConfirmedAsync(user.Id))*/)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPassword");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion





        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        UserManager.AddToRole(user.Id, "Customer");
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }



        public static async Task<string> EMailTemplate(string template)
        {
            var templateFilePath = HostingEnvironment.MapPath("~/Content/templates/") + template + ".cshtml";
            StreamReader objstreamreaderfile = new StreamReader(templateFilePath);
            var body = await objstreamreaderfile.ReadToEndAsync();
            objstreamreaderfile.Close();
            return body;
        }

        public static string GetConnectionString(string connection)
        {
            return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
        }

        public static string ReturnString(string str)
        {
            string strOut = null;
            using (SqlConnection myConnection = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(command, myConnection))
            {
                cmd.Parameters.AddWithValue(parameterName, str);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            if (methodName == "FindEmail")
                            {
                                strOut = reader["Email"].ToString();
                            }
                            else if (methodName == "FindUserName" || methodName == "FindUserNameById")
                            {
                                strOut = reader["UserName"].ToString();
                            }
                            else if (methodName == "FindUserId")
                            {
                                strOut = reader["UserId"].ToString();
                            }
                        }
                        myConnection.Close();
                    }
                    return strOut;
                }
            }
        }
        public static string FindEmail(string email)
        {
            command = "SELECT Email AS Email FROM AspNetUsers WHERE Email = @Email";
            parameterName = "@Email";
            methodName = "FindEmail";
            return ReturnString(email);
        }
        public string FindUserName(string username)
        {
            command = "SELECT UserName AS UserName FROM AspNetUsers WHERE UserName = @UserName";
            parameterName = "@UserName";
            methodName = "FindUserName";
            return ReturnString(username);
        }
        public string FindUserNameById(string userid)
        {
            command = "SELECT UserName AS UserName FROM AspNetUsers WHERE Id = @Id";
            parameterName = "@Id";
            methodName = "FindUserNameById";
            return ReturnString(userid);
        }
        public string FindUserId(string userprokey)
        {
            command = "SELECT UserId AS UserId FROM AspNetUserLogins WHERE ProviderKey = @ProviderKey";
            parameterName = "@ProviderKey";
            methodName = "FindUserId";
            return ReturnString(userprokey);
        }


        public bool ReturnBool(string str)
        {
            bool econfOut = false;
            string res = null;
            using (SqlConnection myConnection = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(command, myConnection))
            {
                cmd.Parameters.AddWithValue(parameterName, str);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            res = reader["EmailConfirmed"].ToString();
                            if (res == "False")
                            {
                                econfOut = false;
                            }
                            else
                            {
                                econfOut = true;
                            }
                        }
                        myConnection.Close();
                    }
                    return econfOut;
                }
            }
        }
        public bool EmailConfirmation(string username)
        {
            command = "SELECT EmailConfirmed AS EmailConfirmed FROM AspNetUsers WHERE UserName = @UserName";
            parameterName = "@UserName";
            return ReturnBool(username);
        }
        public bool EmailConfirmationById(string userid)
        {
            command = "SELECT EmailConfirmed AS EmailConfirmed FROM AspNetUsers WHERE Id = @Id";
            parameterName = "@Id";
            return ReturnBool(userid);
        }

        public static int UpdateDatabase(string username)
        {
            using (SqlConnection myConnection = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(command, myConnection))
            {
                cmd.Parameters.AddWithValue(parameterName, username);
                myConnection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}