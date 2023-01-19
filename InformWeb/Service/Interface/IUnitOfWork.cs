using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformWeb.Service.Interface
{
    public interface IUnitOfWork
    {
        void commit();
    }
}
