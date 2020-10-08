using Microsoft.EntityFrameworkCore;
using MovieApi.Context;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository
{
    public class ActorRepositoryAsync : GenericAsyncRepository<Actor>, IActorRepositoryAsync
    {
        private readonly DbSet<Actor> _actors;

        public ActorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _actors = dbContext.Set<Actor>();
        }
    }
}