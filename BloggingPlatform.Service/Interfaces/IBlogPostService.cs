using BloggingPlatform.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> GetBlogPostByIdAsync(int id);
        Task<IEnumerable<BlogPostDto>> GetBlogPostsByAuthorAsync(int authorId);
        Task<IEnumerable<BlogPostDto>> SearchBlogPostsAsync(string title, string author);
        Task CreateBlogPostAsync(BlogPostDto blogPostDto);
        Task UpdateBlogPostAsync(BlogPostDto blogPostDto);
        Task DeleteBlogPostAsync(int id);
    }
}
