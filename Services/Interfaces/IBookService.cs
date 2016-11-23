using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        void Add(Book book);

        List<Book> GetAll();

        List<Book> Search(string name, int? fromPages, int? toPages, string genre, int pageNumber);
    }
}
