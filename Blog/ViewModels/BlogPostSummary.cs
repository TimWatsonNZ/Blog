using Blog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class BlogPostSummary
    {
        public BlogPostSummary()
        {

        }

        public BlogPostSummary(BlogPost blogPost)
        {
            BlogPostId = blogPost.BlogPostId;
            Title = blogPost.Title;
            Created = blogPost.Created;
        }

        public int BlogPostId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        
        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }
        
    }
}