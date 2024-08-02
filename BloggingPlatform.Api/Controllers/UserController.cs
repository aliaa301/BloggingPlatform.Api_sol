//using BloggingPlatform.Service.Dtos;
//using BloggingPlatform.Service.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BloggingPlatform.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetUserById(int id)
//        {
//            var user = await _userService.GetUserByIdAsync(id);
//            if (user == null)
//                return NotFound();

//            return Ok(user);
//        }

//        [HttpGet("email/{email}")]
//        public async Task<IActionResult> GetUserByEmail(string email)
//        {
//            var user = await _userService.GetUserByEmailAsync(email);
//            if (user == null)
//                return NotFound();

//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                await _userService.CreateUserAsync(userDto);
//                return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
//        {
//            if (userDto.Id != id)
//                return BadRequest("User ID mismatch.");

//            try
//            {
//                await _userService.UpdateUserAsync(userDto);
//                return NoContent(); // Indicates that the update was successful
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound(); // User not found
//            }
//            catch (InvalidOperationException ex)
//            {
//                return BadRequest(ex.Message); // User ID mismatch
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, "An unexpected error occurred."); // Internal server error
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            await _userService.DeleteUserAsync(id);
//            return NoContent();
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var users = await _userService.GetAllUsersAsync();
//            return Ok(users);
//        }
//    }
//}

using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

       [HttpPost]
public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        await _userService.CreateUserAsync(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(ex.Message);
    }
}


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (userDto.Id != id)
                return BadRequest("User ID mismatch.");

            try
            {
                await _userService.UpdateUserAsync(userDto);
                return Ok("User updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // User not found
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // User ID mismatch
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred."); // Internal server error
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("User deleted successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
