using Gallery.DataAccess;
using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gallery.Providers 
{
	public class EmployeeVisitResponseProvider : BaseProvider
	{
		public EmployeeVisitResponseProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddEmployeeVisitResponse(EmployeeVisitResponse employeeVisitResponse)
        {
            DataContext.EmployeeVisitResponses.Add(employeeVisitResponse);
            SetAuditFields(employeeVisitResponse);
            DataContext.SaveChanges();
        }

        public void UpdateEmployeeVisitResponse(EmployeeVisitResponse employeeVisitResponse)
        {
            DataContext.EmployeeVisitResponses.Attach(employeeVisitResponse);
            DataContext.Entry(employeeVisitResponse).State = EntityState.Modified;
            SetAuditFields(employeeVisitResponse);
            DataContext.SaveChanges();
        }

        public void DeleteEmployeeVisitResponse(long employeeVisitResponseId)
        {
            EmployeeVisitResponse employeeVisitResponse = GetEmployeeVisitResponse(employeeVisitResponseId);
            DataContext.EmployeeVisitResponses.Remove(employeeVisitResponse);
            DataContext.SaveChanges();
        }

        public void DeleteEmployeeVisitResponse(long[] arrayEmployeeVisitResponseId)
        {
            IEnumerable<EmployeeVisitResponse> employeevisitresponses = DataContext.EmployeeVisitResponses.Where(it => arrayEmployeeVisitResponseId.Contains(it.Id)).ToList();
            DataContext.EmployeeVisitResponses.RemoveRange(employeevisitresponses);
            DataContext.SaveChanges();
        }

        public EmployeeVisitResponse GetEmployeeVisitResponse(long employeeVisitResponseId)
        {
            return DataContext.EmployeeVisitResponses.Single(entity => entity.Id == employeeVisitResponseId);
        }

        public IEnumerable<EmployeeVisitResponse> GetEmployeeVisitResponses()
        {
            IQueryable<EmployeeVisitResponse> query = DataContext.EmployeeVisitResponses;
            return query.ToList();
        }

        public IQueryable<EmployeeVisitResponse> ListEmployeeVisitResponses() => DataContext.EmployeeVisitResponses;

    }
}
