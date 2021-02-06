using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.DataAccess;
using Gallery.Framework.Base;

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

        public IEnumerable<Fee> GetFees()
        {
            IQueryable<Fee> query = DataContext.Fees;

            return query.ToList();
        }

        public IQueryable<Fee> ListFees() => DataContext.Fees;
    }
}
