using Image_upload.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.ViewModels
{
    // this is class was created so we dont create a navigation property not to complicate
    // we dont want to store the image in db only the name of file or path, for simplicity for now
    //
    public class MovieCreateViewModel
    {
        
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public Genere Gener { get; set; }
        [Required]

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime RealeaseDate { get; set; }


        public IFormFile Poster { get; set; }
    }
}
