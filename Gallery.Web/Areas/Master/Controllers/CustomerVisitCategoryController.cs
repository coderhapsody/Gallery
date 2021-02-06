using AutoMapper;
using Gallery.Framework.Base;
using Gallery.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.CustomerVisitCategory;
using Gallery.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Castle.Core.Internal;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class CustomerVisitCategoryController : BaseController
    {
        private CustomerVisitCategoryProvider customerVisitCategoryProvider;
        private IMapper mapper;

        public CustomerVisitCategoryController(
            CustomerVisitCategoryProvider customerVisitCategoryProvider,
            IMapper mapper)
        {
            this.customerVisitCategoryProvider = customerVisitCategoryProvider;
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
            var visitCategory = customerVisitCategoryProvider.GetCustomerVisitCategory(id);
            mapper.Map(visitCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var visitCategory = new DataAccess.CustomerVisitCategory();
            mapper.Map(model, visitCategory);
            try
            {
                customerVisitCategoryProvider.UpdateCustomerVisitCategory(visitCategory);
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
            var visitCategory = new DataAccess.CustomerVisitCategory();
            mapper.Map(model, visitCategory);
            try
            {
                customerVisitCategoryProvider.AddCustomerVisitCategory(visitCategory);
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
            var list = customerVisitCategoryProvider.ListCustomerVisitCategories();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(customerVisitCategoryProvider.DeleteCustomerVisitCategory);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}