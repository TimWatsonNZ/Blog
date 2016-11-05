using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    [Table("BlogPostTag")]
    public class BlogPostTag
    {
        [Key]
        public int BlogPostTagId { get; set; }

        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }

        
        public virtual BlogPost BlogPost { get; set; }

        public virtual Tag Tag{ get; set; }
    }
}