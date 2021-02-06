using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Framework.Base;
using Gallery.DataAccess;

namespace Gallery.Providers 
{
	public class TaxonomyProvider : BaseProvider
	{
		public TaxonomyProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddItemCategory(Taxonomy taxonomy)
        {
            DataContext.Taxonomies.Add(taxonomy);
            SetAuditFields(taxonomy);
            DataContext.SaveChanges();
        }

        public void UpdateItemCategory(Taxonomy taxonomy)
        {
            DataContext.Taxonomies.Attach(taxonomy);
            DataContext.Entry(taxonomy).State = EntityState.Modified;
            SetAuditFields(taxonomy);
            DataContext.SaveChanges();
        }

        public void DeleteTaxonomy(long taxonomyId)
        {
            Taxonomy Taxonomy = GetTaxonomy(taxonomyId);
            DataContext.Taxonomies.Remove(Taxonomy);
            DataContext.SaveChanges();
        }

        public void DeleteItemCategory(long[] arrayItemCategoryId)
        {
            IEnumerable<Taxonomy> itemcategories = DataContext.Taxonomies.Where(it => arrayItemCategoryId.Contains(it.Id)).ToList();
            DataContext.Taxonomies.RemoveRange(itemcategories);
            DataContext.SaveChanges();
        }

        public Taxonomy GetTaxonomy(long taxonomyId)
        {
            return DataContext.Taxonomies.Single(entity => entity.Id == taxonomyId);
        }

        public IEnumerable<Taxonomy> GetTaxonomies(bool onlyActive = true, long[] listExcludeId = null)
        {
            DataContext.DisableProxyCreation();
            IQueryable<Taxonomy> query = DataContext.Taxonomies;

            if (onlyActive)
                query = query.Where(it => it.Active);

            if (listExcludeId != null)
                query = query.Where(it => !listExcludeId.Contains(it.Id));

            return query.ToList();
        }

        public IQueryable<ViewModels.Taxonomy.ListTaxonomyViewModel> ListTaxonomies() => 
            from taxonomy in DataContext.Taxonomies
            select new ViewModels.Taxonomy.ListTaxonomyViewModel
            {
                Id = taxonomy.Id,
                Name = taxonomy.Name,
                ParentId = taxonomy.ParentTaxonomyId,
                Parent = taxonomy.ParentTaxonomy.Name,
                Active = taxonomy.Active,
                ChangedWhen = taxonomy.ChangedWhen,
                CreatedWhen = taxonomy.CreatedWhen,
                CreatedWho = taxonomy.CreatedWho,
                ChangedWho = taxonomy.ChangedWho
            };
    }
}
