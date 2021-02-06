
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class BranchProvider : BaseProvider
	{
		public BranchProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddBranch(Branch branch)
        {
            DataContext.Branches.Add(branch);
            SetAuditFields(branch);
            DataContext.SaveChanges();
        }

        public void UpdateBranch(Branch branch)
        {
            DataContext.Branches.Attach(branch);
            DataContext.Entry(branch).State = EntityState.Modified;
            SetAuditFields(branch);
            DataContext.SaveChanges();
        }

        public void DeleteBranch(long branchId)
        {
            Branch branch = GetBranch(branchId);
            DataContext.Branches.Remove(branch);
            DataContext.SaveChanges();
        }

        public void DeleteBranch(long[] arrayBranchId)
        {
            IEnumerable<Branch> branches = DataContext.Branches.Where(it => arrayBranchId.Contains(it.Id)).ToList();
            DataContext.Branches.RemoveRange(branches);
            DataContext.SaveChanges();
        }

        public Branch GetBranch(long branchId)
        {
            return DataContext.Branches.Single(entity => entity.Id == branchId);
        }

        public IEnumerable<Branch> GetBranches(bool onlyActive = true)
        {
            IQueryable<Branch> query = DataContext.Branches;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
