using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Controllers
{
    public class BrowseController : BaseController
    {
        // GET: Browse
        public ActionResult Index()
        {
            return View();
        }
    }
}