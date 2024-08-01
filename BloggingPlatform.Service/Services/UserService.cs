using AutoMapper;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Repository.Interfaces;
using BloggingPlatform.Service.Dtos;
using BloggingPlatform.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            // Ensure Password is set
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDto.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found.");

            // Check if IDs match
            if (existingUser.Id != userDto.Id)
                throw new InvalidOperationException("User ID mismatch.");

            _mapper.Map(userDto, existingUser);
            _userRepository.UpdateAsync(existingUser);
            await _userRepository.SaveChangesAsync();
        }



        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            _userRepository.RemoveAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
