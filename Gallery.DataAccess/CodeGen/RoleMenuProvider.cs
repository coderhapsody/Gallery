using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class RoleMenuProvider : BaseProvider
	{
		public RoleMenuProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddRoleMenu(RoleMenu roleMenu)
        {
            DataContext.RoleMenus.Add(roleMenu);
            SetAuditFields(roleMenu);
            DataContext.SaveChanges();
        }

        public void UpdateRoleMenu(RoleMenu roleMenu)
        {
            DataContext.RoleMenus.Attach(roleMenu);
            DataContext.Entry(roleMenu).State = EntityState.Modified;
            SetAuditFields(roleMenu);
            DataContext.SaveChanges();
        }

        public void DeleteRoleMenu(long roleMenuId)
        {
            RoleMenu roleMenu = GetRoleMenu(roleMenuId);
            DataContext.RoleMenus.Remove(roleMenu);
            DataContext.SaveChanges();
        }

        public void DeleteRoleMenu(long[] arrayRoleMenuId)
        {
            IEnumerable<RoleMenu> rolemenus = DataContext.RoleMenus.Where(it => arrayRoleMenuId.Contains(it.Id)).ToList();
            DataContext.RoleMenus.RemoveRange(rolemenus);
            DataContext.SaveChanges();
        }

        public RoleMenu GetRoleMenu(long roleMenuId)
        {
            return DataContext.RoleMenus.Single(entity => entity.Id == roleMenuId);
        }

        public IEnumerable<RoleMenu> GetRoleMenus(bool onlyActive = true)
        {
            IQueryable<RoleMenu> query = DataContext.RoleMenus;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
