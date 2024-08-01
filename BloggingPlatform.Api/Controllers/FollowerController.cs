//using BloggingPlatform.Service.Dtos;
//using BloggingPlatform.Service.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BloggingPlatform.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FollowerController : ControllerBase
//    {
//        private readonly IFollowerService _followerService;

//        public FollowerController(IFollowerService followerService)
//        {
//            _followerService = followerService;
//        }

//        [HttpPost("follow")]
//        public async Task<IActionResult> FollowUser([FromBody] FollowerDto followerDto)
//        {
//            await _followerService.FollowUserAsync(followerDto.UserId, followerDto.FollowerId);
//            return NoContent();
//        }

//        [HttpPost("unfollow")]
//        public async Task<IActionResult> UnfollowUser([FromBody] FollowerDto followerDto)
//        {
//            await _followerService.UnfollowUserAsync(followerDto.UserId, followerDto.FollowerId);
//            return NoContent();
//        }

//        [HttpGet("{userId}/followers")]
//        public async Task<IActionResult> GetFollowers(int userId)
//        {
//            var followers = await _followerService.GetFollowersAsync(userId);
//            return Ok(followers);
//        }

//        [HttpGet("{userId}/following")]
//        public async Task<IActionResult> GetFollowing(int userId)
//        {
//            var following = await _followerService.GetFollowingAsync(userId);
//            return Ok(following);
//        }
//    }
//}
using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerService _followerService;

        public FollowerController(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        [HttpPost("follow")]
        public async Task<IActionResult> FollowUser([FromBody] FollowerDto followerDto)
        {
            try
            {
                await _followerService.FollowUserAsync(followerDto.UserId, followerDto.FollowerId);
                return Ok("User followed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowUser([FromBody] FollowerDto followerDto)
        {
            try
            {
                await _followerService.UnfollowUserAsync(followerDto.UserId, followerDto.FollowerId);
                return Ok("User unfollowed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            var followers = await _followerService.GetFollowersAsync(userId);
            return Ok(followers);
        }

        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(int userId)
        {
            var following = await _followerService.GetFollowingAsync(userId);
            return Ok(following);
        }
    }
}
