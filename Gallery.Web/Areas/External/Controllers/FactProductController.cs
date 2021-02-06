using Gallery.Framework.Base;
using Gallery.Providers.External;
using Gallery.ViewModels.External.FactProduct;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.External.Controllers
{
    public class FactProductController : BaseController
    {
        private FactProvider factProvider;

        public FactProductController(FactProvider factProvider)
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
            var data = factProvider.ListFactProducts();
            return Json(data.ToDataSourceResult(request));
        }

        public ActionResult Detail(string prodcode)
        {
            var factProduct = factProvider.GetFactProduct(prodcode);
            return View(factProduct);
        }
    }
}