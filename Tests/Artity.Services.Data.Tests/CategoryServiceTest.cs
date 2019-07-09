using Artity.Data;
using Artity.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Artity.Services.Data.Tests
{
    public class CategoryServiceTest
    {

        [Fact]
        public void TestGetAllCategories_ShouldReturnAllCategoies()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Category_Database")
            .Options;

            using (var dbContext = new ApplicationDbContext(options)) // Initialize Testing Data
            {
                dbContext.Categories.AddRange(GetTestData());
                dbContext.SaveChanges();
            }

            IList<string> categories;
            using (var dbContext = new ApplicationDbContext(options)) // Initialize Context again
            {
                ICategoryService service = new CategoryService(dbContext); // Pass it to Service as dependency
                categories = service.GetAllCategories(); // Find the User
            }

            Assert.True(categories.Count == 3);



        }

        public List<Category> GetTestData()
        {
            return new List<Category>()
        {
           new Category(){ Name = "Test1",
           CategoryType = 0,
       
           },
            new Category(){ Name = "Test2",
           CategoryType = 0,

           },
             new Category(){ Name = "Test3",
           CategoryType = 0,

           }

        };
        }

    }
}
