namespace Artity.Web.ViewModels
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    public class AllArtistViewModel : IMapFrom<Artist>
    {
        public string Name { get; set; }
    }
}
