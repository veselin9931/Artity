namespace Artity.Services
{

    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    public interface IFileService
    {
       Task<string> UploadProfilePicture(HttpContext context);

    }
}
