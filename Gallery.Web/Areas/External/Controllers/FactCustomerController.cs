using Gallery.Framework.Base;
using Gallery.Providers.External;
using Gallery.ViewModels.External.FactCustomer;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.External.Controllers
{
    public class FactCustomerController : BaseController
    {
        private FactProvider factProvider;

        public FactCustomerController(FactProvider factProvider)
        {
            this.factProvider = factProvider;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        [OutputCache(Duration = 30)]
        public ActionResult List([DataSourceRequest] DataSourceRequest request)
        {
            var data = factProvider.ListFactCustomers();
            return Json(data.ToDataSourceResult(request));
        }

        public ActionResult Detail(string custcode)
        {
            var factCustomer = factProvider.GetFactCustomer(custcode);
            return View(factCustomer);
        }
    }
}