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

        public int BlogPostId { get; set; }

        public int TagId { get; set; }

        [ForeignKey("BlogPostId")]
        public virtual BlogPost BlogPost { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag{ get; set; }
    }
}