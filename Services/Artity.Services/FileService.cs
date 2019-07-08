using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Artity.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Artity.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadProfilePicture(HttpContext context)
        {
            var newFileName = string.Empty;

            if (context.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = context.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        var FileExtension = Path.GetExtension(fileName).Trim('"');

                        newFileName = myUniqueFileName + FileExtension;

                        fileName = Path.Combine(this.hostingEnvironment.WebRootPath, "ProfilePicture") + $@"\{newFileName}";

                        PathDB = "ProfilePicture/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            await file.CopyToAsync(fs);
                            await fs.FlushAsync();
                        }

                        newFileName = PathDB;
                    }
                }
            }

            return newFileName;
        }

        public Picture UploadProfilePicture()
        {
            throw new NotImplementedException();
        }
    }
}
