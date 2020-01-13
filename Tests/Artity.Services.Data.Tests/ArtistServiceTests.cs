namespace Artity.Services.Data.Tests
{
    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    public class ArtistServiceTests
    {
        private IArtistService artistService;

        [SetUp]
        public void Init()
        {
            var mockArtistRepository = new Mock<IDeletableEntityRepository<Artist>>();

            var artist = new List<Artist>
            {
                new Artist() { Nikname = "aaa"},
                new Artist() { Nikname = "bbb"},
                new Artist() { Nikname = "ccc"},
            };

            mockArtistRepository.Setup(mr => mr.All()).Returns(artist.AsQueryable());

            this.artistService = new ArtistService(mockArtistRepository.Object);
        }

        [Test]
        public void GetAllArtistsShouldGetAllNotDeletedArtistsInRepository()
        {
            var artist = new List<Artist>
            {
                new Artist() { Nikname = "aaa"},
                new Artist() { Nikname = "bbb"},
                new Artist() { Nikname = "ccc"},
            };

            this.artistService.GetAllArtists<AllArtistViewModel>();

        }
    }
}
