using AutoMapper;
using Castle.Core.Internal;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Gallery.ViewModels.EmployeeVisitResponse;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class EmployeeVisitResponseController : BaseController
    {
        private EmployeeVisitResponseProvider employeeVisitResponseProvider;
        private IMapper mapper;

        public EmployeeVisitResponseController(
            EmployeeVisitResponseProvider employeeVisitResponseProvider, 
            IMapper mapper)
        {
            this.employeeVisitResponseProvider = employeeVisitResponseProvider;
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
            var unit = employeeVisitResponseProvider.GetEmployeeVisitResponse(id);
            mapper.Map(unit, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var visitResponse = new DataAccess.EmployeeVisitResponse();
            mapper.Map(model, visitResponse);
            try
            {
                employeeVisitResponseProvider.UpdateEmployeeVisitResponse(visitResponse);
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
            var visitResponse = new DataAccess.EmployeeVisitResponse();
            mapper.Map(model, visitResponse);
            try
            {
                employeeVisitResponseProvider.AddEmployeeVisitResponse(visitResponse);
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
            var list = employeeVisitResponseProvider.ListEmployeeVisitResponses();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(employeeVisitResponseProvider.DeleteEmployeeVisitResponse);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}