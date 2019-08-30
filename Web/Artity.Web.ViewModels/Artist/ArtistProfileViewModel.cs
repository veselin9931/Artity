using Artity.Services.Mapping;
using Artity.Web.ViewModels.Picture;
using Artity.Web.ViewModels.Social;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artity.Web.ViewModels.Artist
{
    public class ArtistProfileViewModel : IMapFrom<Data.Models.Artist>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public double Rating { get; set; }

        public SocialViewModel Social { get; set; }

        public string ProfilePictureLink { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
        }
    }
}
