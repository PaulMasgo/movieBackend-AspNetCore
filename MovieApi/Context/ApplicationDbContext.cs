using Microsoft.EntityFrameworkCore;
using MovieApi.Entities;

namespace MovieApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity => { entity.ToTable("Category"); });
            builder.Entity<Movie>(entity => { entity.ToTable("Movie"); });
            builder.Entity<Actor>(entity => { entity.ToTable("Actor"); });
            builder.Entity<MovieActor>(entity => { entity.ToTable("MovieActor"); });
        }
    }
}