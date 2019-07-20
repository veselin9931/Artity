namespace Artity.Web.InputModels.Picture
{

    using Artity.Services.Mapping;
    using Artity.Data.Models;

    public class PictureInputModel : IMapFrom<Picture>, IMapTo<Picture>
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }


    }
}
