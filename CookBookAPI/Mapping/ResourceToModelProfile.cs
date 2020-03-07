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
            CreateMap<SaveRecipeResource, Recipe>();
            CreateMap<IngredientResource, Ingredients>().ForMember(src=> src.Measure, opt => opt.MapFrom(src => src.Measure.ToDescriptionString()));
            
        }
    }
}
