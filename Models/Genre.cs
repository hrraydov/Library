using Library.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Genre : BaseEntity
    {
        private ICollection<Book> books;

        public Genre()
        {
            this.books = new HashSet<Book>();
        }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}