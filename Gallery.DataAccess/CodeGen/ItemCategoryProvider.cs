using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class ItemCategoryProvider : BaseProvider
	{
		public ItemCategoryProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddItemCategory(ItemCategory itemCategory)
        {
            DataContext.ItemCategories.Add(itemCategory);
            SetAuditFields(itemCategory);
            DataContext.SaveChanges();
        }

        public void UpdateItemCategory(ItemCategory itemCategory)
        {
            DataContext.ItemCategories.Attach(itemCategory);
            DataContext.Entry(itemCategory).State = EntityState.Modified;
            SetAuditFields(itemCategory);
            DataContext.SaveChanges();
        }

        public void DeleteItemCategory(long itemCategoryId)
        {
            ItemCategory itemCategory = GetItemCategory(itemCategoryId);
            DataContext.ItemCategories.Remove(itemCategory);
            DataContext.SaveChanges();
        }

        public void DeleteItemCategory(long[] arrayItemCategoryId)
        {
            IEnumerable<ItemCategory> itemcategories = DataContext.ItemCategories.Where(it => arrayItemCategoryId.Contains(it.Id)).ToList();
            DataContext.ItemCategories.RemoveRange(itemcategories);
            DataContext.SaveChanges();
        }

        public ItemCategory GetItemCategory(long itemCategoryId)
        {
            return DataContext.ItemCategories.Single(entity => entity.Id == itemCategoryId);
        }

        public IEnumerable<ItemCategory> GetItemCategories(bool onlyActive = true)
        {
            IQueryable<ItemCategory> query = DataContext.ItemCategories;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
