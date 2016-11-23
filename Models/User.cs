using Library.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class User:BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}