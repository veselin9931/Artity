namespace Artity.Web.ViewModels.Artist
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;
    using Artity.Web.ViewModels.Picture;
  
    public class ArtistAllViewModel : IMapFrom<Artist>
    {
        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public PictureViewModel Picture { get; set; }

        public string Facebook { get; set; }

        public string Twiter { get; set; }

        public string LinkIn { get; set; }

        public string Youtube { get; set; }

        public double Rating { get; set; }
    }
}
