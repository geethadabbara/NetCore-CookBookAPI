using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Domain.Models;

namespace CookBookAPI.Domain.Services
{
   public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> ListAsync();
        Task<SaveRecipeResponse> GetRecipeAsync(int id);
        Task<SaveRecipeResponse> SaveAsync(Recipe recipe);
        Task<SaveRecipeResponse> UpdateAsync(int id, Recipe recipe);
        Task<SaveRecipeResponse> Delete(Recipe recipe);
    }
}
