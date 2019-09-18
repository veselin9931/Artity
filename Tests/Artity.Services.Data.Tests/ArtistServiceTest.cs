using Artity.Data;
using Artity.Data.Common.Repositories;
using Artity.Data.Models;
using Artity.Services.Messaging;
using Artity.Web.ViewModels.Artist;
using Microsoft.EntityFrameworkCore;
using MIS.Tests.ServicesTests;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Artity.Services.Data.Tests
{
    using Artists;

    using User;

    using Category = Artity.Data.Models.Category;

    public class ArtistServiceTest : BaseServiceTest
    {
        public readonly IRepository<Artist> Repository;
        public readonly IArtistService ArtistService;
        private readonly ISendGrid emailSender;
        private readonly ApplicationDbContext dbContext;



        //public ArtistServiceTest()
        //{

        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //                 .Options;

        //    this.dbContext = new ApplicationDbContext(options);

        //    var mock = new Mock<IRepository<Artist>>();
        //    mock.Setup<IQueryable<Artist>>(x => x.All())
        //        .Returns(this.Data().AsQueryable);

        //    var mock2 = new Mock<IRepository<Social>>();
        //    mock.Setup<IQueryable<Artist>>(x => x.All())
        //        .Returns(this.Data().AsQueryable);

        //    this.Repository = mock.Object;

        //    this.UserService = new UserService(this.dbContext);
        //    this.ArtistService = new ArtistService(this.Repository, this.emailSender , this.UserService, mock2.Object);
        //}

        public IUserService UserService { get; }

        public IList<Artist> Data()
        {
            var a = new Artist()
            {
                Id = "aaa",
                Nikname = "Gosho",
                Category = new Category()
                {
                    CategoryType = Artity.Data.Models.Enums.CategoryType.BirthdayParty,
                    Name = "HAHA",
                },
                AboutMe = "asdklasdnl;asndjlas;dnjlaskdjkl;",
                IsApproved = true,
            };

            var b = new Artist()
            {
                Id = "bbb",
                Nikname = "Pesho",
                Category = new Category()
                {
                    CategoryType = Artity.Data.Models.Enums.CategoryType.Cinema,
                    Name = "HAHA",
                },
                AboutMe = "asdklasdnl;asndjlas;dnjlaskdjkl;",
                IsApproved = true,
            };

            var c = new Artist()
            {
                Id = "ccc",
                Nikname = "Radi",
                Category = new Category()
                {
                    CategoryType = Artity.Data.Models.Enums.CategoryType.BirthdayParty,
                    Name = "HAHA",
                },
                AboutMe = "asdklasdnl;asndjlas;dnjlaskdjkl;",
                IsApproved = false,
            };

            return new List<Artist>() { a, c,b };
        }

        //[Fact]
        //public void GetAllArtistsShouldReturnAllArtists()
        //{
        //    var mockService = new Mock<ArtistService>();
        //    mockService
        //        .Setup<IEnumerable<Artist>>(x => x.GetAllArtists<Artist>(true))
        //        .Returns(this.Data);
        //    var actualResult = mockService.Object.GetAllArtists<Artist>(true).Count();
        //    var result = this.Data().Count();

        //    Assert.Equal(actualResult, result);

        //}

        [Fact]
        public async Task GetArtistIdByNameShouldReturnArtistId()
        {
            string actualResult = await this.ArtistService.GetArtistIdByName("Gosho");
            string expectedResult = "aaa";
            Assert.Equal(actualResult, expectedResult);
        }

        [Fact]
        public async Task GetAllArtistsShouldReturnAllArtists()
        {
            int actualResult = this.ArtistService.GetAllArtists<ArtistAllViewModel>(true).Count();
            int expectedResult = 2;
            Assert.Equal(actualResult, expectedResult);
        }

        [Fact]
        public async Task GetAllArtiststFromCategoryShouldReturnOnlyArtistFromTargetCategory()
        {
            int category = 2;
            int actualResult = this.ArtistService.GetAllArtiststFrom<ArtistAllViewModel>(category).Count();
            int expectedResult = 1;

            ;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
