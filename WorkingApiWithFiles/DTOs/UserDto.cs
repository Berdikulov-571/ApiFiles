namespace WorkingApiWithFiles.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public IFormFile Image { get; set; } = default!;
    }
}
