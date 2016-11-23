using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.ViewModels
{
    public class BookViewModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public int PageCount { get; set; }

        public int CreationYear { get; set; }

        public string ImageUrl { get; set; }
    }
}