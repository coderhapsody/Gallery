using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.DataAccess;
using Gallery.Framework.Base;
using Gallery.ViewModels.Region;

namespace Gallery.Providers 
{
	public class RegionProvider : BaseProvider
	{
		public RegionProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddRegion(Region region)
        {
            DataContext.Regions.Add(region);
            SetAuditFields(region);
            DataContext.SaveChanges();
        }

        public void UpdateRegion(Region region)
        {
            DataContext.Regions.Attach(region);
            DataContext.Entry(region).State = EntityState.Modified;
            SetAuditFields(region);
            DataContext.SaveChanges();
        }

        public void DeleteRegion(long regionId)
        {
            Region region = GetRegion(regionId);
            DataContext.Regions.Remove(region);
            DataContext.SaveChanges();
        }

        public void DeleteRegion(long[] arrayRegionId)
        {
            IEnumerable<Region> regions = DataContext.Regions.Where(it => arrayRegionId.Contains(it.Id)).ToList();
            DataContext.Regions.RemoveRange(regions);
            DataContext.SaveChanges();
        }

        public Region GetRegion(long regionId)
        {
            return DataContext.Regions.Single(entity => entity.Id == regionId);
        }

        public IEnumerable<Region> GetRegions()
        {
            IQueryable<Region> query = DataContext.Regions;
            return query.ToList();
        }

        public IQueryable<RegionViewModel> ListRegion()
        {
            IQueryable<RegionViewModel> queryRegion =
                from region in DataContext.Regions
                join country in DataContext.Countries on region.CountryId equals country.Id
                select new RegionViewModel
                {
                    Id = region.Id,
                    CountryName = country.Name,
                    Name = region.Name,
                    ChangedWhen = region.ChangedWhen
                };
            return queryRegion;
        }
    }
}
