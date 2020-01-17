namespace Artity.Services.Data.ServiceModels
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    public class PictureServiceModel : IMapFrom<Picture>, IMapTo<Picture>, IMapTo<PictureServiceModel>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }
    }
}
