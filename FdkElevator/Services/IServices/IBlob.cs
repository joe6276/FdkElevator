namespace FdkElevator.Services.IServices
{
    public interface IBlob
    {
        Task<string> UploadImageFileAsync(IFormFile file);
    }
}
