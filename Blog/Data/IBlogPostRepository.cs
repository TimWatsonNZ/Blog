﻿using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Data
{
    public interface IBlogPostRepository
    {
        void SavePost(BlogPost post);

        BlogPost GetPost(int id);

        BlogPost GetLatestPost();

        IEnumerable<BlogPost> GetPosts();

        IEnumerable<BlogPost> GetLatestNPosts(int n);

        IEnumerable<BlogPost> GetPageOfPosts();
    }
}