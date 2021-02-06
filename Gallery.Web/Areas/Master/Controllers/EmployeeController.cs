using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Master/Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}