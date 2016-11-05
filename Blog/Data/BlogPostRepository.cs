using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DbContext _context;

        public BlogPostRepository(DbContext context)
        {
            _context = context;
        }

        public BlogPost GetLatestPost()
        {
            return _context.Posts.OrderByDescending(p => p.Created).FirstOrDefault();
        }

        public BlogPost GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.BlogPostId == id);
        }

        public int SavePost(BlogPost post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

            return post.BlogPostId;
        }

        public bool UpdatePost(BlogPost post)
        {
            var toUpdate = _context.Posts.FirstOrDefault(p => p.BlogPostId == post.BlogPostId);

            if (toUpdate == null)
                return false;

            toUpdate.Content = post.Content;

            _context.SaveChanges();

            return true;
        }

        public IEnumerable<BlogPost> GetPosts()
        {
            return _context.Posts;
        }

        public IEnumerable<BlogPost> GetLatestNPosts(int n)
        {
            return _context.Posts.OrderByDescending(post => post.Created).Take(n);
        }

        public IEnumerable<BlogPost> GetPageOfPosts()
        { 
            //  One line of text is about 160 chars.
            var charsInLine = 160;
            //  Not sure how many lines there are...80?
            var lineNumber = 80;
            
            int postCount = 3;
            var posts = new List<BlogPost>();
            posts = GetLatestNPosts(postCount).ToList();

            var totalNumberOfPosts = _context.Posts.Count();
            
            var charactersToFillPage = charsInLine * lineNumber;
            int charCount = posts.Sum(post => post.Content.Length);

            //  Yes this is inefficient but I can't figure out a better way atm. Too sleepy.
            while(charCount < charactersToFillPage && postCount < totalNumberOfPosts)
            {
                postCount++;
                posts = GetLatestNPosts(postCount).ToList();
                charCount = posts.Sum(post => post.Content.Length);
            }

            return posts;
        }
    }
}