using InformWeb.Repository.Entities;
using Microsoft.EntityFrameworkCore;


namespace InformWeb.Repository.Common
{
    public class RepositoryBase<T> where T : class
    {
        #region Properties
        private ContactDbContext contactDbContext;

        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ContactDbContext DbContext
        {
            get { return contactDbContext ?? (contactDbContext = DbFactory.InitialiseDbContext()); }
        }

        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
    }
}
