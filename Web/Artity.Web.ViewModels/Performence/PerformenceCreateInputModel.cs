using Artity.Common;
using Artity.Services.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Artity.Web.ViewModels.Performence
{
    public class PerformenceCreateInputModel : IMapTo<Data.Models.Performence>, IHaveCustomMappings
    {
        [Required]
        [StringLength(maximumLength: 40, ErrorMessage = PerformenceErrors.StringLenght, MinimumLength = 4)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = PerformenceErrors.StringLenght, MinimumLength = 4)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100000", ErrorMessage = PerformenceErrors.Price)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Photos")]
        public IFormFile PerformencePhoto { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                    .CreateMap<PerformenceCreateInputModel, Data.Models.Performence>()
                    .ForMember(
                destination => destination.PerformencePhoto,
                opts => opts.MapFrom(origin => new Data.Models.Picture { Description = this.Description }));
        }
    }
}