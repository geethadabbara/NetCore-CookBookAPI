using CookBookAPI.Domain.Models;
using CookBookAPI.Domain.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CookBookAPI.Domain.Repositores
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        public readonly AppDBContext _context;
        public RecipeRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _context.Recipes.ToListAsync().ConfigureAwait(false);
        }

        public void Update(Recipe recipe)
        {
             _context.Recipes.Update(recipe);
        }

       public void Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }
    }
}
