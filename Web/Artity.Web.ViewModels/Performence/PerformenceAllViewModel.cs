using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Performence
{
    public class PerformenceAllViewModel : IMapFrom<Artity.Data.Models.Performence>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string АrtistsNikname { get; set; }

        public IEnumerable<string> PicturesLink { get; set; }

        public virtual string PerformencePhotoLink { get; set; }

        public virtual double Rating { get; set; }
    }
}
