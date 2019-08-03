using Artity.Services.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Order
{
    public class UserArtistOrderViewModel : IMapFrom<Data.Models.Order> , IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ArtistNikname { get; set; }

        public string Status { get; set; }

        public string Place { get; set; }

        public DateTime Duration { get; set; }

        public DateTime EventDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                    .CreateMap<Data.Models.Order, UserArtistOrderViewModel>()
                      .ForMember(
               destination => destination.Status,
               opts => opts.MapFrom(origin => origin.Status.ToString()));

        }
    }
}

