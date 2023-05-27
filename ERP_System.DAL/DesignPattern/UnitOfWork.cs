using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Threading.Tasks;

namespace ERP_System.DAL
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        #region Fields

        bool _IsDisposed = false;

        public UnitOfWork(T ERP_SystemDbContext) => this.ERP_SystemDbContext = ERP_SystemDbContext;

        #endregion

        #region Props

        public T ERP_SystemDbContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get => _IsDisposed; }

        #endregion

        #region Methods

        public virtual void Commit() => ERP_SystemDbContext.Database.CurrentTransaction.Commit();

        public bool SaveChanges()
        {
            try
            {
                return ERP_SystemDbContext.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await ERP_SystemDbContext.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            ERP_SystemDbContext.Dispose();
            _IsDisposed = true;
        }
        #endregion
    }

}
