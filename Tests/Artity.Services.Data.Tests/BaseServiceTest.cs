namespace MIS.Tests.ServicesTests
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;
    using Artity.Web.ViewModels.Artist;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;

    
    public abstract class BaseServiceTest
    {
        protected BaseServiceTest()
        {
            this.RegisterMappings();
        }

        private void RegisterMappings()
        {
            AutoMapperConfig.RegisterMappings(typeof(ArtistAllViewModel).GetTypeInfo().Assembly,
                typeof(Artist).GetTypeInfo().Assembly);
        }
    }
}