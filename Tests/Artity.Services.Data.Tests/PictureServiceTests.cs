namespace Artity.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.Tests.TestViewModels;
    using Artity.Tests.ServicesTests;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class PictureServiceTests : BaseServiceTests
    {
        private IPictueService pictueService;

        [SetUp]
        public void Init()
        {
            var mockPictureRepository = new Mock<IDeletableEntityRepository<Picture>>();
            mockPictureRepository.Setup(mr => mr.All()).Returns(this.AllPicture());
            this.pictueService = new PictureService(mockPictureRepository.Object);
        }

        [Test]
        public async Task GetPicture_WithValidId_ShouldReturnPictureById()
        {
            var picture = this.pictueService.GetPicture<PictureTestViewModel>("v");

            Assert.IsNotNull(picture);
            Assert.IsNotNull(picture.Link);
            Assert.IsNotEmpty(picture.Link);
        }

        [Test]
        public async Task GetPicture_WithInvalidId_ShouldReturnPictureById()
        {
            var picture = this.pictueService.GetPicture<PictureTestViewModel>("c");
            Assert.IsNull(picture);
        }

        [Test]
        public async Task GetPicture_Null_ShouldReturnPictureById()
        {
            var picture = this.pictueService.GetPicture<PictureTestViewModel>(null);
            Assert.IsNull(picture);
        }

        private IQueryable<Picture> AllPicture()
        {
            return new List<Picture>()
            {
                new Picture() { Id = "v", Title = "Vegata", Description = "Na Vegata snimkata", Link = "www.Vegata.com" },
                new Picture() { Id = "d" ,Title = "Dena", Description = "Na Dena snimkata", Link = "www.Dena.com" },
                new Picture() { Id = "a", Title = "Alex", Description = "Na Alex snimkata", Link = "www.Alex.com" },
            }.AsQueryable();
        }
    }
}
 