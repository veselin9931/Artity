namespace Artity.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Tests.ServicesTests;
    using global::TestViewModels;
    using Moq;
    using NUnit.Framework;

    public class ArtistServiceTests : BaseServiceTests
    {
        private IArtistService artistService;

        private IList<Artist> artists;

        [SetUp]
        public void Init()
        {
            var mockArtistRepository = new Mock<IDeletableEntityRepository<Artist>>();

            this.artists = new List<Artist>
            {
                new Artist() { Nikname = "aaa" },
                new Artist() { Nikname = "bbb" },
                new Artist() { Nikname = "ccc"},
            };
            mockArtistRepository.Setup(mr => mr.All()).Returns(this.artists.AsQueryable());
            this.artistService = new ArtistService(mockArtistRepository.Object);
        }

        [Test]
        public async Task CreateArtistWithInvalidValidDataShouldCreateAndAddAristInRepository()
        {
            var actualResult = await this.artistService.CreateNewArtist("ddd", "ddd", "ddd", "ddd", "ddd", "ddd");

            var artist = this.artists.FirstOrDefault(a => a.Id == actualResult);
            Assert.IsNull(artist);
        }

        [Test]
        public async Task CreateArtistWithValidDataShouldCreateAndAddAristInRepository()
        {
            var actualResult = await this.artistService.CreateNewArtist("ddd", "ddd", "ddd", "ddd", "ddd", "ddd");
            this.artists.Add(new Artist() { Id = actualResult });

            var artist = this.artists.FirstOrDefault(a => a.Id == actualResult);
            Assert.IsNotNull(artist);
        }

        [Test]
        public void GetAllArtists_Count_ShouldGetAllArtistsCountInRepository()
        {
            int actualCountOfArtists = this.artistService.GetAllArtists<GetArtistsTestViewModels>().Count();

            int expectedCountOfArtists = this.artists.Count;
            Assert.AreEqual(expectedCountOfArtists, actualCountOfArtists);
        }

        [Test]
        public void GetAllArtists_Equal_ShouldReturnSameObject()
        {
            var actualCountOfArtists = this.artistService.GetAllArtists<GetArtistsTestViewModels>().ToList();

            var expectedCountOfArtists = this.artists;
            Assert.IsTrue(expectedCountOfArtists.FirstOrDefault().Nikname == actualCountOfArtists.FirstOrDefault().Nikname);
        }
    }
}
