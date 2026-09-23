using Microsoft.AspNetCore.Components.Forms;

namespace Academy.Services
{
    public class FileService
    {
        public async Task<byte[]> ConvertToBytesAsync(IBrowserFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
