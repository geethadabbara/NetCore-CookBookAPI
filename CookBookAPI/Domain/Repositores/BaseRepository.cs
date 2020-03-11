using CookBookAPI.Domain.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Repositores
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext context;

        public BaseRepository(AppDBContext _context)
        {
            context = _context;
        }
    }
}
