using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class BusinessCategoryProvider : BaseProvider
	{
		public BusinessCategoryProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddBusinessCategory(BusinessCategory businessCategory)
        {
            DataContext.BusinessCategories.Add(businessCategory);
            SetAuditFields(businessCategory);
            DataContext.SaveChanges();
        }

        public void UpdateBusinessCategory(BusinessCategory businessCategory)
        {
            DataContext.BusinessCategories.Attach(businessCategory);
            DataContext.Entry(businessCategory).State = EntityState.Modified;
            SetAuditFields(businessCategory);
            DataContext.SaveChanges();
        }

        public void DeleteBusinessCategory(long businessCategoryId)
        {
            BusinessCategory businessCategory = GetBusinessCategory(businessCategoryId);
            DataContext.BusinessCategories.Remove(businessCategory);
            DataContext.SaveChanges();
        }

        public void DeleteBusinessCategory(long[] arrayBusinessCategoryId)
        {
            IEnumerable<BusinessCategory> businesscategories = DataContext.BusinessCategories.Where(it => arrayBusinessCategoryId.Contains(it.Id)).ToList();
            DataContext.BusinessCategories.RemoveRange(businesscategories);
            DataContext.SaveChanges();
        }

        public BusinessCategory GetBusinessCategory(long businessCategoryId)
        {
            return DataContext.BusinessCategories.Single(entity => entity.Id == businessCategoryId);
        }

        public IEnumerable<BusinessCategory> GetBusinessCategories(bool onlyActive = true)
        {
            IQueryable<BusinessCategory> query = DataContext.BusinessCategories;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
