using Gallery.DataAccess;
using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gallery.Providers 
{
	public class CustomerVisitCategoryProvider : BaseProvider
	{
		public CustomerVisitCategoryProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddCustomerVisitCategory(CustomerVisitCategory customerVisitCategory)
        {
            DataContext.CustomerVisitCategories.Add(customerVisitCategory);
            SetAuditFields(customerVisitCategory);
            DataContext.SaveChanges();
        }

        public void UpdateCustomerVisitCategory(CustomerVisitCategory customerVisitCategory)
        {
            DataContext.CustomerVisitCategories.Attach(customerVisitCategory);
            DataContext.Entry(customerVisitCategory).State = EntityState.Modified;
            SetAuditFields(customerVisitCategory);
            DataContext.SaveChanges();
        }

        public void DeleteCustomerVisitCategory(long customerVisitCategoryId)
        {
            CustomerVisitCategory customerVisitCategory = GetCustomerVisitCategory(customerVisitCategoryId);
            DataContext.CustomerVisitCategories.Remove(customerVisitCategory);
            DataContext.SaveChanges();
        }

        public void DeleteCustomerVisitCategory(long[] arrayCustomerVisitCategoryId)
        {
            IEnumerable<CustomerVisitCategory> customervisitcategories = DataContext.CustomerVisitCategories.Where(it => arrayCustomerVisitCategoryId.Contains(it.Id)).ToList();
            DataContext.CustomerVisitCategories.RemoveRange(customervisitcategories);
            DataContext.SaveChanges();
        }

        public CustomerVisitCategory GetCustomerVisitCategory(long customerVisitCategoryId)
        {
            return DataContext.CustomerVisitCategories.Single(entity => entity.Id == customerVisitCategoryId);
        }

        public IEnumerable<CustomerVisitCategory> GetCustomerVisitCategories(bool onlyActive = true)
        {
            IQueryable<CustomerVisitCategory> query = DataContext.CustomerVisitCategories;

            return query.ToList();
        }

        public IQueryable<CustomerVisitCategory> ListCustomerVisitCategories() => DataContext.CustomerVisitCategories;

    }
}
