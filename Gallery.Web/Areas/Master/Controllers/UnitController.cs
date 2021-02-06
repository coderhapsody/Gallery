using AutoMapper;
using Castle.Core.Internal;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Gallery.ViewModels.Unit;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class UnitController : BaseController
    {
        private UnitProvider unitProvider;
        private IMapper mapper;

        public UnitController(UnitProvider unitProvider, IMapper mapper)
        {
            this.unitProvider = unitProvider;
            this.mapper = mapper;
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
            var unit = unitProvider.GetUnit(id);
            mapper.Map(unit, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var unit = new DataAccess.Unit();
            mapper.Map(model, unit);
            try
            {
                unitProvider.UpdateUnit(unit);
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
            var unit = new DataAccess.Unit();
            mapper.Map(model, unit);
            try
            {
                unitProvider.AddUnit(unit);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            var jsonViewModel = new AjaxViewModel(true, model, null);
            return Json(jsonViewModel);
        }

        public ActionResult List([DataSourceRequest] DataSourceRequest request)
        {
            var list = unitProvider.ListUnits();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(unitProvider.DeleteUnit);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}