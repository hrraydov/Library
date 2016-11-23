using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {

        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Book> Books { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}