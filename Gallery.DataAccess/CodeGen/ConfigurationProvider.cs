using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class ConfigurationProvider : BaseProvider
	{
		public ConfigurationProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddConfiguration(Configuration configuration)
        {
            DataContext.Configurations.Add(configuration);
            SetAuditFields(configuration);
            DataContext.SaveChanges();
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            DataContext.Configurations.Attach(configuration);
            DataContext.Entry(configuration).State = EntityState.Modified;
            SetAuditFields(configuration);
            DataContext.SaveChanges();
        }

        public void DeleteConfiguration(long configurationId)
        {
            Configuration configuration = GetConfiguration(configurationId);
            DataContext.Configurations.Remove(configuration);
            DataContext.SaveChanges();
        }

        public void DeleteConfiguration(long[] arrayConfigurationId)
        {
            IEnumerable<Configuration> configurations = DataContext.Configurations.Where(it => arrayConfigurationId.Contains(it.Id)).ToList();
            DataContext.Configurations.RemoveRange(configurations);
            DataContext.SaveChanges();
        }

        public Configuration GetConfiguration(long configurationId)
        {
            return DataContext.Configurations.Single(entity => entity.Id == configurationId);
        }

        public IEnumerable<Configuration> GetConfigurations(bool onlyActive = true)
        {
            IQueryable<Configuration> query = DataContext.Configurations;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
