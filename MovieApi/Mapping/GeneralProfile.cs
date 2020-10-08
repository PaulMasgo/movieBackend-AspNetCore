using AutoMapper;
using MovieApi.DTOs.Category;
using MovieApi.Entities;

namespace MovieApi.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // Category
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}