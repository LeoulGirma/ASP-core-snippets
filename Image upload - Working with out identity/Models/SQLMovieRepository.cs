using Image_upload.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    public class SQLMovieRepository : IMovieRepository
    {
        private readonly MovieContext context;

        public SQLMovieRepository(MovieContext _context)
        {
            context = _context;
        }
        public Movie Add(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return movie;
        }

        public Movie Delete(int id)
        {
          Movie movie=  context.Movies.Find(id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
               
            }
            return movie;
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            return context.Movies;
        }

        public Movie GetMovie(int Id)
        {
           return context.Movies.Find(Id);
        }

        public Movie Update(Movie movieChanges)
        {
            var movie = context.Movies.Attach(movieChanges);
            movie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return movieChanges;
        } 
    }
}
