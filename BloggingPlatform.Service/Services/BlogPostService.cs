using AutoMapper;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<BlogPostDto> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            return _mapper.Map<BlogPostDto>(blogPost);
        }

        public async Task<IEnumerable<BlogPostDto>> GetBlogPostsByAuthorAsync(int authorId)
        {
            var blogPosts = await _blogPostRepository.GetByAuthorAsync(authorId);
            return _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
        }

        public async Task<IEnumerable<BlogPostDto>> SearchBlogPostsAsync(string title, string author)
        {
            var blogPosts = await _blogPostRepository.SearchBlogPostsAsync(title, author);
            return _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
        }

        public async Task CreateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDto);
            await _blogPostRepository.AddAsync(blogPost);
            await _blogPostRepository.SaveChangesAsync();
        }

        public async Task UpdateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var existingBlogPost = await _blogPostRepository.GetByIdAsync(blogPostDto.Id);
            if (existingBlogPost == null)
                throw new KeyNotFoundException("Blog post not found.");

            _mapper.Map(blogPostDto, existingBlogPost);
            _blogPostRepository.UpdateAsync(existingBlogPost);
            await _blogPostRepository.SaveChangesAsync();
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            if (blogPost == null)
                throw new KeyNotFoundException("Blog post not found.");

            _blogPostRepository.RemoveAsync(blogPost);
            await _blogPostRepository.SaveChangesAsync();
        }
    }
}
