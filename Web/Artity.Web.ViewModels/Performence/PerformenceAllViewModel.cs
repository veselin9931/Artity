using Artity.Services.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artity.Web.ViewModels.Performence
{
    public class PerformenceAllViewModel : IMapFrom<Artity.Data.Models.Performence>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string SmallDescription { get; set; }

        public virtual string АrtistNikname { get; set; }

        public virtual IEnumerable<string> PicturesLink { get; set; }

        public virtual string PerformencePhotoLink { get; set; }

        public double Rating { get; set; }

        


    }
}
