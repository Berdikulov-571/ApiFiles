using WorkingApiWithFiles.DTOs;
using WorkingApiWithFiles.Entities;

namespace WorkingApiWithFiles.Interfaces
{
    public interface IUserRepository
    {
        ValueTask CreateAsync(UserDto userDto);
        ValueTask<UserResponseDto> GetByIdAsync(int UserId);
        ValueTask<IEnumerable<UserResponseDto>> GetAllAsync();
    }
}
