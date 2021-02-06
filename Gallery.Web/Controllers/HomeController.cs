using Gallery.DataAccess;
using Gallery.Framework.Attributes;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IOwinContext owinContext;
        private readonly SecurityProvider securityProvider;

        public HomeController(IOwinContext context, SecurityProvider securityProvider)
        {
            this.owinContext = context;
            this.securityProvider = securityProvider;
        }

        public ActionResult About()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            ViewBag.VersionNumber = currentAssembly.GetName().Version.ToString(3);
            ViewBag.Copyright = versionInfo.LegalCopyright;
            return PartialView();
        }

        [HttpGet]
        [ImportModelStateFromTempData]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ExportModelStateToTempData]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (securityProvider.ValidateUser(CurrentUserName, model.OldPassword))
                {
                    securityProvider.ChangePassword(CurrentUserName, model.NewPassword);
                    return RedirectToAction("ChangePasswordConfirmation");
                }
                ModelState.AddModelError(this.GetType().FullName, "Unable to validate current password");
            }
            return RedirectToAction("ChangePassword");
        }

        public ActionResult ChangePasswordConfirmation() => View();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(System.Web.Mvc.FormCollection form)
        {
            string userName = form["username"];
            string password = form["password"];
            if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(password))
            {
                if (true || securityProvider.ValidateUser(userName, password))
                {
                    UserLogin userLogin = securityProvider.LogInUser(userName);
                    var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) },
                                    "ApplicationCookie",
                                    ClaimTypes.Name,
                                    ClaimTypes.Role);

                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, userLogin.Role.Name));

                    var authenticationProperties = new AuthenticationProperties { IsPersistent = false };
                    owinContext.Authentication.SignIn(authenticationProperties, claimsIdentity);
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("Login", "Invalid User Name or Password");
            return View();
        }

        public ActionResult LogOut()
        {
            owinContext.Authentication.SignOut();
            return RedirectToAction("Index");
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult GetRootMenus()
        {
            var rootMenus = securityProvider.ListMenus(null);
            return PartialView("_RootMenus", rootMenus);
        }

        public ActionResult GetMenus(int parentMenuId)
        {
            var rootMenus = securityProvider.ListMenus(parentMenuId);
            return PartialView("_Menus", rootMenus);
        }

        //[HttpPost]
        //public ActionResult ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    return RedirectToAction("ChangePassword");
        //}
    }
}
