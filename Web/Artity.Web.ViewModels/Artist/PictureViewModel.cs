using Artity.Data.Models;
using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Artist
{
    public class PictureViewModel : IMapFrom<Picture>
    {
        public string Link { get; set; }
    }
}
