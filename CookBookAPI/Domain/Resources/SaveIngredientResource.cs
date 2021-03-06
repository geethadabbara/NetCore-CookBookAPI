﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Resources
{
    public class SaveIngredientResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
        public RecipeResource RecipeResource { get; set; }
    }
}
