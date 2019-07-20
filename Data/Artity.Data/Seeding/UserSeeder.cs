namespace Artity.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Data.Models;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>(){
                new Category()
                {
                     Name = "Theater",
                     CategoryType = Models.Enums.CategoryType.Theater,
                },
                new Category()
                {
                     Name = "Cinema",
                     CategoryType = Models.Enums.CategoryType.Cinema,
                },
                new Category()
                {
                     Name = "WeddingParty",
                     CategoryType = Models.Enums.CategoryType.WeddingParty,
                },
                new Category()
                {
                     Name = "BirthdayParty",
                     CategoryType = Models.Enums.CategoryType.BirthdayParty,
                },
                new Category()
                {
                     Name = "EventLeader",
                     CategoryType = Models.Enums.CategoryType.EventLeader,
                },
                new Category()
                {
                     Name = "Painter",
                     CategoryType = Models.Enums.CategoryType.Painter,
                },
                new Category()
                {
                     Name = "Handmade",
                     CategoryType = Models.Enums.CategoryType.Handmade,
                },
                new Category()
                {
                     Name = "Writer",
                     CategoryType = Models.Enums.CategoryType.Writer,
                },
            };


            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
