using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class MenuProvider : BaseProvider
	{
		public MenuProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddMenu(Menu menu)
        {
            DataContext.Menus.Add(menu);
            SetAuditFields(menu);
            DataContext.SaveChanges();
        }

        public void UpdateMenu(Menu menu)
        {
            DataContext.Menus.Attach(menu);
            DataContext.Entry(menu).State = EntityState.Modified;
            SetAuditFields(menu);
            DataContext.SaveChanges();
        }

        public void DeleteMenu(long menuId)
        {
            Menu menu = GetMenu(menuId);
            DataContext.Menus.Remove(menu);
            DataContext.SaveChanges();
        }

        public void DeleteMenu(long[] arrayMenuId)
        {
            IEnumerable<Menu> menus = DataContext.Menus.Where(it => arrayMenuId.Contains(it.Id)).ToList();
            DataContext.Menus.RemoveRange(menus);
            DataContext.SaveChanges();
        }

        public Menu GetMenu(long menuId)
        {
            return DataContext.Menus.Single(entity => entity.Id == menuId);
        }

        public IEnumerable<Menu> GetMenus(bool onlyActive = true)
        {
            IQueryable<Menu> query = DataContext.Menus;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
