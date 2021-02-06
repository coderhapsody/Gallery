using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class FactCustomerProvider : BaseProvider
	{
		public FactCustomerProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddFactCustomer(FactCustomer factCustomer)
        {
            DataContext.FactCustomers.Add(factCustomer);
            SetAuditFields(factCustomer);
            DataContext.SaveChanges();
        }

        public void UpdateFactCustomer(FactCustomer factCustomer)
        {
            DataContext.FactCustomers.Attach(factCustomer);
            DataContext.Entry(factCustomer).State = EntityState.Modified;
            SetAuditFields(factCustomer);
            DataContext.SaveChanges();
        }

        public void DeleteFactCustomer(long factCustomerId)
        {
            FactCustomer factCustomer = GetFactCustomer(factCustomerId);
            DataContext.FactCustomers.Remove(factCustomer);
            DataContext.SaveChanges();
        }

        public void DeleteFactCustomer(long[] arrayFactCustomerId)
        {
            IEnumerable<FactCustomer> factcustomers = DataContext.FactCustomers.Where(it => arrayFactCustomerId.Contains(it.Id)).ToList();
            DataContext.FactCustomers.RemoveRange(factcustomers);
            DataContext.SaveChanges();
        }

        public FactCustomer GetFactCustomer(long factCustomerId)
        {
            return DataContext.FactCustomers.Single(entity => entity.Id == factCustomerId);
        }

        public IEnumerable<FactCustomer> GetFactCustomers(bool onlyActive = true)
        {
            IQueryable<FactCustomer> query = DataContext.FactCustomers;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
