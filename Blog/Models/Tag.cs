using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
    }
}