﻿using Blog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    //  Main purpose here is just to get previous and next posts
    //  In additional to this post.
    public class BlogPostVm
    {
        public BlogPostVm(BlogPost post, BlogPost previous, BlogPost next)
        {
            BlogPostId = post.BlogPostId;
            Title = post.Title;
            Content = post.Content;
            Created = post.Created;

            PreviousPostId = previous.BlogPostId;
            PreviousPostTitle = previous.Title;
            NextPostId = next.BlogPostId;
            NextPostTitle = next.Title;
        }

        [JsonIgnore]
        public int BlogPostId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }
        
        [JsonProperty(PropertyName = "previousPostId")]
        public int PreviousPostId { get; set; }

        [JsonProperty(PropertyName = "previousPostTitle")]
        public string PreviousPostTitle { get; set; }

        [JsonProperty(PropertyName = "nextPostId")]
        public int NextPostId { get; set; }

        [JsonProperty(PropertyName = "nextPostTitle")]
        public string NextPostTitle { get; set; }
    }
}