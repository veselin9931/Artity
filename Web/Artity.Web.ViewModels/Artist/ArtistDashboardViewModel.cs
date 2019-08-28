namespace Artity.Web.ViewModels.Artist
{
    using System;
    using System.Collections.Generic;
    using Artity.Services.Mapping;
    using Artity.Web.ViewModels.Offert;
    using Artity.Web.ViewModels.Order;
    using Artity.Web.ViewModels.Picture;
    using AutoMapper;

    public class ArtistDashboardViewModel : IMapFrom<Data.Models.Artist>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public PictureViewModel ProfilePicture { get; set; }

        public string Facebook { get; set; }

        public string Twiter { get; set; }

        public string LinkIn { get; set; }

        public string Youtube { get; set; }

        public double Rating { get; set; }

        public string CategoryName { get; set; }

        public string CrearedOn { get; set; }

        public int PerformenceCount { get; set; }

        public IEnumerable<ArtistOrdersViewModel> Orders { get; set; }

        public IEnumerable<OffertViewModel> Offerts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                    .CreateMap<Data.Models.Artist, ArtistDashboardViewModel>()
                     .ForMember(
               destination => destination.PerformenceCount,
               opts => opts.MapFrom(origin => origin.Performences.Count))
               .ForMember(
               destination => destination.CrearedOn,
               opts => opts.MapFrom(origin => origin.CreatedOn.ToString("dd MMM/yyyy")));
        }
    }
}
