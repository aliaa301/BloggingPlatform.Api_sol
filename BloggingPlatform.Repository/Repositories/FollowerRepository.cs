using BloggingPlatform.Data.Context.BloggingPlatform.Data;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Repository.Repositories
{
    public class FollowerRepository : BaseRepository<Follower>, IFollowerRepository
    {
        public FollowerRepository(BloggingPlatformDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetFollowersAsync(int userId)
        {
            return await _context.Followers
                .Where(f => f.UserId == userId)
                .Select(f => f.FollowerUser)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetFollowingAsync(int userId)
        {
            return await _context.Followers
                .Where(f => f.FollowerId == userId)
                .Select(f => f.User)
                .ToListAsync();
        }
        public async Task<Follower> GetByIdsAsync(int userId, int followUserId)
        {
            return await _context.Followers
                .FirstOrDefaultAsync(f => f.UserId == userId && f.FollowerId == followUserId);
        }
    }
}
