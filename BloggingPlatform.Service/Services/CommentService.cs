using AutoMapper;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            var comments = await _commentRepository.GetCommentsByBlogPostAsync(blogPostId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(CommentDto commentDto)
        {
            var existingComment = await _commentRepository.GetByIdAsync(commentDto.Id);
            if (existingComment == null)
                throw new KeyNotFoundException("Comment not found.");

            _mapper.Map(commentDto, existingComment);
            _commentRepository.UpdateAsync(existingComment);
            await _commentRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found.");

            _commentRepository.RemoveAsync(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
