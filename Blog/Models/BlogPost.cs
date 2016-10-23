using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    [Table("BlogPost")]
    public class BlogPost
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        public DateTime Created
        {
            get; set;
        }

        [JsonProperty(PropertyName = "tags")]
        public List<Tag> Tags { get; set; }
    }
}