namespace Artity.Services.Data.Tests.TestViewModels
{
    using Artity.Services.Data.ServiceModels;
    using Artity.Services.Mapping;

    public class PictureTestViewModel : IMapFrom<PictureServiceModel>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }
    }
}
