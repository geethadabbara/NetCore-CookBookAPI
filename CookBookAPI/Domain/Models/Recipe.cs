using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MealType { get; set; }
        public string Description { get; set; }
        public virtual IList<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
    }
}
