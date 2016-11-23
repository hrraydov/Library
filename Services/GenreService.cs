using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using Library.Data;

namespace Library.Services
{
    public class GenreService : IGenreService
    {
        private IAppDbContext db;

        public GenreService()
        {
            this.db = new AppDbContext();
        }

        public GenreService(IAppDbContext db)
        {
            this.db = db;
        }
        public List<Genre> GetAll()
        {
            return this.db.Genres.ToList();
        }
    }
}