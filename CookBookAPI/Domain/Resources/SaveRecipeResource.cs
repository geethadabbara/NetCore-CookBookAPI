using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CookBookAPI.Domain.Resources
{
    public class SaveRecipeResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string MealType { get; set; }
        [Required]
        public string Description { get; set; }
        public IList<IngredientResource> Ingredients { get; set; }
    }
}
