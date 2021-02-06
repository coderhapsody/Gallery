using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class CustomerOccupationProvider : BaseProvider
	{
		public CustomerOccupationProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddCustomerOccupation(CustomerOccupation customerOccupation)
        {
            DataContext.CustomerOccupations.Add(customerOccupation);
            SetAuditFields(customerOccupation);
            DataContext.SaveChanges();
        }

        public void UpdateCustomerOccupation(CustomerOccupation customerOccupation)
        {
            DataContext.CustomerOccupations.Attach(customerOccupation);
            DataContext.Entry(customerOccupation).State = EntityState.Modified;
            SetAuditFields(customerOccupation);
            DataContext.SaveChanges();
        }

        public void DeleteCustomerOccupation(long customerOccupationId)
        {
            CustomerOccupation customerOccupation = GetCustomerOccupation(customerOccupationId);
            DataContext.CustomerOccupations.Remove(customerOccupation);
            DataContext.SaveChanges();
        }

        public void DeleteCustomerOccupation(long[] arrayCustomerOccupationId)
        {
            IEnumerable<CustomerOccupation> customeroccupations = DataContext.CustomerOccupations.Where(it => arrayCustomerOccupationId.Contains(it.Id)).ToList();
            DataContext.CustomerOccupations.RemoveRange(customeroccupations);
            DataContext.SaveChanges();
        }

        public CustomerOccupation GetCustomerOccupation(long customerOccupationId)
        {
            return DataContext.CustomerOccupations.Single(entity => entity.Id == customerOccupationId);
        }

        public IEnumerable<CustomerOccupation> GetCustomerOccupations(bool onlyActive = true)
        {
            IQueryable<CustomerOccupation> query = DataContext.CustomerOccupations;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
