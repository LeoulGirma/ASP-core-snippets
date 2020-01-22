using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Image_upload.Models;
using Microsoft.AspNetCore.Hosting;
using Image_upload.ViewModels;
using System.IO;

namespace Image_upload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _movieRepository;

        public IWebHostEnvironment HostingEnvironment { get; }

        public HomeController(ILogger<HomeController> logger,IMovieRepository movieRepository,IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _movieRepository = movieRepository;
            HostingEnvironment = hostingEnvironment;
        }


        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                 movie = _movieRepository.GetMovie(id ?? 1),
                 PageTitle = "Movie Details changed"
           
            };
           
            return View(homeDetailsViewModel);
        }


        public IActionResult Index()
        {
            return View();
        }
        //content negotiation and accepet header to deal and 
        //respect those change jsonresult to object Result
        // nd change json(model) to new Objectresult(model)
        //public ObjectResult Details()
        //{
        //    Movie model = _movieRepository.GetMovie(1);
        //    return new ObjectResult(model);
        //}

        //public IActionResult GetMovie(int id)
        //{
        //    if (id != null)
        //    {
        //        return _movieRepository.GetMovie(id).Title;
        //    }
        //    return View();
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (movie.Poster != null)
                {
                    string uploadfolder = Path.Combine(HostingEnvironment.WebRootPath + "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.Poster.FileName;
                    string filePath = Path.Combine(uploadfolder, uniqueFileName);

                    movie.Poster.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Movie newMovie = new Movie()
                {
                    Title = movie.Title,
                    Length = movie.Length,
                    Gener = movie.Gener,
                    RealeaseDate = movie.RealeaseDate,
                    PhotoPath = uniqueFileName
                };

                _movieRepository.Add(newMovie);
                return RedirectToAction("details", new { id = newMovie.MovieId });
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
