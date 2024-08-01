using AutoMapper;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FollowerService(IFollowerRepository followerRepository, IUserRepository userRepository, IMapper mapper)
        {
            _followerRepository = followerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task FollowUserAsync(int userId, int followUserId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var followUser = await _userRepository.GetByIdAsync(followUserId);

            if (user == null || followUser == null)
                throw new ArgumentException("User or followUser not found.");

            var existingFollower = await _followerRepository.GetByIdsAsync(userId, followUserId);
            if (existingFollower != null)
                throw new InvalidOperationException("User is already following this user.");

            var newFollower = new Follower { UserId = userId, FollowerId = followUserId };
            await _followerRepository.AddAsync(newFollower);
            await _followerRepository.SaveChangesAsync();
        }

        public async Task UnfollowUserAsync(int userId, int followUserId)
        {
            var follower = await _followerRepository.GetByIdsAsync(userId, followUserId);
            if (follower == null)
                throw new ArgumentException("Follow relationship not found.");

            await _followerRepository.RemoveAsync(follower);
            await _followerRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FollowerDto>> GetFollowersAsync(int userId)
        {
            var followers = await _followerRepository.GetFollowersAsync(userId);
            return _mapper.Map<IEnumerable<FollowerDto>>(followers);
        }

        public async Task<IEnumerable<FollowerDto>> GetFollowingAsync(int userId)
        {
            var following = await _followerRepository.GetFollowingAsync(userId);
            return _mapper.Map<IEnumerable<FollowerDto>>(following);
        }
    }
}
