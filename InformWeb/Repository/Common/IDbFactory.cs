using InformWeb.Repository.Entities;

namespace InformWeb.Repository.Common
{
    public interface IDbFactory
    {
        ContactDbContext InitialiseDbContext();
    }
}
