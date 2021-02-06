using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class FactProductProvider : BaseProvider
	{
		public FactProductProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddFactProduct(FactProduct factProduct)
        {
            DataContext.FactProducts.Add(factProduct);
            SetAuditFields(factProduct);
            DataContext.SaveChanges();
        }

        public void UpdateFactProduct(FactProduct factProduct)
        {
            DataContext.FactProducts.Attach(factProduct);
            DataContext.Entry(factProduct).State = EntityState.Modified;
            SetAuditFields(factProduct);
            DataContext.SaveChanges();
        }

        public void DeleteFactProduct(long factProductId)
        {
            FactProduct factProduct = GetFactProduct(factProductId);
            DataContext.FactProducts.Remove(factProduct);
            DataContext.SaveChanges();
        }

        public void DeleteFactProduct(long[] arrayFactProductId)
        {
            IEnumerable<FactProduct> factproducts = DataContext.FactProducts.Where(it => arrayFactProductId.Contains(it.Id)).ToList();
            DataContext.FactProducts.RemoveRange(factproducts);
            DataContext.SaveChanges();
        }

        public FactProduct GetFactProduct(long factProductId)
        {
            return DataContext.FactProducts.Single(entity => entity.Id == factProductId);
        }

        public IEnumerable<FactProduct> GetFactProducts(bool onlyActive = true)
        {
            IQueryable<FactProduct> query = DataContext.FactProducts;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
