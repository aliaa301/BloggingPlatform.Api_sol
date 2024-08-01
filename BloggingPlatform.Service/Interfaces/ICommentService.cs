using BloggingPlatform.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task<IEnumerable<CommentDto>> GetCommentsByBlogPostIdAsync(int blogPostId);
        Task CreateCommentAsync(CommentDto commentDto);
        Task UpdateCommentAsync(CommentDto commentDto);
        Task DeleteCommentAsync(int id);
    }
}
