namespace WorkingApiWithFiles.Interfaces
{
    public interface IFileService
    {
        ValueTask<string> UploadAsync(IFormFile formFile);
    }
}
