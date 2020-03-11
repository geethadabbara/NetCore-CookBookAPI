using CookBookAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Services
{
    public class RecipeResponse : BaseResponse<Recipe>
    {
        public RecipeResponse(Recipe recipe) : base(recipe)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public RecipeResponse(string message, bool success) : base(message, success: success)
        { }
    }
}
