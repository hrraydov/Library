using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IAppDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Book> Books { get; set; }

        int SaveChanges();

    }
}
