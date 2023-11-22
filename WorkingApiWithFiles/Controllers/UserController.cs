using Microsoft.AspNetCore.Mvc;
using WorkingApiWithFiles.DTOs;
using WorkingApiWithFiles.Interfaces;

namespace WorkingApiWithFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] UserDto userModel)
        {
            await _userRepository.CreateAsync(userModel);
            return Ok("Created");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int Id)
        {
            UserResponseDto user = await _userRepository.GetByIdAsync(Id);

            return Ok(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }

        [HttpGet]
        public async ValueTask<FileContentResult> GetImageByUserIdAsync(int UserId)
        {
            UserResponseDto user = await _userRepository.GetByIdAsync(UserId);

            return File(user.imageBytes, "image/png");
        }


        // Doesn't Working

        //[HttpGet]
        //public async ValueTask<List<FileContentResult>> GetAllUserImages()
        //{
        //    IEnumerable<UserResponseDto> users = await _userRepository.GetAllAsync();

        //    List<FileContentResult> result = new List<FileContentResult>();

        //    foreach (UserResponseDto i in users)
        //    {
        //        result.Add(File(i.imageBytes,"image/png"));
        //    }

        //    return result;
        //}
    }
}
