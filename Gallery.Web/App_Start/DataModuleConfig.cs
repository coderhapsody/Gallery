﻿using Autofac;
using Gallery.DataAccess;
using System.Linq;
using System.Web;

namespace Gallery.Web
{
    internal class DataModuleConfig : Module
    {
        private string connectionString;

        public DataModuleConfig(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.GetOwinContext());
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication.User);
            RegisterDataContext(builder);
            RegisterProviders(builder);

            base.Load(builder);
        }

        private void RegisterDataContext(ContainerBuilder builder) =>
                builder.RegisterType<GalleryDbContext>().As<IGalleryDbContext>()
                .WithParameter("connectionString", connectionString)
                .InstancePerRequest();

        private void RegisterProviders(ContainerBuilder builder) =>
            ThisAssembly.GetReferencedAssemblies()
            .Where(a => a.Name.Contains("Providers"))
            .ToList()
            .ForEach(assemblyName =>
            {
                System.Reflection.Assembly.Load(assemblyName).GetTypes()
                    .Where(a => a.Name.EndsWith("Provider"))
                    .ToList()
                    .ForEach(providerType => builder.RegisterType(providerType)
                                                    .AsSelf()
                                                    .PropertiesAutowired()
                                                    .InstancePerRequest());
            });
    }

}
