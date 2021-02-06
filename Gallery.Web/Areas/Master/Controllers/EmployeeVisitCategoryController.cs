using AutoMapper;
using Castle.Core.Internal;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Gallery.ViewModels.EmployeeVisitCategory;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class EmployeeVisitCategoryController : BaseController
    {
        private EmployeeVisitCategoryProvider employeeVisitCategoryProvider;
        private IMapper mapper;

        public EmployeeVisitCategoryController(
            EmployeeVisitCategoryProvider employeeVisitCategoryProvider,
            IMapper mapper)
        {
            this.employeeVisitCategoryProvider = employeeVisitCategoryProvider;
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
            var unit = employeeVisitCategoryProvider.GetEmployeeVisitCategory(id);
            mapper.Map(unit, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var visitCategory = new DataAccess.EmployeeVisitCategory();
            mapper.Map(model, visitCategory);
            try
            {
                employeeVisitCategoryProvider.UpdateEmployeeVisitCategory(visitCategory);
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
            var visitCategory = new DataAccess.EmployeeVisitCategory();
            mapper.Map(model, visitCategory);
            try
            {
                employeeVisitCategoryProvider.AddEmployeeVisitCategory(visitCategory);
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
            var list = employeeVisitCategoryProvider.ListEmployeeVisitCategories();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(employeeVisitCategoryProvider.DeleteEmployeeVisitCategory);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}