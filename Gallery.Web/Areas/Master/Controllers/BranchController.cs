using AutoMapper;
using Castle.Core.Internal;
using Gallery.Framework.Base;
using Gallery.Providers;
using Gallery.ViewModels;
using Gallery.ViewModels.Branch;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class BranchController : BaseController
    {
        private BranchProvider branchProvider;
        private IMapper mapper;

        public BranchController(BranchProvider branchProvider, IMapper mapper)
        {
            this.branchProvider = branchProvider;
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
            var unit = branchProvider.GetBranch(id);
            mapper.Map(unit, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var branch = new DataAccess.Branch();
            mapper.Map(model, branch);
            try
            {
                branchProvider.UpdateBranch(branch);
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
            var branch = new DataAccess.Branch();
            mapper.Map(model, branch);
            try
            {
                branchProvider.AddBranch(branch);
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
            var list = branchProvider.ListBranches();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(branchProvider.DeleteBranch);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}