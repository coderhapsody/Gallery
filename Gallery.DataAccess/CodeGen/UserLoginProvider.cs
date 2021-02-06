using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Quickafe.DataAccess;
using Quickafe.Framework.Base;

namespace Gallery.Providers 
{
	public class UserLoginProvider : BaseProvider
	{
		public UserLoginProvider(IGalleryDbContext context) : base(context)
        {
        }

        public void AddUserLogin(UserLogin userLogin)
        {
            DataContext.UserLogins.Add(userLogin);
            SetAuditFields(userLogin);
            DataContext.SaveChanges();
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            DataContext.UserLogins.Attach(userLogin);
            DataContext.Entry(userLogin).State = EntityState.Modified;
            SetAuditFields(userLogin);
            DataContext.SaveChanges();
        }

        public void DeleteUserLogin(long userLoginId)
        {
            UserLogin userLogin = GetUserLogin(userLoginId);
            DataContext.UserLogins.Remove(userLogin);
            DataContext.SaveChanges();
        }

        public void DeleteUserLogin(long[] arrayUserLoginId)
        {
            IEnumerable<UserLogin> userlogins = DataContext.UserLogins.Where(it => arrayUserLoginId.Contains(it.Id)).ToList();
            DataContext.UserLogins.RemoveRange(userlogins);
            DataContext.SaveChanges();
        }

        public UserLogin GetUserLogin(long userLoginId)
        {
            return DataContext.UserLogins.Single(entity => entity.Id == userLoginId);
        }

        public IEnumerable<UserLogin> GetUserLogins(bool onlyActive = true)
        {
            IQueryable<UserLogin> query = DataContext.UserLogins;

            if (onlyActive)
                query = query.Where(it => it.IsActive);

            return query.ToList();
        }
	}
}
