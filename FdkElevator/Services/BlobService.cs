using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class BlobService : IBlob
    {
    
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=africaparts;AccountKey=GqAwDD6eLm2USWCzcB0uwbp5ES/GLn97UnW3YZdYvHwvYALBo831zT2Wl+W7iOlDS5xSlIbU2WNn+ASth14zSg==;EndpointSuffix=core.windows.net";


        public async Task<string> UploadImageFileAsync(IFormFile file)
        {
            try
            {

                var blobServiceClient = new BlobServiceClient(connectionString);


                var containerClient = blobServiceClient.GetBlobContainerClient("fdkelevators");
                await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

                string fileName = Path.GetFileName(file.FileName);
                Guid newGuid = Guid.NewGuid();
                string blobName = newGuid.ToString() + fileName;


                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                await using var stream = file.OpenReadStream();
                await blobClient.UploadAsync(stream, overwrite: true);

                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error uploading image: {ex.Message}");
                throw;
            }
        }

        public async Task<string> UploadAsync(byte[] fileBytes, string fileName,
                                      string contentType)
        {

            var _blobServiceClient= new BlobServiceClient(connectionString);
            var containerClient = _blobServiceClient
                .GetBlobContainerClient("fdkelevators");

            // Create container if it doesn't exist, with public blob access
            await containerClient.CreateIfNotExistsAsync(
                PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient(fileName);

            using var stream = new MemoryStream(fileBytes);

            await blobClient.UploadAsync(stream,
                new BlobHttpHeaders { ContentType = contentType });

            return blobClient.Uri.ToString();
        }
    }
}
