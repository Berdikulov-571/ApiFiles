
using WorkingApiWithFiles.Data;
using WorkingApiWithFiles.Interfaces;

namespace WorkingApiWithFiles.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileService(ApplicationDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async ValueTask<string> UploadAsync(IFormFile formFile)
        {
            string extention = Path.GetExtension(formFile.FileName);

            var path = "/Images/" + Guid.NewGuid() + extention;

            string fullPath = _environment.WebRootPath + path;

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return path;
        }
    }
}
