using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        public List<Movie> _moviesList { get; set; }

        public MockMovieRepository()
        {
            _moviesList = new List<Movie>()
            {
                new Movie(){MovieId = 1,Title = "Avengers",Length = "3hr",Gener = Genere.Action},
                new Movie(){MovieId = 2,Title = "The Irish Man",Length = "3:30hr",Gener = Genere.Action},
                new Movie(){MovieId = 3,Title = "Bad Boys",Length = "1:50hr",Gener = Genere.Action},
                new Movie(){MovieId = 4,Title = "Game",Length = "1:30hr",Gener = Genere.Action}
            };
        }
        public Movie GetMovie(int Id)
        {
            return _moviesList.FirstOrDefault(e => e.MovieId == Id);
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            throw new NotImplementedException();
        }

        public Movie Add(Movie movie)
        {
            movie.MovieId = _moviesList.Max(e => e.MovieId) + 1;
            _moviesList.Add(movie);
            return movie;
        }

        public Movie Update(Movie movieChnges)
        {
            Movie movie = _moviesList.FirstOrDefault(e => e.MovieId == movieChnges.MovieId);
            if (movie != null)
            {
                movie.Title = movieChnges.Title;  
                movie.Length = movieChnges.Length;  
                movie.RealeaseDate = movieChnges.RealeaseDate;  
                movie.PhotoPath = movieChnges.PhotoPath;  
                movie.Gener = movieChnges.Gener;
            }
            return movie;
        }

        public Movie Delete(int id)
        {
          Movie movie =  _moviesList.FirstOrDefault(e => e.MovieId == id);
            if (movie != null)
            {
                _moviesList.Remove(movie);
            }
            return movie;
        }
    }
}
