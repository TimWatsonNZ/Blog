using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly Context _context;

        public PostRepository(Context context)
        {
            _context = context;
        }

        public BlogPost GetLatestPost()
        {
            return _context.Posts.OrderByDescending(p => p.Created).FirstOrDefault();
        }

        public BlogPost GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void SavePost(BlogPost post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<BlogPost> GetPosts()
        {
            return _context.Posts;
        }
    }
}