using CookBookAPI.Domain.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Repositores
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
    }
}
