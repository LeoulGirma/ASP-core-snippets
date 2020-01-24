using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        IEnumerable<Movie> GetAllMovie();
        Movie Add(Movie movie);
        Movie Update(Movie movieChanges);
        Movie Delete(int id);

    }
}
