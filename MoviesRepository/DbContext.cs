using Microsoft.EntityFrameworkCore;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies)
            .UsingEntity(j => j.HasData(
                new { MoviesId = 1, ActorsId = 1 },
                new { MoviesId = 2, ActorsId = 2 }, 
                new { MoviesId = 3, ActorsId = 3 }, 
                new { MoviesId = 1, ActorsId = 3 }  
            ));
            // Seed Dummy Data
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010 },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008 },
                new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014 }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Leonardo DiCaprio" },
                new Actor { Id = 2, Name = "Christian Bale" },
                new Actor { Id = 3, Name = "Anne Hathaway" }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, MovieId = 1, RatingValue = 5, VotersFullName = "John Doe" },
                new Rating { Id = 2, MovieId = 1, RatingValue = 4, VotersFullName = "Jane Smith" },
                new Rating { Id = 3, MovieId = 2, RatingValue = 5, VotersFullName = "Alice Brown" }
            );
        }
    }
}
