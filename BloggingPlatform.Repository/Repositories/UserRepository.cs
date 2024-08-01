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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BloggingPlatformDbContext context) : base(context) { }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> GetByEmailAsync(string email) =>
            await _dbSet.SingleOrDefaultAsync(u => u.Email == email);

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
    }
}
