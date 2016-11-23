using Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.ViewModels
{
    public class BookCreateViewModel
    {
        public List<SelectListItem> Genres { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public int CreationYear { get; set; }

        [ValidateFile(ErrorMessage = "Please select a PNG or JPEG image smaller than 4MB")]
        public HttpPostedFileBase Image { get; set; }
    }
}