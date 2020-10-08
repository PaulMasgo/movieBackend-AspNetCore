using Microsoft.EntityFrameworkCore;
using MovieApi.Context;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository
{
    public class MovieRepositoryAsync : GenericAsyncRepository<Movie>, IMovieRepositoryAsync
    {
        private readonly DbSet<Movie> _movies;

        public MovieRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _movies = dbContext.Set<Movie>();
        }
    }
}