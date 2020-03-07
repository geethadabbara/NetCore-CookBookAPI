using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Repositores
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}
