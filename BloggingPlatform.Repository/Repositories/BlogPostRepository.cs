using BloggingPlatform.Data.Context.BloggingPlatform.Data;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Repository.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BloggingPlatformDbContext context) : base(context) { }

        public async Task<IEnumerable<BlogPost>> GetByAuthorAsync(int authorId)
        {
            return await _context.BlogPosts.Where(bp => bp.AuthorId == authorId).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> SearchBlogPostsAsync(string title, string author)
        {
            return await _context.BlogPosts
                .Where(bp => bp.Title.Contains(title) || bp.Author.Username.Contains(author))
                .ToListAsync();
        }
    }
}
