namespace Artity.Web.ViewModels.Artist
{
    using System.Collections.Generic;

    public class ArtistListViewModel
    {
        public IEnumerable<ArtistAllViewModel> Artists { get; set; }
    }
}
