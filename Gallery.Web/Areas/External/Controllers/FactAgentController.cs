using Gallery.Framework.Base;
using Gallery.Providers.External;
using Gallery.ViewModels.External.FactAgent;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.External.Controllers
{
    public class FactAgentController : BaseController
    {
        private FactProvider factProvider;

        public FactAgentController(FactProvider factProvider)
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
            var data = factProvider.ListFactAgents();
            return Json(data.ToDataSourceResult(request));
        }

        public ActionResult Detail(string agentcode)
        {
            var factAgent = factProvider.GetFactAgent(agentcode);
            return View(factAgent);
        }
    }
}