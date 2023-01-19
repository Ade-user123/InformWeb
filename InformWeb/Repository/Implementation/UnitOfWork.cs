using InformWeb.Repository.Common;
using InformWeb.Repository.Entities;
using InformWeb.Service.Interface;

namespace InformWeb.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ContactDbContext _contactDbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public ContactDbContext DbContext
        {
            get { return _contactDbContext ?? (_contactDbContext = _dbFactory.InitialiseDbContext()); }

        }
        // Methid to commit changes to database
        public void commit()
        {
            DbContext.SaveChanges();
        }
    }
}
