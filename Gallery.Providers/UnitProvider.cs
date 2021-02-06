using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.DataAccess;
using Gallery.Framework.Base;

namespace Gallery.Providers 
{
	public class UnitProvider : BaseProvider
	{
		public UnitProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddUnit(Unit unit)
        {
            DataContext.Units.Add(unit);
            SetAuditFields(unit);
            DataContext.SaveChanges();
        }

        public void UpdateUnit(Unit unit)
        {
            DataContext.Units.Attach(unit);
            DataContext.Entry(unit).State = EntityState.Modified;
            SetAuditFields(unit);
            DataContext.SaveChanges();
        }

        public void DeleteUnit(long unitId)
        {
            Unit unit = GetUnit(unitId);
            DataContext.Units.Remove(unit);
            DataContext.SaveChanges();
        }

        public void DeleteUnit(long[] arrayUnitId)
        {
            IEnumerable<Unit> units = DataContext.Units.Where(it => arrayUnitId.Contains(it.Id)).ToList();
            DataContext.Units.RemoveRange(units);
            DataContext.SaveChanges();
        }

        public Unit GetUnit(long unitId)
        {
            return DataContext.Units.Single(entity => entity.Id == unitId);
        }

        public IQueryable<Unit> ListUnits() => DataContext.Units;

        public IEnumerable<Unit> GetUnits()
        {
            IQueryable<Unit> query = DataContext.Units;
            return query.ToList();
        }
	}
}
