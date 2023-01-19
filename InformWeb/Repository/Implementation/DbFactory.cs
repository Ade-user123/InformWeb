using InformWeb.Repository.Common;
using InformWeb.Repository.Entities;
using Microsoft.EntityFrameworkCore;


namespace InformWeb.Repository.Implementation
{
    public class DbFactory : IDbFactory
    {
        ContactDbContext contactDbContext;
        public ContactDbContext InitialiseDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactDbContext>();
            return contactDbContext ?? (contactDbContext = new ContactDbContext(optionsBuilder.Options));
        }
    }
}
