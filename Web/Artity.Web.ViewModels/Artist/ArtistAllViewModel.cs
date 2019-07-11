namespace Artity.Web.ViewModels.Artist
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    using AutoMapper;

    public class ArtistAllViewModel : IMapFrom<Artist>
    { 
        public string Name { get; set; }

        public string Description { get; set; }

        public PictureViewModel Picture { get; set; }
    }
}
