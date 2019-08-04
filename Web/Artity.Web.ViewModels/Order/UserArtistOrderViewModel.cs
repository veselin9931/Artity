namespace Artity.Web.ViewModels.Order
{
    using System;

    using AutoMapper;

    using Artity.Data.Models.Enums;

    using Artity.Services.Mapping;

    public class UserArtistOrderViewModel : IMapFrom<Data.Models.Order>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ArtistNikname { get; set; }

        public string Status { get; set; }

        public string Place { get; set; }

        public string Duration { get; set; }

        public string EventDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
              .CreateMap<Data.Models.Order, UserArtistOrderViewModel>()
              .ForMember(
          destination => destination.Status,
          opts => opts.MapFrom(origin => Enum.GetName(typeof(OrderStatus), origin.Status)))
          .ForMember(
          destination => destination.Duration,
          opts => opts.MapFrom(origin => (origin.Duration.ToString("hh") + ":" + origin.Duration.ToString("MM") + " hour")))
             .ForMember(
          destination => destination.EventDate,
          opts => opts.MapFrom(origin => origin.EventDate.ToString("dd MMM/yyyy")));
        }
    }
}