using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    [Table("Tag")]
    public class Tag
    {
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
        public string Name { get; set; }
    }
}