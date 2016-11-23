using Library.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}