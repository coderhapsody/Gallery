using Gallery.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.ComplaintType;
using AutoMapper;
using Gallery.Framework.Base;
using Gallery.ViewModels;
using Kendo.Mvc.UI;
using Castle.Core.Internal;
using Kendo.Mvc.Extensions;
using Gallery.Web.Extensions;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class ComplaintTypeController : BaseController
    {
        private ComplaintTypeProvider complaintTypeProvider;
        private IMapper mapper;

        public ComplaintTypeController(ComplaintTypeProvider complaintTypeProvider, IMapper mapper)
        {
            this.mapper = mapper;
            this.complaintTypeProvider = complaintTypeProvider;
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
            var visitCategory = complaintTypeProvider.GetComplaintType(id);
            mapper.Map(visitCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var complaintType = new DataAccess.ComplaintType();
            mapper.Map(model, complaintType);
            try
            {
                complaintTypeProvider.UpdateComplaintType(complaintType);
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
            var complaintType = new DataAccess.ComplaintType();
            mapper.Map(model, complaintType);
            try
            {
                complaintTypeProvider.AddComplaintType(complaintType);
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
            var list = complaintTypeProvider.ListComplaintTypes();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(complaintTypeProvider.DeleteComplaintType);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}