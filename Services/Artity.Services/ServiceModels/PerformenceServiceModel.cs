namespace Artity.Services.ServiceModels
{
    using Artity.Services.Mapping;

    using System.Collections.Generic;

    public class PerformenceServiceModel : IMapFrom<Artity.Data.Models.Performence>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> АrtistsName { get; set; }

        public IEnumerable<string> PicturesLink { get; set; }

        public virtual string PerformencePhotoLink { get; set; }

        public virtual double Rating { get; set; }

        public string ArtistId { get; set; }
    }
}
