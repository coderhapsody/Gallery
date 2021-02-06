using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.DataAccess;
using Gallery.Framework.Base;

namespace Gallery.Providers 
{
	public class ComplaintTypeProvider : BaseProvider
	{
		public ComplaintTypeProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddComplaintType(ComplaintType complaintType)
        {
            DataContext.ComplaintTypes.Add(complaintType);
            SetAuditFields(complaintType);
            DataContext.SaveChanges();
        }

        public void UpdateComplaintType(ComplaintType complaintType)
        {
            DataContext.ComplaintTypes.Attach(complaintType);
            DataContext.Entry(complaintType).State = EntityState.Modified;
            SetAuditFields(complaintType);
            DataContext.SaveChanges();
        }

        public void DeleteComplaintType(long complaintTypeId)
        {
            ComplaintType complaintType = GetComplaintType(complaintTypeId);
            DataContext.ComplaintTypes.Remove(complaintType);
            DataContext.SaveChanges();
        }

        public void DeleteComplaintType(long[] arrayComplaintTypeId)
        {
            IEnumerable<ComplaintType> complainttypes = DataContext.ComplaintTypes.Where(it => arrayComplaintTypeId.Contains(it.Id)).ToList();
            DataContext.ComplaintTypes.RemoveRange(complainttypes);
            DataContext.SaveChanges();
        }

        public ComplaintType GetComplaintType(long complaintTypeId)
        {
            return DataContext.ComplaintTypes.Single(entity => entity.Id == complaintTypeId);
        }

        public IEnumerable<ComplaintType> GetComplaintTypes()
        {
            IQueryable<ComplaintType> query = DataContext.ComplaintTypes;
            return query.ToList();
        }

        public IQueryable<ComplaintType> ListComplaintTypes() => DataContext.ComplaintTypes;
                
    }
}
