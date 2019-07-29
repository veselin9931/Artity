using Artity.Services.Mapping;
using Artity.Web.ViewModels.Picture;
using Artity.Web.ViewModels.Social;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Artist
{
    public class ArtistProfileViewModel : IMapFrom<Data.Models.Artist>
    {

        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public double Rating { get; set; }

        public SocialViewModel Social { get; set; }

        public string ProfilePictureLink { get; set; }

        public string CategoryName { get; set; }
    }
}
