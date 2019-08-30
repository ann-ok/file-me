using FileMe.DAL.Classes;
using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace FileMe.Authorization
{
    public class IdentityStore : IUserStore<Person, long>,
        IUserPasswordStore<Person, long>,
        IUserLockoutStore<Person, long>,
        IUserTwoFactorStore<Person, long>
    {
        private readonly ISession session;

        public IdentityStore(ISession session)
        {
            this.session = session;
        }

        #region IUserStore<User, int>
        public Task CreateAsync(Person user)
        {
            return Task.Run(() => {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(user);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            });
        }

        public Task DeleteAsync(Person user)
        {
            return Task.Run(() =>
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(user);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            });
        }

        public Task<Person> FindByIdAsync(long userId)
        {
            return Task.Run(() => session.Get<Person>(userId));
        }

        public Task<Person> FindByIdAsync(long? userId)
        {
            return Task.Run(() => session.Get<Person>(userId));
        }

        public Task<Person> FindByNameAsync(string username)
        {
            return Task.Run(() =>
            {
                return session.QueryOver<Person>()
                    .Where(u => u.UserName == username)
                    .SingleOrDefault();
            });
        }

        public Task UpdateAsync(Person user)
        {
            return Task.Run(() =>
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(user);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            });
        }
        #endregion

        #region IUserPasswordStore<User, int>
        public Task SetPasswordHashAsync(Person user, string passwordHash)
        {
            return Task.Run(() => user.Password = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(Person user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(Person user)
        {
            return Task.FromResult(true);
        }
        #endregion

        #region IUserLockoutStore<User, int>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(Person user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(Person user, DateTimeOffset lockoutEnd)
        {
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(Person user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(Person user)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(Person user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(Person user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(Person user, bool enabled)
        {
            return Task.CompletedTask;
        }
        #endregion

        #region IUserTwoFactorStore<User, int>
        public Task SetTwoFactorEnabledAsync(Person user, bool enabled)
        {
            return Task.CompletedTask;
        }

        public Task<bool> GetTwoFactorEnabledAsync(Person user)
        {
            return Task.FromResult(false);
        }

        public void Dispose()
        {

        }
        #endregion
    }
}