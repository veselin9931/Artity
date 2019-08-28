using Artity.Services.Mapping;
using Artity.Services.ServiceModels;

namespace Artity.Web.InputModels.Type
{
    public class OffertTypeInputModel : IMapFrom<OffertTypeServiceModel>
    {
       public string Name { get; set; }

        public string EnumValue { get; set; }

    }
}
