using BloggingPlatform.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Interfaces
{
    public interface IFollowerService
    {
        Task FollowUserAsync(int userId, int followUserId);
        Task UnfollowUserAsync(int userId, int followUserId);
        Task<IEnumerable<FollowerDto>> GetFollowersAsync(int userId);
        Task<IEnumerable<FollowerDto>> GetFollowingAsync(int userId);
    }
}
