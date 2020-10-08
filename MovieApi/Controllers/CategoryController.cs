using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Context;
using MovieApi.DTOs.Category;
using MovieApi.Features;
using MovieApi.Repository;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly Categories _categories;

        public CategoryController(ICategoryAsyncRepository categoryRepository, IMapper mapper)
        {
            _categories = new Categories(categoryRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categories.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryViewModel categoryViewModel)
        {
            return Ok(await _categories.Post(categoryViewModel));
        }
        
    }
}