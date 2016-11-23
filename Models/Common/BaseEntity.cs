using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models.Common
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}