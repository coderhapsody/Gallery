using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class ProjectProvider : BaseProvider
	{
		public ProjectProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddProject(Project project)
        {
            DataContext.Projects.Add(project);
            SetAuditFields(project);
            DataContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            DataContext.Projects.Attach(project);
            DataContext.Entry(project).State = EntityState.Modified;
            SetAuditFields(project);
            DataContext.SaveChanges();
        }

        public void DeleteProject(long projectId)
        {
            Project project = GetProject(projectId);
            DataContext.Projects.Remove(project);
            DataContext.SaveChanges();
        }

        public void DeleteProject(long[] arrayProjectId)
        {
            IEnumerable<Project> projects = DataContext.Projects.Where(it => arrayProjectId.Contains(it.Id)).ToList();
            DataContext.Projects.RemoveRange(projects);
            DataContext.SaveChanges();
        }

        public Project GetProject(long projectId)
        {
            return DataContext.Projects.Single(entity => entity.Id == projectId);
        }

        public IEnumerable<Project> GetProjects(bool onlyActive = true)
        {
            IQueryable<Project> query = DataContext.Projects;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
