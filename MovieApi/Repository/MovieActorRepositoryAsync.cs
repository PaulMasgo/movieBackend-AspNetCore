using Microsoft.EntityFrameworkCore;
using MovieApi.Context;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository
{
    public class MovieActorRepositoryAsync : GenericAsyncRepository<MovieActor> , IMovieActorRepositoryAsync
    {
        private readonly DbSet<MovieActor> _movieActors;
        
        public MovieActorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _movieActors = dbContext.Set<MovieActor>();
        }
    }
}