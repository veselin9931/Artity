namespace Artity.Web.ViewModels.Picture
{
    using Artity.Data.Models;

    using Artity.Services.Mapping;

    public class PictureViewModel : IMapFrom<Picture>
    {
        public string Link { get; set; }
    }
}
