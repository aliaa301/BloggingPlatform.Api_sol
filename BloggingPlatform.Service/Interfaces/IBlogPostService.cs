using BloggingPlatform.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> GetBlogPostByIdAsync(int id);
        Task<IEnumerable<BlogPostDto>> GetBlogPostsByAuthorAsync(int authorId);
        // Task<IEnumerable<BlogPostDto>> SearchBlogPostsAsync(string title, string author);
        Task<IEnumerable<BlogPostDto>> GetByTitleAsync(string title);
        Task<IEnumerable<BlogPostDto>> GetByAuthorIdAsync(int authorId);
        Task CreateBlogPostAsync(BlogPostDto blogPostDto);
        Task UpdateBlogPostAsync(BlogPostDto blogPostDto);
        Task DeleteBlogPostAsync(int id);
    }
}
