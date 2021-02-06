using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Security.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Security/Config
        public ActionResult Index()
        {
            return View();
        }
    }
}