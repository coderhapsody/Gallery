using Gallery.DataAccess;
using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            IEnumerable<EmployeeVisitCategory> employeevisitCategorys = DataContext
                .EmployeeVisitCategories
                .Where(it => arrayEmployeeVisitCategoryId.Contains(it.Id))
                .ToList();
            DataContext.EmployeeVisitCategories.RemoveRange(employeevisitCategorys);
            DataContext.SaveChanges();
        }

        public EmployeeVisitCategory GetEmployeeVisitCategory(long employeeVisitCategoryId)
        {
            return DataContext.EmployeeVisitCategories.Single(entity => entity.Id == employeeVisitCategoryId);
        }

        public IEnumerable<EmployeeVisitCategory> GetEmployeeVisitCategories()
        {
            IQueryable<EmployeeVisitCategory> query = DataContext.EmployeeVisitCategories;
            return query.ToList();
        }

        public IQueryable<EmployeeVisitCategory> ListEmployeeVisitCategories() => DataContext.EmployeeVisitCategories;

    }
}
