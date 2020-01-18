namespace Artity.Services.Data.ServiceModels
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    public class ArtistServiceModel : IMapFrom<Artist>
    {
        public string Nikname { get; set; }
    }
}
