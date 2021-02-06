using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class EmployeeProvider : BaseProvider
	{
		public EmployeeProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddEmployee(Employee employee)
        {
            DataContext.Employees.Add(employee);
            SetAuditFields(employee);
            DataContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            DataContext.Employees.Attach(employee);
            DataContext.Entry(employee).State = EntityState.Modified;
            SetAuditFields(employee);
            DataContext.SaveChanges();
        }

        public void DeleteEmployee(long employeeId)
        {
            Employee employee = GetEmployee(employeeId);
            DataContext.Employees.Remove(employee);
            DataContext.SaveChanges();
        }

        public void DeleteEmployee(long[] arrayEmployeeId)
        {
            IEnumerable<Employee> employees = DataContext.Employees.Where(it => arrayEmployeeId.Contains(it.Id)).ToList();
            DataContext.Employees.RemoveRange(employees);
            DataContext.SaveChanges();
        }

        public Employee GetEmployee(long employeeId)
        {
            return DataContext.Employees.Single(entity => entity.Id == employeeId);
        }

        public IEnumerable<Employee> GetEmployees(bool onlyActive = true)
        {
            IQueryable<Employee> query = DataContext.Employees;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
