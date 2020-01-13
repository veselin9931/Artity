using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artity.Services.Data
{
    public interface IPictueService
    {
        Task<string> AddPictureToDb(PictureInputModel picture, ApplicationUser user);
    }
}
