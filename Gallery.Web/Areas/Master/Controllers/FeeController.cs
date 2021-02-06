using AutoMapper;
using Gallery.Framework.Base;
using Gallery.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.Fee;
using Gallery.ViewModels;
using Kendo.Mvc.UI;
using Castle.Core.Internal;
using Kendo.Mvc.Extensions;
using Gallery.Web.Extensions;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class FeeController : BaseController
    {
        private FeeProvider feeProvider;
        private IMapper mapper;

        public FeeController(FeeProvider feeProvider, IMapper mapper)
        {
            this.mapper = mapper;
            this.feeProvider = feeProvider;
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
            var visitCategory = feeProvider.GetFee(id);
            mapper.Map(visitCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var fee = new DataAccess.Fee();
            mapper.Map(model, fee);
            try
            {
                feeProvider.UpdateFee(fee);
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
            var fee = new DataAccess.Fee();
            mapper.Map(model, fee);
            try
            {
                feeProvider.AddFee(fee);
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
            IQueryable<DataAccess.Fee> list = feeProvider.ListFees();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(feeProvider.DeleteFee);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}