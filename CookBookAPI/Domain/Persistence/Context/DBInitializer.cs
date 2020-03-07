using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Persistence.Context
{
    public static class DBInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();
            if (context.Recipes.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}
