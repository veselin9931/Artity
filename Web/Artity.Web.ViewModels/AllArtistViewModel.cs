namespace Artity.Web.ViewModels
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    public class AllArtistViewModel : IMapFrom<Picture>
    {
        public string Name { get; set; }
    }
}
