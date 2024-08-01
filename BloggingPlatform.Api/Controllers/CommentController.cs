using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [HttpGet("blogpost/{blogPostId}")]
        public async Task<IActionResult> GetCommentsByBlogPostId(int blogPostId)
        {
            var comments = await _commentService.GetCommentsByBlogPostIdAsync(blogPostId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
        {
            await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentDto commentDto)
        {
            if (id != commentDto.Id)
                return BadRequest("Comment ID mismatch.");

            await _commentService.UpdateCommentAsync(commentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
