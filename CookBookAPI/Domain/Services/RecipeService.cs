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
        public async Task<SaveRecipeResponse> SaveAsync(Recipe recipe)
        {
            try
            {
                await _recipeRepository.AddAsync(recipe);
                await _unitOfWork.CompleteAsync();
                return new SaveRecipeResponse(recipe);
            }
            catch (Exception ex)
            {
                return new SaveRecipeResponse($"An error occurred when saving the recipe: {ex.Message}",false);
            }
        }

        public async Task<SaveRecipeResponse> GetRecipeAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeAsync(id);
            return new SaveRecipeResponse(recipe);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _recipeRepository.ListAsync().ConfigureAwait(false);
        }

        public async Task<SaveRecipeResponse> UpdateAsync(int id, Recipe recipe)
        {
            try
            {
                Recipe persistedRecipe = await _recipeRepository.GetRecipeAsync(id).ConfigureAwait(false);
                if (persistedRecipe != null && recipe != null)
                {
                    persistedRecipe.Name = recipe.Name;
                    persistedRecipe.Description = recipe.Description;
                    persistedRecipe.MealType = recipe.MealType;

                    _recipeRepository.Update(persistedRecipe);
                    await _unitOfWork.CompleteAsync();
                    return new SaveRecipeResponse(recipe);
                }
                else
                    return new SaveRecipeResponse("Recipe not found",false);

            }
            catch (Exception ex)
            {
                return new SaveRecipeResponse($"An error occurred when updating the recipe: {ex.Message}",false);
            }
        }

        public async Task<SaveRecipeResponse> Delete(Recipe recipe)
        {
            try
            {
                if (recipe == null)
                    return new SaveRecipeResponse("Recipe not found",false);
                _recipeRepository.Delete(recipe);
                await _unitOfWork.CompleteAsync();
                return new SaveRecipeResponse("Recipe deleted successfully", true);
            }
            catch (Exception ex)
            {
                return new SaveRecipeResponse($"An error occurred when deleting the recipe: {ex.Message}", false);
            }
        }
    }
}
