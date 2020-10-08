using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.DTOs.Category;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Features
{
    public class Categories
    {
        private readonly ICategoryAsyncRepository _categoryRepository;
        private readonly IMapper _mapper;

        public Categories(ICategoryAsyncRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var categories  = await _categoryRepository.GetAllAsync();
            var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public async Task<CategoryViewModel> Post([FromBody]CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.AddAsync(category);
            return categoryViewModel;
        }
        
    }
}