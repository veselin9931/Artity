namespace Artity.Web.Areas.Administration.ViewModels.Dashboard
{
    using System;

    using Artity.Data.Models;

    using Artity.Services.Mapping;

    using AutoMapper;

    public class ArtistsEditingViewModel : IMapFrom<Artist>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Nikname { get; set; }

        public string Email { get; set; }

        public string CreatedOn { get; set; }

        public bool IsApproved { get; set; }

        public int NumberOfPerformances { get; set; }

        public int NumberOfOfferts { get; set; }

        //TODO: REFACTOR ORDER ENTITY
        public int NumberOfOrders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
              .CreateMap<Artist, ArtistsEditingViewModel>()
              .ForMember(
          destination => destination.NumberOfPerformances,
          opts => opts.MapFrom(origin => origin.Performences.Count))
          .ForMember(
          destination => destination.NumberOfOfferts,
          opts => opts.MapFrom(origin => origin.Offerts.Count))
             .ForMember(
          destination => destination.CreatedOn,
          opts => opts.MapFrom(origin => origin.CreatedOn.ToString("dd MMM/yyyy")));

            configuration
             .CreateMap<ApplicationUser, ArtistsEditingViewModel>()
             .ForMember(
         destination => destination.Email,
         opts => opts.MapFrom(origin => origin.Email));
        }
    }
}
