using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class FactAgentProvider : BaseProvider
	{
		public FactAgentProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddFactAgent(FactAgent factAgent)
        {
            DataContext.FactAgents.Add(factAgent);
            SetAuditFields(factAgent);
            DataContext.SaveChanges();
        }

        public void UpdateFactAgent(FactAgent factAgent)
        {
            DataContext.FactAgents.Attach(factAgent);
            DataContext.Entry(factAgent).State = EntityState.Modified;
            SetAuditFields(factAgent);
            DataContext.SaveChanges();
        }

        public void DeleteFactAgent(long factAgentId)
        {
            FactAgent factAgent = GetFactAgent(factAgentId);
            DataContext.FactAgents.Remove(factAgent);
            DataContext.SaveChanges();
        }

        public void DeleteFactAgent(long[] arrayFactAgentId)
        {
            IEnumerable<FactAgent> factagents = DataContext.FactAgents.Where(it => arrayFactAgentId.Contains(it.Id)).ToList();
            DataContext.FactAgents.RemoveRange(factagents);
            DataContext.SaveChanges();
        }

        public FactAgent GetFactAgent(long factAgentId)
        {
            return DataContext.FactAgents.Single(entity => entity.Id == factAgentId);
        }

        public IEnumerable<FactAgent> GetFactAgents(bool onlyActive = true)
        {
            IQueryable<FactAgent> query = DataContext.FactAgents;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
