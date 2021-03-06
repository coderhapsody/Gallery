using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class CountryProvider : BaseProvider
	{
		public CountryProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddCountry(Country country)
        {
            DataContext.Countries.Add(country);
            SetAuditFields(country);
            DataContext.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            DataContext.Countries.Attach(country);
            DataContext.Entry(country).State = EntityState.Modified;
            SetAuditFields(country);
            DataContext.SaveChanges();
        }

        public void DeleteCountry(long countryId)
        {
            Country country = GetCountry(countryId);
            DataContext.Countries.Remove(country);
            DataContext.SaveChanges();
        }

        public void DeleteCountry(long[] arrayCountryId)
        {
            IEnumerable<Country> countries = DataContext.Countries.Where(it => arrayCountryId.Contains(it.Id)).ToList();
            DataContext.Countries.RemoveRange(countries);
            DataContext.SaveChanges();
        }

        public Country GetCountry(long countryId)
        {
            return DataContext.Countries.Single(entity => entity.Id == countryId);
        }

        public IEnumerable<Country> GetCountries(bool onlyActive = true)
        {
            IQueryable<Country> query = DataContext.Countries;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
