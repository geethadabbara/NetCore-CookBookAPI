using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Domain.Models;
using CookBookAPI.Domain.Resources;
using CookBookAPI.Extensions;

namespace CookBookAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RecipeResource, Recipe>();
            CreateMap<IngredientResource, Ingredients>();
            
        }
    }
}
    