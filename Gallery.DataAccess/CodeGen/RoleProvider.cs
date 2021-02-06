using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class RoleProvider : BaseProvider
	{
		public RoleProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddRole(Role role)
        {
            DataContext.Roles.Add(role);
            SetAuditFields(role);
            DataContext.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            DataContext.Roles.Attach(role);
            DataContext.Entry(role).State = EntityState.Modified;
            SetAuditFields(role);
            DataContext.SaveChanges();
        }

        public void DeleteRole(long roleId)
        {
            Role role = GetRole(roleId);
            DataContext.Roles.Remove(role);
            DataContext.SaveChanges();
        }

        public void DeleteRole(long[] arrayRoleId)
        {
            IEnumerable<Role> roles = DataContext.Roles.Where(it => arrayRoleId.Contains(it.Id)).ToList();
            DataContext.Roles.RemoveRange(roles);
            DataContext.SaveChanges();
        }

        public Role GetRole(long roleId)
        {
            return DataContext.Roles.Single(entity => entity.Id == roleId);
        }

        public IEnumerable<Role> GetRoles(bool onlyActive = true)
        {
            IQueryable<Role> query = DataContext.Roles;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
