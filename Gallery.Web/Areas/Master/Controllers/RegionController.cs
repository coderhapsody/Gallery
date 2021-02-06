using AutoMapper;
using Castle.Core.Internal;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.Region;
using Gallery.Web.Extensions;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class RegionController : BaseController
    {
        private CountryProvider countryProvider;
        private RegionProvider regionProvider;
        private IMapper mapper;

        public RegionController(CountryProvider countryProvider, RegionProvider regionProvider, IMapper mapper)
        {
            this.mapper = mapper;
            this.countryProvider = countryProvider;
            this.regionProvider = regionProvider;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateEditViewModel();
            return PartialView("CreateEdit", model);
        }

        public ActionResult Edit(long id)
        {
            var model = new CreateEditViewModel();
            var visitCategory = regionProvider.GetRegion(id);
            mapper.Map(visitCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var region = new DataAccess.Region();
            mapper.Map(model, region);
            try
            {
                regionProvider.UpdateRegion(region);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            var jsonViewModel = new AjaxViewModel(true, model, null);
            return Json(jsonViewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateEditViewModel model)
        {
            var Region = new DataAccess.Region();
            mapper.Map(model, Region);
            try
            {
                regionProvider.AddRegion(Region);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            var jsonViewModel = new AjaxViewModel(true, model, null);
            return Json(jsonViewModel);
        }

        public ActionResult GetCountries()
        {
            var countries = countryProvider.GetCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List([DataSourceRequest] DataSourceRequest request)
        {
            request.RemoveDefaultSort();
            var list = regionProvider.ListRegion();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(regionProvider.DeleteRegion);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}