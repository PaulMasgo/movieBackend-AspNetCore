using System;
using System.Threading;
using System.Threading.Tasks;
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Create = DateTime.Now;
                        entry.Entity.State = true;
                        break;
                }
            }

            return SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity => { entity.ToTable("Category"); });
            builder.Entity<Movie>(entity => { entity.ToTable("Movie"); });
            builder.Entity<Actor>(entity => { entity.ToTable("Actor"); });
            builder.Entity<MovieActor>(entity => { entity.ToTable("MovieActor"); });
        }
    }
}