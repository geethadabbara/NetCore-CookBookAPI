using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBookAPI.Domain.Models;
using CookBookAPI.Domain.Services;
using CookBookAPI.Domain.Resources;
using CookBookAPI.Extensions;
using AutoMapper;

namespace CookBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _recipeService.ListAsync().ConfigureAwait(false);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var result = await _recipeService.GetRecipeAsync(id);

            if (result.Resource == null)
            {
                return NotFound();
            }
            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] RecipeResource recipe)
        {
            var _recipe = _mapper.Map<RecipeResource, Recipe>(recipe);
            var result = await _recipeService.UpdateAsync(id, _recipe);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(categoryResource);
        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RecipeResource recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var _recipe = _mapper.Map<RecipeResource, Recipe>(recipe);
            var result = await _recipeService.SaveAsync(_recipe);

            if (!result.Success)
                return BadRequest(result.Message);

            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteAsync(int id)
        {
            var recipe = await _recipeService.GetRecipeAsync(id);
            if (recipe.Resource == null)
            {
                return NotFound();
            }

           var result = await _recipeService.Delete(recipe.Resource);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        //private bool RecipeExists(long id)
        //{
        //    return _context.Recipes.Any(e => e.Id == id);
        //}
    }
}
