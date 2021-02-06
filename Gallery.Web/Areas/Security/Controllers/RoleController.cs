using AutoMapper;
using Gallery.Framework.Base;
using Gallery.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.Role;
using Gallery.ViewModels;
using Kendo.Mvc.UI;
using Castle.Core.Internal;
using Kendo.Mvc.Extensions;
using Gallery.Web.Extensions;

namespace Gallery.Web.Areas.Security.Controllers
{
    public class RoleController : BaseController
    {
        private SecurityProvider securityProvider;
        private IMapper mapper;

        public RoleController(SecurityProvider securityProvider, IMapper mapper)
        {
            this.mapper = mapper;
            this.securityProvider = securityProvider;
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
            var visitCategory = securityProvider.GetRole(id);
            mapper.Map(visitCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var role = new DataAccess.Role();
            mapper.Map(model, role);
            try
            {
                securityProvider.UpdateRole(role);
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
            var role = new DataAccess.Role();
            mapper.Map(model, role);
            try
            {
                securityProvider.AddRole(role);
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
            request.RemoveDefaultSort();
            IQueryable<DataAccess.Role> list = securityProvider.ListRoles();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(securityProvider.DeleteRole);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}