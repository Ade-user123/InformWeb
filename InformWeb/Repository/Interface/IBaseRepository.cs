using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformWeb.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        // Declaring common methods
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(Guid Id);
        Task Update(T entity);
        Task<T> GetById(Guid Id);
    }
}
