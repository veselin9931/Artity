using Artity.Services.Mapping;

namespace Artity.Web.ViewModels.Offert
{
    public class OffertViewModel : IMapFrom<Data.Models.Offert>
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Features { get; set; }

        public bool Contract { get; set; }

        public decimal Price { get; set; }

        public string Review { get; set; }

        public string Town { get; set; }

        public string Tel { get; set; }
    }
}
