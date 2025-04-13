using Microsoft.AspNetCore.Http;

namespace PetSpeak.Service.Cloud
{
    public interface ICloudinaryService
    {
        Task<Dictionary<string, object>> UploadFile(IFormFile file);
    }
}
