using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class EmployeeVisitCategoryProvider : BaseProvider
	{
		public EmployeeVisitCategoryProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddEmployeeVisitCategory(EmployeeVisitCategory employeeVisitCategory)
        {
            DataContext.EmployeeVisitCategories.Add(employeeVisitCategory);
            SetAuditFields(employeeVisitCategory);
            DataContext.SaveChanges();
        }

        public void UpdateEmployeeVisitCategory(EmployeeVisitCategory employeeVisitCategory)
        {
            DataContext.EmployeeVisitCategories.Attach(employeeVisitCategory);
            DataContext.Entry(employeeVisitCategory).State = EntityState.Modified;
            SetAuditFields(employeeVisitCategory);
            DataContext.SaveChanges();
        }

        public void DeleteEmployeeVisitCategory(long employeeVisitCategoryId)
        {
            EmployeeVisitCategory employeeVisitCategory = GetEmployeeVisitCategory(employeeVisitCategoryId);
            DataContext.EmployeeVisitCategories.Remove(employeeVisitCategory);
            DataContext.SaveChanges();
        }

        public void DeleteEmployeeVisitCategory(long[] arrayEmployeeVisitCategoryId)
        {
            IEnumerable<EmployeeVisitCategory> employeevisitcategories = DataContext.EmployeeVisitCategories.Where(it => arrayEmployeeVisitCategoryId.Contains(it.Id)).ToList();
            DataContext.EmployeeVisitCategories.RemoveRange(employeevisitcategories);
            DataContext.SaveChanges();
        }

        public EmployeeVisitCategory GetEmployeeVisitCategory(long employeeVisitCategoryId)
        {
            return DataContext.EmployeeVisitCategories.Single(entity => entity.Id == employeeVisitCategoryId);
        }

        public IEnumerable<EmployeeVisitCategory> GetEmployeeVisitCategories(bool onlyActive = true)
        {
            IQueryable<EmployeeVisitCategory> query = DataContext.EmployeeVisitCategories;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
