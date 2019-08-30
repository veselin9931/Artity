using Artity.Data.Models;
using Artity.Services.Mapping;

namespace Artity.Web.Areas.Administration.ViewModels.Dashboard
{
    public class ApprovedPerformenceViewModel : IMapFrom<Performence>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsApproved { get; set; }
    }
}