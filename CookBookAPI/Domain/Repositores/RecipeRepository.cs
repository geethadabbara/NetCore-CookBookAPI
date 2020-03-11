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
            return await _context.Recipes.Include(n => n.Ingredients).FirstOrDefaultAsync(n => n.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _context.Recipes.ToListAsync().ConfigureAwait(false);
        }

        public void Update(int id, Recipe recipe)
        {
            Recipe persistedRecipe = GetRecipeAsync(id).Result;
            if (persistedRecipe != null && recipe != null)
            {
                //update Parent
                //_context.Entry(persistedRecipe).CurrentValues.SetValues(recipe);
                persistedRecipe.Name = recipe.Name;
                persistedRecipe.Description = recipe.Description;
                persistedRecipe.MealType = recipe.MealType;

                //Delete children
                foreach (var item in persistedRecipe.Ingredients.ToList())
                {
                    if (!recipe.Ingredients.Any(e => e.Id == item.Id))
                        _context.Ingredients.Remove(item);
                }
                // update and Insert
                foreach (var item in recipe.Ingredients.ToList())
                {
                    var persistedIngredient = _context.Ingredients.Find(item.Id);
                    if (persistedIngredient != null)
                    {
                        _context.Entry(persistedIngredient).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        persistedRecipe.Ingredients.Add(item);
                    }
                }
            }
           // _context.Recipes.Update(recipe);
        }

        public void Delete(Recipe recipe)
        {
            //_context.Ingredients.RemoveRange(recipe.Ingredients);
            _context.Recipes.Remove(recipe);

        }
        public bool IsExists(string name)
        {
            return _context.Recipes.Any(n => n.Name == name);
        }
    }
}
