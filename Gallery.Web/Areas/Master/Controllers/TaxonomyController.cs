using AutoMapper;
using Gallery.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.ViewModels.Taxonomy;
using Gallery.Framework.Base;
using Gallery.ViewModels;
using Kendo.Mvc.UI;
using Castle.Core.Internal;
using Kendo.Mvc.Extensions;

namespace Gallery.Web.Areas.Master.Controllers
{
    public class TaxonomyController : BaseController
    {
        private TaxonomyProvider taxonomyProvider;
        private IMapper mapper;

        public TaxonomyController(
            TaxonomyProvider taxonomyProvider,
            IMapper mapper)
        {
            this.taxonomyProvider = taxonomyProvider;
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
            var itemCategory = taxonomyProvider.GetTaxonomy(id);
            mapper.Map(itemCategory, model);

            return PartialView("CreateEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditViewModel model)
        {
            var itemCategory = new DataAccess.Taxonomy();
            mapper.Map(model, itemCategory);
            try
            {
                taxonomyProvider.UpdateItemCategory(itemCategory);
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
            var itemCategory = new DataAccess.Taxonomy();
            mapper.Map(model, itemCategory);
            try
            {
                taxonomyProvider.AddItemCategory(itemCategory);
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
            IQueryable<ListTaxonomyViewModel> list = taxonomyProvider.ListTaxonomies();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult GetParentTaxonomy(bool isAddNew = false, long excludeTaxonomyId = 0)
        {
            var taxonomies = taxonomyProvider.GetTaxonomies(
                onlyActive: isAddNew, 
                listExcludeId: new[] { excludeTaxonomyId });
            return Json(taxonomies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<long> arrayOfId)
        {
            try
            {
                arrayOfId.ForEach(taxonomyProvider.DeleteTaxonomy);
                return Json(new AjaxViewModel(true, null, null));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}