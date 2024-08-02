//using BloggingPlatform.Service.Dtos;
//using BloggingPlatform.Service.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BloggingPlatform.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BlogPostController : ControllerBase
//    {
//        private readonly IBlogPostService _blogPostService;

//        public BlogPostController(IBlogPostService blogPostService)
//        {
//            _blogPostService = blogPostService;
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetBlogPostById(int id)
//        {
//            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
//            if (blogPost == null)
//                return NotFound();

//            return Ok(blogPost);
//        }

//        [HttpGet("author/{authorId}")]
//        public async Task<IActionResult> GetBlogPostsByAuthor(int authorId)
//        {
//            var blogPosts = await _blogPostService.GetBlogPostsByAuthorAsync(authorId);
//            return Ok(blogPosts);
//        }

//        //[HttpGet("search")]
//        //public async Task<IActionResult> SearchBlogPosts([FromQuery] string title, [FromQuery] string author)
//        //{
//        //    var blogPosts = await _blogPostService.SearchBlogPostsAsync(title, author);
//        //    return Ok(blogPosts);
//        //}
//        // Search by title
//        [HttpGet("search/title")]
//        public async Task<IActionResult> SearchByTitle([FromQuery] string title)
//        {
//            if (string.IsNullOrWhiteSpace(title))
//            {
//                return BadRequest("Title query parameter cannot be empty.");
//            }

//            var blogPosts = await _blogPostService.GetByTitleAsync(title);
//            var blogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
//            return Ok(blogPostDtos);
//        }

//        // Search by author
//        [HttpGet("search/author")]
//        public async Task<IActionResult> SearchByAuthor([FromQuery] int authorId)
//        {
//            if (authorId <= 0)
//            {
//                return BadRequest("Author ID must be greater than zero.");
//            }

//            var blogPosts = await _blogPostService.GetByAuthorIdAsync(authorId);
//            var blogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
//            return Ok(blogPostDtos);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPostDto blogPostDto)
//        {
//            await _blogPostService.CreateBlogPostAsync(blogPostDto);
//            return CreatedAtAction(nameof(GetBlogPostById), new { id = blogPostDto.Id }, blogPostDto);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateBlogPost(int id, [FromBody] BlogPostDto blogPostDto)
//        {
//            if (id != blogPostDto.Id)
//                return BadRequest("Blog post ID mismatch.");

//            await _blogPostService.UpdateBlogPostAsync(blogPostDto);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteBlogPost(int id)
//        {
//            await _blogPostService.DeleteBlogPostAsync(id);
//            return NoContent();
//        }
//    }
//}
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (blogPost == null)
                return NotFound();

            var blogPostDto = _mapper.Map<BlogPostDto>(blogPost);
            return Ok(blogPostDto);
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetBlogPostsByAuthor(int authorId)
        {
            var blogPosts = await _blogPostService.GetBlogPostsByAuthorAsync(authorId);
            var blogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
            return Ok(blogPostDtos);
        }

        // Search by title
        [HttpGet("search/title")]
        public async Task<IActionResult> SearchByTitle([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Title query parameter cannot be empty.");
            }

            var blogPosts = await _blogPostService.GetByTitleAsync(title);
            var blogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
            return Ok(blogPostDtos);
        }

        // Search by author
        [HttpGet("search/author")]
        public async Task<IActionResult> SearchByAuthor([FromQuery] int authorId)
        {
            if (authorId <= 0)
            {
                return BadRequest("Author ID must be greater than zero.");
            }

            var blogPosts = await _blogPostService.GetByAuthorIdAsync(authorId);
            var blogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
            return Ok(blogPostDtos);
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
