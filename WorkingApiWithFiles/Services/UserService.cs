using Microsoft.EntityFrameworkCore;
using WorkingApiWithFiles.Data;
using WorkingApiWithFiles.DTOs;
using WorkingApiWithFiles.Entities;
using WorkingApiWithFiles.Interfaces;

namespace WorkingApiWithFiles.Services
{
    public class UserService : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;
        public UserService(ApplicationDbContext context, IFileService fileService, IWebHostEnvironment environment)
        {
            _context = context;
            _fileService = fileService;
            _environment = environment;
        }
        public async ValueTask CreateAsync(UserDto userDto)
        {
            User user = new User();

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.ImageUrl = await _fileService.UploadAsync(userDto.Image);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async ValueTask<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            IEnumerable<User> users = await _context.Users.ToListAsync();

            List<UserResponseDto> userResponse = new List<UserResponseDto>();

            foreach (var i in users)
            {
                if (i != null)
                {
                    userResponse.Add(new UserResponseDto()
                    {
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        imageBytes = File.ReadAllBytes($@"{_environment.WebRootPath}{i.ImageUrl}")
                    });
                }
            }

            return userResponse;
        }

        public async ValueTask<UserResponseDto> GetByIdAsync(int UserId)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (user != null)
            {
                UserResponseDto userResponse = new UserResponseDto();
                userResponse.FirstName = user.FirstName;
                userResponse.LastName = user.LastName;
                userResponse.imageBytes = File.ReadAllBytes($@"{_environment.WebRootPath}{user.ImageUrl}");

                return userResponse;
            }
            return new UserResponseDto();
        }
    }
}