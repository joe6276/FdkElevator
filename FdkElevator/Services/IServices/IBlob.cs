namespace FdkElevator.Services.IServices
{
    public interface IBlob
    {
        Task<string> UploadImageFileAsync(IFormFile file);
        Task<string> UploadAsync(byte[] fileBytes, string fileName, string contentType);
    }
}
