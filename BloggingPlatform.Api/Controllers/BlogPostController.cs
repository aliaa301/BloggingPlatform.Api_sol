using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (blogPost == null)
                return NotFound();

            return Ok(blogPost);
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetBlogPostsByAuthor(int authorId)
        {
            var blogPosts = await _blogPostService.GetBlogPostsByAuthorAsync(authorId);
            return Ok(blogPosts);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBlogPosts([FromQuery] string title, [FromQuery] string author)
        {
            var blogPosts = await _blogPostService.SearchBlogPostsAsync(title, author);
            return Ok(blogPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            await _blogPostService.CreateBlogPostAsync(blogPostDto);
            return CreatedAtAction(nameof(GetBlogPostById), new { id = blogPostDto.Id }, blogPostDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(int id, [FromBody] BlogPostDto blogPostDto)
        {
            if (id != blogPostDto.Id)
                return BadRequest("Blog post ID mismatch.");

            await _blogPostService.UpdateBlogPostAsync(blogPostDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            await _blogPostService.DeleteBlogPostAsync(id);
            return NoContent();
        }
    }
}
