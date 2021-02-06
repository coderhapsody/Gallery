using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Security.Controllers
{
    public class RoleAccessController : BaseController
    {
        // GET: Security/RoleAccess
        public ActionResult Index()
        {
            return View();
        }
    }
}