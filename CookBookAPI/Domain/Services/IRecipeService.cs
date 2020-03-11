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
        Task<RecipeResponse> GetRecipeAsync(int id);
        Task<RecipeResponse> SaveAsync(Recipe recipe);
        Task<RecipeResponse> UpdateAsync(int id, Recipe recipe);
        Task<RecipeResponse> Delete(Recipe recipe);
    }
}
