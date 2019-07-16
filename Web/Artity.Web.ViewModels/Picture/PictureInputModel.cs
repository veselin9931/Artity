namespace Artity.Web.ViewModels.Picture
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;

    public class PictureInputModel : IMapFrom<Picture>, IMapTo<Picture>
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }


    }
}
