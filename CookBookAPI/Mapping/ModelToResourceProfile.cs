using AutoMapper;
using CookBookAPI.Domain.Models;
using CookBookAPI.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Extensions;
namespace CookBookAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Recipe, RecipeResource>();
            CreateMap<Ingredients, IngredientResource>();
        }
    }
}
