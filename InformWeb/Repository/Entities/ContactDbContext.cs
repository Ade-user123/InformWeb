using InformWeb.Helper;
using Microsoft.EntityFrameworkCore;

namespace InformWeb.Repository.Entities
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        // Table entity
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            // passing the connection string to optionsBuilder
            dbContextOptionsBuilder.UseSqlServer(ConnectionString.ConStr);
        }
    }
}
