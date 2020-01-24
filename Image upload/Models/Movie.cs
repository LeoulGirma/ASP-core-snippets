using Image_upload.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload
{
    public class Movie
    {
        [Key]
        public int  MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Length {get; set;}

        [Required]
        public Genere Gener { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime RealeaseDate { get; set; }

        public string PhotoPath { get; set; }

        //[NotMapped]
        //public IFormFile Poster { get; set; }

        //int movieId;
        //int theaterId;
        //MovieType movieType;
        //MovieStatus movieStatus;
    }
}
