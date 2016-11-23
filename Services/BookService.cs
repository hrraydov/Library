using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using Library.Data;
using System.Data.Entity;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private IAppDbContext db;

        public BookService()
        {
            this.db = new AppDbContext();
        }

        public BookService(IAppDbContext db)
        {
            this.db = db;
        }
        public void Add(Book book)
        {
            this.db.Books.Add(book);
            this.db.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return this.db.Books.Include(x => x.Genre).OrderByDescending(x => x.CreationDate).ToList();
        }

        public List<Book> Search(string name, int? fromPages, int? toPages, string genre, int pageNumber)
        {
            IQueryable<Book> query = this.db.Books.Include(x => x.Genre);
            if (!String.IsNullOrEmpty(name))
            {
                var exactNameQuery = query.Where(x => x.Name.ToLower() == name.ToLower());
                if (exactNameQuery.Count() > 0)
                {
                    query = exactNameQuery;
                }
                else
                {
                    query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }
            }

            if (fromPages != null)
            {
                query = query.Where(x => x.PageCount >= fromPages.Value);
            }

            if (toPages != null)
            {
                query = query.Where(x => x.PageCount <= toPages.Value);
            }

            if (!String.IsNullOrEmpty(genre))
            {
                query = query.Where(x => x.Genre.Name == genre);
            }

            query = query.OrderByDescending(x => x.CreationDate).Skip(12 * pageNumber).Take(12);
            return query.ToList();
        }
    }
}