using BloggingPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Repository.Interfaces
{
    public interface IFollowerRepository : IBaseRepository<Follower>
    {
        Task<Follower> GetByIdsAsync(int userId, int followUserId); // Add this method

        Task<IEnumerable<User>> GetFollowersAsync(int userId);
        Task<IEnumerable<User>> GetFollowingAsync(int userId);
    }
}
