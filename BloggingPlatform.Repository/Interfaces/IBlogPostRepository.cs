using BloggingPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Repository.Interfaces
{
    public interface IBlogPostRepository : IBaseRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetByAuthorAsync(int authorId);
        Task<IEnumerable<BlogPost>> SearchBlogPostsAsync(string title, string author);  // Assuming this method exists
    }
}
