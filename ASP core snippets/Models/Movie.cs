using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_core_snippets.Models
{
    public class Movie
    {
        public string Title { get; set; }

        public DateTime RealeaseDate { get; set; }

        public IFormFile Poster { get; set; }
    }
}
