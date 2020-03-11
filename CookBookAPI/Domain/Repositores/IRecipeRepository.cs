using CookBookAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Repositores
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> ListAsync();
        Task AddAsync(Recipe recipe);
        Task<Recipe> GetRecipeAsync(int id);

        void Update(int id, Recipe recipe);
        void Delete(Recipe recipe);
        bool IsExists(string name);
    }
}
