using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Controllers
{
    public class FactController : Controller
    {
        // GET: Fact
        public ActionResult Index()
        {
            return View();
        }

    }
}