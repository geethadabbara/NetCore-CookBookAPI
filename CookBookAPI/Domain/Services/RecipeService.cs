using CookBookAPI.Domain.Models;
using CookBookAPI.Domain.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        public readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RecipeResponse> SaveAsync(Recipe recipe)
        {
            try
            {
                if (this.IsExists(recipe))
                {
                    return new RecipeResponse($"Recipe already exists: ", false);
                }
                await _recipeRepository.AddAsync(recipe);
                await _unitOfWork.CompleteAsync();
                return new RecipeResponse(recipe);
            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error occurred when saving the recipe: {ex.Message}",false);
            }
        }

        public async Task<RecipeResponse> GetRecipeAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeAsync(id);
            return new RecipeResponse(recipe);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _recipeRepository.ListAsync().ConfigureAwait(false);
        }

        public async Task<RecipeResponse> UpdateAsync(int id, Recipe recipe)
        {
            try
            {
                if (recipe != null)
                {
                    //persistedRecipe.Name = recipe.Name;
                    //persistedRecipe.Description = recipe.Description;
                    //persistedRecipe.MealType = recipe.MealType;

                    _recipeRepository.Update(id, recipe);
                    await _unitOfWork.CompleteAsync();
                    return new RecipeResponse(recipe);
                }
                else
                    return new RecipeResponse("Recipe not found",false);

            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error occurred when updating the recipe: {ex.Message}",false);
            }
        }

        public async Task<RecipeResponse> Delete(Recipe recipe)
        {
            try
            {
                if (recipe == null)
                    return new RecipeResponse("Recipe not found",false);
                _recipeRepository.Delete(recipe);
                await _unitOfWork.CompleteAsync();
                return new RecipeResponse("Recipe deleted successfully", true);
            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error occurred when deleting the recipe: {ex.Message}", false);
            }
        }
        bool IsExists(Recipe recipe)
        {
            return _recipeRepository.IsExists(recipe.Name);
        }
    }
}
