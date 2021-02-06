using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class FeeProvider : BaseProvider
	{
		public FeeProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddFee(Fee fee)
        {
            DataContext.Fees.Add(fee);
            SetAuditFields(fee);
            DataContext.SaveChanges();
        }

        public void UpdateFee(Fee fee)
        {
            DataContext.Fees.Attach(fee);
            DataContext.Entry(fee).State = EntityState.Modified;
            SetAuditFields(fee);
            DataContext.SaveChanges();
        }

        public void DeleteFee(long feeId)
        {
            Fee fee = GetFee(feeId);
            DataContext.Fees.Remove(fee);
            DataContext.SaveChanges();
        }

        public void DeleteFee(long[] arrayFeeId)
        {
            IEnumerable<Fee> fees = DataContext.Fees.Where(it => arrayFeeId.Contains(it.Id)).ToList();
            DataContext.Fees.RemoveRange(fees);
            DataContext.SaveChanges();
        }

        public Fee GetFee(long feeId)
        {
            return DataContext.Fees.Single(entity => entity.Id == feeId);
        }

        public IEnumerable<Fee> GetFees(bool onlyActive = true)
        {
            IQueryable<Fee> query = DataContext.Fees;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
