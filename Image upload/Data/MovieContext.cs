using Image_upload.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Data
{
    public class MovieContext :DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) :base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "Avengers End Game",
                    Gener = Genere.Action,
                    Length = "3hr",
                    RealeaseDate = DateTime.Today,
                    PhotoPath ="Avengers.jpg"
                }
                ) ; 
        }
    }
}
