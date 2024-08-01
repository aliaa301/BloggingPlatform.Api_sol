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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BloggingPlatformDbContext context) : base(context) { }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogPostAsync(int blogPostId)
        {
            return await _context.Comments.Where(c => c.BlogPostId == blogPostId).ToListAsync();
        }
    }

}