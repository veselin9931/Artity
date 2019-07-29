namespace Artity.Web.ViewModels.Artist
{
    using System.Text;
    using Artity.Data.Models;
    using Artity.Services.Mapping;
    using Artity.Web.ViewModels.Picture;
    using AutoMapper;

    public class ArtistAllViewModel : IMapFrom<Artist>, IHaveCustomMappings

    {
        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public PictureViewModel ProfilePicture { get; set; }

        public string Facebook { get; set; }

        public string Twiter { get; set; }

        public string LinkIn { get; set; }

        public string Youtube { get; set; }

        public double Rating { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                    .CreateMap<Data.Models.Artist, ArtistAllViewModel>()
                      .ForMember(
               destination => destination.AboutMe,
               opts => opts.MapFrom(origin => origin.AboutMe.Length <= 85 ? origin.Description : origin.AboutMe.Substring(0, 85)))
                ;
        }
    }
}
