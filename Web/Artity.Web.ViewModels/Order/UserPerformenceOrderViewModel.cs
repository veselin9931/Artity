using Artity.Data.Models.Enums;
using Artity.Services.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Order
{
    public class UserPerformenceOrderViewModel : IMapFrom<Data.Models.Order>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PerformenceTitle { get; set; }

        public string Status { get; set; }

        public string Place { get; set; }

        public string Duration { get; set; }

        public string CreatedOn { get; set; }

        public string EventDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
              .CreateMap<Data.Models.Order, UserPerformenceOrderViewModel>()
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
