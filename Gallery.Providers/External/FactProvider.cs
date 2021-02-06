using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.DataAccess;

namespace Gallery.Providers.External
{
    public class FactProvider : BaseProvider
    {
        public FactProvider(IGalleryDbContext db) : base(db)
        {
        }

        public IQueryable<FactProduct> ListFactProducts() => 
            DataContext.FactProducts;

        public FactProduct GetFactProduct(string prodCode) => 
            DataContext.FactProducts.SingleOrDefault(p => p.Prodcode == prodCode);

        public IQueryable<FactAgent> ListFactAgents() => 
            DataContext.FactAgents;

        public FactAgent GetFactAgent(string agentCode) => 
            DataContext.FactAgents.SingleOrDefault(ag => ag.Agentcode == agentCode);

        public IQueryable<FactCustomer> ListFactCustomers() => 
            DataContext.FactCustomers;

        public FactCustomer GetFactCustomer(string custCode) => 
            DataContext.FactCustomers.SingleOrDefault(cust => cust.Custcode == custCode);
    }
}
