using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    /*
     * 
     */
    public static class ModelbuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
               new Movie
               {
                   MovieId = 1,
                   Title = "Avengers End Game",
                   Gener = Genere.Action,
                   Length = "3hr",
                   RealeaseDate = DateTime.Today,
                   PhotoPath = "Avengers.jpg"
               },
                new Movie
                {
                    MovieId = 2,
                    Title = "The Irishman",
                    Gener = Genere.Action,
                    Length = "3hr 30min",
                    RealeaseDate = DateTime.Today,
                    PhotoPath = "The Irishman.jpg"
                }
               );
        }
    }
}
