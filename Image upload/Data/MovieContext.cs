using Image_upload.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Data
{
    public class MovieContext :IdentityDbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) :base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //keys of identity tables are maped in onmodelcreating
            //primary key not defined error
            //caused by not caaling the base class on model creating method
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
