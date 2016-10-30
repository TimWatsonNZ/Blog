using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    [Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        [JsonIgnore]
        public int BlogPostId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public int? CategoryId { get; set; }

        [JsonProperty(PropertyName = "category")]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public virtual List<Tag> Tags { get; set; }
    }
}