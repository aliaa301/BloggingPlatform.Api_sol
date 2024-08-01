using BloggingPlatform.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
