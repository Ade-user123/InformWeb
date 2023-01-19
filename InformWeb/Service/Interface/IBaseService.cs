using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformWeb.Service.Interface
{
    public interface IBaseService<T>
    {
        // Declaring common methods
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(Guid Id);
        void Update(T entity);
        T GetById(Guid Id);
    }
}
