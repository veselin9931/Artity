using Artity.Services.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Performence
{
    public class PerformenceAllViewModel : IMapFrom<Artity.Data.Models.Performence>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public virtual string АrtistNikname { get; set; }

        public virtual IEnumerable<string> PicturesLink { get; set; }

        public virtual string PerformencePhotoLink { get; set; }

        public virtual double Rating { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                    .CreateMap<Data.Models.Performence, PerformenceAllViewModel>()
                    .ForMember(
                destination => destination.АrtistNikname,
                opts => opts.MapFrom(origin => origin.Artist.Nikname))
                .ForMember(
               destination => destination.SmallDescription,
               opts => opts.MapFrom(origin => origin.Description.Length < 90 ? origin.Description : origin.Description.Substring(0, 88)));

        }
    }
}
