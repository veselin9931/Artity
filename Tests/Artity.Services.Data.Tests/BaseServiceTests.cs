namespace Artity.Tests.ServicesTests
{
    using System.Reflection;
    using Artity.Data.Models;
    using Artity.Services.Data.ServiceModels;
    using Artity.Services.Data.Tests.TestViewModels;
    using Artity.Services.Mapping;
    using NUnit.Framework;

    [TestFixture]
    public abstract class BaseServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.RegisterMappings();
        }

        private void RegisterMappings() => AutoMapperConfig.RegisterMappings(
            typeof(Picture).GetTypeInfo().Assembly,
            typeof(PictureServiceModel).GetTypeInfo().Assembly,
            typeof(PictureTestViewModel).GetTypeInfo().Assembly);
    }
}