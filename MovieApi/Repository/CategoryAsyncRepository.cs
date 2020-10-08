using Microsoft.EntityFrameworkCore;
using MovieApi.Context;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository
{
    public class CategoryAsyncRepository : GenericAsyncRepository<Category> , ICategoryAsyncRepository
    {
        private readonly DbSet<Category> _categories;
        
        public CategoryAsyncRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<Category>();
        }
    }
}